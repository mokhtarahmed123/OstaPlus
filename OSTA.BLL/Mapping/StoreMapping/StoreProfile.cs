using AutoMapper;

namespace OSTA.BLL.Mapping.StoreMapping
{
    public partial class StoreProfile : Profile
    {
        public StoreProfile()
        {
            AddStoreMapping();
            AddStoreDetailsMapping();
            Update();
        }
    }
}
