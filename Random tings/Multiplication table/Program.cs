using System.Data;

namespace Multiplication_table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //multiplication table generator

            Console.Write("How big do you want the table to be? ");
            int howBig = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nHere's your {howBig}x{howBig} multiplication table:\n");

            Console.WriteLine(MultGenerate(howBig));
        }

        public static string StringMult(string streeng, int n)
        {
            string temp = "";

            for (int i = 0; i < n; i++)
                temp += streeng;

            return temp;
        }

        public static void MultGenerateOldVer(int howBig)
        {
            int i, j, k;
            int numLength;
            int theBiggest = (howBig * howBig).ToString().Length;

            i = 1;
            while (i <= howBig)
            {
                string row = "";

                j = 1;
                while (j <= howBig)
                {
                    row += $"{i * j} ";

                    numLength = (i * j).ToString().Length; //how many digits i*j has

                    //the loop below makes the spacing between numbers even
                    //by adding bonus spaces " ", depending on how long a number is
                    k = 1;
                    while (k <= theBiggest - numLength)
                    {
                        row += " ";
                        k++;
                    }

                    j++;
                }
                
                Console.WriteLine(row);
                i++;
            }
        }

        public static string MultGenerate(int howBig)
        {
            string table = "";
            string row;

            int numLength;
            int theBiggest = (howBig * howBig).ToString().Length; //length of biggest number, for example 1600 ~ 4

            for (int i = 1; i <= howBig; i++)
            {
                row = "";

                for (int j = 1; j <= howBig; j++)
                {
                    row += i * j;
                    numLength = (i * j).ToString().Length;

                    row += StringMult(" ", theBiggest - numLength + 1); //1 more extra space
                }

                table += row + "\n";
            }

            return table;
        }
    }
}