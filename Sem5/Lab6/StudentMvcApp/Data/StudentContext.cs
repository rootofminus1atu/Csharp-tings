using Microsoft.EntityFrameworkCore;
using StudentClassLibrary;
using System.Collections.Generic;

namespace StudentMvcApp.Data
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name)
                    .HasMaxLength(50);
            });
        }
    }
}
