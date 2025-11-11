using AutoMapper;
using OSTA.BLL.DTOs.CategoryDTOS;

namespace OSTA.BLL.Mapping.CategoryMapping
{
    public partial class CategoryProfile : Profile
    {
        public void EditCategory()
        {
            CreateMap<EditCategory, DAL.Entities.Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
