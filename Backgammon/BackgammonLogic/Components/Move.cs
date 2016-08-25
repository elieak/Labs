using System;

namespace BackgammonLogic.Components
{
    public class Move : IComparable<Move>, IEquatable<Move>
    {


        public Move(int _SourceField, int _TargetField, PColorEnum _Color)
        {

            SourceField = _SourceField;
            TargetField = _TargetField;
            Color = _Color;
        }

        public readonly int SourceField;
        public readonly int TargetField;
        public readonly PColorEnum Color;
        public int Length
        {
            get
            {
                switch (SourceField)
                {
                    case ColorsAndConstants.WhiteBand:
                        return SourceField - TargetField - 18;
                    case ColorsAndConstants.BlackBand:
                        return TargetField + 8 - SourceField;
                }

                if (TargetField != ColorsAndConstants.Nowhere) return Math.Abs(TargetField - SourceField);
                if (Color == PColorEnum.White)
                {
                    return 24 - SourceField;
                }
                return SourceField + 1;
            }
        }

        int IComparable<Move>.CompareTo(Move move)
        {
            if (SourceField > move.SourceField) return 1;
            if (SourceField < move.SourceField) return -1;
            if (TargetField > move.TargetField) return 1;
            if (TargetField < move.TargetField) return -1;
            if (Color > move.Color) return 1;
            if (Color < move.Color) return -1;
            return 0;
        }
        bool IEquatable<Move>.Equals(Move move)
        {
            return
                (Color == move.Color) &&
                (SourceField == move.SourceField) &&
                (TargetField == move.TargetField);
        }

        public override int GetHashCode()
        {
            var r = 100 * SourceField + TargetField;
            if (Color == PColorEnum.White) r += 30000;
            else r += 50000;
            return r;
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;

            var move = obj as Move;
            if (move == null) return false;

            return
                (Color == move.Color) &&
                (SourceField == move.SourceField) &&
                (TargetField == move.TargetField);
        }

        public static Move EmptyMove(PColorEnum playerColor)
        {
            return new Move(0, 0, playerColor);
        }

        public bool IsEmpty => SourceField == 0 && TargetField == 0;
    }
}
