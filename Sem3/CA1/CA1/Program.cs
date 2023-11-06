using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card cc = new(new Number(10), Suit.Clubs);

            DrawCard(2, 2, cc);




            Game g = new Game();
            g.Play();

        }

        public class Game : GameLogic
        {
            public override void HandleSetup()
            {
                Console.WriteLine("Setup");
            }

            public override void HandlePlayerTurn()
            {
                Console.WriteLine("Player turn");
            }

            public override void HandleDealerTurn()
            {
                Console.WriteLine("Dealer turn");
            }

            public override void HandleCleanup()
            {
                Console.WriteLine("Cleanup");
            }
        }

        public class ConsoleGame : GameLogic
        {
            public override void HandleSetup()
            {
                Console.WriteLine("new game start");
                Deck.Shuffle();

                GameState = GameState.PlayerTurn;
            }

            public override void HandleCleanup()
            {
                Console.WriteLine("Final scores:");
                Console.WriteLine($"Your score is {Player.Points}");
                Console.WriteLine($"Dealer's score is {Dealer.Points}");

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
                else if (Player.Points == Dealer.Points)
                {
                    GameResult = GameResult.Draw;
                }
                else if (Player.Points > Dealer.Points)
                {
                    GameResult = GameResult.PlayerWins;
                }
                else
                {
                    GameResult = GameResult.DealerWins;
                }
            }

            public override void HandlePlayerTurn()
            {
                Card card1 = Player.DrawTop(Deck);
                Console.WriteLine($"Card dealt is {card1}, worth {card1.GetPoints()}");
                Console.WriteLine($"Your score is {Player.Points}");
                Card card2 = Player.DrawTop(Deck);
                Console.WriteLine($"Card dealt is {card2}, worth {card2.GetPoints()}");
                Console.WriteLine($"Your score is {Player.Points}");

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
                    Console.WriteLine($"Your score is {Player.Points}");
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

            public override void HandleDealerTurn()
            {
                while (Dealer.Points < Player.Points && Dealer.HasToTake)
                {
                    Card card = Dealer.DrawTop(Deck);

                    Console.WriteLine(card.GetDetails());
                    Console.WriteLine($"Dealer's score is {Dealer.Points}");
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





        public static void DrawCard(int x, int y, Card card)
        {
            const int WIDTH = 9;
            const int HEIGHT = 7;

            string rankInitial = card.Rank.GetInitial();
            string suitIcon = card.Suit.Icon();
            ConsoleColor fg = card.Suit.Color();
            ConsoleColor bg = ConsoleColor.White;


            for (int i = 0; i < HEIGHT; i++)
            {
                DrawAt(x, y + i, " ".Repeat(WIDTH), bg, fg);
            }

            // drawing the 1st row
            DrawAt(x, y, rankInitial.InsertIntoStringWithPadLeft(" ".Repeat(WIDTH), 1), bg, fg);

            // drawing the last row
            DrawAt(x, y + HEIGHT - 1, rankInitial.InsertIntoStringWithPadRight(" ".Repeat(WIDTH), 1), bg, fg);

            // draw the suit in the center
            DrawAt(x + WIDTH / 2, y + HEIGHT / 2, suitIcon, bg, fg);

            // reset cursor position for the future
            Console.SetCursorPosition(x + WIDTH, y + HEIGHT - 1);
        }

        public static void DrawAt(int x, int y, string thing, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.Gray)
        {
            string[] chunks = thing.Split('\n');

            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;

            for (int i = 0; i < chunks.Length; i++)
            {
                string chunk = chunks[i];
                Console.SetCursorPosition(x, y + i);
                Console.Write(chunk);
            }

            Console.ResetColor();
        }
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
        public static string Stringify<T>(this IEnumerable<T> list)
        {
            return $"[ {string.Join(", ", list)} ]";
        }
    }

    public static class StringExtension
    {
        public static string InsertIntoStringWithPadLeft(this string str, string slate, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[..howMuchRemove];


            var slateSB = new StringBuilder(slate);
            slateSB.Remove(pad, howMuchRemove);
            slateSB.Insert(pad, strLimited);

            return slateSB.ToString();
        }

        public static string Repeat(this string str, int n)
        {
            return Enumerable.Repeat(str, n).Aggregate("", (acc, c) => acc + c);
        }


        public static string InsertIntoStringWithPadRight(this string str, string slate, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[^howMuchRemove..];


            var slateSB = new StringBuilder(slate);
            int where = slate.Length - pad - howMuchRemove;
            slateSB.Remove(where, howMuchRemove);
            slateSB.Insert(where, strLimited);

            return slateSB.ToString();
        }

    }

}