using System.Collections.Generic;
using System.Linq;

namespace Lab12Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // shirotori game

            Shirotori game = new Shirotori();

            game.Play("hello");
            game.Play("over");
            game.Play("hi");
            game.Play("range");

            game.Restart();
            game.Play("range");
            game.Play("error");
            game.Play("range");
            game.Play("range");
            game.Play("range");
            game.Play("range");

            Console.WriteLine("Commands: ");
            Console.WriteLine(">play - play a new game");
            Console.WriteLine("to input a word just type it in, without any prefixes or suffixes");
            Console.WriteLine(">restart - restart the game");


            // how to game loop


            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();

                if (input == "play")
                {
                    Console.WriteLine("gameplay");
                    Shirotori myGame = new Shirotori();

                    while(!myGame.isOver)
                    {
                        string word = Console.ReadLine();
                        myGame.Play(word);
                    }

                }
                else if (input == "restart")
                {

                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }


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
            if (isOver)
            {
                Console.WriteLine("Game over\n");
                return;
            }

            if (this.words.Count > 0)
            {
                char lastChar = this.words.Last()[this.words.Last().Length - 1];

                if (input[0] != lastChar)
                {
                    Console.WriteLine($"Game over! \"{input}\" doesn't start with \"{lastChar}\"\n");
                    isOver = true;
                    return;
                }
            }

            if (this.words.Contains(input))
            {
                Console.WriteLine($"Game over! You used \"{input}\" already\n");
                isOver = true;
                return;
            }


            this.words.Add(input);
            Console.WriteLine($"\"{input}\" accepted");
            Console.WriteLine($"Progress: {ListToStr(this.words)}\n");
        }


        public void Restart()
        {
            this.isOver = false;
            this.words.Clear();
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