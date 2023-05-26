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

        private enum TextEffect
        {
            Red = 31,
            Green = 32,
            Yellow = 33,
            ColorReset = 39,
            Underline = 4,
            UnderlineReset = 24,
            AllReset = 0
        }

        private static string ToAnsi(TextEffect type)
        {
            return $"\u001b[{(int) type}m";
        }

        public static string Underline(string input)
        {
            return ToAnsi(TextEffect.Underline) + input + ToAnsi(TextEffect.UnderlineReset);
        }

        public static string Red(string input)
        {
            return ToAnsi(TextEffect.Red) + input + ToAnsi(TextEffect.ColorReset);
        }

        public static void WriteWarning(string input, string? end = "\n")
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"[Warning] {input}{end}");
            Console.ResetColor();
        }

        public static void WriteAdvancedWarning(string input)
        {
            string[] chunks = input.Split('`');

            for (int i = 0; i < chunks.Length; i++)
            {
                if (i % 2 == 1)
                    chunks[i] = Underline(chunks[i]); 
            }

            Console.WriteLine(Red($"[Warning] {string.Join("", chunks)}") + ToAnsi(TextEffect.AllReset));
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