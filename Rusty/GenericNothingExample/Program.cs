using System.Collections.Generic;

namespace GenericNothingExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> intList = new List<int> { 1, 2, 3 };
            IEnumerable<object> objectEnumerable = intList as IEnumerable<object>;

            Console.WriteLine($"is null? {objectEnumerable == null}");


            Dog[] dogs = new Dog[] { };
            Animal[] angs = dogs;

            Console.WriteLine(angs.Length);

            Option
        }
    }

    public class Animal
    {

    }

    public class Dog : Animal
    {

    }
}