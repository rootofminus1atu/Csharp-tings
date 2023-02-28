namespace Lab5Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // taxes

            const double TAX_RATE = 0.4;
            Console.OutputEncoding = System.Text.Encoding.UTF8; //for the euro symbol


            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine());




            Console.WriteLine($"With a tax rate of {TAX_RATE:p0}, tax is {salary*TAX_RATE:c} and take home pay is {salary*(1-TAX_RATE):c}");

        }
    }
}