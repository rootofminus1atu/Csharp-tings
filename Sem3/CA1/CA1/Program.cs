using System.Collections;
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
            Console.OutputEncoding = Encoding.UTF8;
            Card cc = new(new Number(10), Suit.Clubs);


            Game g = new Game();
            g.Play();

            while (true)
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                bool yesNo = Utils.CasePrompt(("y", true), ("n", false));

                if (!yesNo)
                {
                    break;
                }

                g.PlayAgain();
            }


        }

        



        public class Game : GameLogic
        {
            public void RenderDisplay()
            {
                Console.Clear();

                const int CORNER_X = 2;
                const int CORNER_Y = 1;

                const int ROW_JUMP_Y = 11;
                const int CARD_JUMP_X = 12;
                const int CARD_PAD_Y = 2;

                DrawAt(CORNER_X, CORNER_Y, $"Dealer ({Dealer.Points}) {Dealer.AllCardSymbolsString}");
                for (int i = 0; i < Dealer.Cards.Count; i++)
                {
                    int x = CORNER_X + (i + 1) * CARD_JUMP_X;
                    int y = CORNER_Y + CARD_PAD_Y;

                    DrawCard(x, y, Dealer.Cards[i]);
                }

                DrawAt(CORNER_X, CORNER_Y + ROW_JUMP_Y, $"Player ({Player.Points}) {Player.AllCardSymbolsString}");
                for (int i = 0; i < Player.Cards.Count; i++)
                {
                    int x = CORNER_X + (i + 1) * CARD_JUMP_X;
                    int y = CORNER_Y + ROW_JUMP_Y + CARD_PAD_Y;

                    DrawCard(x, y, Player.Cards[i]);
                }

                Console.WriteLine("\n\n\n");
            }

            public override void HandleSetup()
            {
                Player.DrawTop(Deck);
                RenderDisplay();
                Thread.Sleep(200);

                Player.DrawTop(Deck); 
                RenderDisplay();
                Thread.Sleep(200);

                Dealer.DrawTop(Deck);
                RenderDisplay();

                // could use an observer here, whenever the deck changes we want to render
            }

            public override void HandlePlayerTurn()
            {
                Console.WriteLine("=== Player's turn ===");

                while (!Player.Bust && !Player.GotBlackjack && Player.IsTwisting)
                {
                    Console.WriteLine("Do you want to stick or twist? (s/t): ");
                    StickOrTwist input = Utils.CasePrompt(
                        ("s", StickOrTwist.Stick), 
                        ("t", StickOrTwist.Twist)
                    );

                    Player.StickOrTwist = input;

                    if (Player.IsSticking)
                    {
                        RenderDisplay();
                        break;
                    }

                    Player.DrawTop(Deck);
                    RenderDisplay();
                }

                if (Player.GotBlackjack)
                {
                    Console.WriteLine("BLACKJACK!");
                    SkipDealerTurn();
                    return;
                }

                if (Player.Bust)
                {
                    SkipDealerTurn();
                    return;
                }

            }

            public override void HandleDealerTurn()
            {
                Console.WriteLine("=== Dealer's turn ===");

                while (Dealer.HasToTake)
                {
                    Thread.Sleep(1000);

                    Dealer.DrawTop(Deck);
                    RenderDisplay();
                }
            }

            public override void HandleCleanup()
            {
                GameResult result = DetermineWinner();

                Console.ForegroundColor = result.FgColor();
                Console.WriteLine(result.Message());
                Console.ResetColor();
            }

            public GameResult DetermineWinner()
            {
                if (Player.Bust)
                {
                    return GameResult.PlayerBust;
                }
                else if (Dealer.Bust)
                {
                    return GameResult.DealerBust;
                }
                else if (Player.Points == Dealer.Points)
                {
                    return GameResult.Draw;
                }
                else if (Player.Points > Dealer.Points)
                {
                    return GameResult.PlayerWins;
                }
                else
                {
                    return GameResult.DealerWins;
                }
            }
        }






        public static void DrawCard(int x, int y, Card card)
        {
            const int WIDTH = 9;
            const int HEIGHT = 7;

            string rankInitial = card.Rank.Initial();
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

        public static void DrawAt(int x, int y, string str, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.Gray)
        {
            string[] chunks = str.Split('\n');

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

}