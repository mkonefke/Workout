using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Workout.Data;
using Workout.Model;

namespace Workout.Pages.Exercises
{
    public class CreateModel : PageModel
    {
        private readonly Workout.Data.WorkoutContext _context;

        public CreateModel(Workout.Data.WorkoutContext context)
        {
            _context = context;
        }

        // Property to hold the Enum values
        public List<string> TypeList { get; set; } = new List<string>();

        public IActionResult OnGet()
        {
            TypeList = Enum.GetNames(typeof(Workout.Model.Type)).ToList();
            return Page();
        }

        [BindProperty]
        public Exercise Exercise { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Excercise.Add(Exercise);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
