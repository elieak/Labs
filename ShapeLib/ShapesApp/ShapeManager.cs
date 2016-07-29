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
    
        /**
      
      What happens when you add more shapes?
      Do you add more cases to the switch?
      What happens if you want to use this method for any shape out there, even those which are not in your code?
      Polymorphism is the answer
      Prefer it over using the dynamic keyword!

      Consider this implementation:

          foreach (var persistable in Shapes.OfType<IPersist>())
          {
             persistable.Write(st);
          }

      OfType will select only members which are assignable to an IPersist reference and return such a collection
      https://msdn.microsoft.com/en-us/library/bb360913(v=vs.110).aspx

      */
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
            Console.WriteLine(sb.ToString());// this does not belong here
        }
    }
}
