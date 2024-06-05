using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.Attendances
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public DetailsModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public Attendance Attendance { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.FirstOrDefaultAsync(m => m.AttendanceID == id);
            if (attendance == null)
            {
                return NotFound();
            }
            else
            {
                Attendance = attendance;
            }
            return Page();
        }
    }
}
