using System;
using System.Drawing;

namespace BackgammonLogic.Components
{
    public class Dice : Drawable
    {
        private Dice(Rectangle _Rect) : base(_Rect)
        {
            var myRandom = new Random();
            Left = myRandom.Next(6) + 1;
            Right = myRandom.Next(6) + 1;
        }

        public static Dice GetNewDice()
        {
            var r = GetDiceRect(ColorsAndConstants.DicePoint);
            return new Dice(r);
        }

        public int Left { get; }

        public int Right { get; }

        public int Sum => Left + Right;

        private static Rectangle GetDiceRect(Point at)
        {
            return new Rectangle(at.X - ColorsAndConstants.DiceSize / 2, at.Y - ColorsAndConstants.DiceSize / 2,
                2 * ColorsAndConstants.DiceSize, ColorsAndConstants.DiceSize);
        }

        private void DrawSingleDiceAt(Graphics g, int number, Point at)
        {
            var dr = new Rectangle(at.X - ColorsAndConstants.DiceSize / 2, at.Y - ColorsAndConstants.DiceSize / 2,
                ColorsAndConstants.DiceSize, ColorsAndConstants.DiceSize);

            Brush b = new SolidBrush(Color.Cyan);
            g.FillRectangle(b, dr);

            var p = new Pen(Color.Coral, 4.5f);
            g.DrawRectangle(p, dr);

            var black = Brushes.Black;

            var middlex = at.X;
            var middley = at.Y;
            var leftx = at.X - ColorsAndConstants.DiceSize / 4;
            var rightx = at.X + ColorsAndConstants.DiceSize / 4;
            var lowery = at.Y - ColorsAndConstants.DiceSize / 4;
            var uppery = at.Y + ColorsAndConstants.DiceSize / 4;

            switch (number)
            {
                case 1:
                    g.FillEllipse(black, middlex - ColorsAndConstants.DiceDotSize / 2, middley - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    break;
                case 2:
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    break;
                case 3:
                    g.FillEllipse(black, middlex - ColorsAndConstants.DiceDotSize / 2, middley - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    break;
                case 4:
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    break;
                case 5:
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, middlex - ColorsAndConstants.DiceDotSize / 2, middley - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    break;
                case 6:
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, uppery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, lowery - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, leftx - ColorsAndConstants.DiceDotSize / 2, middley - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    g.FillEllipse(black, rightx - ColorsAndConstants.DiceDotSize / 2, middley - ColorsAndConstants.DiceDotSize / 2, ColorsAndConstants.DiceDotSize, ColorsAndConstants.DiceDotSize);
                    break;
            }
        }

        public override void Draw(Graphics graphics)
        {
            DrawSingleDiceAt(graphics, Left, ColorsAndConstants.DicePoint);
            DrawSingleDiceAt(graphics, Right, new Point(ColorsAndConstants.DicePoint.X + ColorsAndConstants.DiceSize, ColorsAndConstants.DicePoint.Y));
        }

        public DiceState GetDiceState()
        {
            return new DiceState(this);
        }
    }
}
