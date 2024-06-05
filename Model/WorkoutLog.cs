using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Model
{
    public class WorkoutLog
    {
        [Key]
        public int LogID { get; set; }
        [Required]
        public int MemberID { get; set; }

        public DateTime WorkoutDate { get; set; }
        public string? ExerciseName { get; set; }
        public int Sets { get; set; }

        public int Reps { get; set; }
        public string Notes { get; set; }

        public Member? Member { get; set; }

    }
}
