using LibrarySmallSystem.Data;
using LibrarySmallSystem.DTOs.Books;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class BookingCustom : GenaricRepo<Book>, IBookCustom
    {
        private readonly AppDbcontext _context;
        public BookingCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public Book BookWithHighstPrice()
        {
            return  _context.Books.OrderByDescending(a => a.Price).FirstOrDefault();
        
        }

        public ICollection<Book> Search(string word)
        {
            return  _context.Books.Where(a => a.Title.Contains(word.ToLower().ToUpper()) || a.Author.Contains(word.ToLower().ToUpper()))
           .Select(a => new Book
           {
               Id = a.Id,
               Author = a.Author,
               Title = a.Title,
               Price = a.Price


           }).OrderBy(a => a.Title).ToList();
        }
    }
}
