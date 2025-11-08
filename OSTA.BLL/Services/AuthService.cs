using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.BLL.Exceptions;
using OSTA.BLL.Interfaces;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper mapper;
        private readonly IValidator<SignUpUser> signUpValidator;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAuthRepository authRepository;
        private readonly RoleManager<RoleApplication> roleManager;
        private readonly IValidator<UpdateUserDTO> updateValid;

        public AuthService(IMapper mapper,
            IValidator<SignUpUser> SignUpValidator,
            UserManager<ApplicationUser> userManager,
            IAuthRepository authRepository,
            RoleManager<RoleApplication> roleManager, IValidator<UpdateUserDTO> UpdateValid)
        {
            this.mapper = mapper;
            signUpValidator = SignUpValidator;
            this.userManager = userManager;
            this.authRepository = authRepository;
            this.roleManager = roleManager;
            updateValid = UpdateValid;
        }

        public Task<bool> ChangePasswordAsync(string email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountOfUsers()
        {
            return await authRepository.GetCountOfAll();
        }

        public async Task<int> CountOfUsersByRoleName(string RoleName)
        {
            if (string.IsNullOrEmpty(RoleName))
                throw new BadRequestException("Role Name cannot be null or empty.");
            var IsFound = await roleManager.RoleExistsAsync(RoleName);
            if (!IsFound)
                throw new NotFoundException($"Role '{RoleName}' does not exist.");
            return await authRepository.GetCountByRoleName(RoleName);
        }

        public async Task<string> Delete(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new BadRequestException("Email cannot be null or empty.");
            var user = await authRepository.GetByEmail(email)
           ?? throw new NotFoundException($"User with Email '{email}' not found.");
            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errorsList = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException($"Failed to delete user: {errorsList}");
            }
            return $"User with Email '{email}' deleted successfully.";

        }
        public async Task<string> EditAsync(string currentEmail, UpdateUserDTO userDto)
        {
            var existingUser = await authRepository.GetByEmail(currentEmail);
            if (existingUser is null)
                throw new NotFoundException($"User with Email '{currentEmail}' not found.");
            var validationResult = await updateValid.ValidateAsync(userDto);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);


            userDto.CurrentEmail ??= currentEmail;

            mapper.Map(userDto, existingUser);

            var result = await userManager.UpdateAsync(existingUser);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException($"Failed to update user: {errors}");
            }

            return $"User with Email '{currentEmail}' updated successfully.";
        }


        public async Task<List<GetAllUsersDTO>> GetAllUsersAsync()
        {

            var Count = await authRepository.GetCountOfAll();
            if (Count == 0)
                throw new NotFoundException("No Users Found.");
            var List = await authRepository.GetAll();
            var mapped = mapper.Map<List<GetAllUsersDTO>>(List);
            return mapped;
        }

        public async Task<List<GetAllUsersDTO>> GetAllUsersByRoleNameAsync(string RoleName)
        {
            if (string.IsNullOrEmpty(RoleName))
                throw new BadRequestException("Role Name cannot be null or empty.");
            var IsFound = await roleManager.RoleExistsAsync(RoleName);
            if (!IsFound)
                throw new NotFoundException($"Role '{RoleName}' does not exist.");
            var Count = await authRepository.GetCountByRoleName(RoleName);
            if (Count == 0)
                throw new NotFoundException($"No Users Found with Role Name '{RoleName}'.");
            var List = await authRepository.GetAllByRoleName(RoleName);
            var mapped = mapper.Map<List<GetAllUsersDTO>>(List);
            return mapped;

        }

        public async Task<GetUser> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new BadRequestException("Email cannot be null or empty.");

            var user = await authRepository.GetByEmail(email)
                       ?? throw new NotFoundException($"User with Email '{email}' not found.");

            return mapper.Map<GetUser>(user);
        }
        public Task<string> Login(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }

        public Task<string> LogoutAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SignUp(SignUpUser signUpUser)
        {
            var validationResult = await signUpValidator.ValidateAsync(signUpUser);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            var userMapped = mapper.Map<ApplicationUser>(signUpUser);

            var role = await roleManager.FindByNameAsync(signUpUser.RoleName);
            if (role == null)
                throw new NotFoundException($"Role '{signUpUser.RoleName}' does not exist.");

            userMapped.RoleID = role.Id;

            var result = await userManager.CreateAsync(userMapped, signUpUser.Password);
            if (!result.Succeeded)
            {
                var errorsList = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException($"Failed to create user: {errorsList}");
            }

            var roleResult = await userManager.AddToRoleAsync(userMapped, signUpUser.RoleName);
            if (!roleResult.Succeeded)
            {
                var roleErrors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new BadRequestException($"User created but failed to assign role: {roleErrors}");
            }

            return $"{signUpUser.RoleName} With Email {signUpUser.Email} created successfully.";
        }

        public Task<bool> VerifyEmailAsync(string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}
