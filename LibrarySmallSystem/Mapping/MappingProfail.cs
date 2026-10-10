using AutoMapper;
using LibrarySmallSystem.DTOs.Books;
using LibrarySmallSystem.DTOs.Borrowing;
using LibrarySmallSystem.DTOs.Catigory;
using LibrarySmallSystem.DTOs.Member;
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
            CreateMap<CreateBookDTO, Book>().ReverseMap();
            CreateMap<UpdateBookDTO, Book> ().ReverseMap();


            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<CreateMemberDTO, Member>().ReverseMap();
            CreateMap<UpdateMemberDTO, Member>().ReverseMap();
          


            CreateMap<Borrowing, BorrowingDTO>().ReverseMap();
            CreateMap<CreateBorrowingDTO, Borrowing>().ReverseMap();
            CreateMap<UpdateBookDTO, Borrowing>().ReverseMap();


        }
    }
}
