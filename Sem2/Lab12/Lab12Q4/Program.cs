using System.Collections.Generic;
using System.Linq;

namespace Lab12Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // shirotori

            Shirotori game = new Shirotori();

            game.Play("hello");
            game.Play("ok");
            game.Play("areme");



        }
    }

    public class Shirotori
    {
        public List<string> words { get; set; }
        public bool isOver { get; set; }

        public Shirotori()
        {
            this.words = new List<string>() { };
            this.isOver = false;
        }

        public void Play(string input)
        {
            if (this.words.Count > 1)
            {
                var endChar = this.words.Last()[this.words.Last().Length - 1];

                if (input[0] != endChar)
                {
                    Console.WriteLine($"{input} doesn't start with {endChar}");
                    return;
                }
            }
                

            this.words.Add(input);
            Console.WriteLine($"{input} -> {ListToStr(this.words)}");
        }

        public void GetWords()
        {
            Console.WriteLine(ListToStr(this.words));
        }

        public static string ListToStr(List<string> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }

    }

}