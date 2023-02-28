namespace Lab10Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // printing and reversing arrays

            double[] nums = { 1, 2, 3, 4, 5, 6, };

            PrintArray(nums);
            PrintFormatedArray(nums);
            PrintReversedArray(nums);
        }

        static void PrintArray(double[] array)
        {
            foreach (double item in array)
                Console.Write(item);

            Console.Write("\n");
        }

        static void PrintFormatedArray(double[] array)
        {
            // fancy array
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static double[] ReverseArray(double[] array)
        {
            double[] reversed = new double[array.Length];

            for(int i = 0; i < array.Length; i++)
                reversed[i] = array[array.Length - i - 1];

            return reversed;
        }

        static void PrintReversedArray(double[] array)
        {
            PrintArray(ReverseArray(array));
        }
    }
}