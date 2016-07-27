using System;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(int rad, ConsoleColor color) : base(rad, rad, color) { }

        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine($"The radius is {radius}");
        }

    }
}
