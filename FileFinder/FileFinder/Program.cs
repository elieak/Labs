using System;
using System.IO;
using System.Linq;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = Directory.GetFiles(args[0]).Where(file => file.Contains(args[1]));
            foreach (var fileName in directory)
            {
                Console.WriteLine($"File Name: {fileName}\nFile Length: {fileName.Length}");
            }
        }
    }
}