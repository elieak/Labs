using System;

namespace GenericApp
{
    internal class Program
    {
        private static void Main()
        {
            var multiDictionary = new MultiDictionary<myKey, stringStruct>();
            //{
            //    {1, "one"},
            //    {2, "two"},
            //    {3, "three"},
            //    {1, "ich"},
            //    {2, "nee"},
            //    {3, "sun"}
            //};

            myKey number;
            number.num = 1;
            stringStruct str;
            str.myString = "One";

            myKey number2;
            number2.num = 1;
            stringStruct str2;
            str2.myString = "ich";

            multiDictionary.Add(number, str);
            multiDictionary.Add(number2, str2);

            DisplayDictionary(multiDictionary);
            multiDictionary.Remove(number);
            DisplayDictionary(multiDictionary);

        }

        private static void DisplayDictionary(MultiDictionary<myKey, stringStruct> multiDictionary)
        {
            if (multiDictionary.Count != 0)
                foreach (var key in multiDictionary)
                    foreach (var value in key.Value)
                        Console.WriteLine($"Key: {key.Key}, Value: {value}");
            else
                Console.WriteLine("The Dictionary has been cleared and is now Empty.");
        }

        [Key]
        private struct myKey
        {
            public int num;
        }

        private struct stringStruct
        {
            public string myString;
        }
    }
}
