using FluentValidation;
using OSTA.BLL.DTOs.RoleDTOs;

namespace OSTA.BLL.FluentValidation.RoleValidation
{
    public class EditRoleValidation : AbstractValidator<EditRoleDto>
    {
        public EditRoleValidation()
        {
            ValidateRoleName();
        }
        public void ValidateRoleName()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role name is required.")
                .MaximumLength(256).WithMessage("Role name must not exceed 256 characters.")
                .MinimumLength(3).WithMessage("Role name must be at least 3 characters long.")
                .Matches("^[a-zA-Z]+$").WithMessage("Role name can only contain letters.");

            RuleFor(x => x.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name) && !name.Contains("  "))
                .WithMessage("Role name cannot contain consecutive spaces or be only whitespace.");


        }
    }
}
