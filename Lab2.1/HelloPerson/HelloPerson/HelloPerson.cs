using System;

namespace HelloPerson
{
    public class HelloPerson
    {
        public static void Main()
        {
            var userInput = 0;

            Console.WriteLine("Hello ");
            Console.Write("Enter your name: ");
            var userName = Console.ReadLine();
            Console.WriteLine($"Hello {userName}");

            while (userInput < 1 || userInput > 10)
            {
                Console.Write("Please Enter a number between 1 - 10: ");
                int.TryParse(Console.ReadLine(), out userInput);
            }

            for (var i = 0; i < userInput; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(userName);
            }
        }
    }
}
