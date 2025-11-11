using AutoMapper;
using OSTA.BLL.DTOs.RoleDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.RoleMapping
{
    public partial class RoleProfile : Profile
    {
        public void GetAllMapping()
        {
            CreateMap<RoleApplication, GetAllRolesNameDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
