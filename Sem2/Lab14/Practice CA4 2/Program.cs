using System.Globalization;
using System.IO;
using System.Security.Claims;

namespace Practice_CA4_2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;



            string filePath = @"../../../clames.csv";
            List<string> categories = new List<string>() { "fire", "flood", "burglary" };



            List<Claim> claims = GetClaimData(filePath);

            claims.DisplayReport(categories);
        }

        public static List<Claim> GetClaimData(string filePath)
        {
            List<Claim> claims = new List<Claim>() { };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Loading the file...");
            Console.ResetColor();

            try
            {
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
                        Console.WriteLine(claim.ToString());
                    }
                }


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File loaded successfully!");
                Console.ResetColor();
            }
            catch (Exception ex) when (
                ex is DirectoryNotFoundException ||
                ex is FileNotFoundException ||
                ex is UnauthorizedAccessException ||
                ex is IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {ex.Message}");
                Console.ResetColor();

                Environment.Exit(0);
            }

            return claims;
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
            return $"Id: {Id}, Date: {Date}, Claim type: {ClaimType}, Amount: {Amount}";
        }
    }

    public static class ClaimExtension
    {
        public static int GetTotalClaimsFor(this List<Claim> claims, string claimType)
        {
            int total = claims
                .Where(c => c.ClaimType == claimType)
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
                .Where(c => c.ClaimType == claimType)
                .Select(c => c.Amount)
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
                Console.WriteLine($"{type.ToTitle(),k1}{claims.GetTotalClaimsFor(type),k1}€{claims.GetTotalValueFor(type)}");

            Console.WriteLine("");
            Console.WriteLine($"{"Grand Totals",k1}{claims.GetTotalClaimsFor(categories),k1}€{claims.GetTotalValueFor(categories)}");

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