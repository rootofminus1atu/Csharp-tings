using System.Linq;

namespace Rational_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // todo: 
            // improve + operator to use LCM (not gcd)
            // improve comparison operators to use LCM (not gcd)
            // conversion decimal -> rational and the other way around
            // add prooper exception handling for 1/0 situtions

            Rational num1 = new Rational(1, -3);
            Rational num2 = new Rational(6, -9);
            Rational num3 = new Rational(-1, 2);
            Rational num4 = new Rational(-2, 6);

            Console.WriteLine(num1.ToString());
            Console.WriteLine(num3.ToString());



            Console.WriteLine("\nmultiplying");
            Console.WriteLine((num1 * num3).ToString());

            Console.WriteLine("\nadding");
            Console.WriteLine((num1 + num3).ToString());

            Console.WriteLine("\nsubtracting");
            Console.WriteLine((num1 - num3).ToString());

            Console.WriteLine("\ndividing");
            Console.WriteLine((num1 / num3).ToString());

            Console.WriteLine("\nsign of the num above");
            Console.WriteLine((num1 / num3).sign);

            Console.WriteLine(num1 > num3);
            Console.WriteLine(num1 < num3);

            decimal d = (decimal)num1;
            Console.WriteLine(d);


            Rational r = (Rational)12.411m;        // decimals are so bad
            Console.WriteLine(r.ToString());
        }
    }

    public class Color
    {
        public static void WriteColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }

    public struct Rational
    {
        int numerator;
        int denominator;
        public readonly int sign;

        public Rational(int num, int den)
        {
            int gcd = GCD(num, den);
            int sign = Math.Sign(num) * Math.Sign(den);

            this.numerator = Math.Abs(num) / gcd * sign;
            this.denominator = Math.Abs(den) / gcd;
            this.sign = sign;
        }


        public static Rational operator +(Rational R1, Rational R2)
        {
            return new Rational(R1.numerator * R2.denominator + R1.denominator * R2.numerator, R1.denominator * R2.denominator);
        }
        public static Rational operator *(Rational R1, Rational R2)
        {
            return new Rational(R1.numerator * R2.numerator, R1.denominator * R2.denominator);
        }

        public static Rational operator -(Rational R)  
        {
            return new Rational(-1 * R.numerator, R.denominator);
        }  // negative
        public static Rational operator ~(Rational R)  
        {
            return new Rational(R.denominator, R.numerator);
        }  // inverse

        public static Rational operator -(Rational R1, Rational R2) => R1 + -R2;
        public static Rational operator /(Rational R1, Rational R2) => R1 * ~R2;


        public static bool operator ==(Rational R1, Rational R2)
        {
            return R1.numerator == R2.numerator && R1.denominator == R2.denominator;
        }
        public static bool operator !=(Rational R1, Rational R2) => !(R1 == R2);

        public static bool operator <(Rational R1, Rational R2)
        {
            return R1.numerator * R2.denominator < R1.denominator * R2.numerator;
        }

        public static bool operator >=(Rational R1, Rational R2) => !(R1 < R2);

        public static bool operator >(Rational R1, Rational R2)
        {
            return R1.numerator * R2.denominator > R1.denominator * R2.numerator;
        }
        public static bool operator <=(Rational R1, Rational R2) => !(R1 > R2);
        


        public static explicit operator decimal(Rational R)
        {
            return (decimal)R.numerator/(decimal)R.denominator;
        }

        public static explicit operator Rational(decimal R)
        {
            string Rstr = R.ToString();
            int count = Rstr.Split('.')[1].Count();
            decimal power = (decimal)Math.Pow(10, count);

            return new Rational(Convert.ToInt32(R * (decimal)power), Convert.ToInt32(power));
        }


        public override string ToString()
        {
            try
            {
                if (this.numerator % this.denominator == 0)
                    return $"{this.numerator / this.denominator}";
                else
                    return $"{this.numerator}/{this.denominator}";
            }
            catch (DivideByZeroException)
            {
                Color.WriteColor("[ERROR] Division by 0", ConsoleColor.Red);
                return "";
            }
            
        }


        public static int GCD(int a, int b)
        {
            if (a == 0)
                return Math.Abs(b);

            return GCD(b % a, a);
        }

        public static int FindGCD(int n, int k) // too slow
        {
            int gcd = 1;

            for (int i = 1; i <= Math.Min(Math.Abs(n), Math.Abs(k)); i++)
            {
                if (n % i == 0 && k % i == 0)
                    gcd = i;
            }

            return gcd;
        }
    }
}