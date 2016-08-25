using System.Drawing;

namespace BackgammonLogic.Components
{
    class Field : AbstractField
    {
        private Field(Rectangle _Rect, int _Number, bool _FieldColor, bool _FieldOrientation) : base(_Rect, _Number)
        {
            FieldColor = _FieldColor;
            FieldOrientation = _FieldOrientation;

            Triangle = new Point[3];
            var triangle = Triangle;

            if (FieldOrientation == ColorsAndConstants.Upper)
            {
                triangle[0] = new Point(Rect.Left, Rect.Top);
                triangle[1] = new Point(Rect.Left + ColorsAndConstants.FieldSize, Rect.Top);
                triangle[2] = new Point(Rect.Left + ColorsAndConstants.FieldSize / 2, Rect.Top + Rect.Height);
            }
            else
            {
                triangle[0] = new Point(Rect.Left, Rect.Top + Rect.Height);
                triangle[1] = new Point(Rect.Left + ColorsAndConstants.FieldSize, Rect.Top + Rect.Height);
                triangle[2] = new Point(Rect.Left + ColorsAndConstants.FieldSize / 2, Rect.Top);
            }
        }

        private readonly Point[] Triangle;

        public static Field MakeField(int _Number)
        {
            var _FieldOrientation = _Number > 11;

            var _FieldColor = _Number % 2 == 0;

            Rectangle _Rect;
            if (_Number > 11)      
            {
                var x = (_Number - 12);
                if (_Number > 17) x += 2;
                _Rect = new Rectangle(x * ColorsAndConstants.FieldSize, 0, ColorsAndConstants.FieldSize, 5 * ColorsAndConstants.FieldSize);
            }
            else
            {
                var y = 7;
                var x = (11 - _Number);
                if (_Number < 6) x += 2;
                _Rect = new Rectangle(x * ColorsAndConstants.FieldSize, y * ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize, 5 * ColorsAndConstants.FieldSize);
            }

            return new Field(_Rect, _Number, _FieldColor, _FieldOrientation);
        }

        public override void Draw(Graphics graphics)
        {
            DrawBackground(graphics);
            DrawStones(graphics);
        }

        public override void DrawWithLight(Graphics graphics, Color color)
        {
            DrawBackground(graphics);
            DrawLight(graphics, color);
            DrawStones(graphics);
        }

        private void DrawLight(Graphics graphics, Color color)
        {
            var p = new Pen(color);
            graphics.DrawPolygon(p, Triangle);
        }

        private void DrawBackground(Graphics graphics)
        {
            var brush = FieldColor == ColorsAndConstants.Black ? Brushes.Black : Brushes.White;

            graphics.FillPolygon(brush, Triangle);
        }

        private void DrawStones(Graphics graphics)
        {
            if (SumStones <= 5)
            {
                var slot = 0;
                if (WhiteStones > BlackStones)
                {
                    for (var i = 0; i < WhiteStones; ++i)
                    {
                        graphics.FillEllipse(ColorsAndConstants.WhiteStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                    for (var i = 0; i < BlackStones; ++i)
                    {
                        graphics.FillEllipse(ColorsAndConstants.BlackStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                }
                else
                {
                    for (var i = 0; i < BlackStones; ++i)
                    {
                        graphics.FillEllipse(ColorsAndConstants.BlackStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                    for (var i = 0; i < WhiteStones; ++i)
                    {
                        graphics.FillEllipse(ColorsAndConstants.WhiteStoneBrush, GetFieldSlot(slot));
                        slot++;
                    }
                }
            }
            else
            {
                if (WhiteStones > BlackStones)
                {
                    graphics.DrawString(WhiteStones.ToString(), ColorsAndConstants.StoneFont, ColorsAndConstants.WhiteStoneBrush, GetFieldSlot(0));

                    if (BlackStones > 0)
                        graphics.DrawString(BlackStones.ToString(), ColorsAndConstants.StoneFont, ColorsAndConstants.BlackStoneBrush, GetFieldSlot(1));
                }
                else
                {
                    graphics.DrawString(BlackStones.ToString(), ColorsAndConstants.StoneFont, ColorsAndConstants.BlackStoneBrush, GetFieldSlot(0));

                    if (WhiteStones > 0)
                        graphics.DrawString(WhiteStones.ToString(), ColorsAndConstants.StoneFont, ColorsAndConstants.WhiteStoneBrush, GetFieldSlot(1));
                }
            }
        }

        private Rectangle GetFieldSlot(int slotNumber)
        {
            return FieldOrientation == ColorsAndConstants.Lower ? 
                new Rectangle(Rect.X, Rect.Y + Rect.Height - (slotNumber + 1) * ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize) : 
                new Rectangle(Rect.X, Rect.Y + slotNumber * ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize, ColorsAndConstants.FieldSize);
        }

        public override bool IsAccessibleFor(PColorEnum playerColor)
        {
            if (playerColor == PColorEnum.White)
            {
                return BlackStones <= 1;
            }
            return WhiteStones <= 1;
        }

        private readonly bool FieldColor;
        private readonly bool FieldOrientation;
    }
}
