using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsAndVetsLibrary
{
    public class PetsAndVetsContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<VetVisit> VetVisits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=petsandvets.db");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Pet>()
        //        .HasOne(p => p.Owner)
        //        .WithMany(o => o.Pets)
        //        .HasForeignKey(p => p.OwnerId);

        //    modelBuilder.Entity<VetVisit>()
        //        .HasOne(vv => vv.Pet)
        //        .WithMany(p => p.VetVisits)
        //        .HasForeignKey(vv => vv.PetId);

        //    modelBuilder.Entity<VetVisit>()
        //        .HasOne(vv => vv.Vet)
        //        .WithMany(v => v.VetVisits)
        //        .HasForeignKey(vv => vv.VetId);
        //}
    }
}
