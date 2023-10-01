namespace Option
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOption<int> maybeValue = new Some<int>(15);

            int res = maybeValue.UnwrapOrExec(() => 12);

            Console.WriteLine($"Result is {res}");




        }

        static IOption<int> ParseThenAdd(string v1, string v2)
        {
            IOption<int> v1Res = MyTryParse(v1);

            int v1Num;
            if (v1Res.IsNone)
                return new None<int>();
            else
                v1Num = v1Res.Unwrap();


            IOption<int> v2Res = MyTryParse(v2);

            int v2Num;
            if (v2Res.IsNone)
                return new None<int>();
            else
                v2Num = v2Res.Unwrap();


            return new Some<int>(v1Num + v2Num);
        }

        static IOption<int> ParseThenAddBetter(string v1, string v2)
        {
            int v1Num = MyTryParse(v1).Questionmark();  // causes the method to end early if v1 cannot be converted, ie the result of such a conversion is None (a C# class instance that inherits from IOption<T>)
            int v2Num = MyTryParse(v2).Questionmark();

            return new Some<int>(v1Num + v2Num);
        }

        static IOption<int> MyTryParse(string num)
        {
            bool success = int.TryParse(num, out int val);

            if (success == true)
                return new Some<int>(val);
            else
                return new None<int>();
        }
    }

    public abstract class IOption<T>
    {
        bool IsSome { get; }
        public bool IsNone => !IsSome;

        public abstract T Unwrap();
        public abstract T UnwrapOr(T other);

        public abstract T UnwrapOrExec(Func<T> func);

        public T Questionmark()
        {
            if (this.IsSome)
            {
                return this.Unwrap();
            }
            else
            {
                return default(T);
            }

        }
    }

    public class Some<T> : IOption<T>
    {
        private readonly T _value;
        public Some(T value)
        {
            this._value = value;
        }

        public bool IsSome => true;

        public override T Unwrap()
        {
            return this._value;
        }

        public override T UnwrapOr(T other)
        {
            return this.Unwrap();
        }

        public override T UnwrapOrExec(Func<T> func)
        {
            return this.Unwrap();
        }
    }

    public class None<T> : IOption<T>
    {
        public bool IsSome => false;

        public override T Unwrap()
        {
            throw new InvalidOperationException("Tried to unwrap a 'None' value.");
        }

        public override T UnwrapOr(T other)
        {
            return other;
        }

        public override T UnwrapOrExec(Func<T> func)
        {
            return func();
        }
    }

    public struct OptionStruct<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        private OptionStruct(T value)
        {
            _value = value;
            _hasValue = true;
        }

        public static OptionStruct<T> Some(T value)
        {
            return new OptionStruct<T>(value);
        }

        public static OptionStruct<T> None()
        {
            return new OptionStruct<T>();
        }

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            return _hasValue ? some(_value) : none();
        }
    }
}