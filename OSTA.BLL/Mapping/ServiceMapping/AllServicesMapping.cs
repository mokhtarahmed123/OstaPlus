using AutoMapper;
using OSTA.BLL.DTOs.ServiceDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.ServiceMapping
{
    public partial class ServiceProfile : Profile
    {
        public void AllServicesMapping()
        {
            CreateMap<Service, AllServicesDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.BasePrice))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
