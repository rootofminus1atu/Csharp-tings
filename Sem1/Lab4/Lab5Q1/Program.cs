namespace Lab5Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // displaying numbers in different ways

            double money = 1547.2;
            double percenter = 0.23;
            int numbr = 15000;
            double numbr2 = 432.8175;
            double numbr3 = 300000;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine($"You have {money:c}");
            Console.WriteLine($"{percenter:p0}");
            Console.WriteLine($"The 1st number is {numbr:###,###,###,###}");
            Console.WriteLine($"The 2nd number is {numbr2:###,###,###.000}");
            Console.WriteLine($"The 3rd number is {numbr3:E2}");
        }
    }
}