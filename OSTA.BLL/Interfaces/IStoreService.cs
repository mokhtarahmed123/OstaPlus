using OSTA.BLL.DTOs.StoreDTOs;

namespace OSTA.BLL.Interfaces
{
    public interface IStoreService
    {
        Task<StoreDetailsDTO> AddStoreAsync(AddStoreDTO model);
        Task<IEnumerable<StoreDetailsDTO>> GetAllAsync();
        Task<StoreDetailsDTO?> GetByIdAsync(string id);
        Task<bool> UpdateStoreAsync(string id, UpdateStoreDTO model);
        Task<bool> DeleteStoreAsync(string id);
        Task<IEnumerable<StoreDetailsDTO>> FilterAsync(StoreFilterDTO filter);
        Task<int> CountStoresAsync();


    }
}
