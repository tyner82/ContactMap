using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public List<Person> Contacts{ get; private set; }

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
            MessagingCenter.Subscribe<ModifyContactViewModel, Person>(this, "AddItem", (sender, person) =>
            {
                try
                {
                    //Console.WriteLine($"Add {person.Name}");
                    DataStore.AddItemAsync(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception trying to add to Store:{e}");
                }
            });
            MessagingCenter.Subscribe<ModifyContactViewModel, Person>(this, "UpdateItem", (sender, person) =>
            {
                DataStore.UpdateItemAsync(person);
            });
        }

        public ICommand SelectionCommand => new Command(ItemSelected);
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

        public ICommand AddContactCommand => new Command(AddContact);
        private async void AddContact()
        {
            Console.WriteLine("Going to modify contact...");
            await Shell.Current.GoToAsync($"modifycontact?uid={"0"}");
        }
    }
}
