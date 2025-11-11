using OSTA.DAL.Entities;

namespace OSTA.DAL.Interfaces
{
    public interface ICategoryRepo : IGenericRepositoryAsync<Category>
    {
        // Add More If You Want

        public Task<Category> GetByName(string Name);
        public Task<List<Category>> GetAllCategories();
        public Task<bool> NameISFoundWithAnotherId(string Name, string Id);
        public Task<string> GetIdByName(string Name);
    }
}
