using AutoMapper;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.AuthMapping

{
    public partial class AuthProfile : Profile
    {
        public void GetUserMapping()
        {
            CreateMap<ApplicationUser, GetUser>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleApplication.Name));
        }
    }
}
