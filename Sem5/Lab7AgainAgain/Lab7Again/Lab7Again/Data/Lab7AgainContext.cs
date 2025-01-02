using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab7Again.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Lab7Again.Data
{
    public class Lab7AgainContext : IdentityDbContext<AppUser>
    {
        public Lab7AgainContext(DbContextOptions<Lab7AgainContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; } = default!;
    }
}
