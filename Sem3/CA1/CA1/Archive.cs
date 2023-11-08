using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class Archive
    {
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

        static string InsertIntoStringWithPadLeft(string slate, string str, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[..howMuchRemove];


            var slateSB = new StringBuilder(slate);
            slateSB.Remove(pad, howMuchRemove);
            slateSB.Insert(pad, strLimited);

            return slateSB.ToString();
        }

        static string InsertIntoStringWithPadRight(string slate, string str, int pad)
        {
            int howMuchRemove = Math.Min(str.Length, slate.Length - pad);

            string strLimited = str[^howMuchRemove..];


            var slateSB = new StringBuilder(slate);
            int where = slate.Length - pad - howMuchRemove;
            slateSB.Remove(where, howMuchRemove);
            slateSB.Insert(where, strLimited);

            return slateSB.ToString();
        }

        static string InsertIntoSlateWithPadLeft(string slate, string str, int pad)
        {
            string extended = ExtendWithLeftPad(slate, str, pad);

            var inserted = slate
                .Zip(extended, (c1, c2) => c2 == '\0' ? c1 : c2)
                .Aggregate("", (acc, c) => acc + c);

            return inserted;
        }

        static string ExtendWithLeftPad(string slate, string str, int pad)
        {
            int maxLength = slate.Length - pad;
            var result = Enumerable
                .Repeat('\0', pad)
                .Concat(str.Take(maxLength))
                .Concat(Enumerable.Repeat('\0', maxLength - Math.Min(maxLength, str.Length)));


            return string.Join("", result);
        }

        static string ExtendWithRightPad(string slate, string str, int pad)
        {
            int maxLength = slate.Length - pad;

            var result = Enumerable
                .Repeat('\0', maxLength - Math.Min(maxLength, str.Length))
                .Concat(str.TakeLast(maxLength))
                .Concat(Enumerable.Repeat('\0', pad));

            return string.Join("", result);
        }

        /*
        static char[] ExtendWithRightPad(char[] slate, char[] str, int pad)
        {
            int maxLength = slate.Length - pad;

            char[] result = Enumerable
                .Repeat('\0', maxLength - Math.Min(maxLength, str.Length))
                .Concat(str.TakeLast(maxLength))
                .Concat(Enumerable.Repeat('\0', pad))
                .ToArray();

            return result;
        }
        */

        
        public static string InsertWithLeftSpace2(string slate, string thing, int space)
        {
            // string total = "";

            // ok maybe not
            char[] slateArr = slate.ToCharArray();
            // Console.WriteLine(thing.ToCharArray().Prepend('\0');


            return "";
        }

        public static string InsertWithLeftSpace(string slate, string inserted, int space)
        {
            string total = "";

            int j = 0;

            for (int i = 0; i < slate.Length; i++)
            {
                if (i >= space && j < inserted.Length)
                {
                    total += inserted[j];
                    j++;
                }
                else
                {
                    total += slate[i];
                }
            }

            return total;
        }












        public static void DrawCard(int x, int y, Card card)
        {
            const int WIDTH = 11;
            const int HEIGHT = 9;

            string rankInitial = card.Rank.Initial();
            string suitIcon = card.Suit.Icon();
            ConsoleColor fg = card.Suit.Color();
            // ConsoleColor bg = ConsoleColor.White;

            // isolate this below
            var rankIndex1 = (1, 0);
            var rankIndex2 = (WIDTH - 2, HEIGHT - 1);
            var suitIndex = (WIDTH / 2, HEIGHT / 2);
            List<(int, int)> rankIndeces = new() { rankIndex1, rankIndex2 };
            List<(int, int)> suitIndeces = new() { suitIndex };

            // replace with more efficient string blank slate

            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    string thingToDraw = (i, j) switch
                    {
                        //_ when (i, j) == rankIndex1 => rankInitial,
                        //_ when (i, j) == rankIndex2 => rankInitial,
                        //_ when (i, j) == suitIndex => suitIcon,
                        _ => " "
                    };

                    //DrawAt(x + i, y + j, thingToDraw, bg, fg);
                }
            }


            /*
            foreach (var (i, j) in suitIndeces)
            {
                DrawAt(x + i, y + j, suitIcon, bg, fg);
            }

            foreach (var (i, j) in  rankIndeces)
            {
                DrawAt(x + i, y + j, rankInitial, bg, fg);
            }
            */

            // drawing the 1st row
            //DrawAt(x, y, rankInitial.InsertIntoStringWithPadLeft(" ".Repeat(WIDTH), 1), bg, fg);

            // drawing the last row
            //DrawAt(x, y + HEIGHT, rankInitial.InsertIntoStringWithPadRight(" ".Repeat(WIDTH), 1), bg, fg);

            Console.SetCursorPosition(x + WIDTH, y + HEIGHT);
        }
    }

    public class ConsoleGame : GameLogic
    {
        public ConsoleGame(Player player) : base(player) { }

        public override void HandleSetup()
        {
            Console.WriteLine("new game start");
            Deck.Shuffle();

            //GameState = GameState.PlayerTurn;
        }

        public override void HandleCleanup()
        {
            Console.WriteLine("Final scores:");
            Console.WriteLine($"Your score is {Player.Points}");
            Console.WriteLine($"Dealer's score is {Dealer.Points}");

            DetermineWinner();
            /*
            string resultMessage = GameResult switch
            {
                GameResult.PlayerWins => "Player wins!",
                GameResult.DealerWins => "Dealer wins!",
                GameResult.Draw => "It's a draw!",
                GameResult.PlayerBust => "Dealer wins - Player busts",
                GameResult.DealerBust => "Player wins - Dealer busts",
                _ => "Invalid game result"
            };

            Console.WriteLine(resultMessage);*/
        }

        public void DetermineWinner()
        {
            if (Player.Bust)
            {
                //GameResult = GameResult.PlayerBust;
            }
            else if (Dealer.Bust)
            {
                //GameResult = GameResult.DealerBust;
            }
            else if (Player.Points == Dealer.Points)
            {
                //GameResult = GameResult.Draw;
            }
            else if (Player.Points > Dealer.Points)
            {
                //GameResult = GameResult.PlayerWins;
            }
            else
            {
                //GameResult = GameResult.DealerWins;
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
                //GameState = GameState.GameOver;
                return;
            }

            if (Player.Bust)
            {
                Console.WriteLine("Oh no you bust :(");
                //GameState = GameState.GameOver;
                return;
            }

            //GameState = GameState.DealerTurn;
        }

        public override void HandleDealerTurn()
        {
            while (Dealer.Points < Player.Points && Dealer.HasToTake)
            {
                Card card = Dealer.DrawTop(Deck);

                Console.WriteLine(card.ToStringLong());
                Console.WriteLine($"Dealer's score is {Dealer.Points}");
            }

            if (Dealer.Bust)
            {
                Console.WriteLine("Dealer bust...");
                //GameState = GameState.GameOver;
            }

            //GameState = GameState.GameOver;
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

    public class Testing
    {
        public static void DeckDemo()
        {
            Deck d1 = new();
            d1.Shuffle();

            Console.WriteLine(d1.Cards.Stringify());

            Card c = d1.DrawBottom();
            Console.WriteLine(c);

            Console.WriteLine(d1.Cards.Stringify());

            Console.WriteLine("♥ ♣ ♦ ♠ ♤ ♡ ♧ ♢");
        }

        public static void CardDemo()
        {
            Card c1 = new(new King(), Suit.Diamonds);
            Console.WriteLine(c1);
        }
    }
}
