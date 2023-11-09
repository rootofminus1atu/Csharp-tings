namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // player with a custom name (CreatePlayer gets input from the user)
            Player player = CreatePlayer();

            // dealer with the default name
            Dealer dealer = new Dealer();

            DrawingEngine engine = new DrawingEngine();
            Game g = new Game(player, dealer, engine);



            g.Play();

            while (true)
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                bool yesNo = Utils.CasePrompt(
                    ("y", true), 
                    ("n", false)
                );

                if (!yesNo)
                {
                    break;
                }

                g.PlayAgain();
            }
        }

        static Player CreatePlayer()
        {
            Console.Write("Enter player name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                return new Player();
            }
            
            return new Player(name);
        }
    }


    /// <summary>
    /// Draws cards and other inforomation to the console.
    /// </summary>
    public class DrawingEngine
    {

        /// <summary>
        /// Draws a <see cref="Card"/> to the screen at the given x and y coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate where the Card will be drawn.</param>
        /// <param name="y">The y-coordinate where the Card will be drawn.</param>
        /// <param name="card">The card that will be drawn.</param>
        private static void DrawCard(int x, int y, Card card)
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

        /// <summary>
        /// Draws a string on the console screen at the given x and y coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate where the string will be drawn.</param>
        /// <param name="y">The y-coordinate where the string will be drawn.</param>
        /// <param name="str">The string that will be drawm.</param>
        /// <param name="bg">The background color.</param>
        /// <param name="fg">The foreground color.</param>
        private static void DrawAt(int x, int y, string str, ConsoleColor bg = ConsoleColor.Black, ConsoleColor fg = ConsoleColor.Gray)
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

        /// <summary>
        /// Renders the UI to the console screen. 
        /// </summary>
        public void RenderDisplay(Game game)
        {
            Console.Clear();

            const int CORNER_X = 2;
            const int CORNER_Y = 1;

            const int ROW_JUMP_Y = 11;
            const int CARD_JUMP_X = 12;
            const int CARD_PAD_Y = 2;

            DrawAt(CORNER_X, CORNER_Y, $"Dealer ({game.Dealer.Points}) {game.Dealer.AllCardSymbolsString}");
            for (int i = 0; i < game.Dealer.Cards.Count; i++)
            {
                int x = CORNER_X + i * CARD_JUMP_X;
                int y = CORNER_Y + CARD_PAD_Y;

                DrawCard(x, y, game.Dealer.Cards[i]);
            }

            DrawAt(CORNER_X, CORNER_Y + ROW_JUMP_Y, $"{game.Player.Name} ({game.Player.Points}) {game.Player.AllCardSymbolsString}");
            for (int i = 0; i < game.Player.Cards.Count; i++)
            {
                int x = CORNER_X + i * CARD_JUMP_X;
                int y = CORNER_Y + ROW_JUMP_Y + CARD_PAD_Y;

                DrawCard(x, y, game.Player.Cards[i]);
            }

            Console.WriteLine("\n\n\n");
        }
    }


    public class Game : GameLogic
    {
        /// <summary>
        /// The time in miliseconds used to incrementally display the 3 cards at the start of the game.
        /// </summary>
        public const int SETUP_DELAY = 200;

        /// <summary>
        /// The time in miliseconds sued to incrementally display the Delaer's cards.
        /// </summary>
        public const int DEALER_DELAY = 1000;



        public DrawingEngine Drawer { get; }

        public Game(Player player, Dealer dealer, DrawingEngine engine) : base(player, dealer) 
        {
            Drawer = engine;
        }

        // NOTE:
        // There aren't that many comments here, because there's a lot of XML comments in the other classes already.
        // You can hover over "HandleSetup()" or "IsSticking" to see the details through intellisense.



        public override void HandleSetup()
        {
            Player.DrawTop(Deck);
            Drawer.RenderDisplay(this);

            Thread.Sleep(SETUP_DELAY);

            Player.DrawTop(Deck);
            Drawer.RenderDisplay(this);

            Thread.Sleep(SETUP_DELAY);

            Dealer.DrawTop(Deck);
            Drawer.RenderDisplay(this);

            // could use an observer here, whenever the deck changes we want to render
        }

        public override void HandlePlayerTurn()
        {
            Console.WriteLine("=== Player's turn ===");

            while (!Player.Bust && !Player.GotBlackjack && Player.IsTwisting)
            {
                Console.WriteLine("Do you want to stick or twist? (s/t)");
                StickOrTwist input = Utils.CasePrompt(
                    ("s", StickOrTwist.Stick),
                    ("t", StickOrTwist.Twist)
                );

                Player.StickOrTwist = input;

                if (Player.IsSticking)
                {
                    Drawer.RenderDisplay(this);
                    break;
                }

                Player.DrawTop(Deck);
                Drawer.RenderDisplay(this);
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
                Thread.Sleep(DEALER_DELAY);

                Dealer.DrawTop(Deck);
                Drawer.RenderDisplay(this);
            }
        }

        public override void HandleCleanup()
        {
            GameResult result = DetermineWinner();

            Console.ForegroundColor = result.FgColor();
            Console.WriteLine(result.Message());
            Console.ResetColor();
        }
    }
}