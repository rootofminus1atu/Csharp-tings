using System.Text.RegularExpressions;

namespace CA6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../../faminefiletoanalyse.csv";

            List<Passenger> passengerList = GetPassengerData(filePath);

            List<Ship> ships = passengerList.GetShips2();

            foreach(Ship ship in ships)
                Console.WriteLine($"{ship.ShipID} arrived on {ship.ArrivalDate} WITH COUNT {ship.Count}");
        
        }

        // this below is ugly 
        // fix later
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

        static List<Passenger> GetPassengerData(string path)
        {
            List<Passenger> passengers = new List<Passenger>();

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


    
}