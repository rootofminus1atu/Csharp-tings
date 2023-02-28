namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // FizzBuzz, if 3|num type Fizz, if 5|num type Buzz
            int num = 16;

            PrintList(FizzBuzz(num));
        }
        public static IList<string> FizzBuzz(int n)
        {
            List<string> list = new List<string>() { };
            string temp;

            for(int i = 1; i <= n; i++)
            {
                temp = $"{i}";

                if (i % 3 == 0)
                    temp = "Fizz";

                if (i % 5 == 0)
                    temp = "Buzz";

                if (i % 3 == 0 && i % 5 == 0)
                    temp = "Fizz" + "Buzz";

                list.Add(temp);
            }

            return list;
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach(T item in list)
                Console.Write(item + " ");
        }

        public static void PrintList<T>(IList<T> list)
        {
            foreach (T item in list)
                Console.Write(item + " ");
        }
    }
}