using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.UnitOfWorkk
{
    public interface IUnitOfWork
    {
        ICategoryCustom Category { get; }
        IBookCustom Book { get; }
        int save();
    }
}
