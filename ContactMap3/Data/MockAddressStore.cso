using System;
using System.Threading.Tasks;
using ContactMap3.Models;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ContactMap3.Data
{
    [QueryProperty("Name", "name")]
    public class MockAddressStore:IDataStore<Address>
    {
        public string _query { get; set; }

        public async Task<bool> AddItemAsync(Address address)
        {
            ContactsData.Contacts.Where(m => m.Name == Uri.UnescapeDataString(_query)).Address = address;
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Address address)
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

        public async Task<Address> GetItemAsync(string id)
        {
            return await Task.FromResult(Contacts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Address>> GetItemAsync(bool forceRefresh = true)
        {
            return await Task.FromResult(Contacts);
        }
    }
}
