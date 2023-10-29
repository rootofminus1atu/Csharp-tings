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
        public Player? Winner { get; set; } = null;


        public Game() { }

        public void Play()
        {
            Console.WriteLine("new game start");

            // get randomized deck
            Deck deck = new();
            deck.Shuffle();

            // take 2 cards for the player
            Card card1 = Player.DrawTop(deck);
            Card card2 = Player.DrawTop(deck);

            Console.WriteLine(card1.GetDetails());
            Console.WriteLine(card2.GetDetails());
            Console.WriteLine($"Your score is {Player.Score}");

            while (!Player.Bust && !Player.Got21 && Player.IsTwisting)
            {
                // this part can change based on the context
                StickOrTwist input = KeepAskingForInput();
                // this above

                Player.StickOrTwist = input;

                if (Player.IsSticking)
                {
                    break;
                }

                Card anotherCard = Player.DrawTop(deck);
                // Card anotherCard = Player.TestGetCard(new Card(new Ace(), Suit.Spades));

                Console.WriteLine(anotherCard.GetDetails());
                Console.WriteLine($"Your score is {Player.Score}");
            }

            if (Player.Got21)
            {
                Console.WriteLine("Woohoo you won!");
                return;
            }

            if (Player.Bust)
            {
                Console.WriteLine("Oh no you bust :(");
                return;
            }


            while (Dealer.Score < Player.Score && Dealer.HasToTake)
            {
                Card card = Dealer.DrawTop(deck);

                Console.WriteLine(card.GetDetails());
                Console.WriteLine($"Dealer's score is {Dealer.Score}");
            }

            Console.WriteLine("Final scores:");
            Console.WriteLine($"Your score is {Player.Score}");
            Console.WriteLine($"Dealer's score is {Dealer.Score}");

            DetermineWinner();

        }

        public DetermineWinner()
        {
            // what should it accept, what should it return, should it return anything
        }

        public static StickOrTwist KeepAskingForInput()
        {
            Console.WriteLine("Do you want to stick or twist? (s/t): ");

            StickOrTwist? input = null;
            while (!input.HasValue)
            {
                input = AskForInput();
            }

            return input.Value;
        }

        public static StickOrTwist? AskForInput()
        {
            Console.Write("> ");
            string? input = Console.ReadLine()?.ToLower();

            return input switch
            {
                "s" => StickOrTwist.Stick,
                "t" => StickOrTwist.Twist,
                _ => null
            };
        }
    }

    public class Player 
    {
        public const int MAX_SCORE = 21;

        public int Score { get; set; } = 0;
        public bool Bust => Score > MAX_SCORE;
        public bool Got21 => Score == MAX_SCORE;

        public StickOrTwist StickOrTwist { get; set; } = StickOrTwist.Twist;
        public bool IsTwisting => this.StickOrTwist == StickOrTwist.Twist;
        public bool IsSticking => !IsTwisting;
        
        

        public Card DrawTop(Deck deck)
        {
            Card card = deck.DrawTop();
            AddPoints(card);
            return card;
        }

        public Card TestGetCard(Card card)
        {
            AddPoints(card);
            return card;
        }

        private void AddPoints(Card card)
        {
            if (card.Rank is Ace)
            {
                if (Score +  card.GetPoints() > MAX_SCORE)
                {
                    // special value
                    Score += 1;
                    Console.WriteLine("Ace counted as 1 instead of 11");
                    return;
                }
            }

            Score += card.GetPoints();
        }
    }

    public class Dealer : Player
    {
        const int DEALER_CUTOFF = 17;
        
        public bool HasToTake => Score < DEALER_CUTOFF;
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
            Card c1 = new(new King(), Suit.Diamonds);
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