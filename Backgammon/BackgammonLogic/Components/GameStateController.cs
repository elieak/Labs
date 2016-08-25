using System.Collections.Generic;
using System.Linq;
using BackgammonLogic.Interfaces;

namespace BackgammonLogic.Components
{
    public class GameStateController
    {
        public GameStateController(Player PlayerWhite, Player PlayerBlack)
        {
            this.PlayerBlack = PlayerBlack;
            this.PlayerWhite = PlayerWhite;

            _gameState = GetNewGameState();
        }

        private GameState _gameState;
        public GameState GameState
        {
            get { return _gameState; }
            private set
            {
                _gameState = value;
                CallOnGamestateUpdate();
            }
        }

        private Player PlayerWhite { get; }

        private Player PlayerBlack { get; }

        private Dice _dice;

        public Scene GetScene()
        {
            var scene = _gameState == null ? new Scene(new List<Drawable>(), new int[0], new Dictionary<int, int[]>()) 
                : new Scene(new List<Drawable>(_gameState.CurrentFields), _gameState.PossibleSources, _gameState.PossibleTargets);

            if (_dice != null)
                scene.Items.Add(_dice);
            return scene;
        }

        private static GameState GetNewGameState()
        {
            return new GameState(GameState.Phase.PreGame, PColorEnum.White, GameState.GetInitialFields(), null, new GameState.PreGame());
        }

        public MoveResult RegisterMove(Move move)
        {
            if (_gameState.CurTurnType != GameState.TurnType.Move) return new MoveResult(MoveResult.ResultType.Negative, "You must roll the dice");

            if (move == null)
                return new MoveResult(MoveResult.ResultType.Negative, "Attempting to make a wrong move");

            if (_gameState.CurrentTurn != move.Color)
                return new MoveResult(MoveResult.ResultType.Negative, "Not your turn");

            if (move.IsEmpty)
                if (_gameState.PossibleMoves.Length == 0)
                {

                    GameState = new GameState(GameState.CurPhase, GetOpposite(GameState.CurrentTurn), (AbstractField[])GameState.CurrentFields.Clone(), null, GameState.CurPreGame);
                    return new MoveResult(MoveResult.ResultType.Positive, null);
                }
                else return new MoveResult(MoveResult.ResultType.Negative, "Attempting to make a wrong move");


            if (!_gameState.PossibleMoves.Contains(move))
                return new MoveResult(MoveResult.ResultType.Negative, "Can't move like that...");

            var newFields = (AbstractField[])_gameState.CurrentFields.Clone();
            var newTurn = _gameState.CurrentTurn;
            var newDiceState = _gameState.CurDiceState.ReducedByOne(move.Length);

            newFields[move.SourceField].RemoveStone(move.Color);
            newFields[move.TargetField].AddStone(move.Color);

            if (newFields[move.TargetField].StonesOfColor(GetOpposite(move.Color)) == 1)
            {
                newFields[move.TargetField].RemoveStone(GetOpposite(move.Color));
                if (GetOpposite(move.Color) == PColorEnum.White)
                    newFields[ColorsAndConstants.WhiteBand].AddStone(PColorEnum.White);
                else newFields[ColorsAndConstants.BlackBand].AddStone(PColorEnum.Black);
            }

            if (newDiceState.Pipes.Length == 0)
            {
                newDiceState = null;
                newTurn = GetOpposite(newTurn);
            }

            var newGameState = new GameState(_gameState.CurPhase, newTurn, newFields, newDiceState, GameState.CurPreGame);

            if (_gameState.CurDiceState?.PrimevalLength == 2 &&
                _gameState.CurDiceState.Pipes.Length == 2)
                if (move.Length == _gameState.CurDiceState.Pipes[0])
                    if (newGameState.PossibleMoves.Length == 0)
                        return new MoveResult(MoveResult.ResultType.Negative, "Wrong Move.");

            GameState = newGameState;

            return new MoveResult(MoveResult.ResultType.Positive, null);
        }

        private MoveResult RegisterNewDice()
        {
            if (_gameState.CurPhase == GameState.Phase.One)
            {
                if (_gameState.CurDiceState != null)
                    return new MoveResult(MoveResult.ResultType.Negative,string.Empty);

                GameState = new GameState(_gameState.CurPhase, _gameState.CurrentTurn, (AbstractField[])_gameState.CurrentFields.Clone(), _dice.GetDiceState(), _gameState.CurPreGame);
                return new MoveResult(MoveResult.ResultType.Positive, null);
            }
            if (GameState.CurPreGame.PutPreGameDice(GameState.CurrentTurn, _dice.Sum))
            {
                if (GameState.CurPreGame.PreGameWinner != null)
                {
                    GameState = new GameState(GameState.Phase.One, (PColorEnum)GameState.CurPreGame.PreGameWinner, (AbstractField[])GameState.CurrentFields.Clone(), null, GameState.CurPreGame);
                }
                else
                {
                    GameState = new GameState(GameState.Phase.PreGame, GetOpposite(GameState.CurrentTurn), (AbstractField[])GameState.CurrentFields.Clone(), null, GameState.CurPreGame);
                }
                return new MoveResult(MoveResult.ResultType.Positive, null);
            }
            return new MoveResult(MoveResult.ResultType.Negative, "PreGame is over");
        }

        public MoveResult RollTheDice(Player player)
        {
            if (GameState.CurrentTurn != player.Color) return new MoveResult(MoveResult.ResultType.Negative, "Your turn");

            _dice = Dice.GetNewDice();

            var res = RegisterNewDice();
            CallOnGamestateUpdate();

            return res;
        }

        private static PColorEnum GetOpposite(PColorEnum playerColor)
        {
            if (playerColor == PColorEnum.White) return PColorEnum.Black;
            return PColorEnum.White;
        }

        public List<IGameControllerEvent> Listeners { get; } = new List<IGameControllerEvent>();

        public void CallOnGamestateUpdate()
        {
            Proceed();
            foreach (var listener in Listeners)
                listener.OnGamestateUpdate();
        }

        private void Proceed()
        {
            if (GameState.Winner == null)
            {
                if (GameState.CurrentTurn == PColorEnum.White)
                {
                    if (GameState.CurTurnType == GameState.TurnType.Move)
                        PlayerWhite.AskForMove(this);
                    else
                        PlayerWhite.AskForRoll(this);
                }
                else
                {
                    if (GameState.CurTurnType == GameState.TurnType.Move)
                        PlayerBlack.AskForMove(this);
                    else
                        PlayerBlack.AskForRoll(this);
                }
            }
            else
            {
                foreach (var listener in Listeners)
                    listener.OnGameEnd();
            }
        }
    }
}
