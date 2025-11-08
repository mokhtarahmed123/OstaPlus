using AutoMapper;
using OSTA.BLL.DTOs.CategoryDTOS;
using OSTA.DAL.Entities;
namespace OSTA.BLL.Mapping.CategoryMapping
{
    public partial class CategoryProfile : Profile
    {

        public void GetByNameMapping()
        {
            CreateMap<Category, GetByNameCategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
