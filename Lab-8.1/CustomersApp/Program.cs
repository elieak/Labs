using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static CustomersApp.Customer;

namespace CustomersApp
{
    class Program
    {
        public delegate bool CustomerFilter(Customer cust);

        static void Main()
        {
            Customer[] customers = {
                new Customer {Address = "Tel Aviv", Name = "Bibi", Id = 2},
                new Customer {Address = "haifa", Name = "Avi", Id = 1},
                new Customer {Address = "maalot", Name = "avi", Id = 5},
                new Customer {Address = "yokneam", Name = "bouji", Id = 4},
                new Customer {Address = "Jerusalem", Name = "Kossi", Id = 3}
            };

            var customerList = new Collection<Customer>()
            { 
                new Customer { Address = "Tel Aviv", Name = "Bibi", Id = 101 },
                new Customer { Address = "haifa", Name = "Avi", Id = 1 },
                new Customer { Address = "maalot", Name = "avi", Id = 5 },
                new Customer { Address = "yokneam", Name = "Louji", Id = 4 },
                new Customer { Address = "Jerusalem", Name = "Yossi", Id = 3 }
            };

            var comparer = new AnotherCustomerComparer();
            CustomerFilter filter2 =
                delegate(Customer cust) { return cust.Name.ElementAt(0) >= 'L' && cust.Name.ElementAt(0) <= 'Z'; };

            CustomerFilter filter3 = cust => cust.Id < 100;

            Display(customers);

            Array.Sort(customers);
            Console.WriteLine("Sorterd Array");
            Display(customers);
            
            Array.Sort(customers, comparer);
            Console.WriteLine("Sorted by id: ");
            Display(customers);

            Console.WriteLine("Delegate Filter A-K: ");
            Display(GetCustomers(customerList, Filter1));

            Console.WriteLine("Anonymous Delegate Filter L-Z");
            Display(GetCustomers(customerList, filter2));

            Console.WriteLine("Lambda Delegate Filter ID less than 100");
            Display(GetCustomers(customerList, filter3));
        }

        public static bool Filter1(Customer cust)
        {
            return cust.Name.ElementAt(0) >= 'A' && cust.Name.ElementAt(0) <= 'K';
        }

        public static Collection<Customer> GetCustomers(Collection<Customer> custCollection,
            CustomerFilter custFilter)
        {
            var custList = new Collection<Customer>();

            foreach (var customer in custCollection)
                if (custFilter(customer))
                    custList.Add(customer);
            return custList;
        }

        private static void Display<T>(IEnumerable<T> objectsToDisplay)
        {
            foreach (var obj in objectsToDisplay)
                Console.WriteLine(obj);
        }
    }
}
