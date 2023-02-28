namespace Lab11Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "hello there";
            PrintString(input);
            Console.WriteLine("====================================");
            PrintNthLetter(input, 3);
            Console.WriteLine("====================================");

            string gibberish = "XoiYyoIxhOixSa";
            Console.WriteLine(HowManyXY(gibberish));

            Console.WriteLine(TripleGroup(gibberish));   // a bit worse
            Console.WriteLine(TripleGroup2(gibberish));  // a bit better
            Console.WriteLine(NGroup(gibberish, 3));

            string numbr = "12987987214";
            Console.WriteLine(InsertDash(numbr));

            string messy = "avd$$kh% g,  %g";
            char[] bannedChars = { '$', '%', ',', ' ' };
            Console.WriteLine(RemoveMess(messy, bannedChars));


            string message = "my secretss";
            message = Encrypt(message);
            Console.WriteLine(message);
            message = Encrypt(message);
            Console.WriteLine(message);
            message = Encrypt(message);
            Console.WriteLine(message);
            message = Encrypt(message);
            Console.WriteLine(message);
            message = Encrypt(message);
            Console.WriteLine(message);

            for (int i = 0; i < message.Length / 2; i++)
            {
                Console.WriteLine(message.Substring(2*i, 2));
            }
        }
        

        static void PrintString(string input)
        {
            foreach(char c in input)
                Console.WriteLine(c);
        }

        static void PrintNthLetter(string input, int n)
        {
            for (int i = 0; i < input.Length; i += n)
                Console.WriteLine(input[i]);
        }

        static int HowManyXY(string input)
        {
            int count = 0;

            foreach (char c in input)
                if (c == 'x' || c == 'y')
                    count++;

            return count;
        }

        static string TripleGroup(string input)
        {
            string str = "";

            for (int i = 0; i < input.Length/3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i % 2 == 0)
                        str += input[3*i + j];
                }     
            }
                
            return str;
        }

        static string TripleGroup2(string input)
        {
            string str = "";
            bool state = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 3 == 0)
                    state = !state;

                if (state == true)
                    str += input[i];
            }

            return str;
        }

        static string NGroup(string input, int n)
        {
            string str = "";
            bool state = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (i % n == 0)
                    state = !state;

                if (state == true)
                    str += input[i];
            }

            return str;
        }

        static string InsertDash(string input)
        {
            // str.Insert sucks
            string str = "";

            for (int i = 0; i < input.Length; i++)
            {
                if ((i % 3 == 0) && i != 0)
                    str += "-";

                str += input[i];
            }

            return str;
        }

        static string RemoveMess(string input, char[] bannedChars)
        {
            string str = "";

            foreach (char c in input)
            {
                if (!bannedChars.Contains(c))
                    str += c;
            }

            return str;
        }


        // encryption and decryption
        public static string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();

            Array.Reverse(charArray);

            return new string(charArray);
        }

        // encryption mod 2
        static string Encrypt(string input)
        {
            string str = "";
            char temp;
            
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    temp = input[i];
                    str += input[i + 1];
                    str += temp;
                }
            }

            if (input.Length % 2 == 1)
                str += input[input.Length - 1];

            return str;
        }

        /*
        static string Encrypt2(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                Console.WriteLine(input.Substring(i, 2));
            }

            return str;
        }   
        */
    }
}