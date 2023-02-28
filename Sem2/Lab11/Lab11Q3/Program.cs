namespace Lab11Q3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input validation
            // aka pain

            /*
            Console.WriteLine("Input name");
            string name = ReadName();

            Console.WriteLine(name);

            Console.WriteLine("Input ID number");
            string id = ReadID();
            */

            string doubleNum;
            bool isValid = false;

            while (isValid == false)
            {
                Console.Write("I need a double: ");
                doubleNum = Console.ReadLine();

                if (IsDouble(doubleNum))
                    isValid = true;
                else
                    isValid = false;
            }

            string id;
            bool isValidID = false;

            while  (isValidID == false)
            {
                Console.Write("Input ID: ");
                id = Console.ReadLine();

                if (IsPresent(id) && StartsWith(id, "E") && IsNLong(id, 6))
                    isValidID = true;
                else
                    isValidID = false;

                // nvm I'm too lazy, for now you get just 1 error message
                // more would prob require an array
            }

        }

        // ok but not very general
        static string ReadName()
        {
            string name = "";

            while (name == "")
            {
                Console.Write("> ");
                name = Console.ReadLine();
            }

            return name;
        }
        static string ReadID()
        {
            string id = "";

            while (id == "" || id.Length != 6 /*|| id[0].ToUpper != 'E'*/)
            {
                Console.Write("> ");
                id = Console.ReadLine();
            }

            return id;
        }


        // more general
        static bool IsPresent(string text)
        {
            if (text == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must enter something");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

            return true;
        }

        static bool IsDouble(string input)
        {
            double num;
            bool success = double.TryParse(input, out num);

            if (!success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {input} isn't a double (decimal number)");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

            return true;
        }

        static bool StartsWith(string input, string start)
        {
            // wow somehow this isn't recursion
            // no override

            // this version is case sensitive
            // to make it case insensitive replace the line below with:
            // if (input.ToLower().StartsWith(startToLower()) == false)
            if (input.StartsWith(start) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {input} should start with \"{start}\"");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

            return true;
        }

        static bool IsNLong(string input, int length)
        {
            if (input.Length != length)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {input} should be {length} character(s) long");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

            return true;
        }

        static bool IsWithinRange(string input, int lower, int upper)
        {
            double num;
            bool success = double.TryParse(input, out num);

            if (!success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {input} isn't a double (decimal number)");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }

            if (num < lower || num > upper)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Error] {input} isn't within the range [{lower}, {upper}]");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
                return false;

            return true;
        }
    }
}