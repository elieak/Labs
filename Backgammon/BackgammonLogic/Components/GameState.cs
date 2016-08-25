using System;
using System.Collections.Generic;
using System.Linq;

namespace BackgammonLogic.Components
{
    public class GameState
    {
        public enum Phase
        {
            PreGame,
            One
        }

        public enum TurnType
        {
            Roll,
            Move
        }

        public AbstractField[] CurrentFields { get; }

        public Phase CurPhase { get; }

        public DiceState CurDiceState { get; }

        public PColorEnum CurrentTurn { get; }

        public PColorEnum? Winner
        {
            get
            {
                if (CurrentFields[ColorsAndConstants.BlackBand].StonesOfColor(PColorEnum.Black) == 15)
                    return PColorEnum.Black;
                if (CurrentFields[ColorsAndConstants.WhiteBand].StonesOfColor(PColorEnum.White) == 15)
                    return PColorEnum.White;
                return null;
            }
        }

        public readonly PreGame CurPreGame;

        public TurnType CurTurnType
        {
            get
            {
                if (CurPhase == Phase.PreGame) return TurnType.Roll;
                if (CurDiceState == null) return TurnType.Roll;
                return TurnType.Move;
            }
        }

        public GameState(Phase _phase, PColorEnum _turn, AbstractField[] _fields, DiceState _dicestate, PreGame _preGame)
        {
            CurDiceState = _dicestate;
            CurrentTurn = _turn;
            CurrentFields = _fields;
            CurPhase = _phase;
            CurPreGame = _preGame;

            CalculatePossibleMoves();
        }

        public static AbstractField[] GetInitialFields()
        {
            var field = new AbstractField[27];

            for (var i = 0; i < 24; ++i)
                field[i] = Field.MakeField(i);

            field[ColorsAndConstants.WhiteBand] = Band.MakeBand(PColorEnum.White);
            field[ColorsAndConstants.BlackBand] = Band.MakeBand(PColorEnum.Black);
            field[ColorsAndConstants.Nowhere] = NoWhere.GetNowhere();

            field[0].WhiteStones = 2;
            field[5].BlackStones = 5;
            field[7].BlackStones = 3;
            field[11].WhiteStones = 5;
            field[12].BlackStones = 5;
            field[16].WhiteStones = 3;
            field[18].WhiteStones = 5;
            field[23].BlackStones = 2;

            return field;
        }

        public Move[] PossibleMoves { get; private set; }

        public int[] PossibleSources { get; private set; }

        public Dictionary<int, int[]> PossibleTargets { get; private set; }

        private bool IsPlayerWhiteHome()
        {
            if (CurrentFields[ColorsAndConstants.WhiteBand].WhiteStones > 0) return false;
            var result = true;
            for (var i = 0; i < 18; ++i)
                if (CurrentFields[i].WhiteStones > 0)
                {
                    result = false;
                    break;
                }
            return result;
        }

        private bool IsPlayerBlackHome()
        {
            if (CurrentFields[ColorsAndConstants.BlackBand].BlackStones > 0) return false;
            var result = true;
            for (var i = 6; i < 24; ++i)
                if (CurrentFields[i].BlackStones > 0)
                {
                    result = false;
                    break;
                }
            return result;
        }

