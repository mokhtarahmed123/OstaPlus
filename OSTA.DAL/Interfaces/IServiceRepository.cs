using OSTA.DAL.Entities;

namespace OSTA.DAL.Interfaces
{
    public interface IServiceRepository : IGenericRepositoryAsync<Service>
    {
        public Task<IEnumerable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(string id);
        Task<bool> CategoryWithNameIsFound(string categoryName);

        Task<int> CountOfServices();

        Task<IEnumerable<Service>> GetByCategoryAsync(string categoryName);

    }
}
