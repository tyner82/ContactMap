using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactMap3.Models;

namespace ContactMap3.Data
{
    public class MockDataStore : IDataStore<Person>
    {
        public readonly List<Person> Contacts;

        public MockDataStore()
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

        public async Task<bool> AddItemAsync(Person person)
        {
            Contacts.Add(person);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Person person)
        {
            var oldPerson = Contacts.Where((Person arg) => arg.Id == person.Id).FirstOrDefault();
            Contacts.Remove(oldPerson);
            Contacts.Add(person);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldPerson = Contacts.Where((Person arg) => arg.Id == id).FirstOrDefault();
            Contacts.Remove(oldPerson);
            return await Task.FromResult(true);
        }

        public async Task<Person> GetItemAsync(string id)
        {
            return await Task.FromResult(Contacts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Person>> GetItemAsync(bool forceRefresh = true)
        {
            return await Task.FromResult(Contacts);
        }
    }
}
