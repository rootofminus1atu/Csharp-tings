using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace General_CSV_Loader
{
    /// <summary>
    /// Parses CSV files and converts the data into objects of the specified type.
    /// </summary>
    public class CSVParser
    {
        /// <summary>
        /// The delimiter used to separate values in the CSV file.
        /// </summary>
        public readonly char delimeter;

        /// <summary>
        /// Whether to skip the first row of the CSV file.
        /// </summary>
        public readonly bool skip1stRow;

        /// <summary>
        /// Whether to print debug information during parsing.
        /// </summary>
        public readonly bool printDebug;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVParser"/> class.
        /// </summary>
        /// <param name="delimeter">The delimiter character.</param>
        /// <param name="skip1stRow">Whether to skip the first row.</param>
        /// <param name="printDebug">Whether to print debug information.</param>
        public CSVParser(char delimeter = ',', bool skip1stRow = false, bool printDebug = false)
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
                Console.WriteLine("Loading file contents...");

                using (StreamReader sr = File.OpenText(filePath))
                {
                    // skipping the 1st row
                    if (this.skip1stRow)
                        sr.ReadLine();

                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);

                        if (this.printDebug)
                            Console.WriteLine(line);
                    }

                }

                CustomConsole.WriteSuccess("File contents loaded successfully!");
            }
            catch (Exception ex) when (
                ex is DirectoryNotFoundException ||
                ex is FileNotFoundException ||
                ex is UnauthorizedAccessException ||
                ex is IOException ||
                ex is ArgumentException)
            {
                CustomConsole.WriteError(ex.Message);

                Environment.Exit(0);
            }

            return lines;
        }

        private void CheckCounts<T>(List<string> contents) 
        { 
            var properties = typeof(T).GetProperties();

            int propertiesCount = properties.Length;
            int fieldsCount = contents[0].Split(this.delimeter).Length;

            if (fieldsCount < propertiesCount)
            {
                PropertyInfo[] unneededProps = properties[fieldsCount..];
                string[] unneededNames = unneededProps.Select(x => x.Name).ToArray();
                string unneededNamesStr = string.Join(", ", unneededNames);

                CustomConsole.WriteWarning($"{typeof(T).Name} has {propertiesCount} properties, but there are only {fieldsCount} fields in the CSV file. Consider removing `{unneededNamesStr}` or else they'll be initialized to default values.");
            }
            else if (fieldsCount > propertiesCount)
            {
                CustomConsole.WriteWarning($"The CSV file has {fieldsCount} fields, but there are only {propertiesCount} properties in the {typeof(T).Name} class. Consider adding more properties to {typeof(T).Name}");
            }
        }

        public List<T> IntoClass<T>(string filePath, bool skip1stRow = false)
        {
            List<string> contents = LoadContents(filePath);

            CheckCounts<T>(contents);

            CustomConsole.WriteSuccess("Beginning conversion...");

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

        public ConversionResult<T> TryLineToObj<T>(string line)
        {
            string[] csvFields = line.Split(this.delimeter);
            ConversionResult<T> result = new ConversionResult<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < Math.Min(properties.Length, csvFields.Length); i++)
            {
                string field = csvFields[i];
                PropertyInfo property = properties[i];

                if (TryConvertValue(field, property.PropertyType, out object convertedValue))
                {
                    result.AssignProp(property, convertedValue);
                }
                else
                {
                    result.AddFaultyField(field);
                }
            }

            return result;
        }

        public List<T> SafeConvertToList<T>(List<string> contents)
        {
            List<T> objects = new List<T>();

            foreach (string line in contents)
            {
                ConversionResult<T> result = ConversionResult.TryLineToObj<T>(line);

                if (result.Success)
                {
                    objects.Add(result.Object);
                }
                else
                {
                    CustomConsole.WriteWarning($"`{line}` contains data that could not be converted ({string.Join(", ", result.FaultyFields)}). Skipping.");
                }
            }

            return objects;
        }
    }

    /// <summary>
    /// Represents the result of trying to convert a CSV line into an object.
    /// </summary>
    /// <typeparam name="T">The type of object being converted.</typeparam>
    public class ConversionResult<T>
    {
        public T Object { get; }
        public List<string> FaultyFields { get; }

        public bool Success => FaultyFields.Count() == 0;

        public ConversionResult() 
        {
            Object = Activator.CreateInstance<T>();
            FaultyFields = new List<string>();
        }

        public ConversionResult(T obj, List<string> faultyFields)
        {
            Object = obj;
            FaultyFields = faultyFields;
        }

        public void AddFaultyField(string field)
        {
            FaultyFields.Add(field);
        }

        public void AssignProp(PropertyInfo property, object value)
        {
            property.SetValue(Object, value);
        }

        public ConversionResult
    }
}
