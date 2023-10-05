namespace Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a method named Zero that accepts an int array as an argument and stores the value 0 in each element.

            int[][] arrs =
            {
                new int[] {1, 2},
                new int[] {999, 888, 777},
                new int[] {}
            };

            foreach (int[] arr in arrs)
            {
                Console.WriteLine($"{arr.Stringify()} zero'd into {Zero(arr).Stringify()}");
            }

        }

        static int[] Zero(int[] arr)
        {
            return arr.Select(i => 0).ToArray();
        }
    }

    
    public static class ArrayExtension
    {
        // helper extension method for array display
        // ToString() doesn't work
        public static string Stringify<T>(this T[] arr)
        {
            return $"[{string.Join(", ", arr)}]";
        }
    }
}