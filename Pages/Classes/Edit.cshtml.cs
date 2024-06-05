using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.Classes
{
    public class EditModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public EditModel(ProjectGym.Data.ProjectGymContext context)
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

            var classtb =  await _context.ClassTB.FirstOrDefaultAsync(m => m.ClassID == id);
            if (classtb == null)
            {
                return NotFound();
            }
            ClassTB = classtb;
           ViewData["TrainerID"] = new SelectList(_context.Trainer, "TrainerID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ClassTB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassTBExists(ClassTB.ClassID))
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

        private bool ClassTBExists(int id)
        {
            return _context.ClassTB.Any(e => e.ClassID == id);
        }
    }
}
