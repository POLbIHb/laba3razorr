using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesPersonal.Models;

namespace RazorPagesPersonal.Data
{
    public class RazorPagesPersonalContext : DbContext
    {
        public RazorPagesPersonalContext (DbContextOptions<RazorPagesPersonalContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesPersonal.Models.Personal> Personal { get; set; }
    }
}
