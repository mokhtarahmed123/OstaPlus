using AutoMapper;
using OSTA.BLL.DTOs.StoreDTOs;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.StoreMapping
{
    public partial class StoreProfile : Profile
    {
        public void AddStoreMapping()
        {
            CreateMap<AddStoreDTO, Store>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode));
        }
    }
}
