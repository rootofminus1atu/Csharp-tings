using System.Net.Http.Headers;

namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Card c1 = new(new Card.King(), Suit.Diamonds);
            Console.WriteLine(c1);

            Deck d1 = new Deck();
            Console.WriteLine(d1.Cards.Stringify());
            d1.Shuffle();
            Console.WriteLine(d1.Cards.Stringify());

            Console.WriteLine("♥ ♣ ♦ ♠ ♤ ♡ ♧ ♢");
        }
    }

    public class Game
    {
        // contain dealer and player
        // start and control game
    }

    public class Player 
    {
        
    }

    public class Dealer
    {

    }


    public class Deck
    {
        public List<Card> Cards {  get; set; } = new();

        public Deck()
        {
            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                // maybe we could use a card factory insted of static methods

                foreach(Card.ICardValue val in Card.GetPictureValues())
                {
                    Cards.Add(new Card(val, s));
                }

                foreach(Card.ICardValue num in Card.GetNumberValues())
                {
                    Cards.Add(new Card(num, s));
                }
            }
        }

        public void Shuffle()
        {
            var rand = new Random();
            Cards = Cards.OrderBy(c => rand.Next()).ToList();
        }
    }






    

    


    public static class ListExtension
    {
        public static string Stringify<T>(this List<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }
    }

}