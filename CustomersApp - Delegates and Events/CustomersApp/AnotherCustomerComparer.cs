using System.Collections.Generic;

namespace CustomersApp
{
    internal class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
