using System.Drawing;

namespace BackgammonLogic.Components
{
    public static class ColorsAndConstants
    {
        public const int FieldSize = 50;
        public const bool White = false;
        public const bool Black = true;
        public const bool Upper = true;
        public const bool Lower = false;

        public const int Nowhere = 26;
        public const int WhiteBand = 24;
        public const int BlackBand = 25;

        public const int DiceSize = 56;
        public const int DiceDotSize = 10;

        public static readonly Brush WhiteStoneBrush = Brushes.BurlyWood;
        public static readonly Brush BlackStoneBrush = Brushes.Maroon;
        public static readonly Font StoneFont = new Font("Arial", 20.0f);
        public static readonly Color BackgroundColor = Color.DimGray;
        public static readonly Brush BandBrush = Brushes.CadetBlue;

        public static readonly Color SourceLight = Color.Green;
        public static readonly Color TargetLight = Color.Yellow;

        public static readonly Point DicePoint = new Point(6 * FieldSize, 6 * FieldSize);
        public static readonly Pen SelectionPen = Pens.Blue;
    }
}
