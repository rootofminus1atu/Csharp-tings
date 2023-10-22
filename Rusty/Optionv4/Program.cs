namespace Optionv4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Option<T>
    {
        private T _value;
        private bool _hasValue;

        private Option(T item, bool hasValue)
        {
            _value = item;
            _hasValue = hasValue;
        }
    }
}