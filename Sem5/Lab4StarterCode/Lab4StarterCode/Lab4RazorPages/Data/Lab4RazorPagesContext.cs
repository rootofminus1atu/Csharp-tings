using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab4RazorPages.Models;

namespace Lab4RazorPages.Data
{
    public class Lab4RazorPagesContext : DbContext
    {
        public Lab4RazorPagesContext (DbContextOptions<Lab4RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<Lab4RazorPages.Models.Product> Product { get; set; } = default!;
        public DbSet<Lab4RazorPages.Models.Category> Category { get; set; } = default!;
        public DbSet<Lab4RazorPages.Models.Supplier> Supplier { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {

            });
        }
    }
}
}
