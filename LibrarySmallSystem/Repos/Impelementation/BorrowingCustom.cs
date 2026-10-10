using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class BorrowingCustom : GenaricRepo<Borrowing>, IBorowCustom
    {
        private readonly AppDbcontext _context;
        public BorrowingCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public ICollection<Borrowing> Details()
        {
            return _context.borrowings.Include(a => a.Member).Include(a => a.Book).OrderByDescending(a=>a.BorrowedDate).ToList();
        }

        public Borrowing Updateee(int id)
        {
            var x = _context.borrowings.Include(a => a.Book).SingleOrDefault(a => a.Id == id && a.ReturnedDate == null);
            if (x == null)
            {
                return null;
            }
            x.ReturnedDate = DateTime.Now;
            x.Book.IsAvailable = true;
            return x;

        }
    }
}
