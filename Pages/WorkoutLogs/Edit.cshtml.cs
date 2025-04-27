using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workout.Data;
using Workout.Model;

namespace Workout.Pages.WorkoutLogs
{
    public class EditModel : PageModel
    {
        private readonly Workout.Data.WorkoutContext _context;

        public EditModel(Workout.Data.WorkoutContext context)
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

            var workoutlog =  await _context.WorkoutLog.FirstOrDefaultAsync(m => m.Id == id);
            if (workoutlog == null)
            {
                return NotFound();
            }
            WorkoutLog = workoutlog;
           ViewData["ExerciseId"] = new SelectList(_context.Excercise, "Id", "Name");
           ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WorkoutLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutLogExists(WorkoutLog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkoutLogExists(int id)
        {
            return _context.WorkoutLog.Any(e => e.Id == id);
        }
    }
}
