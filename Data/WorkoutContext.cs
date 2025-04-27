using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout.Model;

namespace Workout.Data
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext (DbContextOptions<WorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<Workout.Model.User> User { get; set; } = default!;
        public DbSet<Workout.Model.Exercise> Excercise { get; set; } = default!;

        public DbSet<Workout.Model.WorkoutLog> WorkoutLog { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Jack Frost", Email = "jackfrost@frosty.com" },
                new User { Id = 2, Name = "Junie B Jones", Email = "juniebjones@jones.com" },
                new User { Id = 3, Name = "Cookie Monster", Email = "cookiemonster@cookie.com" }
                );
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Push Up", Type = Workout.Model.Type.Strength, MuscleGroup = "Chest", Reps = 10, Sets = 3 },
                new Exercise { Id = 2, Name = "Legs", Type = Workout.Model.Type.Strength, MuscleGroup = "Hamstrings", Reps = 15, Sets = 3 },
                new Exercise { Id = 3, Name = "Abs", Type = Workout.Model.Type.Strength, MuscleGroup = "Crunch", Reps = 100, Sets = 3 },
                new Exercise { Id = 4, Name = "Arms", Type = Workout.Model.Type.Strength, MuscleGroup = "Curl", Reps = 10, Sets = 3 },
                new Exercise { Id = 5, Name = "Speed Walking", Type = Workout.Model.Type.Cardio, MuscleGroup = "All", Duration = 120 }
                );
            modelBuilder.Entity<WorkoutLog>().HasData(
                new WorkoutLog { Id = 1, Date = DateTime.Today, UserId = 1, ExerciseId = 1 },
                new WorkoutLog { Id = 2, Date = DateTime.Today, UserId = 2, ExerciseId = 2 }
                );
        }
    }
}
