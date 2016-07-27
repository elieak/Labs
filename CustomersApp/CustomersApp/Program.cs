using System;

namespace CustomersApp
{
    class Program
    {
        static void Main()
        {
            Customer[] customers = {
                new Customer {Address = "Tel Aviv", Name = "Bibi", Id = 2},
                new Customer {Address = "haifa", Name = "Avi", Id = 1},
                new Customer {Address = "maalot", Name = "avi", Id = 5},
                new Customer {Address = "yokneam", Name = "bouji", Id = 4},
                new Customer {Address = "Jerusalem", Name = "Yossi", Id = 3}
            };

            Display(customers);
            Array.Sort(customers);
            Console.WriteLine("Sorterd Array");
            Display(customers);
            var comparer = new AnotherCustomerComparer();
            Array.Sort(customers, comparer);
            Console.WriteLine("Sorted by id: ");
            Display(customers);
        }

        private static void Display<T>(T[] objectsToDisplay)
        {
            foreach (var obj in objectsToDisplay)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
