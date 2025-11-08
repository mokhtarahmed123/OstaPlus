using AutoMapper;
using OSTA.BLL.DTOs.ServiceDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.ServiceMapping

{
    public partial class ServiceProfile : Profile
    {
        public void AddServiceMapping()
        {
            CreateMap<AddServiceDTO, Service>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.BasePrice))
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration));


        }
    }
}
