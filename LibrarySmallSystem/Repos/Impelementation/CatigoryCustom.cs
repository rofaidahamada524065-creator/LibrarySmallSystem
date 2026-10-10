using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class CatigoryCustom : GenaricRepo<Category>, ICatigoryCustom
    {
        private readonly AppDbcontext _context;
        public CatigoryCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public ICollection<Category> CatigoryWithNumberOfBook()
        {
            return _context.categories.Include(a => a.Books).ToList();
        }
    }
}
