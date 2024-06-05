using System.ComponentModel.DataAnnotations;

namespace ProjectGym.Model
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Contact { get; set; }

        [Required]
        public string? Specialties { get; set; }
    }
}