        private void CalculatePossibleMoves()
        {
            var state = CurDiceState;

            if (state == null || CurPhase == Phase.PreGame)
            {
                PossibleMoves = new Move[0];
                PossibleSources = new int[0];
                PossibleTargets = new Dictionary<int, int[]>();
                return;
            }

            var moves = new Dictionary<Move, object>();

            if (CurrentTurn == PColorEnum.White)
            {
                if (CurrentFields[ColorsAndConstants.WhiteBand].WhiteStones == 0)
                {
                    foreach (var pipeState in state.Pipes)
                    {
                        for (var i = 0; i < 24; ++i)
                            if (CurrentFields[i].IsAccessibleFor(PColorEnum.White))
                                if (i - pipeState >= 0)
                                    if (CurrentFields[i - pipeState].WhiteStones > 0)
                                    {
                                        var move = new Move(i - pipeState, i, CurrentTurn);
                                        if (!moves.ContainsKey(move))
                                            moves.Add(move, null);
                                    }
                    }
                }
                else
                {
                    var magicNumber = 6;
                    foreach (var pipe in state.Pipes)
                    {
                        var target = magicNumber - pipe;
                        if (CurrentFields[target].IsAccessibleFor(PColorEnum.White))
                        {
                            var move = new Move(ColorsAndConstants.WhiteBand, target, CurrentTurn);
                            if (!moves.ContainsKey(move))
                                moves.Add(move, null);
                        }
                    }
                }

                if (IsPlayerWhiteHome())
                {

                    foreach (var pipe in state.Pipes)
                    {
                        var source = 24 - pipe;
                        if (source <= 0 || source >= 23) continue;
                        if (CurrentFields[source].WhiteStones <= 0) continue;
                        var move = new Move(source, ColorsAndConstants.Nowhere, CurrentTurn);
                        if (!moves.ContainsKey(move))
                            moves.Add(move, null);
                    }
                }
            }
            else
            {
                if (CurrentFields[ColorsAndConstants.BlackBand].BlackStones == 0)
                {
                    foreach (var pipe in state.Pipes)
                    {
                        for (var i = 0; i < 24; ++i)
                            if (CurrentFields[i].IsAccessibleFor(PColorEnum.Black))
                                if (i + pipe < CurrentFields.Length)
                                    if (CurrentFields[i + pipe].BlackStones > 0)
                                    {
                                        var m = new Move(i + pipe, i, CurrentTurn);
                                        if (!moves.ContainsKey(m))
                                            moves.Add(m, null);
                                    }
                    }
                }
                else
                {
                    foreach (var pipe in state.Pipes)
                    {
                        var target = ColorsAndConstants.BlackBand + pipe - 8;
                        if (!CurrentFields[target].IsAccessibleFor(PColorEnum.Black)) continue;
                        var move = new Move(ColorsAndConstants.BlackBand, target, CurrentTurn);
                        if (!moves.ContainsKey(move))
                            moves.Add(move, null);
                    }
                }

                if (IsPlayerBlackHome()) // wywalanie
                {

                    foreach (var pipe in state.Pipes)
                    {
                        var source = pipe - 1;
                        if (source <= 0 || source >= 23) continue;
                        if (CurrentFields[source].BlackStones <= 0) continue;
                        var move = new Move(source, ColorsAndConstants.Nowhere, CurrentTurn);
                        if (!moves.ContainsKey(move))
                            moves.Add(move, null);
                    }
                }

            }

            var result = moves.Keys.ToArray();

            var resutDict = new Dictionary<int, List<int>>();

            foreach (var moveResult in result)
            {
                var source = moveResult.SourceField;
                var target = moveResult.TargetField;

                if (!resutDict.ContainsKey(source))
                    resutDict.Add(source, new List<int>());

                resutDict[source].Add(target);
            }

            PossibleSources = resutDict.Keys.ToArray();

            PossibleTargets = new Dictionary<int, int[]>();
            foreach (var pipe in resutDict)
                PossibleTargets.Add(pipe.Key, pipe.Value.ToArray<int>());


            PossibleMoves = result;
        }

        private int WhitePlayerNeeds()
        {
            if (CurrentFields[ColorsAndConstants.WhiteBand].WhiteStones > 0) return -1;

            var result = 0;
            for (var i = 0; i < 24; ++i)
            {
                result += (CurrentFields[i].WhiteStones) * (24 - i);
            }
            return result;
        }

        private int BlackPlayerNeeds()
        {
            if (CurrentFields[ColorsAndConstants.BlackBand].BlackStones > 0) return -1;

            var result = 0;
            for (var i = 0; i < 24; ++i)
            {
                result += (CurrentFields[i].BlackStones) * (i + 1);
            }
            return result;
        }

        public int PlayerNeeds(PColorEnum Color)
        {
            return Color == PColorEnum.White ? WhitePlayerNeeds() : BlackPlayerNeeds();
        }

        public class PreGame
        {
            public PreGame()
            {
                PreWhiteSum = 0;
                PreBlackSum = 0;
            }

            private int PreWhiteSum, PreBlackSum;
            public PColorEnum? PreGameWinner
            {
                get
                {
                    if (PreBlackSum == 0 || PreWhiteSum == 0) return null;
                    if (PreBlackSum > PreWhiteSum) return PColorEnum.Black;
                    if (PreWhiteSum > PreBlackSum) return PColorEnum.White;
                    return null;
                }
            }
            public bool PutPreGameDice(PColorEnum Color, int sum)
            {
                if (PreGameWinner != null) return false;

                if (Color == PColorEnum.White)
                    PreWhiteSum = sum;
                else
                {
                    PreBlackSum = sum;
                    if (PreWhiteSum != PreBlackSum) return true;
                    PreBlackSum = 0;
                    PreWhiteSum = 0;
                }

                return true;
            }

        }

    }
}

