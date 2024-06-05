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
    public class IndexModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public IndexModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public IList<Attendance> Attendance { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Attendance = await _context.Attendance
                .Include(a => a.Member).ToListAsync();
        }
    }
}
