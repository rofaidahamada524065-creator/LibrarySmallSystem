using System.ComponentModel.DataAnnotations;

namespace LibrarySmallSystem.DTOs.Books
{
    public class BookDTO
    {
        public int Id { get; set; }
      
        public string Title { get; set; }
     
        public string Author { get; set; }
   
        public decimal Price { get; set; }
    }
}
