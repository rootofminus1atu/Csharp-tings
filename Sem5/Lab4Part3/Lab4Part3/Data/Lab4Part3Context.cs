using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab4Part3.Models;

namespace Lab4Part3.Data
{
    public class Lab4Part3Context : DbContext
    {
        public Lab4Part3Context (DbContextOptions<Lab4Part3Context> options)
            : base(options)
        {
        }

        public DbSet<Lab4Part3.Models.Category> Category { get; set; } = default!;
        public DbSet<Lab4Part3.Models.Product> Product { get; set; } = default!;
        public DbSet<Lab4Part3.Models.Supplier> Supplier { get; set; } = default!;
    }
}
