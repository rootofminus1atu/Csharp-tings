using System.ComponentModel.DataAnnotations;

namespace SXXXXXXXX_ClassLibrary
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Country { get; set; }
        public int MaxSeats { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }

    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(7, ErrorMessage = "Passport number must be less than 7 chars long")]
        public string PassportNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }

    public class Booking
    {
        [Key]
        public int PassengerId { get; set; }
        [Key]
        public int FlightId { get; set; }
        public TicketType TicketType { get; set; }
        [Range(5, double.MaxValue, ErrorMessage = "Ticket cost must be at least 5")]
        public double TicketCost { get; set; }
        public int BaggageCharge { get; set; }
    }

    public enum TicketType
    {
        Economy,
        FirstClass
    }
}
