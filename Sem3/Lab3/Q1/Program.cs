namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // A website only allows users in the age bracket 18 to 21 inclusive to access its content.
            // Write a method that accepts the age as an int argument and decides whether it is possible to access the site.
            // Your method shall return a boolean value.

            int[] ages = { 0, 1, 17, 18, 19, 20, 21, 22, 23, 100 };

            foreach (int age in ages)
            {
                Console.WriteLine($"Age {age} can access? {CanAccess(age)}");
            }
        }

        static bool CanAccess(int age)
        {
            return age >= 18 && age <= 21;
        }
    }
}