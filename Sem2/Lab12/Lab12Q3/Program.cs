using System;

namespace Lab12Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // pointers are cool but this garbage collector
            

            Pointer x;  // allocate the pointers x and y
            Pointer y;  // (but not the Pointer values)

            x = new Pointer();   // allocate a Pointer value

            x.value = 42;        // dereference x to store 42


            y = x;  // now they point to the same value so they're... the same thing

            y.value = 13;   // deference y to store 13 in its (shared) pointee

            Console.WriteLine($"*x = {x.value} *y = {y.value}");

            x.value = 12;

            Console.WriteLine($"*x = {x.value} *y = {y.value}");




            int a = 1;
            int b = 2;

            Console.WriteLine($"a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");
        }

        public static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }

    public class Pointer
    {
        public int value;
    }
}