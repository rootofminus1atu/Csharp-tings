using System.Collections.Generic;

namespace Q8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Write a program which asks the user to enter the name of the players on the team.
            // Use a sentinel value of -1.  Store the names in a List<string> collection.
            // Output the names of the team in alphabetical order to the screen.

            int counter = 0;
            List<string> players = new();

            while (true)
            {
                Console.Write($"{counter + 1}. Input a player (-1 to quit): ");
                string input = Console.ReadLine();

                if (input == "-1")
                    break;

                players.Add(input);



                counter++;


            }

            players.Sort();

            Console.WriteLine("List of all players: ");
            foreach (string player in players) 
            {
                Console.WriteLine($"- {player}");
            }
            
        }

        static void SortingTest()
        {
            List<string> list = new() { "ddd", "bbb", "ccc", "aab", "abc", "bab", "bca", "bcd", "bcc" };

            list.Sort();  // very handy

            Console.WriteLine($"[{string.Join(", ", list)}]");
        }
    }
}