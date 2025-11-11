using AutoMapper;
using OSTA.BLL.DTOs.CategoryDTOS;
using OSTA.DAL.Entities;

namespace OSTA.BLL.Mapping.CategoryMapping
{
    public partial class CategoryProfile : Profile
    {
        public void AddCategoryMapping()
        {
            CreateMap<AddCategory, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
