using AutoMapper;
using LibrarySmallSystem.DTOs.Catigory;
using LibrarySmallSystem.Model;

namespace LibrarySmallSystem.Mapping
{
    public class MappingProfail : Profile
    {
        public MappingProfail()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CreatecatigoryDTO, Category>().ReverseMap();
            CreateMap<UpdatecategoryDTO, Category>().ReverseMap();
        }
    }
}
