﻿namespace Statistics
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double[] values = { 250, 750, 1250, 1750, 2250, 2750, 3250 };
            double[] frequencies = { 22, 27, 41, 44, 37, 18, 11 };

            double[,] pair = StackArrays(values, frequencies);



            string[] valFreqs = StringAlignedArrays(values, frequencies);
            Console.WriteLine(StringMult("=", 55));
            Console.WriteLine($"| Values      {valFreqs[0]}");
            Console.WriteLine($"| Frequencies {valFreqs[1]} ");
            Console.WriteLine(StringMult("=", 55));

            Console.WriteLine($"The mean: {Mean(values, frequencies):.###}");
            Console.WriteLine($"The standard deviation: {StandardDeviation(values, frequencies):.###}");
        }

        //methods to calculate stuff

        public static double Mean(double[] xs, double[] fs)
        {
            double sumTop = 0;
            double sumBot = 0;

            for (int i = 0; i < xs.Length; i++)
                sumTop += xs[i] * fs[i];

            for (int i = 0; i < fs.Length; i++)
                sumBot += fs[i];

            return sumTop / sumBot;
        }

        public static double Variance(double[] xs, double[] fs)
        {
            double sumTop = 0;
            double sumBot = 0;

            for (int i = 0; i < xs.Length; i++)
                sumTop += Math.Pow(xs[i], 2) * fs[i];

            for (int i = 0; i < fs.Length; i++)
                sumBot += fs[i];

            return sumTop / sumBot - Math.Pow(Mean(xs, fs), 2);
        }

        public static double StandardDeviation(double[] xs, double[] fs)
        {
            return Math.Sqrt(Variance(xs, fs));
        }



        //methods to display stuff

        public static void PrintArray(double[] array)
        {
            Console.WriteLine($"[{string.Join(", ", array)}]");
        }

        public static void PrintArray2(double[] array) //same thing as above, different implementation
        {
            string table = "[";

            for (int i = 0; i < array.Length; i++)
            {
                table += array[i];
                if (i < array.Length - 1)
                    table += ", ";
            }

            table += "]";

            Console.WriteLine(table);
        }

        public static void PrintMatrix(double[,] matrix)
        {
            string table = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                table += "\n[ ";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    table += matrix[i, j] + " ";
                }
                table += "]";
            }

            Console.WriteLine(table);
        }

        public static T[][] UnionJagged<T>(T[] first, T[] second)
        {
            //2 arrays -> jagged matrix
            //also wip
            return new T[2][] { first, second };
        }

        public static double[,] StackArrays(double[] xs, double[] fs) //turn 2 arrays into a matrix
        {
            double[,] matrix = new double[2, xs.Length];

            for (int i = 0; i < xs.Length; i++)
            {
                matrix[0, i] = xs[i];
                matrix[1, i] = fs[i];
            }

            return matrix;
        }

        public static void PrintAlignedArrays(double[] xs, double[] fs) //print 2 arrays, but now their values are aligned
        {
            int numLength1, numLength2;
            string table1 = "[", table2 = "[";

            for (int i = 0; i < xs.Length; i++)
            {
                numLength1 = xs[i].ToString().Length;
                numLength2 = fs[i].ToString().Length;

                if (numLength1 < numLength2)
                    table1 += StringMult(" ", numLength2 - numLength1);

                if (numLength1 > numLength2)
                    table2 += StringMult(" ", numLength1 - numLength2);

                table1 += xs[i];
                table2 += fs[i];

                if (i < xs.Length - 1)
                {
                    table1 += ", ";
                    table2 += ", ";
                }
            }

            table1 += "]";
            table2 += "]";

            Console.WriteLine(table1);
            Console.WriteLine(table2);
        }
        public static void PrintAlignedArrays(double[] xs, double[] fs, string separator) //same as above, overload
        {
            int numLength1, numLength2;
            string table1 = "[", table2 = "[";

            for (int i = 0; i < xs.Length; i++)
            {
                numLength1 = xs[i].ToString().Length;
                numLength2 = fs[i].ToString().Length;

                if (numLength1 < numLength2)
                    table1 += StringMult(" ", numLength2 - numLength1);

                if (numLength1 > numLength2)
                    table2 += StringMult(" ", numLength1 - numLength2);

                table1 += xs[i];
                table2 += fs[i];

                if (i < xs.Length - 1)
                {
                    table1 += separator;
                    table2 += separator;
                }
            }

            table1 += "]";
            table2 += "]";

            Console.WriteLine(table1);
            Console.WriteLine(table2);
        }

        public static string[] StringAlignedArrays(double[] xs, double[] fs) //turn those 2 arrays into aligned arrays which are now strings
        {
            //reminder to add a separator parameter, for more customization
            //and to get the name of values/frequencies somehow

            int numLength1, numLength2;
            string table1 = "| ", table2 = "| ";
            string[] both = new string[2];

            for (int i = 0; i < xs.Length; i++)
            {
                numLength1 = xs[i].ToString().Length;
                numLength2 = fs[i].ToString().Length;

                if (numLength1 < numLength2)
                    table1 += StringMult(" ", numLength2 - numLength1);

                if (numLength1 > numLength2)
                    table2 += StringMult(" ", numLength1 - numLength2);

                table1 += xs[i];
                table2 += fs[i];

                if (i < xs.Length - 1)
                {
                    table1 += "| ";
                    table2 += "| ";
                }
            }

            table1 += "| ";
            table2 += "| ";

            both[0] = table1;
            both[1] = table2;

            return both;
        }

        public static string StringMult(string separator, int n)
        {
            string streeng = "";
            for (int i = 0; i < n; i++)
                streeng += separator;

            return streeng;
        }

    }
}