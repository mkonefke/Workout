using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.Model;

namespace Workout.Pages.Exercises
{
    public class DetailsModel : PageModel
    {
        private readonly Workout.Data.WorkoutContext _context;

        public DetailsModel(Workout.Data.WorkoutContext context)
        {
            _context = context;
        }

        public Exercise Exercise { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Excercise.FirstOrDefaultAsync(m => m.Id == id);

            if (exercise is not null)
            {
                Exercise = exercise;

                return Page();
            }

            return NotFound();
        }
    }
}
