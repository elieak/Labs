using System;
using System.Linq;
using static System.Console;

namespace Strings
{
    class Program
    {
        public static string SplitString(string usrInput)
        {
            var split = usrInput.Split(' ');
            return "The number of words is: " + split.Length;
        }

        static string ReverseString(string usrInput)
        {
            var reversedString = string.Join(" ", usrInput.Split(' ').Reverse());
            return "The reversed string is: " + reversedString;
        }

        static string SortedArray(string usrInput)
        {
            string[] sortedString = usrInput.Split(' ');
            Array.Sort(sortedString);
            return "The sorted string is: " + string.Join(" ", sortedString);
        }

        private static void Main()
        {
            string userInput;
            do
            {
                Write("Please enter a string: ");
                userInput = ReadLine();
                if (userInput == string.Empty)
                {
                    break;
                }
                WriteLine("===============");
                WriteLine(SplitString(userInput));
                WriteLine("===============");
                WriteLine(ReverseString(userInput));
                WriteLine("===============");
                WriteLine(SortedArray(userInput));
            } while (userInput != null);

        }
    }
}
