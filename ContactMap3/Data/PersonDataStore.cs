﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContactMap3.Data;
using ContactMap3.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ContactMap3.Data
{
    public class PersonDataStore : IContactStore<Person>
    {
        readonly List<Person> contacts;

        string fileName = "contacts.json";

        public PersonDataStore(List<Person> rebuildCache)
        {
            Console.WriteLine("Rebuilt DataStore from cache");
            contacts = rebuildCache;
        }

        public PersonDataStore()
        {
            Console.WriteLine($"New DataStore Created...{this.GetHashCode()}");
            contacts = new List<Person>();
            //List<Person> _ontacts = new List<Person>();
            contacts.Add(new Person
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Bob",
                Phone = "(705)867-5309",
                Address = new Address
                {
                    City = "Utterson",
                    Country = "Canada",
                    Number = "1456456",
                    Postal = "P0B 1M0",
                    State = "Ontario",
                    Street = "Hwy 141"
                }
            });
            contacts.Add(new Person
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
            contacts.Add(new Person
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
            //foreach(Person p in _ontacts)
            //{
            //    contacts.Add(p);
            //}
        }

        public async Task<bool> AddItemAsync(Person person)
        {
            person.Id = Guid.NewGuid().ToString();
            contacts.Add(person);
            Console.WriteLine($"Says it wrote something, Count = {contacts.Count}\n Has: {this.GetHashCode()}");
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Person person)
        {
            var oldItem = contacts.Where((Person arg) => arg.Id == person.Id).FirstOrDefault();
            contacts.Remove(oldItem);
            contacts.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = contacts.Where((Person arg) => arg.Id == id).FirstOrDefault();
            contacts.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetItemAsync(string id)
        {
            //Console.WriteLine($"In ContactStore...{contacts.FirstOrDefault(s => s.Id == id).Name}");
            return await Task.FromResult(contacts.FirstOrDefault(s => s.Id == id));

        }

        public async Task<bool> StoreItemsAsync(string fileName = "contacts.json")
        {
            Console.WriteLine($"FILENAME:{fileName}");
            //string fileName = "contacts.json";
            var cacheFile = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, fileName);

            Console.WriteLine($"Cache file path:\n{cacheFile}");
            try
            {
                using (var writer = File.CreateText(cacheFile))//TODO: Does this overwrite?
                {
                    await writer.WriteLineAsync(JsonConvert.SerializeObject(contacts));
                }
            }
            catch(Exception e)
            {

                Console.WriteLine($"WriteFileException:\n{e}");
            }
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(contacts);
        }

        public async Task<IEnumerable<Person>> GetCacheAsync(bool forceRefresh = false)
        {
            var cacheFile = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, fileName);

            if (cacheFile == null || !File.Exists(cacheFile))
            {
                Console.WriteLine("No Cached Contacts File Exists");
                return new List<Person> { new Person() };
            }

            string rawContacts = "";
            try
            {
                using (var reader = new StreamReader(cacheFile, true))
                {

                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        rawContacts += line;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception Reading Json:\n{e}");
            }
            Console.WriteLine($"Deserializing Json:{contacts[0].Name}");
            List<Person> result = JsonConvert.DeserializeObject<List<Person>>(rawContacts);
            await UpdateChanges(result);
            //contacts = result; //maybe shouldn't touch this here?
            return await Task.FromResult(result);
        }
        Task UpdateChanges(List<Person> result)
        {
            try
            {
                contacts.Clear();
                List<Person> _contacts = result.ToList();
                _contacts = _contacts.OrderBy(o => o.Name).ToList();
                foreach (Person p in _contacts)
                {
                    contacts.Add(p);
                }
                //Console.WriteLine($"Add {person.Name}");
                //await DataStore.AddItemAsync(_person);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Caught Exception while Refreshing Cache:{e}");
            }
            return Task.FromResult(true);
        }
    }
}