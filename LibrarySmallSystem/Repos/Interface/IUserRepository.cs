using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Impelementation;

namespace LibrarySmallSystem.Repos.Interface
{
    public interface IUserRepository:IGenaricRepo<User>
    {
        User? GetByUserNameAsync(string userName);
        
    }
}
