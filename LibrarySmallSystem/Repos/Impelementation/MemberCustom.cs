using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class MemberCustom : GenaricRepo<Member>, IMemberCustom
    {
        private readonly AppDbcontext _context;
        public MemberCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        ICollection<Member> IMemberCustom.top_readers()
        {
            var x = _context.Books.OrderBy(x => x.Id).ToList();
            return x;
        }
    }
}
