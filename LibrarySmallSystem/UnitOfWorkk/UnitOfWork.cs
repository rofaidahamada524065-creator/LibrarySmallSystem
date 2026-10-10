using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.UnitOfWorkk
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbcontext _context;
        public UnitOfWork(AppDbcontext appDbcontext,IBookCustom bookCustom,ICatigoryCustom catigorys,IMemberCustom memberCustom,IBorowCustom borowCustom,IUserRepository userRepository)
        {
            _context = appDbcontext;
            Book = bookCustom;
            catigory = catigorys;
            member = memberCustom;
            borow = borowCustom;
            user = userRepository;
        }

     

        public IBookCustom Book {  get; }

        public ICatigoryCustom catigory { get; }

        public IMemberCustom member { get; }

        public IBorowCustom borow { get; }

        public IUserRepository user { get; }

        public int save()
        {
            return  _context.SaveChanges();
        }
    }
}
