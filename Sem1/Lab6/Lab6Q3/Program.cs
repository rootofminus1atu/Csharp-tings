namespace Lab6Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cinema

            Console.WriteLine("Welcome to our Slio Multiplex");

            Console.WriteLine($"\nmovies\n");

            Console.Write("Enter the number of the film you wish to see: ");
            int whichFilm = int.Parse(Console.ReadLine());

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());


            //1 15 age
            //2 18 age

            int numbr = 0;

            switch (whichFilm)
            {
                case 1:
                    numbr = 15;
                    break;
                case 2:
                    numbr = 18;
                    break;
                case 3:
                    numbr = -1000000;
                    break;
                case 4:
                    numbr = 12;
                    break;
                case 5:
                    numbr = 12;
                    break;
                default:
                    numbr = -10000000;
                    break;
            }

            if (age < numbr)
            {
                Console.WriteLine("Access denied - you are too young");
            }
            else if (numbr == -10000000)
            {
                Console.WriteLine("Invalid film number");
            }
            else
            {
                Console.WriteLine("Enjoy the film!");
            }






            /*
            switch (whichFilm)
            {
                case 1:
                    Console.WriteLine(CheckAge(age));
                    break;
                case 2:
                    Console.WriteLine(CheckAge(age));
                    break;
                case 3:
                    Console.WriteLine(CheckAge(10000));
                    break;
                case 4:
                    Console.WriteLine(CheckAge(12));
                    break;
                case 5:
                    Console.WriteLine(CheckAge(12));
                    break;
                default:
                    Console.WriteLine("Invalid film number");
                    break;
            }
            */
        }

        static private string CheckAge(int age, int whichFilm)
        {
            string msg;
            int what=10;

            if (age < what)
            {
                msg = "Access denied - you are too young";
            }
            else
            {
                msg = "Enjoy the film!";
            }

            return msg;
        }
            
    }
}