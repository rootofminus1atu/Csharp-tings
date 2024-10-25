using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab5Part1.Models;

namespace Lab5Part1.Data
{
    public class Lab5Part1Context : DbContext
    {
        public Lab5Part1Context (DbContextOptions<Lab5Part1Context> options)
            : base(options)
        {
        }

        public DbSet<Lab5Part1.Models.User> User { get; set; } = default!;
    }
}
