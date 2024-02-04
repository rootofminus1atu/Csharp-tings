namespace keyboard_sounds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to play a sound. Press 'Q' to quit.");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }

                PlaySound();
            }
        }

        static void PlaySound()
        {
            string soundFilePath = "path-to-your-sound-file.wav";

            Console.WriteLine("key got");
        }
    }
}