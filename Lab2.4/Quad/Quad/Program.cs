using System;
using System.Globalization;

namespace Quad
{
    public class Program
    {
        public bool CheckArguments(string[] args)
        {
            if (args.Length < 3)
            {

                Console.WriteLine("there aren't 3 arguments");
                return false;
            }
            return true;
        }

        public bool CheckParse(string[] args1, out double a, out double b, out double c)
        {
            if (double.TryParse(args1[0], out a) && double.TryParse(args1[1], out b) && double.TryParse(args1[2], out c))
                return true;
            Console.WriteLine("Could not parse user input");
            a = 0;
            b = 0;
            c = 0;
            return false;
        }
        public double SolutionA(double a, double b, double c) => (-1) * c / b;

        public double SolutionB(double a, double b, double c) => -Math.Sqrt(c) / Math.Sqrt(a);

        public bool NoSolution(out double toSqrt, double a, double b, double c)
        {
            toSqrt = Math.Pow(b, 2) - 4 * a * c;
            if (toSqrt < 0)
            {
                Console.WriteLine("No Solution");
                return false;
            }
            return true;
        }
        public string Stringequation(double toSqrt, double a, double b, double c) => 
            ("X1 = " + ((toSqrt - b) / (2 * a)).ToString(CultureInfo.InvariantCulture) + ",X2 = " + ((-1) * (toSqrt + b) / (2 * a)));

        static void Main(string[] args)
        {
            double a, b, c, toSqrt;
            var programInstance = new Program();
            if (!programInstance.CheckArguments(args))
            {
                Console.ReadLine();
                return;
            }

            if (!programInstance.CheckParse(args, out a, out b, out c))
            {
                Console.ReadLine();
                return;
            }

            if (a == 0)
            {
                Console.WriteLine($"x = {programInstance.SolutionA(a, b, c)}");
                Console.ReadLine();
                return;
            }
            if (b == 2 * a * c)
            {
                Console.WriteLine($"x = {programInstance.SolutionB(a, b, c)}");
                Console.ReadLine();
                return;
            }

            if (programInstance.NoSolution(out toSqrt, a, b, c) == false)
            {
                Console.ReadLine();
                return;
            }

            toSqrt = Math.Sqrt(toSqrt);
            Console.WriteLine(programInstance.Stringequation(toSqrt, a, b, c));
            Console.ReadLine();
        }
    }
}
