namespace Lab10Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // do stuff to arrays

            double[] nums1 = { 1, 2, 3, 4, 5, 6 };
            double[] nums2 = { 1, 2, 3, 4, 5, 6 };

            PrintFormatedArray(nums1);
            PrintFormatedArray(nums2);
            PrintFormatedArray(Mult2Arrays(nums1, nums2));
            Console.WriteLine(DotProduct(nums1, nums2));
        }

        static double[] Mult2Arrays(double[] arr1, double[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                Console.WriteLine("You can't multiply 2 arrays of different sizes!");
                return new double[0];
            }

            int length = arr1.Length;


            double[] added = new double[length];

            for (int i = 0; i < length; i++)
                added[i] = arr1[i] * arr2[i];

            return added;
        }

        static void PrintFormatedArray(double[] array)
        {
            // fancy array
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        static double DotProduct(double[] arr1, double[] arr2)
        {
            return ArraySum(Mult2Arrays(arr1, arr2));
        }

        static double ArraySum(double[] arr)
        {
            double total = 0;

            for (int i = 0; i < arr.Length; i++)
                total += arr[i];

            return total;
        }
    }
}