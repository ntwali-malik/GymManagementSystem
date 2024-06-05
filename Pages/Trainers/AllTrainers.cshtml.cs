using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.Trainers
{
    public class AllTrainersModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public AllTrainersModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public IList<Trainer> Trainer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Trainer = await _context.Trainer.ToListAsync();
        }
    }
}
