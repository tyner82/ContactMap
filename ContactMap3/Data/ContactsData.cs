using System;
using System.Collections.Generic;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.Data
{
    public static class ContactsData
    {
        public static IList<Person> Contacts { get; set; }
        //public static string SelectedItem=null;
        static ContactsData()
        {
            Contacts = new List<Person>();

            Contacts.Add(new Person
            {
                Id = Guid.NewGuid().ToString(),
                Name ="Bob",
                Phone="(705)867-5309",
                Address=new Address
                {
                    City = "Utterson",
                    Country = "Canada",
                    Number = "1456456",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Hwy 141"
                }
            });
            Contacts.Add(new Person
            {
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
            Contacts.Add(new Person
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bob",
                Phone = "(705)867-5309",
                Address = new Address
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
                Id = Guid.NewGuid().ToString(),
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
