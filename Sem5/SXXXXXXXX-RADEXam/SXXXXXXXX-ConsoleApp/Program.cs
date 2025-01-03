using Microsoft.EntityFrameworkCore;
using SXXXXXXXX_ClassLibrary;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<FlightContext>();
optionsBuilder.UseSqlite("Data Source=FlightBooking.db");

using (var db = new FlightContext(optionsBuilder.Options))
{
    db.Database.EnsureCreated();
    Console.WriteLine("Database created");
}
