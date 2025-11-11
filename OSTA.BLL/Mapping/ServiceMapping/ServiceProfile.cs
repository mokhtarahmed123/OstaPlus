using AutoMapper;

namespace OSTA.BLL.Mapping.ServiceMapping
{
    public partial class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            AddServiceMapping();
            AllServicesMapping();
            UpdateServiceMapping();
        }
    }
}
