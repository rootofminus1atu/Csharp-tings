namespace Lab10Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this is pretty ugly, needs more work
            string myStr;
            int i;
            double k;

            string message = "AAA";
            int length = 100;
            int amplitude = 100;

            i = 1;
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                k = Convert.ToInt32(amplitude * Math.Pow(Math.Sin((Math.PI / length) * i), 2));

                myStr = StringMult(" ", Convert.ToInt32(k)) + message;

                Console.WriteLine(myStr);
                i++;

                Thread.Sleep(10);

                // what on earth is this code

                Console.ForegroundColor = ConsoleColor.Red;

                k = Convert.ToInt32(amplitude * Math.Pow(Math.Sin((Math.PI / length) * i), 2));

                myStr = StringMult(" ", Convert.ToInt32(k)) + message;

                Console.WriteLine(myStr);
                i++;

                Thread.Sleep(10);
            }

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