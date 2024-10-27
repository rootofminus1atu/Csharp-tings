using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rad301_2024_Lab3_books.Models;

namespace Rad301_2024_Lab3_books.Data
{
    public class Rad301_2024_Lab3_booksContext : DbContext
    {
        public Rad301_2024_Lab3_booksContext (DbContextOptions<Rad301_2024_Lab3_booksContext> options)
            : base(options)
        {
        }

        public DbSet<Rad301_2024_Lab3_books.Models.Book> Book { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                    .HasMaxLength(5);

                entity.Property(b => b.Summary)
                    .HasMaxLength(50);

                entity.Property(b => b.CoverPageUrl)
                    .IsRequired();
            });
        }
    }
}
