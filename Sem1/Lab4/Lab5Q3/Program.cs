namespace Lab5Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // change calculator

            Console.Write("How much does the customaer have to pay? ");
            double amountDue = double.Parse(Console.ReadLine());
            
            Console.Write("How much did they pay? ");
            double amountPaid = double.Parse(Console.ReadLine());



            double change = amountPaid - amountDue;              //1.98
            int changeInt = Convert.ToInt32(100*(change));       //198 (for example)


            int euroCh, fiftyCh, twentyCh, fiveCh, twoCh, left;

            euroCh = changeInt / 100;
            left = changeInt%100;         //what's left after taking away the 1 euro coins

            fiftyCh = left / 50;
            left = left%50;               //what's left after taking away the 50 cent coins

            twentyCh = left / 20;
            left = left%20;               //and so on

            fiveCh = left / 5;
            left = left%5;

            twoCh = left / 2;
            left = left%2;

            

            Console.WriteLine($"\nYou have to give them back:");
            Console.WriteLine($"{euroCh} Euro, {fiftyCh} Fifty, {twentyCh} Twenty, {fiveCh} Five, {twoCh} Two, {left} Cent ");

            //would probably look better with loops and cases
        }
    }
}