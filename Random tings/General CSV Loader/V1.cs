using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace General_CSV_Loader
{
    internal class V1
    {
        public readonly char delimeter;
        public readonly bool skip1stRow;
        public readonly bool printDebug;


        public V1(char delimeter = ',', bool skip1stRow = false, bool printDebug = false)
        {
            this.delimeter = delimeter;
            this.skip1stRow = skip1stRow;
            this.printDebug = printDebug;
        }

        private List<string> LoadContents(string filePath)
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
                    if (this.skip1stRow)
                        sr.ReadLine();

                    string? line = sr.ReadLine();
                    while (line != null)
                    {
                        lines.Add(line);

                        if (this.printDebug)
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

        public List<T> IntoClass<T>(string filePath, bool skip1stRow = false)
        {
            List<string> contents = LoadContents(filePath);

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

            return SafeConvertToList<T>(contents);
        }

        public static bool TryConvertValue(string value, Type targetType, out object convertedValue)
        {
            bool success;

            try
            {
                convertedValue = Convert.ChangeType(value, targetType);
                success = true;
            }
            catch
            {
                convertedValue = default;
                success = false;
            }

            return success;
        }

        public static (T, List<string>) TryLineToObj<T>(string line)
        {
            string[] fields = line.Split(',');
            T obj = Activator.CreateInstance<T>();

            List<string> log = new List<string>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < Math.Min(properties.Length, fields.Length); i++)
            {
                string field = fields[i];
                PropertyInfo property = properties[i];

                if (TryConvertValue(field, property.PropertyType, out object convertedValue))
                {
                    property.SetValue(obj, convertedValue);
                }
                else
                {
                    log.Add(field);
                }
            }

            return (obj, log);
        }

        public static List<T> SafeConvertToList<T>(List<string> contents)
        {
            List<T> objects = new List<T>();

            foreach (string line in contents)
            {
                (T obj, List<string> log) = TryLineToObj<T>(line);

                if (log.Count == 0)
                {
                    objects.Add(obj);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"[Warning] `{line}` contains data that could not be converted ({string.Join(", ", log)}). Skipping.");
                    Console.ResetColor();
                }
            }

            return objects;
        }
    }
}
