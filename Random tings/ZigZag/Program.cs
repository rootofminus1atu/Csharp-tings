namespace ZigZag
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string myString = "BURGERKINGFOOTLETTUCE";

            int lines = 4;

            string row1 = "";
            string row2 = "";
            string row3 = "";
            string row4 = "";

            string[] row = new string[lines];


            //it kinda works but not really
            for (int i = 0; i < myString.Length; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    if (i % (2 * lines - 2) == j)
                    {
                        row[j] += myString[i];
                    }

                }
            }

            PrintArray(row);
            Console.WriteLine("\n\n");

            for (int i = 0; i < myString.Length; i++)
            {

                if (i % 6 == 0)
                {
                    row1 += myString[i] + "     ";
                }

                else if (i % 6 == 1)
                {
                    row2 += myString[i] + "   ";
                }

                else if (i % 6 == 2)
                {
                    row3 += myString[i] + " ";
                }

                else if (i % 6 == 3)
                {
                    row4 += myString[i] + "     ";
                }

                else if (i % 6 == 4)
                {
                    row3 += myString[i] + "   ";
                }

                else if (i % 6 == 5)
                {
                    row2 += myString[i] + " ";
                }


            }

            Console.WriteLine(row1);
            Console.WriteLine(row2);
            Console.WriteLine(row3);
            Console.WriteLine(row4);

        }

        public static void PrintArray(string[] row)
        {
            foreach (string str in row)
            {
                Console.WriteLine(str);
            }
        }
    }
}