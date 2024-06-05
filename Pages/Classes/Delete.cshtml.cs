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
    public class DeleteModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public DeleteModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassTB ClassTB { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classtb = await _context.ClassTB.FirstOrDefaultAsync(m => m.ClassID == id);

            if (classtb == null)
            {
                return NotFound();
            }
            else
            {
                ClassTB = classtb;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classtb = await _context.ClassTB.FindAsync(id);
            if (classtb != null)
            {
                ClassTB = classtb;
                _context.ClassTB.Remove(ClassTB);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
