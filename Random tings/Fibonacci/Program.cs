namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //fibonacci sequence generator 

            Console.Write("How long do you want the Fibonacci sequence to be? ");
            int size = int.Parse(Console.ReadLine());


            List<long> fibo = new List<long>() { 1, 1 };


            for (int i = 2; i < size; i++)
                fibo.Add(fibo[i - 2] + fibo[i - 1]);

            foreach (long i in fibo)
                Console.Write($"{i} ");

        }
    }
}