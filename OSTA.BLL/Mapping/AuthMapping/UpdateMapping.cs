using AutoMapper;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.AuthMapping
{
    public partial class AuthProfile : Profile
    {
        public void UpdateMapping()
        {
            CreateMap<UpdateUserDTO, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }
    }
}
