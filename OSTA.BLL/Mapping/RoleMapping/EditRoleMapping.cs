using AutoMapper;
using OSTA.BLL.DTOs.RoleDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.RoleMapping
{
    public partial class RoleProfile : Profile
    {
        public void EditRole()
        {
            CreateMap<EditRoleDto, RoleApplication>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.Name.ToUpper()));
        }
    }
}
