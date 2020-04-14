﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContactMap3.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactMap3.Data
{
    public class PersonDataStore : IContactStore<Person>
    {
        List<Person> contacts;

        string fileName = "contacts.json";

        public PersonDataStore()
        {
            bool isBusy = true;
            Console.WriteLine($"Cache First");
            var cacheList = Task.Run(async () => await StoreItemsAsync()).ContinueWith(t=>isBusy=false);
            Console.Write("Busy");
            while (isBusy)
            {
                Console.Write(".");
            }
            //contacts = new List<Person>(LoadList.Result);
            Console.WriteLine($"Getting Update from Json:\n{ContactsData.Contacts[7].Address.ToString()}");
            Task<IEnumerable<Person>> LoadList = Task.Run(async () => await GetCacheAsync());
            contacts = new List<Person>(LoadList.Result);
            Console.WriteLine($"Done Getting Update from Json:\n{ContactsData.Contacts[0].Address.ToString()}");
            /*
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
            });*/
        }

        public async Task<bool> AddItemAsync(Person person)
        {
            person.Id = Guid.NewGuid().ToString();
            contacts.Add(person);
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
            Person result = contacts.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(result);

        }

        public async Task<bool> StoreItemsAsync(string fileName = "contacts.json")
        {
            Console.WriteLine($"FILENAME:{fileName}");
            //string fileName = "contacts.json";
            var cacheFile = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, fileName);

            Console.WriteLine($"Cache file path:\n{cacheFile}");
            try
            {
                using (var writer = File.CreateText(cacheFile))
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
                Console.WriteLine($"No Cached Contacts File Exists:\n{cacheFile}");
                return await Task.FromResult(new List<Person> { new Person() });
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
            //Console.WriteLine($"Deserializing Json:{contacts[0].Name}");
            List<Person> result = JsonConvert.DeserializeObject<List<Person>>(rawContacts);
            contacts.Clear();
            foreach (Person p in result)
            {
                contacts.Add(p);
            }
            contacts = contacts.OrderBy(o=>o.Name).ToList(); //maybe shouldn't touch this here?
            ContactsData.Contacts = contacts;// contacts;
            return await Task.FromResult(result);
        }
    }
}