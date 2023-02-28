namespace Leet_Cooode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 38183;

            Console.WriteLine(IsPalindrome(num));
        }

        public static bool IsPalindrome(int x)
        {
            string xStr = x.ToString();
            int length = xStr.Length;

            for (int i = 0; i < length/2; i++)
            {
                if (xStr[i] != xStr[length - i - 1])
                    return false;
            }
            return true;
        }
    }
}