using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    }
}
