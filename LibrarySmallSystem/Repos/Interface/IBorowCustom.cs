using LibrarySmallSystem.Model;

namespace LibrarySmallSystem.Repos.Interface
{
    public interface IBorowCustom : IGenaricRepo<Borrowing>
    {
        ICollection<Borrowing> Details();

        Borrowing Updateee(int id);
    }
}
