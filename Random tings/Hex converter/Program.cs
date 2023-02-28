namespace Hex_converter
{
    internal class Program
    {
        static Dictionary<char, int> hexToTen = new Dictionary<char, int>
        {
            ['0'] = 0,
            ['1'] = 1,
            ['2'] = 2,
            ['3'] = 3,
            ['4'] = 4,
            ['5'] = 5,
            ['6'] = 6,
            ['7'] = 7,
            ['8'] = 8,
            ['9'] = 9,
            ['A'] = 10,
            ['B'] = 11,
            ['C'] = 12,
            ['D'] = 13,
            ['E'] = 14,
            ['F'] = 15,
        };

        static Dictionary<int, char> tenToHex = new Dictionary<int, char>
        {
            [0] = '0',
            [1] = '1',
            [2] = '2',
            [3] = '3',
            [4] = '4',
            [5] = '5',
            [6] = '6',
            [7] = '7',
            [8] = '8',
            [9] = '9',
            [10] = 'A',
            [11] = 'B',
            [12] = 'C',
            [13] = 'D',
            [14] = 'E',
            [15] = 'F',
        };

        static void Main(string[] args)
        {
            // hex -> base 10
            // base 10 -> hex
            // converter

            string hexNum = "abc";
            int decNum = 2748;

            Console.WriteLine(HexToBase10(hexNum));
            Console.WriteLine(Base10ToHex(decNum));
        }

        public static int HexToBase10(string num)
        {
            char[] numChars = num.ToUpper().ToCharArray();
            int total = 0;
            int length = numChars.Length;

            for (int i = 0; i < length; i++)
            {
                total += hexToTen[numChars[i]] * Convert.ToInt32(Math.Pow(16, length - 1 - i));
                // basically   B * 16^some power,   and you add them up
            }

            return total;
        }

        public static string Base10ToHex(int num)
        {
            int biggestExp = FindBiggestExp(num);
            int quotient = 0;
            int remainder = num;
            string total = ""; 

            for (int i = 0; i < biggestExp + 1 ; i++)
            {
                // example: 3511 / 16^2 = 13 with remainder 183
                //                      quotient          remainder
                quotient = remainder / Convert.ToInt32(Math.Pow(16, biggestExp - i));
                remainder = remainder % Convert.ToInt32(Math.Pow(16, biggestExp - i));

                total += tenToHex[quotient];
            }

            return total;
        }


        public static int FindBiggestExp(int num)
        {
            int maxPow = 0;

            for (int i = 0; i < 60; i++)
            {
                if (Math.Pow(16,i) > num)
                    break;

                maxPow = i;
            }

            return maxPow;
        }
    }
}