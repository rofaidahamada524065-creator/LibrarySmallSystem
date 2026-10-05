using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.UnitOfWorkk
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbcontext _context;
        public UnitOfWork(AppDbcontext appDbcontext,ICategoryCustom categoryCustom)
        {
            _context = appDbcontext;
            Category = categoryCustom;
        }

        public ICategoryCustom Category { get; }

        public int save()
        {
            return _context.SaveChanges();
        }
    }
}
