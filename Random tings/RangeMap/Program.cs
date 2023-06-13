using System.Collections;

namespace RangeMappp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RangeMap<string> woah = new RangeMap<string>()
            {
                ["_2.5"] = "cold",
                ["2.5_10"] = "medium",
                ["10_"] = "hot"
            };
            // for now you have to be a good boy and not input bad stuff for the ranges...

            Console.WriteLine(woah.FallIntoRange(-800));  // output: "cold"
            Console.WriteLine(woah.FallIntoRange(5));  // output: "medium"
            Console.WriteLine(woah.FallIntoRange(10.34));  // output: ""

        }
    }

    public class RangeMap<T> : IEnumerable<KeyValuePair<string, T>>
    {
        public Dictionary<string, T> Values { get; set; }

        public RangeMap()
        {
            Values = new Dictionary<string, T>() { };
        }

        public RangeMap(params (string Key, T Value)[] initialValues) : this()
        {
            foreach (var (key, value) in initialValues)
            {
                Values.Add(key, value);
            }
        }

        public void Add(string key, T value)
        {
            Values.Add(key, value);
        }

        public T this[string key]
        {
            get { return Values[key]; }
            set { Values[key] = value; }
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T FallIntoRange(double num)
        {
            foreach (var key in Values.Keys)
            {
                (double lower, double upper) = GetBounds(key);
                if (num >= lower && num < upper)
                {
                    return this.Values[key];
                }
            }

            return default;
        }

        public static (double, double) GetBounds(string range)
        {
            string[] vals = range.Split("_");

            double lower, upper;

            bool lowerSuccess = double.TryParse(vals[0], out lower);
            bool upperSuccess = double.TryParse(vals[1], out upper);

            // this is probably bad I should have a "Validate Range" function but whatever

            if (!lowerSuccess && !upperSuccess)
            {
                throw new ArgumentException($"`{range}` is not a valid range.");
            }
            else if (!lowerSuccess)
            {
                return (double.NegativeInfinity, upper);
            }
            else if (!upperSuccess)
            {
                return (lower, double.PositiveInfinity);
            }
            else
                return (lower, upper);
        }

    }
}