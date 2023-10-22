
using System.ComponentModel;

namespace Optionv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Option<int> someVal = new Some<int>(42);
            Option<object> noneVal = new None();
            Option<int> noneIntVal = new None<int>();

            // this works
            Option<string> der1 = new Some<string>("hi");
            Option<object> base1 = der1;

            // at first glance it shouldn't work, because covariance
            // but when you think about it, it actually should be possible
            // since a generic None() can easily be converted to None<any type>()
            Option<object> none = new None();
            Option<string> noneStried = none;
            */


            string res = Divide(10, 0)
                .Match(
                    some: val => $"The answer is {val}",
                    none: () => "Illegal"
                    );

            Console.WriteLine(res);


            int resu = 20.ToNone()
                .Map(x => x * 2)
                .Bind(x => Divide(x, 5))
                .UnwrapOr(-999);

            Console.WriteLine(resu);



            Console.WriteLine("input name");
            string name = Console.ReadLine().ToOption().UnwrapOr("Default Name");
            // how can I create a system, where in the case of no input the user would be asked again to input their name


            IOption<string> optionName = new None<string>();

            while (optionName.IsNone)
            {
                Console.WriteLine("input name");
                optionName = Console.ReadLine().ToOption();
            }
            string namee = optionName.Unwrap();
            Console.WriteLine($"Name is {namee}");
        }

        public static IOption<int> Divide(int a, int b)
        {
            return b == 0 ? new None<int>() : new Some<int>(a / b);
        }
    }

    public interface IFunctor<T>  // can't hkt :(
    {
        IFunctor<TResult> Map<TResult>(Func<T, TResult> func);
    }

    public interface IOption<T>
    {
        bool IsSome { get; }
        bool IsNone => !IsSome;
        T Unwrap();
        T UnwrapOr(T alt);
        TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);
        void Match(Action<T> some, Action none);
        IOption<TResult> Map<TResult>(Func<T, TResult> func);
        IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> func);
    }

    public class Some<T> : IOption<T>
    {
        private T Value { get; }

        public Some(T value)
        {
            this.Value = value;
        }

        public bool IsSome => true;

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none) => some(Value);

        public void Match(Action<T> some, Action none) => some(Value);

        public IOption<TResult> Map<TResult>(Func<T, TResult> func) => new Some<TResult>(func(Value));

        public IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> func) => func(Value);

        public T Unwrap() => Value;
        public T UnwrapOr(T alt) => Value;

    }

    public class None<T> : IOption<T>
    {
        public bool IsSome => false;

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            return none();
        }

        public void Match(Action<T> some, Action none)
        {
            none();
        }

        public IOption<TResult> Map<TResult>(Func<T, TResult> func)
        {
            return new None<TResult>();
        }

        public IOption<TResult> Bind<TResult>(Func<T, IOption<TResult>> func) => new None<TResult>();

        public T Unwrap()
        {
            throw new Exception("This is what you get for unwrapping a None value");
        }

        public T UnwrapOr(T alt) => alt;
    }

    public static class OptionExtension
    {
        /// <summary>
        /// Takes anything that isn't null to Some, only null gets mappes to None
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        public static IOption<T> ToOption<T>(this T? input)
        {
            return input == null ? new None<T>() : new Some<T>(input);
        }

        public static Some<T> ToSome<T>(this T input)
        {
            return new Some<T>(input);
        }

        public static None<T> ToNone<T>(this T _)
        {
            return new None<T>();
        }
    }

    // prob won't be used
    /*
    public class None : IOption<object>
    {
        public bool IsSome => false;

        public object Unwrap()
        {
            throw new Exception("no unwrap OBJECT none");
        }
    }
    */
}