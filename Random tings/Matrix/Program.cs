namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double[,] matrix1 = { { -3, 1 }, {2, 1 }, { 0, -2 } };
            double[,] matrix2 = { { 3, 2, 0 }, { 4, 0, -1 }};


            PrintMatrix(matrix1);
            Console.WriteLine("    * ");

            PrintMatrix(matrix2);
            Console.WriteLine("    = ");

            double[,] matrix3 = MultMatrices(matrix1, matrix2);

            PrintMatrix(matrix3);

        }

        public static string MultString(string streeng, int n)
        {
            string temp = "";
            for (int i = 0; i < n; i++)
                temp += streeng;
            return temp;
        } // not a matrix specific method

        public static void OldPrintMatrix(double[,] A)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            string matrixString = "";

            for (int i = 0; i < rowsA; i++)
            {
                matrixString += "[ ";
                for (int j = 0; j < colsA; j++)
                {
                    matrixString += A[i, j] + " ";
                }
                matrixString += "]" + "\n";
            }

            Console.Write(matrixString);
        }

        public static void PrintMatrix(double[,] A) // wow! // now aligned! 
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            string matrixString = "";
            int[] biggestNum = new int[colsA];

            // finding the LENGTH of the biggest num in each column
            for (int i = 0; i < colsA; i++)
            {
                biggestNum[i] = 1;

                for (int j = 0; j < rowsA; j++)
                {
                    if ((A[j, i].ToString().Length) > biggestNum[i])
                    {
                        // notice the index swap j,i instead of i,j
                        // that's because this loop starts going through columns instead of rows
                        biggestNum[i] = A[j, i].ToString().Length;
                    }
                }
            }

            // using the biggest num info to print even columns
            for (int i = 0; i < rowsA; i++)
            {
                matrixString += "[";
                for (int j = 0; j < colsA; j++)
                {
                    matrixString += MultString(" ", 1 + biggestNum[j] - A[i, j].ToString().Length);
                    matrixString += A[i, j];
                }
                matrixString += " ]" + "\n";
            }

            Console.Write(matrixString);
        }

        public static void PrintAlignedMatrix2(double[,] A) // wip
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);

            string[] row = new string[rowsA];

            for (int i = 0; i < rowsA; i++)
                row[i] += "[";

            for (int i = 0; i < rowsA; i++)
                Console.WriteLine(row[i]);
        }


        public static void ReadMatrix(double[,] A) // modify this
        {
            Console.WriteLine("Enter number of rows: ");
            int rowsA = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of columns: ");
            int colsA = int.Parse(Console.ReadLine());

            Console.WriteLine($"{nameof(A)} has dimensions: {rowsA} x {colsA}");

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    Console.Write($"Matrix entry {i + 1}, {j + 1}: ");
                    A[i, j] = double.Parse(Console.ReadLine());
                }
            }
        }

        public static double[,] AddMatrices(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            double[,] C;

            if (rowsA != rowsB || colsA != colsB)
            {
                Console.WriteLine("You can't add those matrices!");
                C = new double[0, 0];
            }
            else
            {
                C = new double[rowsA, colsA];

                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsA; j++)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                    }
                }
            }
            return C;
        }

        public static double[,] ScalarMatrixMult(double[,] A, double n)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);

            for (int i = 0; i < rowsA; i++)
                for (int j = 0; j < colsA; j++)
                    A[i, j] = A[i, j] * n;

            return A;
        }
        public static double[,] ScalarMatrixMult(double n, double[,] A)
        {
            return ScalarMatrixMult(A, n);
        } 

        public static double[,] MultMatrices(double[,] A, double[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            double[,] C;
            double tempSum;

            if (colsA != rowsB)
            {
                Console.WriteLine("You can't multiply those matrices!");
                C = new double[0, 0];
            }
            else
            {
                C = new double[rowsA, colsB];

                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsB; j++)
                    {
                        tempSum = 0;
                        for (int k = 0; k < colsA; k++)
                        {
                            tempSum += A[i, k] * B[k, j];
                        }
                        C[i, j] = tempSum;
                    }
                }
            }
            return C;
        }

        public static double[,] TransposeMatrix(double[,] A)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            double[,] C = new double[colsA, rowsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    C[j, i] = A[i, j];
                }
            }

            return C;
        }

        public static double[,] GetRow(double[,] A, int n)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            double[,] C;

            if (n < 1 || n > rowsA)
            {
                Console.WriteLine("That row doesn't exist");
                C = new double[0, 0];
            }
            else
            {
                C = new double[1, colsA];

                for (int i = 0; i < colsA; i++)
                    C[0, i] = A[n - 1, i];
            }

            return C;
        }

        public static double[,] GetColumn(double[,] A, int n)
        {
            return TransposeMatrix(GetRow(TransposeMatrix(A), n));
        }
    }
}