using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesPersonal.Data;
using RazorPagesPersonal.Models;

namespace RazorPagesPersonal.Pages.Personals
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesPersonal.Data.RazorPagesPersonalContext _context;

        public EditModel(RazorPagesPersonal.Data.RazorPagesPersonalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personal Personal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personal = await _context.Personal.FirstOrDefaultAsync(m => m.ID == id);

            if (Personal == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Personal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(Personal.ID))
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

        private bool PersonalExists(int id)
        {
            return _context.Personal.Any(e => e.ID == id);
        }
    }
}
