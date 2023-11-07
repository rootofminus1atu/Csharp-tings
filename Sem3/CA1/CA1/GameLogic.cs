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
        GameOver,
        GameExit
    }

    public enum GameResult
    {
        PlayerBust,
        DealerBust,
        Draw,
        PlayerWins,
        DealerWins
    }


    public abstract class GameLogic
    {
        public Player Player { get; set; } = new Player();
        public Dealer Dealer { get; set; } = new Dealer();
        public Deck Deck { get; set; } = new Deck();
        public GameState GameState { get; set; } = GameState.NewGame;  // do I even need this?
        public GameResult GameResult { get; set; }


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

        public void OldPlay()
        {
            HandleSetup();

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

            HandleCleanup();
        }

        public void PlayAgain()
        {
            Reset();
            Play();
        }

        public void Reset()
        {
            Deck.Reset();
            Player.ResetHand();
            Dealer.ResetHand();
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
