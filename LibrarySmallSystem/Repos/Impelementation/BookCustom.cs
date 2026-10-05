using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class BookCustom : GenaricRepo<Book>, IBookCustom
    {
        private readonly AppDbcontext _context;
        public BookCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public ICollection<Book> HighestPrice()
        {
            var x = _context.Books.OrderBy(x => x.Price).Take(1).ToList() ;
            return x;
        }

        public ICollection<Book> Search(string title)
        {
            var x = _context.Books.
                Where(a => a.Title == title.ToLower() || a.Author == title.ToLower()).
                OrderBy(a => a.Title).ToList();
        
            return x;
        }
    }
}
