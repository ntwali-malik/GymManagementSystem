using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.Memberships
{
    public class IndexModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public IndexModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public IList<Membership> Membership { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Membership = await _context.Membership
                .Include(m => m.Member).ToListAsync();
        }
    }
}
