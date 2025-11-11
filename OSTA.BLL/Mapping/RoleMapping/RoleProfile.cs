using AutoMapper;

namespace OSTA.BLL.Mapping.RoleMapping
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateRole();
            EditRole();
            GetAllMapping();
        }

    }
}
