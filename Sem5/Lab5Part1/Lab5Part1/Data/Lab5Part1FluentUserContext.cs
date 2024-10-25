using Lab5Part1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5Part1.Data
{
    public class Lab5Part1FluentUserContext : DbContext
    {
        public Lab5Part1FluentUserContext(DbContextOptions<Lab5Part1FluentUserContext> options)
        : base(options)
        {
        }

        public DbSet<FluentUser> FluentUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FluentUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired();

                entity.Property(e => e.Biography)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasColumnName("age_of_user");
            });
        }
    }
}
