using FluentValidation;
using OSTA.BLL.DTOs.RoleDTOs;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.FluentValidation.RoleValidation
{
    public class AddRoleValidation : AbstractValidator<CreateRoleDto>
    {
        private readonly IRoleRepository roleRepository;

        public AddRoleValidation(IRoleRepository roleRepository)
        {
            ValidateRoleName();
            this.roleRepository = roleRepository;
        }
        public void ValidateRoleName()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Role name is required.")
                .MaximumLength(256).WithMessage("Role name must not exceed 256 characters.")
                .MinimumLength(3).WithMessage("Role name must be at least 3 characters long.")
                .Matches("^[a-zA-Z]+$").WithMessage("Role name can only contain letters.");

            RuleFor(x => x.RoleName)
                .Must(name => !string.IsNullOrWhiteSpace(name) && !name.Contains("  "))
                .WithMessage("Role name cannot contain consecutive spaces or be only whitespace.");

            RuleFor(x => x.RoleName)
                .MustAsync(async (name, cancellation) =>
                {
                    var existing = await roleRepository.RoleNameIsFound(name);

                    return !existing;
                })
                .WithMessage("Role Name already exists.");



        }

    }
}
