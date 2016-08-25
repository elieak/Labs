using BackgammonLogic.Components;

namespace BackgammonGame
{
    public class HPlayer : Player
    {
        private Form1 Window;

        public HPlayer(PColorEnum Color, Form1 Window)
            : base(PlayerType.Human, Color)
        {
            this.Window = Window;
        }

        private GameStateController currentGame;

        public override void AskForMove(GameStateController game)
        {
            currentGame = game;
            if (currentGame.GameState.PossibleMoves.Length > 0)
            {
                Window.EnableInputFor(this);
            }
            else
            {
                Window.ShowMessage("There is no available move, you lose a turn");
                var r = currentGame.RegisterMove(Move.EmptyMove(Color));
                if (r.Result != MoveResult.ResultType.Positive)
                    Window.ShowMessage("Internal Software Error");
            }
        }

        public override void AskForRoll(GameStateController game)
        {
            currentGame = game;
            Window.EnableRoll(this);
        }

        public void ReceiveMove(Move m)
        {
            var r = currentGame.RegisterMove(m);
            if (r.Result == MoveResult.ResultType.Negative)
                Window.ShowMessage(r.Description);
        }
    }
}