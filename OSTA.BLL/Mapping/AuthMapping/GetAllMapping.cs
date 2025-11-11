using AutoMapper;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.BLL.Mapping.AuthMapping
{
    public partial class AuthProfile : Profile
    {
        private readonly IAuthRepository authRepository;

        public AuthProfile(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        public void GetAll()
        {
            CreateMap<ApplicationUser, GetAllUsersDTO>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
               .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleApplication.Name));

        }
    }
}
