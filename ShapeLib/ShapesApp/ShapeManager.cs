using System;
using System.Collections;
using System.Text;
using ShapeLib;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList _shapesList;

        public ShapeManager()
        {
            _shapesList = new ArrayList();
        }

        public void Add(Shape newShape)
        {
            _shapesList.Add(newShape);
        }

        public void DisplayAll()
        {
            foreach (Shape shape in _shapesList)
            {
                var area = shape.Area;
                shape.Display();
                Console.WriteLine(area);
            }
        }

        public void Save(StringBuilder sb)
        {
            foreach (dynamic shape in _shapesList)
            {
                if (shape.GetType() == typeof(Ellipse))
                    ((Ellipse)shape).Write(sb);
                if (shape.GetType() == typeof(Rectangle))
                    ((Rectangle)shape).Write(sb);
                if (shape.GetType() == typeof(Circle))
                    ((Circle)shape).Write(sb);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
