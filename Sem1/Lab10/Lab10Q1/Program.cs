namespace Lab10Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many chicken nuggets? ");
            int nuggies = int.Parse(Console.ReadLine());

            CheckOrder(nuggies);
        }

        static public bool CheckOrder(int orderQuantity)
        {
            int k = orderQuantity;

            if (k == 6 || k == 9 || k == 20)
            {
                Console.WriteLine("You can order that!");
                return true;
            }

            else
            {
                Console.WriteLine("Invalid order...");
                return false;
            }
        }
    }
}