using Microsoft.VisualBasic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace General_CSV_Loader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../people.txt";

            List<Person> people2 = ExtractData<Person>(filePath);

            foreach (Person person in people2)
            {
                Console.WriteLine(person.ToString());
            }
        }

        public static T LineToObj<T>(string line)
        {
            string[] fields = line.Split(',');
            T obj = Activator.CreateInstance<T>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < Math.Min(properties.Length, fields.Length); i++)
            {
                PropertyInfo property = properties[i];
                property.SetValue(obj, Convert.ChangeType(fields[i], property.PropertyType));
            }

            return obj;
        }

        public static bool TryConvertValue<T>(string value, out T convertedValue)
        {
            try
            {
                convertedValue = (T)Convert.ChangeType(value, typeof(T));
                return true;
            }
            catch
            {
                convertedValue = default(T);
                return false;
            }
        }

        public static List<T> ConvertToList<T>(List<string> contents)
        {
            List<T> objects = new List<T>() { };

            foreach (string line in contents)
            {
                T obj = LineToObj<T>(line);
                objects.Add(obj);
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[Warning] `{line}` contains data that could not be converted. Skipping.");
                Console.ResetColor();

            }

            return objects;
        }

        public static List<string> LoadCSV(string filePath, bool skip1stRow = false)
        {
            List<string> lines = new List<string>() { };

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Loading file contents...");
                Console.ResetColor();

                using (StreamReader sr = File.OpenText(filePath))
                {
                    // skipping the 1st row
                    if (skip1stRow)
                        sr.ReadLine();

                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);

                        // debug
                        Console.WriteLine(line);
                    }

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File contents loaded successfully!");
                Console.ResetColor();
            }
            catch (Exception ex) when (
                ex is DirectoryNotFoundException ||
                ex is FileNotFoundException ||
                ex is UnauthorizedAccessException ||
                ex is IOException ||
                ex is ArgumentException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {ex.Message}");
                Console.ResetColor();

                Environment.Exit(0);
            }

            return lines;
        }

        public static List<T> ExtractData<T>(string filePath, bool skip1stRow = false)
        {
            List<string> contents = LoadCSV(filePath, skip1stRow);

            PropertyInfo[] properties = typeof(T).GetProperties();

            int propertiesCount = properties.Length;
            int fieldsCount = contents[0].Split(',').Length;

            if (fieldsCount < propertiesCount)
            {
                PropertyInfo[] unneededProps = properties[fieldsCount..];
                string[] unneededNames = unneededProps.Select(x => x.Name).ToArray();
                string unneededNamesStr = string.Join(", ", unneededNames);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[Warning] {typeof(T).Name} has {propertiesCount} properties, but there are only {fieldsCount} fields in the CSV file. Consider removing `{unneededNamesStr}` or else they'll be initialized to default values.");
                Console.ResetColor();
            }
            else if (fieldsCount > propertiesCount)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"[Warning] The CSV file has {fieldsCount} fields, but there are only {propertiesCount} properties in the {typeof(T).Name} class. Consider adding more properties to {typeof(T).Name}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Beginning conversion...");
            Console.ResetColor();

            return ConvertToList<T>(contents);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }


        public Person() { }


        public override string ToString()
        {
            return $"{FirstName} {LastName} aged {Age}";
        }
    }
}