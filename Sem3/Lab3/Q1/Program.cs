namespace Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
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