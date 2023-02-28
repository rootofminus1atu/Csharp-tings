namespace Lab10Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // manu app, calculate areas and volumes

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Area of rectangle");
            Console.WriteLine("2. Area of circle");
            Console.WriteLine("3. Volume of cylinder");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice:");

            int menuChoice = int.Parse(Console.ReadLine());


            while (menuChoice != 4)
            {
                if (menuChoice == 1)
                {
                    Console.Write("\nEnter height: ");
                    int height = int.Parse(Console.ReadLine());
                    Console.Write("Enter width: ");
                    int width = int.Parse(Console.ReadLine());

                    Console.WriteLine($"This rectangle has area = {RectArea(width, height)}");
                }

                else if (menuChoice == 2)
                {
                    Console.Write("\nEnter radius: ");
                    int radius = int.Parse(Console.ReadLine());

                    Console.WriteLine($"This circle has area = {CircleArea(radius)}");
                }

                else if (menuChoice == 3)
                {
                    Console.Write("\nEnter radius: ");
                    int radius = int.Parse(Console.ReadLine());
                    Console.Write("Enter height: ");
                    int height = int.Parse(Console.ReadLine());

                    Console.WriteLine($"This rectangle has area = {CylinderVolume(radius, height)}");
                }

                else
                    Console.WriteLine("\nInvalid Choice");


                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Area of rectangle");
                Console.WriteLine("2. Area of circle");
                Console.WriteLine("3. Volume of cylinder");
                Console.WriteLine("4. Exit");
                
                menuChoice = int.Parse(Console.ReadLine());
            }

        }

        public static double RectArea(double n, double m)
        {
            return n*m;
        }

        public static double CircleArea(double r)
        {
            return Math.PI * Math.Pow(r,2);
        }

        public static double CylinderVolume(double r, double h)
        {
            return Math.PI * Math.Pow(r, 2) * h;
        }
    }
}