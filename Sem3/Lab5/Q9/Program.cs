namespace Q9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> sentencesWithExpectedCounts = new()
            {
                ["This is a test sentence."] = 5,
                ["How many words are in this string?"] = 7,
                ["The quick brown fox jumps over the lazy dog"] = 9,
                ["Split this sentence into words."] = 5,
                ["hi"] = 1
            };

            foreach ((string sentence, int expected) in sentencesWithExpectedCounts)
            {
                int numOfOwrds = sentence.NumOfWords();
                Console.WriteLine($"{sentence} => {numOfOwrds}\t(Expected: {expected}).");
            }
        }
    }

    public static class StringExtension
    {
        public static int NumOfWords(this string s)
        {
            return s.Split(' ').Length;
        }
    }
}