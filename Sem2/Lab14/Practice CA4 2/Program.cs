using System.Globalization;
using System.IO;
using System.Security.Claims;

namespace Practice_CA4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../clames.csv";


            List<Claim> claims2 = GetClaimsWithErrorHandling(filePath);
            List<Claim> claims = GetClaimData(filePath);

            List<string> categories = new List<string>() { "fire", "flood", "burglary" };


            // add list of desired types
            // push it into the func here
            // get desired numbers
            // print them

            // Console.WriteLine(claims.GetTotalClaimsFor("flood"));
            // Console.WriteLine(claims.GetTotalValueFor("fire"));

            claims.DisplayReport(categories);
            claims2.DisplayReport(categories);


        }

        public static Func<string, TResult> ErrorHandlingDecorator<TResult>(Func<string, TResult> fileLoad)
        {
            TResult wrapper(string filePath)
            {
                Console.WriteLine("Started");
                TResult result = fileLoad(filePath);
                Console.WriteLine("Ended");

                return result;
            };

            return wrapper;
        }

        public static List<Claim> GetClaimData(string filePath)
        {
            List<Claim> claims = new List<Claim>() { };

            using (StreamReader sr = File.OpenText(filePath))
            {
                string? s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] fields = s.Split(',');

                    Claim claim = new(
                        fields[0],
                        fields[1],
                        fields[2],
                        double.Parse(fields[3])
                        );

                    claims.Add(claim);

                    // debug stuff
                    // Console.WriteLine(passenger.ToString());
                    Console.WriteLine(s);
                }
            }

            return claims;
        }

        public static List<Claim> GetClaimsWithErrorHandling(string filePath)
        {
            return ErrorHandlingDecorator(GetClaimData)(filePath);
        }
    }

    public class Claim
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string ClaimType { get; set; }
        public double Amount { get; set; }

        public Claim() { }

        public Claim(string id, string date, string claimType, double amount)
        {
            Id = id;
            Date = date;
            ClaimType = claimType;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"";
        }
    }

    public static class ClaimExtension
    {
        public static void SayHi(this List<Claim> lst)
        {
            Console.WriteLine("Hi!");
        }

        public static int GetTotalClaimsFor(this List<Claim> claims, string claimType)
        {
            int total = claims
                .Where(x => x.ClaimType == claimType)
                .Count();

            return total;
        }

        public static int GetTotalClaimsFor(this List<Claim> claims, List<string> claimTypes)
        {
            int total = 0;

            foreach(string type in claimTypes)
                total += claims.GetTotalClaimsFor(type);

            return total;
        }

        public static double GetTotalValueFor(this List<Claim> claims, string claimType)
        {
            double total = claims
                .Where(x => x.ClaimType == claimType)
                .Select(x => x.Amount)
                .Sum();

            return total;
        }

        public static double GetTotalValueFor(this List<Claim> claims, List<string> claimTypes)
        {
            double total = 0;

            foreach (string type in claimTypes)
                total += claims.GetTotalValueFor(type);

            return total;
        }

        public static void DisplayReport(this List<Claim> claims, List<string> categories)
        {
            const int k1 = -20;  // indent

            Console.WriteLine($"{"Claim Type",k1}{"Total Claims",k1}Total Value");
            Console.WriteLine("");

            foreach (string type in categories)
                Console.WriteLine($"{type.ToTitle(),k1}{claims.GetTotalClaimsFor(type),k1}{claims.GetTotalValueFor(type)}");

            Console.WriteLine("");
            Console.WriteLine($"{"Grand Totals",k1}{claims.GetTotalClaimsFor(categories),k1}{claims.GetTotalValueFor(categories)}");

        }
    }

    public static class Helpers
    {
        public static string ToTitle(this string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
    }
}