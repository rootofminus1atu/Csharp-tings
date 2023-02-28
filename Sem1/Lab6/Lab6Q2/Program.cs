namespace Lab6Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //how many hours, minutes, seconds, in seconds

            Console.Write("How many seconds in total? ");
            int total = int.Parse(Console.ReadLine());

            int hours, minutes, seconds, left;


            left = total; 

            hours = left / 3600;
            left = total % 3600;

            minutes = left / 60;
            left = total % 60;

            seconds = total;


            Console.WriteLine($"{total:n0} seconds is {hours} hours, {minutes} minutes and {left} seconds");

        }
    }
}