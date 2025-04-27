using System.ComponentModel.DataAnnotations;

namespace Workout.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }=string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;

        public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
    }
}
