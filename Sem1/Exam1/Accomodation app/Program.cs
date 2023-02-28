namespace Accomodation_app
{
    internal class Program
    {
        const int k1 = -30; // indent

        const int SMALL_S = 235;
        const int STANDARD_S = 245;
        const int SMALL_D = 270;
        const int STANDARD_D = 295;

        static void Main(string[] args)
        {
            // a program that calculates the prices of accomodation

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string choice = "y";
            string name, roomType;
            double weeks, price;



            Console.WriteLine("Welcome to the accomodation pricing app!");

            while (choice == "y")
            {
                Console.Write($"\n{"Please enter student name",k1}: ");
                name = Console.ReadLine();

                Console.Write($"{"Please enter room type",k1}: ");
                roomType = Console.ReadLine().ToLower();

                Console.Write($"{"Please enter number of weeks",k1}: ");
                weeks = double.Parse(Console.ReadLine());



                price = CalculatePrice(roomType, weeks);

                if (price == -1)
                    Console.WriteLine("\nInvalid room type\n");
                else
                    Console.WriteLine($"\n{name}, the cost of your rental is {price:c}\n");



                choice = ""; 
                while (choice != "y" && choice != "n")
                {
                    Console.Write("Do you with to buy another (y/n) : ");
                    choice = Console.ReadLine().ToLower();
                }
            }

            Console.WriteLine($"\nGoodbye!");

        }

        static double CalculatePrice(string room, double weeks)
        {
            if (room == "small single")
                return SMALL_S * weeks;

            else if (room == "standard single")
                return STANDARD_S * weeks;

            else if (room == "small double and ensuite single")
                return SMALL_D * weeks;

            else if (room == "standard double")
                return STANDARD_D * weeks;

            else
                return -1;
        }
    }
}