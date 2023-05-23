using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Practice_CA4_2018
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../graduates.txt";

            List<double> salaryBands = new List<double>() { 0, 20000, 40000, 60000 };



            List<Graduate> grads = GetGraduatesData(filePath);

            grads.Display(salaryBands);
        }

        public static List<Graduate> GetGraduatesData(string filePath)
        {
            List<Graduate> graduates = new List<Graduate>() { };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Loading the file...");
            Console.ResetColor();

            try
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');

                        Graduate grad = new(
                            fields[0],
                            fields[1],
                            double.Parse(fields[2])
                            );

                        graduates.Add(grad);

                        // debug stuff
                        Console.WriteLine(line);
                        //Console.WriteLine(claim.ToString());
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

            return graduates;
        }
    }

    public class Graduate
    {
        public string Id { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

        public Graduate(string id, string gender, double salary)
        {
            Id = id;
            Gender = gender;
            Salary = salary;
        }
    }

    public static class GraduateExtension
    {
        public static int GetTotalsForGender(this List<Graduate> graduates, string gender)
        {
            return graduates
                .Where(g => g.Gender.ToLower() == gender)
                .Count();
        }

        public static int GetAmountsForGenderBetween(this List<Graduate> graduates, string gender, double lower, double upper)
        {
            int count = graduates
                .Where(g => g.Gender == gender)
                .Select(g => g.Salary)
                .Where(s => s > lower && s <= upper)
                .Count();

            return count;
        }

        public static void Display(this List<Graduate> graduates, List<double> ranges)
        {
            const int indent = -20;
            const int indent2 = -12;

            Console.WriteLine($"{"Salary Band", indent}{"Females", indent2}{"Males",indent2}{"Total",indent2}");

            for (int i = 0; i < ranges.Count; i++)
            {
                double lower = ranges[i];
                double upper = i == ranges.Count - 1 ? double.MaxValue : ranges[i + 1];

                int females = graduates.GetAmountsForGenderBetween("female", lower, upper);
                int males = graduates.GetAmountsForGenderBetween("male", lower, upper);
                int total = females + males;

                string rangeStr;
                if (i  != ranges.Count - 1)
                    rangeStr = $"{lower} - {upper}";

                else
                    rangeStr = $"{lower}+";

                Console.WriteLine($"{rangeStr, indent}{females, indent2}{males,indent2}{total,indent2}");
            }

            int totalFemales = graduates.GetTotalsForGender("female");
            int totalMales = graduates.GetTotalsForGender("male");
            int totalTotals = totalFemales + totalMales;

            Console.WriteLine($"{"Grand Totals", indent}{totalFemales,indent2}{totalMales,indent2}{totalTotals,indent2}");
        }
    }
}