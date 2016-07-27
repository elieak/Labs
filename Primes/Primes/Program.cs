using System;
using System.Collections;

namespace Primes
{
    class Program
    {
        private static int[] CalcPrimes(int a, int b)
        {
            var arrayList = new ArrayList();

            for (var i = a; i <= b; i++)
            {
                var isPrime = true;
                if ((i & 1) == 0)
                    if (i != 2)
                        isPrime = false;
                for (var j = 3; (j*j) <= i; j += 2)
                    if (i%j == 0)
                        isPrime = false;
                if (isPrime)
                    arrayList.Add(i);
            }

            var myPrimesArray = new int[arrayList.Count];
            arrayList.CopyTo(myPrimesArray);

            return myPrimesArray;
        }
        static void Main()
        {
            const int fn = 0;
            const int sn = 100;
            var calculatePrimes = CalcPrimes(fn, sn);

            foreach (var prime in calculatePrimes)
                Console.WriteLine(prime);
        }
    }
}
