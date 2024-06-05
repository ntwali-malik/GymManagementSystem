using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.Classes
{
    public class AllClassesModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public AllClassesModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public IList<ClassTB> ClassTB { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ClassTB = await _context.ClassTB
                .Include(c => c.Trainer).ToListAsync();
        }
    }
}
