using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPersonal.Data;
using RazorPagesPersonal.Models;

namespace RazorPagesPersonal.Pages.Personals
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesPersonal.Data.RazorPagesPersonalContext _context;

        public DeleteModel(RazorPagesPersonal.Data.RazorPagesPersonalContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Personal = await _context.Personal.FindAsync(id);

            if (Personal != null)
            {
                _context.Personal.Remove(Personal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
