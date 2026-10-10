using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySmallSystem.DTOs.Borrowing
{
    public class BorrowingDTO
    {
        public int Id { get; set; }
        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public int MemberId { get; set; }
       
        public int BookId { get; set; }
    }
}
