using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesPersonal.Data;
using RazorPagesPersonal.Models;

namespace RazorPagesPersonal.Pages.Personals
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesPersonal.Data.RazorPagesPersonalContext _context;

        public CreateModel(RazorPagesPersonal.Data.RazorPagesPersonalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Personal Personal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personal.Add(Personal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
