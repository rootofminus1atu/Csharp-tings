namespace Category_theory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            Console.WriteLine($"{n} after doing nothing to it is: {Identity(5)}");

            Console.WriteLine(square(n));

            string[] arr = { "hi", "general", "KEnobI" };
            string[] arred = Map(arr, Up);
            Display(arred);



            var testList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var mapList = Map(x => x + 2, testList);

            mapList.ToList<int>().ForEach(i => Console.Write(i + " "));
            Console.WriteLine();



            var func = Compose<double, double, double>(Negative, Square);





            /*
            Console.Write("\nEnter hours: ");
            int hours = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("hours");
            */
        }

        public static anything Identity<anything>(anything thing)
        {
            return thing;
        }

        public static Func<int, int> square = x => x * x;

        public static Action<string> greet = name =>
        {
            string greeting = $"Hello {name}!";
            Console.WriteLine(greeting);
        };

        public static Func<int, int, bool> testForEquality = (x, y) => x == y;

        public static Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;

        public static Func<T1, T3> Compose<T1, T2, T3>(Func<T2, T3> f, Func<T1, T2> g)
        {
            return x => f(g(x));
        }

        public static T2[] Map<T1, T2>(T1[] arr, Func<T1, T2> f)
        {
            T2[] result = new T2[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                result[i] = f(arr[i]);

            return result;
        }
        public static void Display<Thing>(Thing[] arr)
        {
            foreach (Thing thing in arr)
                Console.WriteLine(thing);
        }
        public static string Up(string str)
        {
            return str.ToUpper();
        }

        static IEnumerable<TResult> Map<T, TResult>(Func<T, TResult> func, IEnumerable<T> list)
        {
            foreach (var i in list)
                yield return func(i);
        }

        public static double Square(double n)
        {
            return Math.Pow(n, 2);
        }
        public static double Negative(double n)
        {
            return -1 * n;
        }

        public static bool AreEqaul<T1, T2>(T1 x, T2 y)
        {
            if (5 == 5 /*x == y*/)
                return true;
            else
                return false;
        }

    }

}