namespace Lab6Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ATM thing

            Console.Write("Enter bank balance: ");
            int balance = int.Parse(Console.ReadLine());

            Console.Write("Enter withdrawal amount: ");
            int howMuch = int.Parse(Console.ReadLine());


            if (howMuch > balance) 
                Console.WriteLine("Insufficient funds");

            else
            {
                Console.WriteLine("Enter PIN:");
                string pin = Console.ReadLine();

                if (pin == "1234")
                    Console.WriteLine($"Your balance after the withdrawal: {balance - howMuch}");

                else
                    Console.WriteLine("Wrong PIN");
            }
        }
    }
}