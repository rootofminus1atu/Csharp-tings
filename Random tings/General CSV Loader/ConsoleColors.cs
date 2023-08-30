using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace General_CSV_Loader
{

    // not the best code but whatever I can write something better later

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

    public class CustomConsole
    {
        public static void WriteSuccess(string input, string end = "\n")
        {
            WriteGeneral(input, Fore.Green, message: "Success", end: end);
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
}
