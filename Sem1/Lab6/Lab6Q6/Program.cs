namespace Lab6Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //how much you pay for calling people from different areas

            const double localRate = 0.01;
            const double nationalRate = 0.13;
            double cost;


            Console.Write("Enter your area code: ");
            int areaCode = int.Parse(Console.ReadLine());

            Console.Write("Enter the called area code: ");
            int calledArea = int.Parse(Console.ReadLine());

            Console.Write("Enter duration: ");
            int duration = int.Parse(Console.ReadLine());
            

            if (areaCode == calledArea && duration < 21)
                cost = duration * localRate;

            else
                cost = duration * nationalRate;


            Console.WriteLine($"\n" +
                //$"Your area code: {areaCode} \n" +
                //$"Called area: {calledArea} \n" +
                //$"Duration: {duration} \n" +
                $"Cost of your call: {Math.Round(cost, 2)}");
        }
    }
}