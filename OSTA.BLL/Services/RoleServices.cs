using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using OSTA.BLL.DTOs.RoleDTOs;
using OSTA.BLL.Exceptions;
using OSTA.BLL.Interfaces;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<RoleApplication> _roleManager;
        private readonly IValidator<CreateRoleDto> _createValidator;
        private readonly IValidator<EditRoleDto> _editValidator;
        private readonly IMapper _mapper;

        public RoleServices(
            IRoleRepository roleRepository,
            RoleManager<RoleApplication> roleManager,
            IValidator<CreateRoleDto> createValidator,
            IValidator<EditRoleDto> editValidator,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
            _createValidator = createValidator;
            _editValidator = editValidator;
            _mapper = mapper;
        }

        public async Task<string> CreateRoleAsync(CreateRoleDto createRole)
        {
            var validationResult = await _createValidator.ValidateAsync(createRole);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            var existing = await _roleRepository.GetByName(createRole.RoleName);
            if (existing != null)
                throw new BadRequestException($"Role '{createRole.RoleName}' already exists.");

            var roleMapped = _mapper.Map<RoleApplication>(createRole);

            var result = await _roleManager.CreateAsync(roleMapped);

            if (!result.Succeeded)
            {
                var errorsList = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create role: {errorsList}");
            }

            return "Role added successfully.";
        }


        public async Task<string> UpdateRoleAsync(string name, EditRoleDto editRole)
        {
            var validationResult = _editValidator.Validate(editRole);
            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            var existingRole = await _roleRepository.GetByName(name);
            if (existingRole == null)
                throw new NotFoundException($"Role with name '{name}' not found.");

            var isRepeated = await _roleRepository.NameISFoundWithAnotherId(editRole.Name, existingRole.Id);
            if (isRepeated)
                throw new BadRequestException($"Role name '{editRole.Name}' already exists.");

            _mapper.Map(editRole, existingRole);

            var result = await _roleManager.UpdateAsync(existingRole);
            if (!result.Succeeded)
            {
                var errorsList = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to update role: {errorsList}");
            }

            return "Role updated successfully.";
        }

        public async Task<string> DeleteRoleAsync(string name)
        {
            var existingRole = await _roleRepository.GetByName(name);
            if (existingRole == null)
                throw new NotFoundException($"Role with name '{name}' not found.");

            var result = await _roleManager.DeleteAsync(existingRole);
            if (!result.Succeeded)
            {
                var errorsList = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to delete role: {errorsList}");
            }

            return "Role deleted successfully.";
        }

        public async Task<List<GetAllRolesNameDto>> GetAllRolesAsync()
        {
            var List = await _roleRepository.GetAll();
            var Mapped = _mapper.Map<List<GetAllRolesNameDto>>(List);
            return Mapped;
        }
    }
}
