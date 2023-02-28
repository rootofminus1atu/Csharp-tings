namespace Capitalization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phrase = "How can mirrors be real if our eyes aren't real";
            string[] subs = phrase.Split(' ');

            string phraseUpper = "";
            string[] phraseBetter = new string[subs.Length];


            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i].Length == 1)
                    phraseBetter[i] = Convert.ToString(char.ToUpper(subs[i][0]));

                else
                    phraseBetter[i] = char.ToUpper(subs[i][0]) + subs[i].Substring(1);
            }

            Console.WriteLine(string.Join(" ", phraseBetter));
            Console.WriteLine("hi");


            // idk which one I like more :(


            foreach (string word in subs)
            {
                if (word.Length == 1)
                    phraseUpper += char.ToUpper(word[0]) + " ";

                else
                    phraseUpper += char.ToUpper(word[0]) + word.Substring(1) + " ";
            }

            string phraseFinal = phraseUpper.Remove(phraseUpper.Length - 1);
;
            Console.WriteLine(phraseFinal);
        }
    }
}