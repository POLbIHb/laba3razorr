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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesPersonal.Data.RazorPagesPersonalContext _context;

        public DetailsModel(RazorPagesPersonal.Data.RazorPagesPersonalContext context)
        {
            _context = context;
        }

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
    }
}
