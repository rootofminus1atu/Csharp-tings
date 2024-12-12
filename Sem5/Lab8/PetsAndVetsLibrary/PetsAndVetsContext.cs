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

        public PetsAndVetsContext() : this(GetOptions())
        {
        }

        public PetsAndVetsContext(DbContextOptions<PetsAndVetsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={GetDbPath()}");
        }

        private static DbContextOptions<PetsAndVetsContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetsAndVetsContext>();
            optionsBuilder.UseSqlite($"Data Source={GetDbPath()}");
            return optionsBuilder.Options;
        }

        public static string GetDbPath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;
            return Path.Combine(solutionDirectory, "petsandvets.db");
        }
    }
}
