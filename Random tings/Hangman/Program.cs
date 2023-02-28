namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //hangman :)
            //so far the words to guess cannot have spaces :(

            string word = "hello", display = "";
            int tries = 5;
            int winCounter = 0;
            int index1;
            char tempChar;

            for (int i = 0; i < word.Length; i++)  // generate ___ ___ ___ ___ ___
                display += "___ ";

            List<char> wordList = word.ToList();             // h   e   l   l   o  // but as a list
            List<char> displayList = display.ToList();       //___ ___ ___ ___ ___ // but as a list
            List<char> usedLetters = new List<char>() { };


            //everything above is the setup
            //everything below is the actual game 


            for (int i = 0; i < tries && winCounter < word.Length; i++)
            {
                PrintFancyList(displayList);

                Console.WriteLine($"The letters you used: {string.Join(", ", usedLetters)}");

                Console.Write($"{tries - i} guesses left: ");
                tempChar = char.Parse(Console.ReadLine());


                if (usedLetters.Contains(tempChar) == true) //check if you used a letter previously guessed
                {
                    Console.WriteLine("\nTry a different letter :/");

                    usedLetters.Remove(tempChar);

                    i--;
                }

                else if (wordList.Contains(tempChar) == true)
                {
                    while (wordList.Contains(tempChar) == true) //fill in all the correct char spots
                    {
                        index1 = wordList.IndexOf(tempChar);

                        wordList[index1] = '0';

                        displayList[1 + 4 * index1] = tempChar;

                        winCounter++;
                    }

                    i--;

                }

                else
                {
                    Console.WriteLine($"\nNope :(");
                }

                usedLetters.Add(tempChar);
            }

            PrintFancyList(displayList);

            //win or lose?
            if (winCounter == word.Length)
            {
                Console.WriteLine("You won :)");
            }
            else
            {
                Console.WriteLine($"You lost, the secret word was: {word}");
            }

        }

        public static void PrintFancyList(List<char> list)
        {
            //I'm sorry for this code being so messy but I'm too lazy

            Console.Write($"\n");

            foreach (char i in list)
                Console.Write($"_");

            Console.Write($"\n\n");

            foreach (char i in list)
                Console.Write($"{i}");

            Console.Write($"\n");

            foreach (char i in list)
                Console.Write($"_");

            Console.Write($"\n\n");
        }

    }
}