
namespace BackgammonLogic.Components
{
    public abstract class Player
    {
        protected enum PlayerType
        {
            Human
        }

        protected Player(PlayerType Type, PColorEnum Color)
        {
            this.Type = Type;
            this.Color = Color;
        }

        private readonly PlayerType Type;
        public readonly PColorEnum Color;

        public abstract void AskForRoll(GameStateController game);
        public abstract void AskForMove(GameStateController game);
    }
}
