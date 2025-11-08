using FluentValidation;
using OSTA.BLL.DTOs.ServiceDTOs;

namespace OSTA.BLL.FluentValidation.ServiceValidation
{
    public class UpdateServiceValidation : AbstractValidator<UpdateServiceDTO>
    {
        public UpdateServiceValidation()
        {
            Validate();
        }
        public void Validate()
        {
            RuleFor(x => x.Description)
                         .NotEmpty().WithMessage("Description is required.")
                         .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.BasePrice)
                .GreaterThan(0).WithMessage("Base price must be greater than 0.");
            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Duration must be greater than 0 minutes.");
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.");
        }
    }
}
