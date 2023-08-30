using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace General_CSV_Loader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../people.txt";

            var parser = new CSVParser(printDebug: true);

            List<Person> people = parser.IntoClass<Person>(filePath);

            foreach (Person person in people)
                Console.WriteLine(person.ToString());

            /*
            List<Person> people2 = CSV.ExtractData<Person>(filePath);

            foreach (Person person in people2)
                Console.WriteLine(person.ToString());
            */
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

        public static List<T> ConvertToList<T>(List<string> contents)
        {
            List<T> objects = new List<T>() { };

            foreach (string line in contents)
            {
                T obj = LineToObj<T>(line);
                objects.Add(obj);
                
                //Console.ForegroundColor = ConsoleColor.DarkYellow;
                //Console.WriteLine($"[Warning] `{line}` contains data that could not be converted. Skipping.");
                //Console.ResetColor();

            }

            return objects;
        }

        
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public double Salary { get; set; }


        public Person() { }


        public override string ToString()
        {
            return $"{FirstName} {LastName} aged {Age} with salary {Salary}";
        }
    }

    public static class ParseExtension
    {
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

        public static bool TryParse(this Type targetType, string value, out object convertedValue)
        {
            convertedValue = 1;
            return true;
        }
    }
}