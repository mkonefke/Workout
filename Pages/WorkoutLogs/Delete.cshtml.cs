using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.Model;

namespace Workout.Pages.WorkoutLogs
{
    public class DeleteModel : PageModel
    {
        private readonly Workout.Data.WorkoutContext _context;

        public DeleteModel(Workout.Data.WorkoutContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkoutLog WorkoutLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutlog = await _context.WorkoutLog.FirstOrDefaultAsync(m => m.Id == id);

            if (workoutlog is not null)
            {
                WorkoutLog = workoutlog;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutlog = await _context.WorkoutLog.FindAsync(id);
            if (workoutlog != null)
            {
                WorkoutLog = workoutlog;
                _context.WorkoutLog.Remove(WorkoutLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
