using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14Q1
{
    public class Concert
    {
        public string Artist { get; set; }
        public int Price { get; set; }
        public int TotalSeats { get; set; }
        public int SeatsSold { get; set; }

        public int Number { get; private set; }
        private static int counter = 0;


        public Concert()
        {
            Number = counter;
            counter++;
        }

        public Concert(string artist, int price, int totalSeats, int seatsSold)
        {
            Artist = artist;
            Price = price;
            TotalSeats = totalSeats;
            SeatsSold = seatsSold;

            Number = counter;
            counter++;
        }

        public string GetPriceClassification()
        {
            Dictionary<int, string> classification = new Dictionary<int, string>()
            {
                [0] = "Low",
                [50] = "Medium",
                [80] = "High"
            };

            for (int i = 0; i < classification.Count; i++)
            {
                int current = classification.ElementAt(i).Key;
                var next = i == classification.Count - 1 ? int.MaxValue : classification.ElementAt(i + 1).Key;

                Console.WriteLine($"from {current} to {next}");

                if (Price >= current && Price < next)
                    return classification[current];
            }

            return "Invalid";
        }

        public double GetPercentageSeatsSold()
        {
            return (double)SeatsSold / (double)TotalSeats;
        }

        public override string ToString()
        {
            return $"Concert #{Number} with {Artist}\nPrice: {Price} ({this.GetPriceClassification()})\nAvailable seats: {TotalSeats - SeatsSold}\nSold seats: {SeatsSold}\nPercentage sold: {this.GetPercentageSeatsSold()}";
        }
    }
}
