namespace Lab11Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // bar chart visualization thing

            int numOfSales = 3;
            double conv = 100;

            double[] sales = new double[numOfSales];


            for (int i = 0; i < numOfSales; i++)
            {
                Console.Write($"Enter sales for store {i+1}: ");
                sales[i] = (double.Parse(Console.ReadLine()) / conv);
            }


            double max = ArrayMax(sales);
            Console.WriteLine(max);


            Console.WriteLine("\n\nSales Bar Chart\n");

            for (int i = 0; i < numOfSales; i++)
            {
                Console.WriteLine($"Store{i+1} [{MultString("#", (int)sales[i])}{MultString("_", (int)(max - sales[i]))}]");
            }

        }

        public static string MultString(string text, int n)
        {
            string temp = "";

            for (int i = 0; i < n; i++)
                temp += text;

            return temp;
        }

        public static double ArrayMax(double[] arr)
        {
            double max = arr[0];

            foreach (double num in arr)
                if (num > max)
                    max = num;

            return max;
        }

    }
}