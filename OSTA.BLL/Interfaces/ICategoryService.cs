using OSTA.BLL.DTOs.CategoryDTOS;

namespace OSTA.BLL.Interfaces
{
    public interface ICategoryService
    {
        public Task<string> AddCategory(AddCategory category);
        public Task<List<GetAllCategories>> GetAllCategories();
        public Task<string> Update(string Name, EditCategory category /* new Name*/);
        public Task<string> Delete(string Name);
        public Task<GetByNameCategoryDTO> GetByName(string Name);
    }
}
