namespace Roman_numerals
{
    internal class Program
    {
        static Dictionary<char, int> romToTen = new Dictionary<char, int>
        {
            ['O'] = 0, // dummy char
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000,
        };

        static Dictionary<int, string> tenToRom = new Dictionary<int, string>
        {
            [1] = "I",
            [5] = "V",
            [10] = "X",
            [50] = "L",
            [100] = "C",
            [500] = "D",
            [1000] = "M",

            [4] = "IV",
            [9] = "IX",
            [40] = "XL",
            [90] = "XC",
            [400] = "CD",
            [900] = "CM",
            // idk how to make it work without those 4 and 9 special keys :( yet
        };

        static void Main(string[] args)
        {
            string num1 = "CDXLVII";

            Console.WriteLine($"{num1} is {RomanToBase10(num1)}");
            

            int num2 = 2948;

            Console.WriteLine($"{num2} is {Base10ToRoman(num2)}");
        }

        public static string Base10ToRoman(int num)
        {
            int biggest;
            int quotient;
            int remainder = num;

            int[] dictKeys = tenToRom.Keys.ToArray();
            string total = "";

            if (num < 1 || num > 3999)
                return "No";

            while (remainder > 0)
            {
                biggest = MaxSmallerThan(dictKeys, remainder);

                // example: 34 / 10 = 3 with remainder 4
                //                 quotient         remainder
                quotient = remainder / biggest;
                remainder = remainder % biggest;

                // we add 3 (quotient many) X's to the string
                total += StringMult(tenToRom[biggest], quotient);
            }

            return total;
        }

        public static int RomanToBase10(string num)
        {
            string numBetter = num + "O"; // "XIV" -> "XIVO", bonus dummy char
            char[] numChars = numBetter.ToUpper().ToCharArray();
            int total = 0;

            for (int i = 0; i < num.Length; i++)
            {
                if (romToTen[numChars[i]] >= romToTen[numChars[i + 1]])
                    total += romToTen[numChars[i]];

                else
                    total -= romToTen[numChars[i]];
            }

            return total;
        }

        public static int MaxSmallerThan(int[] list, int n)
        {
            // the biggest number in an array, smaller than some int n
            int biggest = -999;

            foreach (int item in list)
            {
                if (item <= n)
                    if (item > biggest)
                        biggest = item;
            }

            return biggest;
        }

        public static string StringMult(string streeng, int n)
        {
            // string * int multiplication
            string temp = "";

            for (int i = 0; i < n; i++)
                temp += streeng;

            return temp;
        }

    }
}