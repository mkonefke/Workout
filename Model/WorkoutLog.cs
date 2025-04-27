using System.ComponentModel.DataAnnotations;

namespace Workout.Model
{
    public class WorkoutLog
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }= DateTime.Now;

        [Display(Name= "User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Display(Name= "Exercise")]
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
