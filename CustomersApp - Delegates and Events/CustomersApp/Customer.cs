using System;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Address { private get; set; }

        public delegate bool CustomerFilter(Customer customerDelegate);

        public int CompareTo(Customer cust)
        {
            return string.Compare(Name, cust.Name, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(Customer cust2)
        {
            return Name.Equals(cust2.Name) && Id.Equals(cust2.Id);
        }

        public override string ToString()
        {
            return string.Format($"ID: {Id}, Name: {Name}, Address: {Address}");
        }
    }
}
