namespace Lab7Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //calculate the average of as many numbers as you want

            string userInput;
            double sum = 0;
            double howMany = 0;
            double average;

            while (true)
            {
                Console.Write("Enter a number (Type X to quit): ");
                userInput = Console.ReadLine();

                if (userInput.ToUpper() == "X")
                    break;

                sum += int.Parse(userInput);
                howMany++;
            }

            average = sum / howMany;

            if (howMany == 0)
                Console.WriteLine("No numbers? No average.");
            else
                Console.WriteLine($"The average of {howMany} numbers is: {average}");

        }
    }
}