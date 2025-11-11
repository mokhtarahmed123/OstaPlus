using FluentValidation;
using OSTA.BLL.DTOs.CategoryDTOS;
using OSTA.DAL.Interfaces;
namespace OSTA.BLL.FluentValidation.CategoryValidation
{
    public class AddCategoryValidator : AbstractValidator<AddCategory>
    {
        private readonly ICategoryRepo categoryRepository;

        public AddCategoryValidator(ICategoryRepo categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            CreateCategoryValidator();
            NameIsExist();
        }

        public async void CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MinimumLength(2).WithMessage("Category name must be at least 2 characters long.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");
        }
        public void NameIsExist()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellation) =>
                {
                    var existing = await categoryRepository.GetByName(name);

                    return existing == null;
                })
                .WithMessage("Category name already exists.");
        }

    }
}
