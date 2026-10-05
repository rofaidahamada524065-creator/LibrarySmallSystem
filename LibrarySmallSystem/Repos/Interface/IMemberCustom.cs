using LibrarySmallSystem.Model;

namespace LibrarySmallSystem.Repos.Interface
{
    public interface IMemberCustom : IGenaricRepo<Member>
    {
        ICollection<Member> top_readers();
    }
}
