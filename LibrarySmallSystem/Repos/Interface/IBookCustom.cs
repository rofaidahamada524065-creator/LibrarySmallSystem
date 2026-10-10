using LibrarySmallSystem.Model;

namespace LibrarySmallSystem.Repos.Interface
{
    public interface IBookCustom : IGenaricRepo<Book>
    {
       ICollection<Book> Search(string word);

        Book BookWithHighstPrice();
    }
}
