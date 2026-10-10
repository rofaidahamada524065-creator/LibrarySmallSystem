using System.ComponentModel.DataAnnotations;

namespace LibrarySmallSystem.DTOs.Member
{
    public class MemberDTO
    {
        public int Id { get; set; }
  
        public string Name { get; set; }
      
        public string Email { get; set; }
  
        public string Phone { get; set; }
    }
}
