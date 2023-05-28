using System.Reflection;

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

            Console.WriteLine("hi");

            NewConsole.WriteWarning("You can't use `[1 , 2, 3]` in method named `Hecc`");
            NewConsole.WriteSuccess("You can't use `[1 , 2, 3]` in method named `Hecc`");
            NewConsole.WriteError("You can't use `[1 , 2, 3]` in method named `Hecc`");

            Console.WriteLine("hi again");
            Console.WriteLine(Fore.Blue.Apply($"hi but in {Style.Underline.Apply("BLUE")} (cool color)"));




            // wip 

            ProgressBar progressBar = new ProgressBar(10);

            for (int i = 0; i <= 100; i++)
            {
                progressBar.Update(i);
                Thread.Sleep(1000);
            }

            Console.WriteLine("\nProgress complete!");

        }
    }

    public abstract class TextEffect
    {
        private int _code;

        public TextEffect(int code)
        {
            this._code = code;
        }

        public string Apply(string input)
        {
            PropertyInfo resetProperty = this.GetType().GetProperty("Reset");
            TextEffect resetValue = (TextEffect)resetProperty.GetValue(null);

            return $"{Ansify(this._code)}{input}{Ansify(resetValue._code)}";
        }

        private static string Ansify(int code)
        {
            return $"\u001b[{code}m";
        }
    }

    public class Fore : TextEffect
    {
        private Fore(int code) : base(code) { }

        public static Fore Red { get; } = new Fore(31);
        public static Fore Green { get; } = new Fore(32);
        public static Fore Yellow { get; } = new Fore(33);
        public static Fore Blue { get; } = new Fore(34);
        public static Fore Reset { get; } = new Fore(39);
    }

    public class Style : TextEffect
    {
        private Style(int code) : base(code) { }


        public static Style Underline { get; } = new Style(4);
        public static Style Reset { get; } = new Style(24);
    }

    public class NewConsole
    {
        public static void WriteSuccess(string input, string end = "\n")
        {
            WriteGeneral(input, Fore.Green, message:"Success", end: end);
        }

        public static void WriteWarning(string input, string end = "\n")
        {
            WriteGeneral(input, Fore.Yellow, message: "Warning", end: end);
        }

        public static void WriteError(string input, string end = "\n")
        {
            WriteGeneral(input, Fore.Red, message: "Error", end: end);
        }

        private static void WriteGeneral(string input, TextEffect textEffect, string? message = null, string end = "\n")
        {
            string[] chunks = input.Split('`');

            for (int i = 0; i < chunks.Length; i++)
            {
                if (i % 2 == 1)
                    chunks[i] = Style.Underline.Apply(chunks[i]);
            }

            if (message != null)
                message = $"[{message}] ";

            Console.Write(textEffect.Apply($"{message}{string.Join("", chunks)}{end}"));
        }
    }

    public class ProgressBar
    {
        private int total;
        private int progress;

        public ProgressBar(int total)
        {
            this.total = total;
            this.progress = 0;
        }

        public void Update(int value)
        {
            if (value < 0 || value > total)
                throw new ArgumentOutOfRangeException("Invalid progress value.");

            progress = value;

            // Calculate the percentage and fill length
            int percentage = (int)((float)progress / total * 100);
            int fillLength = (int)((float)progress / total * Console.WindowWidth);

            // Save the current cursor position
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            // Update the progress bar
            Console.SetCursorPosition(0, cursorTop);
            Console.Write($"[{new string('#', fillLength)}{new string('-', Console.WindowWidth - fillLength - 1)}] {percentage}%");

            // Restore the cursor position
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }
    }
}