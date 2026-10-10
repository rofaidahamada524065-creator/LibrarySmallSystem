using LibrarySmallSystem.Data;
using LibrarySmallSystem.DTOs.Member;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class MemberCustom : GenaricRepo<Member>, IMemberCustom
    {

        private readonly AppDbcontext _context;

        public MemberCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

        public MemberWithBookWithBorow? Statistics(int Mid)
        {
           return _context.members.Where(a => a.Id == Mid).Select(a => new MemberWithBookWithBorow
            {
                MemberID = a.Id,
                totalbowrow = a.Borrowings.Count(),
                CurantlyBook = a.Borrowings.Count(b => b.ReturnedDate == null),
                ReturnedBook = a.Borrowings.Count(c => c.ReturnedDate != null)

            }).FirstOrDefault();
           
        }

        public ICollection<Member> Top_Reader()
        {
            return _context.members.OrderByDescending(a => a.Borrowings.Count()).Take(5).ToList();
        }

    }
}
