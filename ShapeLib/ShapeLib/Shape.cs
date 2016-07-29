using System;

namespace ShapeLib
{
    public abstract class Shape
    {
        protected ConsoleColor Color { get; }

        public abstract double Area { get; }

        /**
      
      What happens when you add more shapes?
      Do you add more cases to the switch?
      What happens if you want to use this method for any shape out there, even those which are not in your code?
      Polymorphism is the answer

      Consider this implementation:

          foreach (var persistable in Shapes.OfType<IPersist>())
          {
             persistable.Write(st);
          }

      OfType will select only members which are assignable to an IPersist reference and return such a collection
      https://msdn.microsoft.com/en-us/library/bb360913(v=vs.110).aspx

      */
        protected Shape(ConsoleColor color)
        {
            Color = color;
        }

        /*
      It is a good practice to delegate initialization logic to a single constructor.
      This is in accordance to the DRY (Dont Repeat Yourself) principle

      A DRY implementation of the default constructor would be:

       public Shape():this(ConsoleColor.White)
       {
       }
      */
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
