using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.WorkoutLogs
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public DetailsModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public WorkoutLog WorkoutLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutlog = await _context.WorkoutLog.FirstOrDefaultAsync(m => m.LogID == id);
            if (workoutlog == null)
            {
                return NotFound();
            }
            else
            {
                WorkoutLog = workoutlog;
            }
            return Page();
        }
    }
}
