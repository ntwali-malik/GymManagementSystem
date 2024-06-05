using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Model
{
    public class Membership
    {
        [Key]
        public int MembershipID { get; set; }

        [Required]
        public int MemberID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Navigation property
        public Member? Member { get; set; }
    }
}
