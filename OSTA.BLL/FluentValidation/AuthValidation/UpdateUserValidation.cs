using FluentValidation;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.FluentValidation.AuthValidation
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserDTO>
    {
        private readonly IAuthRepository authRepository;

        public UpdateUserValidation(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
            ValidateAll();
            ValidateEmailUnique();
        }
        public void ValidateAll()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone cannot be empty.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number is not valid.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Address)
                .MaximumLength(250).WithMessage("Address cannot exceed 250 characters.");
        }
        public void ValidateEmailUnique()
        {
            RuleFor(x => x)
                .MustAsync(async (dto, cancellation) =>
                {
                    if (dto.Email.Equals(dto.CurrentEmail, StringComparison.OrdinalIgnoreCase))
                        return true;

                    var currentUser = await authRepository.GetByEmail(dto.CurrentEmail);
                    if (currentUser == null)
                        return false;
                    var isRepeated = await authRepository.CheckIfUserWantChangeEmailNotRepeated(dto.Email, currentUser.Id);
                    return !isRepeated;
                })
                .WithMessage("Email already exists.");
        }



    }
}
