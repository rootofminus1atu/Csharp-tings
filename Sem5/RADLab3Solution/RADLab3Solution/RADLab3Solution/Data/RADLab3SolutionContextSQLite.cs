using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RADLab3Solution.Models;

namespace RADLab3Solution.Data
{
    public class RADLab3SolutionContextSQLite : DbContext
    {
        public RADLab3SolutionContextSQLite (DbContextOptions<RADLab3SolutionContextSQLite> options)
            : base(options)
        {
        }

        public DbSet<RADLab3Solution.Models.Book> Book { get; set; } = default!;
        public DbSet<RADLab3Solution.Models.Author> Author { get; set; } = default!;
        public DbSet<RADLab3Solution.Models.Publisher> Publisher { get; set; } = default!;
    }
}
