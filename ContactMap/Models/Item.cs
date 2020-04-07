using System;

namespace ContactMap.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class AddressCl
    {
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
    }

    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AddressCl Address { get; set; }
        public string Phone { get; set; } 
    }
}