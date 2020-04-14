using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ContactMap3.Models;

namespace ContactMap3.Data
{
    public class MockPersonStore : IDataStore<Person>
    {
        public readonly IList<Person> Contacts;

        public MockPersonStore()
        {
            Contacts = ContactsData.Contacts;

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

        public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = true)
        {
            return await Task.FromResult(Contacts);
        }
    }
}
