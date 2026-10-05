using LibrarySmallSystem.Data;
using LibrarySmallSystem.Model;
using LibrarySmallSystem.Repos.Interface;

namespace LibrarySmallSystem.Repos.Impelementation
{
    public class CatigoryCustom : GenaricRepo<Category>, ICategoryCustom
    {
        private readonly AppDbcontext _context;
        public CatigoryCustom(AppDbcontext appDbcontext) : base(appDbcontext)
        {
            _context = appDbcontext;
        }

     

        //public ICollection<Category> GetAllWithNumberOfBook()
        //{

        //    var x = _context.categories.GroupBy(a => a.Id).Select(a => new 
        //    {
        //        Id = a.Key,
        //        Name = a.First().Name,
        //        NumberOfBook = a.Select(b => new 
        //        {
        //            BookName = b.Books.Count()
        //        })
        //    }).ToList();

        //    return x;


        //}
    }
}
