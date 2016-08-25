using System.Drawing;

namespace BackgammonLogic.Components
{
    public class Band : AbstractField
    {
        private Band(PColorEnum _Color, Rectangle _Rect, int _Number) : base(_Rect, _Number)
        {
            Color = _Color;
        }

        public static Band MakeBand(PColorEnum _Color)
        {
            Rectangle r;
            int num;
            if (_Color == PColorEnum.White)
            {
                r = new Rectangle(6 * ColorsAndConstants.FieldSize, 7 * ColorsAndConstants.FieldSize, 2 * ColorsAndConstants.FieldSize, 5 * ColorsAndConstants.FieldSize);
                num = ColorsAndConstants.WhiteBand;
            }
            else
            {
                r = new Rectangle(6 * ColorsAndConstants.FieldSize, 0, 2 * ColorsAndConstants.FieldSize, 5 * ColorsAndConstants.FieldSize);
                num = ColorsAndConstants.BlackBand;
            }

            return new Band(_Color, r, num);
        }

        public override bool IsAccessibleFor(PColorEnum playerColor)
        {
            return (Color == playerColor);
        }

        private readonly PColorEnum Color;

        public override void Draw(Graphics graphics)
        {
            DrawStones(graphics);
        }

        public override void DrawWithLight(Graphics graphics, Color color)
        {
            DrawLight(graphics, color);
            DrawStones(graphics);
        }

        public void DrawStones(Graphics g)
        {
            if (Color == PColorEnum.White)
            {
                if (WhiteStones <= 6)
                {
                    for (var i = 0; i < WhiteStones; ++i)
                    {
                        var x = (1 - (i % 2)) * ColorsAndConstants.FieldSize;
                        var y = (2 - (i / 2)) * ColorsAndConstants.FieldSize;

                        g.FillEllipse(ColorsAndConstants.WhiteStoneBrush, Rect.X + x, Rect.Y + y, ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize);
                    }
                }
                else
                {
                    g.DrawString(WhiteStones.ToString(), ColorsAndConstants.StoneFont, ColorsAndConstants.WhiteStoneBrush,
                        Rect.X + Rect.Width - ColorsAndConstants.FieldSize, Rect.Y + Rect.Height - ColorsAndConstants.FieldSize);
                }
            }
            else
            {
                if (BlackStones <= 6)
                {
                    for (var i = 0; i < BlackStones; ++i)
                    {
                        var x = (2 - (i % 2)) * ColorsAndConstants.FieldSize;
                        var y = (3 - (i / 2)) * ColorsAndConstants.FieldSize;

                        g.FillEllipse(ColorsAndConstants.BlackStoneBrush, Rect.X + Rect.Width - x, Rect.Y + Rect.Height - y,
                            ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize);
                    }
                }
                else
                {
                    g.DrawString(BlackStones.ToString(), ColorsAndConstants.StoneFont, ColorsAndConstants.BlackStoneBrush, Rect.Location);
                }
            }
        }

        public void DrawLight(Graphics g, Color l)
        {
            var p = new Pen(l);
            g.DrawRectangle(p, Rect);
        }

    }

}
