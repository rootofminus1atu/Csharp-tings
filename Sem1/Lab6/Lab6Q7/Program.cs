namespace Lab6Q7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //guess 3 numbers and win some money
            Random random = new Random();

            int count = 0;
            int num1 = random.Next(10);
            int num2 = random.Next(10);
            int num3 = random.Next(10);

            Console.Write("Enter the 1st number: ");
            int guess1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the 2nd number: ");
            int guess2 = int.Parse(Console.ReadLine());

            Console.Write("Enter the 3rd number: ");
            int guess3 = int.Parse(Console.ReadLine());


            //so that repeated guesses wouldn't count
            if (guess1 == guess2)
                guess1 = -1;

            if (guess2 == guess3)
                guess2 = -1;

            if (guess3 == guess1)
                guess3 = -1;


            if (num1 == guess1 || num2 == guess1 || num3 == guess1)
                count++; guess1 = -1;

            if (num1 == guess2 || num2 == guess2 || num3 == guess2)
                count++; guess2 = -1;

            if (num1 == guess3 || num2 == guess3 || num3 == guess3)
                count++; guess3 = -1;


            double moneyWon = Math.Pow(10,count);
            

            if (count == 0)
                Console.WriteLine("You won nothing :(");
            else
                Console.WriteLine($"You won {moneyWon:c}");

            Console.WriteLine($"\nThe numbers were: {num1}, {num2}, {num3}");
        }
    }
}