namespace Intervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Interval itv = Interval.FromStr("some itv here");
            Console.WriteLine(itv.ToString());

        }
    }

    public class BoundaryValue
    {
        public double Number { get; set; }
        public bool Open { get; set; }
        public bool Closed { get => !Open; }

        public BoundaryValue() { }

        public BoundaryValue(double number, bool open)
        {
            Number = number;
            Open = open;
        }

        public static bool operator ==(BoundaryValue left, BoundaryValue right)
        {
            return left.Number == right.Number && left.Open == right.Open;
        }

        public static bool operator !=(BoundaryValue left, BoundaryValue right)
        {
            return !(left == right);
        }

        public static bool operator <(BoundaryValue left, BoundaryValue right)
        {
            if (left.Number != right.Number)
                return left.Number < right.Number;

            if (left.Open && right.Closed)
                return true;
            else
                return false;
        }

        public static bool operator <=(BoundaryValue left, BoundaryValue right)
        {
            if (left.Number != right.Number) 
                return left.Number <= right.Number;

            if (left.Closed && right.Open)
                return false;
            else
                return true;
        }

        public static bool operator >(BoundaryValue left, BoundaryValue right)
        {
            return !(left <= right);
        }

        public static bool operator >=(BoundaryValue left, BoundaryValue right) 
        { 
            return !(left > right); 
        }

        public string GetBrackerUpper()
        {
            return this.Open ? ")" : "]";
        }

        public string GetBrackerLower()
        {
            return this.Open ? "(" : "[";
        }
    }

    public class InvalidIntervalException : Exception
    {

    }

    public class Interval
    {
        BoundaryValue Lower {  get; set; }
        BoundaryValue Upper { get; set; }

        

        private Interval() { }

        private Interval(BoundaryValue lower, BoundaryValue upper)
        {
            Lower = lower;
            Upper = upper;
        }

        public static Interval FromStr(string str)
        {
            // do conversion stuff

            // create BV lower and upper
            BoundaryValue lower = new(10, false);
            BoundaryValue upper = new(25, true);

            // assign the str to StringRepr

            // but first make the StringRepr a bit prettier

            return new Interval(lower, upper);
        }

        public override string ToString()
        {
            // add if else for the singleton case
            return $"{Lower.GetBrackerLower}{Lower.Number}, {Upper.Number}{Upper.GetBrackerUpper()}";
        }

        // add all the other functions
    }
}