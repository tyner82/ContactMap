using System;
using ContactMap3.ViewModels;

namespace ContactMap3.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public override string ToString()
        {

            return $"{Name} {Phone}";
        }
    }
}
