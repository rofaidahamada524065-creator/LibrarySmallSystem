using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.UnitOfWorkk
{
    public interface IUnitOfWork
    {
        IMemberCustom member { get; }
        ICatigoryCustom catigory { get; }
        IBookCustom Book { get; }
        IBorowCustom borow { get; }
        IUserRepository user { get; }
        int save();
    }
}
