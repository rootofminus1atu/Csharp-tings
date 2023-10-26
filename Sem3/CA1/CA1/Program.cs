using System.Net.Http.Headers;
using System.Reflection;

namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            

            Game g1 = new Game();
            g1.Play();


            
        }
    }

    public enum StickOrTwist
    {
        Stick,
        Twist
    }

    public class Game
    {
        public Player Player {  get; set; } = new Player();
        public Dealer Dealer { get; set; } = new Dealer();

        public Game()
        {
            
        }

        public void Play()
        {
            Console.WriteLine("new game start");

            // get randomized deck
            Deck deck = new Deck();
            deck.Shuffle();

            // take 2 cards for the player
            Card card1 = Player.DrawTop(deck);
            Card card2 = Player.DrawTop(deck);

            Console.WriteLine(card1.GetDetails());
            Console.WriteLine(card2.GetDetails());
            Console.WriteLine($"Your score is {Player.Score}");

            Console.WriteLine("Do you want to stick or twist? (s/t): ");
            StickOrTwist? input = GetInput();
                // .ToOption()
                // .Map( apply st enum to char input, if not work, return none )
                // 




            // 2 cards for the dealer

            // do some questioning etc
            // update state
        }

        public StickOrTwist? GetInput()
        {
            string? input = Console.ReadLine();

            if (input == null)
                return null;

            if (input.Length != 1)
                return null;

            // turn char into StickOrTwist.Stick or StickOrTwist.Twist
            // return that
        }
    }

    public class Player 
    {
        public int Score { get; set; } = 0;

        public Card DrawTop(Deck deck)
        {
            Card card = deck.DrawTop();
            Score += card.GetPoints();
            return card;
        }
    }

    public class Dealer : Player
    {

    }


    
    public class Testing
    {
        public static void DeckDemo()
        {
            Deck d1 = new();
            d1.Shuffle();

            Console.WriteLine(d1.Cards.Stringify());
            Console.WriteLine(d1.DiscardedCards.Stringify());

            Card c = d1.DrawBottom();
            Console.WriteLine(c);

            Console.WriteLine(d1.Cards.Stringify());
            Console.WriteLine(d1.DiscardedCards.Stringify());

            Console.WriteLine("♥ ♣ ♦ ♠ ♤ ♡ ♧ ♢");
        }

        public static void CardDemo()
        {
            Card c1 = new(new Card.King(), Suit.Diamonds);
            Console.WriteLine(c1);
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