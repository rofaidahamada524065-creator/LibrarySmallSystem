using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Impelementation;

namespace LibrarySmallSystem.Repos.Interface
{
    public interface ICatigoryCustom:IGenaricRepo<Category>
    {
        ICollection<Category> CatigoryWithNumberOfBook();
    }
}
