using System;
using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main()
        {
            const string FileName = "names.txt";

            var lines = new List<string>();

            ReadFromFile(FileName, lines);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static void ReadFromFile(string FileName, ICollection<string> lines)
        {
            using (var _streamReader = new StreamReader(FileName))
            {
                string line;
                while ((line = _streamReader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
        }
    }
}
