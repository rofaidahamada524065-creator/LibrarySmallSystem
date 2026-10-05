using AutoMapper;
using LibrarySmallSystem.DTOs.Books;
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


            CreateMap<Book,BookDTO>().ReverseMap();
            CreateMap<CreateBookDTO, BookDTO>().ReverseMap();
            CreateMap<UpdateBookDTO, BookDTO> ().ReverseMap();
        }
    }
}
