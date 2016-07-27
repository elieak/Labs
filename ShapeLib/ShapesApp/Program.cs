using System;
using System.Text;
using ShapeLib;

namespace ShapesApp
{
    class Program
    {
        static void Main()
        {
            var ellipse = new Ellipse(12, 4, ConsoleColor.DarkCyan);
            var rectangle = new Rectangle(25, 6);
            var shapeManager = new ShapeManager();

            shapeManager.Add(ellipse);
            shapeManager.Add(rectangle);
            shapeManager.Add(new Circle(5, ConsoleColor.DarkMagenta));

            var stringbuild = new StringBuilder();
            shapeManager.Save(stringbuild);
            string compareResult;

            if (rectangle.CompareTo(ellipse) > 0)
                compareResult = "Bigger than";
            else if (rectangle.CompareTo(ellipse) < 0)
                compareResult = "Smaller than";
            else
                compareResult = "Equal to";

            Console.WriteLine($"The area of the rectangle is {compareResult} the area of the ellipse.");
            shapeManager.DisplayAll();
        }
    }
}
