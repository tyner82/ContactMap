using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactMap.Models;

namespace ContactMap.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Person> people;

        public MockDataStore()
        {
            people = new List<Person>()
            {
                new Person{Id = Guid.NewGuid().ToString(), Name = "Bob", Address = new AddressCl{Number = "123", City = "Lubbock", Postal = "80192", State="Texas",Street = "82nd Ave"},Phone="(905)867-5309" }
            };
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            people.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var oldPerson = people.Where((Person arg) => arg.Id == person.Id).FirstOrDefault();
            people.Remove(oldPerson);
            people.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePersonAsync(string id)
        {
            var oldPerson = people.Where((Person arg) => arg.Id == id).FirstOrDefault();
            people.Remove(oldPerson);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            return await Task.FromResult(people.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(people);
        }




        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}