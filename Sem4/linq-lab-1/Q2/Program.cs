﻿namespace Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };

            var outputNumbers = numbers
                .Where(n => n > 5)
                .OrderByDescending(n => n);

            foreach (var number in outputNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}