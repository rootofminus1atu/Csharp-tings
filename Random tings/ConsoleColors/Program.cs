namespace ConsoleColors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            NewConsole.WriteWarning("you broke the timeline");
            NewConsole.WriteError("stop");
            NewConsole.WriteSuccess("yay");

            Console.WriteLine("\u001b[32mThis text will be displayed in green.\u001b[0m but here");
            NewConsole.WriteAdvancedWarning("You can't use `[1 , 2, 3]` in method named `Hecc`");

            string str = "lol";
            Console.WriteLine(NewConsole.Underline(NewConsole.Red(str)));
            Console.WriteLine(NewConsole.Red($"Hello there {NewConsole.Underline("human")} lol"));
            Console.WriteLine(NewConsole.Underline($"Hello there {NewConsole.Red("human")} lol"));
        }
    }

    public class NewConsole
    {
        private enum Status
        {
            Success,
            Warning,
            Error,

            Important
        }

        private static Dictionary<Status, (string normal, string accent)> colors = new Dictionary<Status, (string, string)>()
        {
            [Status.Success] = ("\u001b[32m", "\u001b[33m"),
            [Status.Warning] = ("\u001b[0m", "\u001b[4m"),
            [Status.Error] = ("\u001b[31m", "\u001b[36m")
        };

        public static string Underline(string input)
        {
            return "\u001b[4m" + input + "\u001b[24m";
        }

        public static string Red(string input)
        {
            return "\u001b[31m" + input + "\u001b[39m";
        }

        public static void WriteWarning(string input, string? end = "\n")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"[Warning] {input}{end}");
            Console.ResetColor();
        }

        public static void WriteAdvancedWarning(string input)
        {
            var (normal, accent) = colors[Status.Warning];

            string[] chunks = input.Split('`');

            for (int i = 0; i < chunks.Length; i++)
            {
                if (i % 2 == 1)
                    chunks[i] = accent + chunks[i] + normal; 
            }

            Console.WriteLine($"{accent}[Warning]{normal} {string.Join("", chunks)}");
        }

        public static void WriteError(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[Error] {input}");
            Console.ResetColor();
        }

        public static void WriteSuccess(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Success] {input}");
            Console.ResetColor();
        }
    }
}