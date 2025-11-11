using AutoMapper;

namespace OSTA.BLL.Mapping.CategoryMapping
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            AddCategoryMapping();
            GetAllCategoriesMapping();
            EditCategory();
            GetByNameMapping();

        }
    }
}
