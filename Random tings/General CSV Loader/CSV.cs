using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace General_CSV_Loader
{
    public class CSVParser
    {
        // TODO: 
        // go to Lab3 and check the todos from there

        public readonly char delimeter;
        public readonly bool skip1stRow;
        public readonly bool printDebug;

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
                // case when the file contents cannot be accessed
                CustomConsole.WriteError(ex.Message);
                Environment.Exit(0);
            }

            return lines;
        }

        /// <summary>
        /// Checks if the amount of fields in the CSV file and the amount of properties in the class provided (T) are the same
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contents"></param>
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

        /// <summary>
        /// Converts the content of a CSV file located at the specified file path into a List of objects of the specified type.
        /// </summary>
        /// <typeparam name="T">The class type to which each CSV record will be converted.</typeparam>
        /// <param name="filePath">The file path to the CSV file to be read.</param>
        /// <returns>A List of objects of type <typeparamref name="T"/> representing the data from the CSV file.</returns>
        public List<T> ObjectListFromCSV<T>(string filePath)
        {
            List<string> contents = LoadContents(filePath);

            CheckCounts<T>(contents);

            CustomConsole.WriteSuccess("Beginning conversion...");

            return SafeConvertToList<T>(contents);
        }

        public List<T> SafeConvertToList<T>(List<string> contents)
        {
            List<T> objects = new List<T>();

            foreach (string line in contents)
            {
                ConversionResult<T> result = ConversionResult<T>.FromCSVLine(line, delimeter);

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
    /// Represents the result of converting a CSV string into an object of type <typeparamref name="T"/> .
    /// </summary>
    /// <typeparam name="T">The target type for the conversion.</typeparam>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionResult{T}"/> class with the converted object
        /// and a list of faulty fields.
        /// </summary>
        /// <param name="obj">The converted object of type T.</param>
        /// <param name="faultyFields">A list of fields that failed to convert.</param>
        public ConversionResult(T obj, List<string> faultyFields)
        {
            Object = obj;
            FaultyFields = faultyFields;
        }

        private void AddFaultyField(string field)
        {
            FaultyFields.Add(field);
        }

        private void AssignProp(PropertyInfo property, object value)
        {
            property.SetValue(Object, value);
        }

        /// <summary>
        /// Converts a CSV string line into an object of type T.
        /// </summary>
        /// <param name="csvString">The CSV string to convert.</param>
        /// <param name="delimiter">The delimiter used to separate CSV fields.</param>
        /// <returns>An instance of <see cref="ConversionResult{T}"/> representing the result of the conversion.</returns>
        public static ConversionResult<T> FromCSVLine(string csvString, char delimeter)
        {
            string[] csvFields = csvString.Split(delimeter);
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

        /// <summary>
        /// Tries to convert a string value to a target type, handling exceptions and returning whether the conversion was successful.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        /// <param name="targetType">The target data type for the conversion.</param>
        /// <param name="convertedValue">The converted value (output parameter).</param>
        /// <returns><c>true</c> if the conversion is successful, <c>false</c> otherwise.</returns>
        private static bool TryConvertValue(string value, Type targetType, out object convertedValue)
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

    }
}
