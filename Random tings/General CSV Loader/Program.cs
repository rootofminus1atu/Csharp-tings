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