namespace LINQToObjects.Extensions
{
    class Customer
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Address {Address}, Age {Age}, Name {Name}";
        }
    }

    class Person
    {
        public string Address { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }

}
