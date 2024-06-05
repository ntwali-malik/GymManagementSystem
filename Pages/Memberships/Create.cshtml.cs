﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectGym.Data;
using ProjectGym.Model;

namespace ProjectGym.Pages.Memberships
{
    public class CreateModel : PageModel
    {
        private readonly ProjectGym.Data.ProjectGymContext _context;

        public CreateModel(ProjectGym.Data.ProjectGymContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "Name");
            return Page();
        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Membership.Add(Membership);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
