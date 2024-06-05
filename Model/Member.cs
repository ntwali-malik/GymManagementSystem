using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Model
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
    }
}
