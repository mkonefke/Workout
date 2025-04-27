using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Workout.Data;
using Workout.Model;

namespace Workout.Pages.WorkoutLogs
{
    public class CreateModel : PageModel
    {
        private readonly Workout.Data.WorkoutContext _context;

        public CreateModel(Workout.Data.WorkoutContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExerciseId"] = new SelectList(_context.Excercise, "Id", "Name");
        ViewData["UserId"] = new SelectList(_context.User, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public WorkoutLog WorkoutLog { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkoutLog.Add(WorkoutLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
