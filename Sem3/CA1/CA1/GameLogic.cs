using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
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
        public Player Player { get; set; } = new Player();
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
}
