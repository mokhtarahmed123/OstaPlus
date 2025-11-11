using FluentValidation;
using OSTA.BLL.DTOs.CategoryDTOS;

namespace OSTA.BLL.FluentValidation.CategoryValidation
{
    public class EditCategoryValidation : AbstractValidator<EditCategory>
    {
        public EditCategoryValidation()
        {
            ValidateName();
        }
        public void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category Name is required.")
                .MaximumLength(100).WithMessage("Category Name must not exceed 100 characters.");
        }

    }
}
