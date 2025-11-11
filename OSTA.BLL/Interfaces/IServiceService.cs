using OSTA.BLL.DTOs.ServiceDTOs;

namespace OSTA.BLL.Interfaces
{

    public interface IServiceService
    {
        public Task<string> Add(AddServiceDTO addService);
        public Task<string> Delete(string id);
        public Task<string> Update(string id, UpdateServiceDTO updateService);

        public Task<List<AllServicesDTO>> ShowAll();
        public Task<List<AllServicesDTO>> GetByCategory(string categoryName);
        public Task<int> CountOfServices();
        public Task<List<AllServicesDTO>> Filter(ServiceFilter serviceFilter);



    }
}
