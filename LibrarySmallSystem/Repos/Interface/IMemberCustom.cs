using LibrarySmallSystem.DTOs.Member;
using LibrarySmallSystem.Model;

namespace LibrarySmallSystem.Repos.Interface
{
    public interface IMemberCustom:IGenaricRepo<Member>
    {
        ICollection<Member> Top_Reader();
        MemberWithBookWithBorow Statistics(int Mid);
    }
}
