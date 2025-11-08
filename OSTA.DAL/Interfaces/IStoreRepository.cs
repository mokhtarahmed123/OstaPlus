using OSTA.DAL.Entities;

namespace OSTA.DAL.Interfaces
{
    public interface IStoreRepository : IGenericRepositoryAsync<Store>
    {
        Task<bool> StoreWithNameExistsAsync(string storeName);
        Task<int> CountAsync();
        Task<List<Store>> GetAllAsync();
        Task<Store?> GetStoreByIdsAsync(string id);
        Task<Store> GetWithNamNotRepeatAndNotTheSameIdAsync(string Id, string name);
    }
}
