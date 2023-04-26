using System.Security.Cryptography.X509Certificates;

namespace Lab14Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // actions, functions and DECORATORS
            // here they actually work
            // note: they work best with actions
            // it's possible to make them work with general functions too
            // although that's more challenging

            var hi = (int x) => x*x ;
            Func<int, int> hi2 = x => x * x;
            Func<int, int, int> hi3 = (x, y) => x * y;
            Func<int, int, (int, int)> hi4 = (x, y) => (y, x);
            Func<int, int, int, int> hi5 = (x, y, z) => x + y + z;

            var fancy = Decorator(SayHi);
            fancy();

            Decorator(() => Say("Hello"))();

            // paramerator with 1 return value

            Func<int> test = () => 5;
            test = Paramerator1(test);

            var x = test();
            Console.WriteLine(x);

            // paramerator with 1 input and 1 return value

            Func<int, int> invert = x => -x;
            invert = Paramerator2(invert);

            var y = invert(6);


            // WHY ???
            // Double = Paramerator2(Double);
            // why not work
            Func<int, int> doubleDecorated = Paramerator2(Double);
            Console.WriteLine(doubleDecorated(7));

        }

        static void SayHi()
        {
            Console.WriteLine("Hi");
        }



        static void Say(string str)
        {
            Console.WriteLine($"I say {str}");
        }

        static int Double(int num)
        {
            return 2 * num;
        }

        static int DecoratedDouble(int num)
        {
            return Paramerator2(Double)(num);
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

        static Func<T> Paramerator1<T>(Func<T> func)
        {
            Func<T> wrapper = () =>
            {
                Console.WriteLine("started");
                var result = func();
                Console.WriteLine(result);
                Console.WriteLine("ended");
                return result;
            };

            return wrapper;
        }


        static Func<T, TResult> Paramerator2<T, TResult>(Func<T, TResult> func)
        {
            Func<T, TResult> wrapper = (T arg) =>
            {
                Console.WriteLine("started");
                var result = func(arg);
                Console.WriteLine(result);
                Console.WriteLine("ended");
                return result;
            };

            return wrapper;
        }

        static Func<int, int> Paramerator2(Func<int, int> func)
        {
            Func<int, int> wrapper = (int arg) =>
            {
                Console.WriteLine("started");
                var result = func(arg);
                Console.WriteLine(result);
                Console.WriteLine("ended");
                return result;
            };

            return wrapper;
        }


    }
}