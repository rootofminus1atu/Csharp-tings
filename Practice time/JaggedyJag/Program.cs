namespace JaggedyJag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // convolutions kinda (bluring)

            int[][] jaggedStupid =
            {
            new int[] {1, 2, 3},
            new int[] {1, 3, 1},
            new int[] {0, 2, 2}
            };

            int[][] jagged2 =
            {
            new int[] {1, 2},
            new int[] {1, 3},
            };

            PrintJagged(jaggedStupid);

            PrintJagged(MatrixBlockSum(jaggedStupid, 1));
        }

        public static void PrintJagged(int[][] mat)
        {
            int rows = mat.Length;
            string temp = "";

            for (int i = 0; i < rows; i++)
            {
                int cols = mat[i].Length;
                temp += "[ ";

                for (int j = 0; j < cols; j++)
                    temp += mat[i][j] + " ";

                temp += "]\n";
            }

            Console.WriteLine(temp);
        }

        public static int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int rows = mat.Length;
            int[][] newMat = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int cols = mat[i].Length;
                newMat[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    int sum = 0;

                    for (int r = i - k; r <= i + k && r < rows; r++)
                    {
                        for (int c = j - k; c <= j + k && c < cols; c++)
                        {
                            if (r < 0 || c < 0) // idk why but I can't put this condition in the for loops
                                sum += 0;
                            else
                                sum += mat[r][c];
                        }
                    }

                    newMat[i][j] = sum;
                }
            }

            return newMat;
        }
    }
}