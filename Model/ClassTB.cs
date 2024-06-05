using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Model
{
    public class ClassTB
    {
        [Key]
        public int ClassID { get; set; }

        [Required]
        public string? ClassName { get; set; }

        [Required]
        public int TrainerID { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public int Capacity { get; set; }

        // Navigation property
        public Trainer? Trainer { get; set; }
    }
}
