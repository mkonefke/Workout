using System.ComponentModel.DataAnnotations;

namespace Workout.Model
{
    public enum Type { Cardio, Strength, Flexibility, Balance }

    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }= string.Empty;

        [EnumDataType (typeof(Type))]
        public Type? Type { get; set; }

        [StringLength(100)]
        [Display(Name= "Muscle Group")]
        public string? MuscleGroup { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Equipment {  get; set; } = string.Empty; 

        public int? Reps { get; set; }

        public int? Sets { get; set; }

        public int? Weight { get; set; }

        public int? Duration { get; set; }

        public ICollection<WorkoutLog> WorkoutLog { get; set; } = new List<WorkoutLog>();
    }
}
