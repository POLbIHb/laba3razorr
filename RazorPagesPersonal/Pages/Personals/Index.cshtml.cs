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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesPersonal.Data.RazorPagesPersonalContext _context;

        public IndexModel(RazorPagesPersonal.Data.RazorPagesPersonalContext context)
        {
            _context = context;
        }

        public IList<Personal> Personal { get;set; }

        public async Task OnGetAsync()
        {
            Personal = await _context.Personal.ToListAsync();
        }
    }
}
