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
    public class IndexModel : PageModel
    {
        private readonly Workout.Data.WorkoutContext _context;

        public IndexModel(Workout.Data.WorkoutContext context)
        {
            _context = context;
        }

        public IList<Exercise> Exercise { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Exercise = await _context.Excercise.ToListAsync();
        }
    }
}
