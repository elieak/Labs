using System.Drawing;

namespace BackgammonLogic.Components
{
    public abstract class Drawable
    {
        protected Drawable(Rectangle _Rect)
        {
            Rect = _Rect;
            OverRect = new Rectangle(Rect.X - 1, Rect.Y - 1, Rect.Width + 2, Rect.Height + 2);
        }

        public readonly Rectangle Rect;
        public readonly Rectangle OverRect;
        public abstract void Draw(Graphics graphics);

        public bool TestAgainst(Point p)
        {
            return Rect.Contains(p);
        }
    }
}
