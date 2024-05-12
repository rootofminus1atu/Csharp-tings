using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
