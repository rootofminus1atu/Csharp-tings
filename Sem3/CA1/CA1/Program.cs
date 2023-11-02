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

    public enum GameState
    {
        NewGame,
        PlayerTurn,
        DealerTurn,
        GameOver
    }

    public enum GameResult
    {
        PlayerBust,
        DealerBust,
        Draw,
        PlayerWins,
        DealerWins
    }

    public class ConsoleGame : Game
    {
        public void WhenPlayerDraw(Card card)
        {
            Console.WriteLine($"Card dealt is {card}, worth {card.GetPoints()}");
            Console.WriteLine($"Your score is {Player.Score}");
        }



    }


    public class Game
    {
        public Player Player {  get; set; } = new Player();
        public Dealer Dealer { get; set; } = new Dealer();
        public Deck Deck { get; set; } = new Deck();
        public GameState GameState { get; private set; } = GameState.NewGame;
        public GameResult GameResult { get; private set; }



        public Game() { }

        public void Play()
        {
            // setup
            Console.WriteLine("new game start");
            Deck.Shuffle();

            GameState = GameState.PlayerTurn;

            while (GameState != GameState.GameOver)
            {
                switch (GameState)
                {
                    case GameState.PlayerTurn:
                        HandlePlayerTurn();
                        break;
                    case GameState.DealerTurn:
                        HandleDealerTurn();
                        break;
                }
            }

            // end
            Console.WriteLine("Final scores:");
            Console.WriteLine($"Your score is {Player.Score}");
            Console.WriteLine($"Dealer's score is {Dealer.Score}");

            DetermineWinner();

            string resultMessage = GameResult switch
            {
                GameResult.PlayerWins => "Player wins!",
                GameResult.DealerWins => "Dealer wins!",
                GameResult.Draw => "It's a draw!",
                GameResult.PlayerBust => "Dealer wins - Player busts",
                GameResult.DealerBust => "Player wins - Dealer busts",
                _ => "Invalid game result"
            };

            Console.WriteLine(resultMessage);



        }

        public void DetermineWinner()
        {
            if (Player.Bust)
            {
                GameResult = GameResult.PlayerBust;
            }
            else if (Dealer.Bust)
            {
                GameResult = GameResult.DealerBust;
            }
            else if (Player.Score == Dealer.Score)
            {
                GameResult = GameResult.Draw;
            }
            else if (Player.Score > Dealer.Score)
            {
                GameResult = GameResult.PlayerWins;
            }
            else
            {
                GameResult = GameResult.DealerWins;
            }
        }

        public void HandlePlayerTurn()
        {
            Card card1 = Player.DrawTop(Deck); 
            Console.WriteLine($"Card dealt is {card1}, worth {card1.GetPoints()}");
            Console.WriteLine($"Your score is {Player.Score}");
            Card card2 = Player.DrawTop(Deck);
            Console.WriteLine($"Card dealt is {card2}, worth {card2.GetPoints()}");
            Console.WriteLine($"Your score is {Player.Score}");

            while (!Player.Bust && !Player.GotBlackjack && Player.IsTwisting)
            {
                StickOrTwist input = StickOrTwistInput();

                Player.StickOrTwist = input;

                if (Player.IsSticking)
                {
                    break;
                }

                Card anotherCard = Player.DrawTop(Deck);
                Console.WriteLine($"Card dealt is {anotherCard}, worth {anotherCard.GetPoints()}");
                Console.WriteLine($"Your score is {Player.Score}");
            }

            if (Player.GotBlackjack)
            {
                Console.WriteLine("Woohoo you won!");
                GameState = GameState.GameOver;
                return;
            }

            if (Player.Bust)
            {
                Console.WriteLine("Oh no you bust :(");
                GameState = GameState.GameOver;
                return;
            }

            GameState = GameState.DealerTurn;
        }

        public void HandleDealerTurn()
        {
            while (Dealer.Score < Player.Score && Dealer.HasToTake)
            {
                Card card = Dealer.DrawTop(Deck);

                Console.WriteLine(card.GetDetails());
                Console.WriteLine($"Dealer's score is {Dealer.Score}");
            }

            if (Dealer.Bust)
            {
                Console.WriteLine("Dealer bust...");
                GameState = GameState.GameOver;
            }

            GameState = GameState.GameOver;
        }

        public StickOrTwist StickOrTwistInput()
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
        public bool GotBlackjack => Score == MAX_SCORE;

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