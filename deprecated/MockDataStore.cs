using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactMap1.Models;

namespace ContactMap1.Services
{
    public static class MockDataStore
    {
        public static readonly List<Person> Contacts;

        static MockDataStore()
        {
            Contacts = new List<Person>()
            {
                new Person{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Bob",
                    Address = new AddressCl{
                        Number = "123",
                        City = "Lubbock",
                        Postal = "80192",
                        State="Texas",
                        Street = "82nd Ave"},
                    Phone="(905)867-5309" }
            };

        }

    }
}
