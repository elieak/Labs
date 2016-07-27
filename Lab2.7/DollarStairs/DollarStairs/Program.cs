using System;

namespace DollarStairs
{
    class Program
    {
        static void Main()
        {
            int usrInput;
            const char dollar = '$';
            Console.Write("Enter number: ");
            int.TryParse(Console.ReadLine(), out usrInput);

            for (var i = 0; i < usrInput; i++)
            {
                for (var j = 0; j <= i; j++)
                    Console.Write(dollar);
                Console.WriteLine("");
            }
        }
    }
}
