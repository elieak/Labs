using System;

namespace ShapeLib
{
    public abstract class Shape
    {
        protected ConsoleColor Color { get; }

        public abstract double Area { get; }

        protected Shape(ConsoleColor color)
        {
            Color = color;
        }

        protected Shape()
        {
            Color = ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.BackgroundColor = Color;
        }

    }
}
