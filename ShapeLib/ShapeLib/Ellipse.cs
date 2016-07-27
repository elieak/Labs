using System;
using System.Text;

namespace ShapeLib
{
    public class Ellipse : Shape, IComparable
    {
        public int radius { get; }
        public int Radius { get; }

        public Ellipse(int eradius, int eRadius, ConsoleColor color) : base(color)
        {
            radius = eradius;
            Radius = eRadius;
        }

        public override double Area => Math.PI*radius*Radius;

        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("the little radius is " + radius + " the big radius is " + Radius);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("the little radius is " + radius + " the big radius is " + Radius);
        }

        public int CompareTo(object obj)
        {
            dynamic shape = obj;
            if (Area > shape.Area)
                return 1;
            if (Area == shape.Area)
                return 0;
            return -1;
        }
    }
}
