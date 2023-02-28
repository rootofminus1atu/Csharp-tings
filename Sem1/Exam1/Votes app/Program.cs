namespace Votes_app
{
    internal class Program
    {
        const int k1 = -32; // all the indents
        const int k2 = -6;
        const int k3 = -16;
        const int k4 = -36;

        static void Main(string[] args)
        {
            // a program to input and display the statistics of student election results



            Console.Write("Enter number of students : ");
            int num = int.Parse(Console.ReadLine());

            if (num > 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] maximum number of 10 students exceeded");  // fancy colors
                Console.ForegroundColor = ConsoleColor.Gray;
                Environment.Exit(0);
            }

            string[] names = new string[num];
            double[] votes = new double[num];



            // input precise info

            for (int i = 0; i < num; i++)
            {
                Console.Write($"\n{"Enter name of student",k1}{i + 1,k2}: ");
                names[i] = Console.ReadLine();

                Console.Write($"{"Enter votes for student",k1}{i + 1,k2}: ");
                votes[i] = int.Parse(Console.ReadLine());
            }



            // all the display info

            string star;
            int maxIndex = FindMaxIndex(votes);

            Console.WriteLine($"\n\n{"Student",k3} Votes");
            for (int i = 0; i < num; i++)
            {
                if (i == maxIndex)
                    star = "*";
                else
                    star = "";

                Console.WriteLine($"{names[i],k3} {votes[i]} {star}");
            }

            Console.WriteLine($"\n{"Total votes",k4} {ArraySum(votes)}");
            Console.WriteLine($"{"Average",k4} {Math.Round(ArrayAverage(votes))}");
            Console.WriteLine($"{"Highest number of votes",k4} {votes[maxIndex]}");
            Console.WriteLine($"{"Student with highest votes",k4} {names[maxIndex]}");

        }

        static int FindMaxIndex(double[] arr)
        {
            double max = arr[0];
            int maxIndex = 0;

            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }

            return maxIndex;
        }

        static double ArraySum(double[] arr)
        {
            double sum = 0;

            foreach (double num in arr)
                sum += num;

            return sum;
        }

        static double ArrayAverage(double[] arr)
        {
            return ArraySum(arr) / arr.Length;
        }

    }
}