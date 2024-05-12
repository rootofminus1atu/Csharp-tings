using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class MovieData : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Movie> Movies { get; set; }


        public MovieData() : base("OODExam_NameSurname") { }
    }
}
