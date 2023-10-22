namespace Optionv3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var noneGeneric = new None();
            // prob impossible without the empty type
            IOption<string> noneSpecific = noneGeneric;
        }
    }

    public interface IOption<out T> 
    {
        bool IsSome { get; }

        T Unwrap();

    }

    public class Some<T> : IOption<T>
    {
        private readonly T value;
        public bool IsSome => true;

        public T Unwrap()
        {
            return value;
        }
    }



    public interface INone<in T> : IOption<object>
    {
        object Unwrap();
    }

    public class None<T> : INone<T>
    {
        public bool IsSome => false;

        public object Unwrap()
        {
            throw new Exception("no");
        }
    }

    public class None : INone<object>
    {
        public bool IsSome => false;

        public object Unwrap()
        {
            throw new Exception("no unwrap (object)");
        }
    }
}