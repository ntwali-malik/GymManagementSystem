    using System.ComponentModel.DataAnnotations;

    namespace ProjectGym.Model
    {
        public class Attendance
        {
            [Key]
            public int AttendanceID { get; set; }

            [Required]
            public int MemberID { get; set; }

            public DateTime Date { get; set; }

            // Navigation property
            public Member? Member { get; set; }
        }
    }
