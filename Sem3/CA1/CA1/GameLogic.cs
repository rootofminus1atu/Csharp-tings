using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    public enum StickOrTwist
    {
        Stick,
        Twist
    }

    public enum GameResult
    {
        PlayerBust,
        DealerBust,
        Draw,
        PlayerWins,
        DealerWins
    }

    public static class GameResultExtension
    {
        public static ConsoleColor FgColor(this GameResult gameResult)
        {
            return gameResult switch
            {
                GameResult.PlayerBust => ConsoleColor.Red,
                GameResult.DealerBust => ConsoleColor.Green,
                GameResult.Draw => ConsoleColor.Yellow,
                GameResult.PlayerWins => ConsoleColor.Green,
                GameResult.DealerWins => ConsoleColor.Red,
                _ => throw new ArgumentException("Invalid GameResult variant")
            };
        }

        public static string Message(this  GameResult gameResult)
        {
            return gameResult switch 
            {
                GameResult.PlayerWins => "Player wins!",
                GameResult.DealerWins => "Dealer wins!",
                GameResult.Draw => "It's a draw!",
                GameResult.PlayerBust => "Dealer wins - Player busts",
                GameResult.DealerBust => "Player wins - Dealer busts",
                _ => throw new ArgumentException("Invalid GameResult variant")
            };
        }
    }


    public abstract class GameLogic
    {
        public Player Player { get; } = new Player();
        public Dealer Dealer { get; } = new Dealer();
        public Deck Deck { get; } = new Deck();


        private bool _skipDealerTurn = false;



        public GameLogic() { }


        public void Play()
        {
            HandleSetup();
            HandlePlayerTurn();
            if (!_skipDealerTurn)
                HandleDealerTurn();
            HandleCleanup();
        }

        public void PlayAgain()
        {
            Reset();
            Play();
        }

        private void Reset()
        {
            Deck.Reset();
            Player.ResetHand();
            Dealer.ResetHand();
            _skipDealerTurn = false;
        }

        public void SkipDealerTurn()
        {
            _skipDealerTurn = true;
        }

        public abstract void HandleSetup();
        public abstract void HandleCleanup();
        public abstract void HandlePlayerTurn();
        public abstract void HandleDealerTurn();

    }
}
