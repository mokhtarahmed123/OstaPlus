using AutoMapper;
using FluentValidation;
using OSTA.BLL.DTOs.CategoryDTOS;
using OSTA.BLL.Exceptions;
using OSTA.BLL.Interfaces;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;
namespace OSTA.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;
        private readonly IMapper mapper;
        private readonly IValidator<AddCategory> _validator;
        private readonly IValidator<EditCategory> editValidator;

        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper, IValidator<AddCategory> validator, IValidator<EditCategory> EditValidator)
        {
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
            this._validator = validator;
            editValidator = EditValidator;
        }

        public async Task<string> AddCategory(AddCategory category)
        {
            var Errors = await _validator.ValidateAsync(category);
            if (!Errors.IsValid)
                throw new OSTA.BLL.Exceptions.ValidationException(Errors.Errors);
            var CateMapping = mapper.Map<Category>(category);
            var result = await categoryRepo.AddAsync(CateMapping);
            if (result == null)
            {
                throw new Exception("Failed To Add Category");
            }
            return "Category Added Successfully";
        }

        public async Task<string> Delete(string Name)
        {
            var NameIsFound = await categoryRepo.GetByName(Name);
            if (NameIsFound == null)
            {
                throw new NotFoundException($"Category With Name {Name} Not Found");
            }
            var result = categoryRepo.DeleteAsync(NameIsFound);
            if (result == null)
            {
                throw new BadRequestException("Failed To Delete Category");
            }
            return "Category Deleted Successfully";

        }

        public async Task<List<GetAllCategories>> GetAllCategories()
        {
            var List = await categoryRepo.GetAllCategories();
            if (List == null || List.Count == 0)
            {
                throw new NotFoundException("No Categories Found");
            }
            var Mapped = mapper.Map<List<GetAllCategories>>(List);
            return Mapped;
        }

        public async Task<GetByNameCategoryDTO> GetByName(string Name)
        {
            var Result = await categoryRepo.GetByName(Name);
            if (Result == null)
            {
                throw new NotFoundException($"Category With Name {Name} Not Found");
            }
            var CategoryMapped = mapper.Map<GetByNameCategoryDTO>(Result);
            return CategoryMapped;

        }

        public async Task<string> Update(string OldName, EditCategory category)
        {
            var Errors = await editValidator.ValidateAsync(category);
            if (!Errors.IsValid)
                throw new OSTA.BLL.Exceptions.ValidationException(Errors.Errors);
            var IsFound = await categoryRepo.GetByName(OldName);
            if (IsFound == null)
            {
                throw new NotFoundException($"Category With Name {OldName} Not Found");
            }
            var NameIsFoundWithAnotherId = await categoryRepo.NameISFoundWithAnotherId(category.Name, IsFound.Id);
            if (NameIsFoundWithAnotherId)
            {
                throw new BadRequestException($"Category Name {category.Name} Is Already Found ");
            }
            var CategoryMapped = mapper.Map(category, IsFound);
            await categoryRepo.UpdateAsync(CategoryMapped);
            return " Updated Successfully ";
        }


    }

}
