using System.Security.Cryptography.X509Certificates;

namespace Lab14Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hi = (int x) => x*x ;
            Func<int, int> hi2 = x => x * x;
            Func<int, int, int> hi3 = (x, y) => x * y;
            Func<int, int, (int, int)> hi4 = (x, y) => (y, x);
            Func<int, int, int, int> hi5 = (x, y, z) => x + y + z;

            var fancy = Decorator(SayHi);
            fancy();

            Decorator(() => Say("Hello"))();

            // test
        }

        static void SayHi()
        {
            Console.WriteLine("Hi");
        }

        static void Say(string str)
        {
            Console.WriteLine($"I say {str}");
        }

        static Action Decorator(Action action)
        {
            var wrapper = () =>
            {
                Console.WriteLine("started");
                action();
                Console.WriteLine("ended");
            };

            return wrapper;
        }

        static Func<T> Paramerator<T>(Func<T> func)
        {
            return func;
        }

        
    }
}