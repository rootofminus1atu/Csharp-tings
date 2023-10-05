﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Q9v2
{
    public class CSVParser
    {
        // TODO:
        // CheckCounts improvement

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
            // todo: CHANGE THIS ABOVE to properly calculate the amount of fields, get that stored somewhere and display as a warning or error msg

            if (fieldsCount < propertiesCount)
            {
                PropertyInfo[] unneededProps = properties[fieldsCount..];  // add comments here
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
        public List<T> IntoClass<T>(string filePath)
        {
            // betteer name needed
            List<string> contents = LoadContents(filePath);

            CheckCounts<T>(contents);

            CustomConsole.WriteSuccess("Beginning conversion...");

            return SafeConvertToList<T>(contents);
        }

        /// <summary>
        /// Converts a List<string> of contents into a List<typeparamref name="T"/>. It does so safely, aka if it cannot convert one of the values, it will skip that line completely.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="contents"></param>
        /// <returns></returns>
        public List<T> SafeConvertToList<T>(List<string> contents)
        {
            List<T> objects = new List<T>();

            foreach (string line in contents)
            {
                // better name (from csv line fore xample)
                ConversionResult<T> result = ConversionResult<T>.FromCSVString(line, delimeter);

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

        public static ConversionResult<T> FromCSVString(string csvString, char delimeter)
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
