using System;
using System.Drawing;

namespace BackgammonLogic.Components
{
    [Serializable]
    public abstract class AbstractField : Drawable
    {
        protected AbstractField(Rectangle _Rect, int _Number)
            : base(_Rect)
        {
            BlackStones = 0;
            WhiteStones = 0;
            Number = _Number;
        }

        public int BlackStones;
        public int WhiteStones;

        public abstract bool IsAccessibleFor(PColorEnum playerColor);

        public abstract void DrawWithLight(Graphics graphics, Color color);

        public int SumStones => BlackStones + WhiteStones;

        public int StonesOfColor(PColorEnum Color)
        {
            if (Color == PColorEnum.Black)
                return BlackStones;
            return WhiteStones;
        }

        public bool AddStone(PColorEnum Color)
        {
            if (IsAccessibleFor(Color) == false) return false;

            if (Color == PColorEnum.White)
                WhiteStones++;
            else BlackStones++;

            return true;
        }

        public bool RemoveStone(PColorEnum Color)
        {
            if (Color == PColorEnum.White)
            {
                if (WhiteStones <= 0) return false;
                WhiteStones--;
                return true;
            }
            if (BlackStones <= 0) return false;
            BlackStones--;
            return true;
        }

        public readonly int Number;
    }
}
