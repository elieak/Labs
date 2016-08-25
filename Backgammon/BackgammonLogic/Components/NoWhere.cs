using System.Drawing;

namespace BackgammonLogic.Components
{
    internal class NoWhere : AbstractField
    {
        private NoWhere(Rectangle _Rect)
            : base(_Rect, ColorsAndConstants.Nowhere)
        {
        }

        public static NoWhere GetNowhere()
        {
            var rectangle = new Rectangle(14 * ColorsAndConstants.FieldSize, 0, ColorsAndConstants.FieldSize, 12 * ColorsAndConstants.FieldSize);
            return new NoWhere(rectangle);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(ColorsAndConstants.BandBrush, Rect);
        }

        public override void DrawWithLight(Graphics graphics, Color color)
        {
            graphics.FillRectangle(ColorsAndConstants.BandBrush, Rect);
            var p = new Pen(color);
            graphics.DrawRectangle(p, Rect);
        }

        public override bool IsAccessibleFor(PColorEnum playerColor)
        {
            return true;
        }

    }
}
