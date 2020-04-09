using System;
using System.Collections.Generic;
using ContactMap3.Models;

namespace ContactMap3.Data
{
    public static class ContactsData
    {
        public static IList<Person> Contacts { get; private set; }

        static ContactsData()
        {
            Contacts = new List<Person>();

            Contacts.Add(new Person
                {Name="Bob",
                Phone="(705)867-5309",
                Address=new Address
                {
                    City = "Utterson",
                    Country = "Canada",
                    Number = "123",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Hwy 141"
                }
                });
            Contacts.Add(new Person
            {
                Name = "Alice",
                Phone = "(705)867-5309",
                Address = new Address
                {
                    City = "Toronto",
                    Country = "Canada",
                    Number = "123",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Younge St"
                }
            });
            Contacts.Add(new Person
            {
                Name = "John",
                Phone = "(705)867-5309",
                Address = new Address
                {
                    City = "Hamilton",
                    Country = "Canada",
                    Number = "123",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Wellington St"
                }
            });
            Contacts.Add(new Person
            {
                Name = "David",
                Phone = "(705)867-5309",
                Address = new Address
                {
                    City = "Barrie",
                    Country = "Canada",
                    Number = "123",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Duckworth Ave"
                }
            });
            Contacts.Add(new Person
            {
                Name = "Sarah",
                Phone = "(705)867-5309",
                Address = new Address
                {
                    City = "Ottawa",
                    Country = "Canada",
                    Number = "123",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Elgin St"
                }
            });
            Contacts.Add(new Person
            {
                Name = "Pat",
                Phone = "(705)867-5309",
                Address = new Address
                {
                    City = "Port Dover",
                    Country = "Canada",
                    Number = "123",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Brown St"
                }
            });
        }
    }
}
