using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class UserRepostry : GenaricRepo<User>, IUserRepository
    {
        private readonly AppDbcontext _contect;
        public UserRepostry(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _contect = appDbcontext;
        }

        public User? GetByUserNameAsync(string userName)
        {
            return _contect.users.SingleOrDefault(a => a.UserName == userName);

        }
    }
}
