using FluentValidation;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.FluentValidation.AuthValidation
{
    public class SignUpValidation : AbstractValidator<SignUpUser>
    {
        private readonly IAuthRepository userRepository;

        public SignUpValidation(IAuthRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Validation()
        {
            RuleFor(a => a.Name)
                        .NotEmpty().WithMessage("Name is required.")
                        .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) =>
                {
                    var existingUser = await userRepository.UserWithEmailIsFound(email);
                    return !existingUser;
                })
                .WithMessage("Email already exists .");

            RuleFor(a => a.Password)
                      .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(a => a.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^[0-9]+$").WithMessage("Phone must contain only digits.")
                .Length(10, 15).WithMessage("Phone must be between 10 and 15 digits.");

            RuleFor(a => a.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");

            RuleFor(a => a.RoleName)
                .NotEmpty().WithMessage("Role name is required.");

        }
    }
}
