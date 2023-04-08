using System.Text.RegularExpressions;

namespace Attempt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../../faminefiletoanalyse.csv";

            // no clue if this is a good idea, I'll attempt it later
            List<Ship> shipList = GetData(filePath);
        }

        static double AgeParse(string ageString)
        {
            string pattern = @"\d+";


            if (ageString.StartsWith("age"))
            {
                Match match = Regex.Match(ageString, pattern);
                double number = double.Parse(match.Value);
                return number;
            }


            else if (ageString.StartsWith("Infant"))
            {
                Match match = Regex.Match(ageString, pattern);
                double number = double.Parse(match.Value);
                return number / 12;
            }


            return 0;
        }

        static List<Ship> GetPassengerData(string path)
        {
            List<Ship> ships = new List<Passenger>();

            using (StreamReader sr = File.OpenText(path))
            {
                // read and discard the first line
                sr.ReadLine();

                string? s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] fields = s.Split(",");

                    Passenger passenger = new()  // wack syntax
                    {
                        // the current implementation depends on the correct ordering of the columns
                        // it's possible to make it depend on the header row names
                        // but I'm going with the former, since changing the header row is easier than rearranging the columns

                        LastName = fields[0],
                        FirstName = fields[1],
                        Age = AgeParse(fields[2]),
                        Sex = fields[3],
                        Occupation = fields[4],
                        NativeCountry = fields[5],
                        Ship = new Ship(
                            fields[6],
                            fields[7],
                            fields[8],
                            fields[9]
                            )
                    };

                    passengers.Add(passenger);

                    // debug stuff
                    // Console.WriteLine(passenger.ToString());
                }
            }

            return passengers;
        }
    }

    public class Ship
    {
        public string DestinationCountry { get; set; }
        public string DepartureSeaport { get; set; }
        public string ShipID { get; set; }
        public string ArrivalDate { get; set; }
        public List<Passenger> Passengers;

        public Ship() { }

        public Ship(string destinationCountry, string departureSeaport, string shipID, string arrivalDate)
        {
            DestinationCountry = destinationCountry;
            DepartureSeaport = departureSeaport;
            ShipID = shipID;
            ArrivalDate = arrivalDate;
            Passengers = new List<Passenger>();
        }

    }

    public class Passenger
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Age { get; set; }
        public string Sex { get; set; }
        public string Occupation { get; set; }
        public string NativeCountry { get; set; }


        public Passenger() { }

        public Passenger(string lastName, string firstName, double age, string sex, string occupation, string nativeCountry)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Sex = sex;
            Occupation = occupation;
            NativeCountry = nativeCountry;
        }

        public override string ToString()
        {
            return $"{this.LastName} {this.FirstName} aged {this.Age}";
        }
    }

}