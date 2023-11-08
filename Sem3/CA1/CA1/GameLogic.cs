using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    /// <summary>
    /// Represents the decision of whether to stick or twist in a card game.
    /// </summary>
    public enum StickOrTwist
    {
        Stick,
        Twist
    }

    /// <summary>
    /// Represents the possible outcomes of a blackjack game.
    /// </summary>
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
        /// <summary>
        /// Gets the foreground color associated with a specific game result.
        /// </summary>
        /// <param name="gameResult">The game result value.</param>
        /// <returns>The foreground color for displaying this game result.</returns>
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

        /// <summary>
        /// Gets a message associated with a specific game result.
        /// </summary>
        /// <param name="gameResult">The game result value.</param>
        /// <returns>A message describing the outcome of the game based on this result.</returns>
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

    /// <summary>
    /// Represents the base logic for a blackjack game.
    /// </summary>
    public abstract class GameLogic
    {
        /// <summary>
        /// The player participating in the game.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// The dealer participating in the game.
        /// </summary>
        public Dealer Dealer { get; } = new Dealer();

        /// <summary>
        /// The deck of cards used in the game.
        /// </summary>
        public Deck Deck { get; } = new Deck();

        /// <summary>
        /// Whether to skip the dealer's turn or not.
        /// </summary>
        private bool _skipDealerTurn = false;


        /// <summary>
        /// Initializes a new instance of the GameLogic class with the specified player.
        /// </summary>
        /// <param name="player">The player participating in the game.</param>
        public GameLogic(Player player) 
        {
            Player = player;
        }

        /// <summary>
        /// Plays a game round, including setup, player's turn, dealer's turn (if not skipped), and cleanup.
        /// </summary>
        public void Play()
        {
            HandleSetup();
            HandlePlayerTurn();
            if (!_skipDealerTurn)
                HandleDealerTurn();
            HandleCleanup();
        }

        /// <summary>
        /// Resets the game and plays it again.
        /// </summary>
        public void PlayAgain()
        {
            Reset();
            Play();
        }

        /// <summary>
        /// Resets the game, by reseting the Deck, Player and Dealer.
        /// </summary>
        private void Reset()
        {
            Deck.Reset();
            Player.ResetHand();
            Dealer.ResetHand();
            _skipDealerTurn = false;
        }

        /// <summary>
        /// Skips the dealer's turn in the current round.
        /// </summary>
        public void SkipDealerTurn()
        {
            _skipDealerTurn = true;
        }

        /// <summary>
        /// Handles the setup phase of the game.
        /// </summary>
        public abstract void HandleSetup();

        /// <summary>
        /// Handles the cleanup phase of the game.
        /// </summary>
        public abstract void HandleCleanup();

        /// <summary>
        /// Handles the Player's turn in the game.
        /// </summary>
        public abstract void HandlePlayerTurn();

        /// <summary>
        /// Handles the Dealer's turn in the game.
        /// </summary>
        public abstract void HandleDealerTurn();

    }
}
