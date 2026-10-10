namespace LibrarySmallSystem.DTOs.Borrowing
{
    public class UpdateBorrowingDTO
    {
        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public int MemberId { get; set; }

        public int BookId { get; set; }
    }
}
