using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXXXXXXXX_ClassLibrary
{
    public class FlightContext : DbContext
    {
        // APPARENTLY THIS IS IMPORTANT
        // gotta love visual studio and ms
        // no i dont
        // thanks for keeping us informed
        public FlightContext() : base() { }
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=FlightBooking.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to make the composite pk work
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.PassengerId, b.FlightId });
        }
    }
}
