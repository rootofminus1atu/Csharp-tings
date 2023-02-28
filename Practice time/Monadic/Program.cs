namespace Monadic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double numbr = 5;
            NumWithLogs numbr2 = NumWithLogs.Wrapper(numbr);

            numbr2.Info();
            NumWithLogs numbr3 = numbr2.Square();
            numbr3.Info();
            NumWithLogs numbr4 = numbr3.Square();
            numbr4.Info();

        }

    }

    // naive class, it works but each method added needs those damn logs
    // monad how
    public class NumWithLogs
    {
        public double num;
        public List<string> logs = new List<string>();

        public NumWithLogs(double num, List<string> logs)
        {
            this.num = num;
            this.logs = logs;
        }

        public void Info()
        {
            Console.WriteLine(this.num);

            foreach (string log in this.logs)
                Console.WriteLine(log);
        }

        public static NumWithLogs Wrapper(double n)
        {
            return new NumWithLogs(n, new List<string>() { });
        }

        public NumWithLogs Square()
        {
            double numSqr = Math.Pow(this.num, 2);
            string log = $"squared {this.num} and got {numSqr}";

            this.logs.Add(log);

            return new NumWithLogs(numSqr, this.logs);
        }

    }
}