using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactMap3.Models;
using ContactMap3.Views;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public ObservableCollection<Person> Contacts { get; set; }

        public Person selectedItem;

        public Person SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
            }
        }

        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Person>();
            MessagingCenter.Subscribe<ModifyContactViewModel, Person>(this, "AddItem", async (sender, person) =>
            {
                try
                {
                    var _person = person as Person;
                    Contacts.Add(_person);
                    Contacts.Clear();
                    List<Person> _contacts = Contacts.ToList();
                    _contacts = _contacts.OrderBy(o => o.Name).ToList();
                    foreach (Person p in _contacts)
                    {
                        Contacts.Add(p);
                    }
                    Console.WriteLine($"Add {person.Name}");
                    await DataStore.AddItemAsync(_person);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception trying to add to Store:{e}");
                }

            });
            MessagingCenter.Subscribe<ModifyContactViewModel, Person>(this, "UpdateItem", async (sender, person) =>
            {
                await DataStore.UpdateItemAsync(person);

                //this.UpdateContactsCommand.Execute(null);
            });
        }

        public ICommand SelectionCommand => new Command(ItemSelected);
        public ICommand UpdateContactsCommand => new Command(UpdateContact);
        public ICommand AddContactCommand => new Command(AddContact);
        public ICommand SaveContactCommand => new Command(SaveContact);
        public ICommand SyncContactCommand => new Command(SyncContacts);
        private async void SaveContact()
        {
            try
            {
                await DataStore.StoreItemsAsync("contacts.json");
            }catch (Exception e)
            {
                Console.WriteLine($"Problem Saving Json:{e}");
            }
        }
        private async void SyncContacts()
        {

            if (IsBusy)
                return;

            IsBusy = true;
            Console.WriteLine("UpdateContacts");

            try
            {
                Contacts.Clear();
                var _items = await DataStore.GetCacheAsync(true);
                List<Person> _contacts = _items.ToList();
                _contacts = _contacts.OrderBy(o => o.Name).ToList();
                foreach (Person p in _contacts)
                {
                    Contacts.Add(p);
                }
                //Console.WriteLine($"Add {person.Name}");
                //await DataStore.AddItemAsync(_person);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Caught Exception while Retrieving Json:{e}");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void ItemSelected()
        {
            if (SelectedItem != null)
            {
                string personId = SelectedItem.Id;

                Application.Current.Properties["id"] = new string[] { personId }; //I know not best way to do this

                await Shell.Current.GoToAsync($"contactdetails?uid={personId}");
                SelectedItem = null;
            }
        }

        private async void UpdateContact()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Console.WriteLine("UpdateContacts");

            try
            {
                Contacts.Clear();
                var _items = await DataStore.GetItemsAsync(true);
                List<Person> _contacts = _items.ToList();
                _contacts = _contacts.OrderBy(o => o.Name).ToList();
                foreach (Person p in _contacts)
                {
                    Contacts.Add(p);
                }
                //Console.WriteLine($"Add {person.Name}");
                //await DataStore.AddItemAsync(_person);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Caught Exception while Refreshing View:{e}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void AddContact()
        {
            Console.WriteLine("Going to modify contact...");
            await Shell.Current.GoToAsync($"modifycontact?uid={"0"}");
        }
    }
}
