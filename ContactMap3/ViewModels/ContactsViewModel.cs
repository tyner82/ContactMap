using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsViewModel: BaseViewModel
    {
        public Person selectedItem;

        public ContactsViewModel()
        {
            MessagingCenter.Subscribe<ModifyContactViewModel,Person>(this, "AddItem", (sender, person) =>
              {
                  Console.WriteLine("Add Helper");
                  Task.Run(async () => await AddItemHelper(person, "Add"));
              });
            MessagingCenter.Subscribe<ModifyContactViewModel, Person>(this, "UpdateItem", (sender, person) =>
            {
                Console.WriteLine("Update Helper");
                Task.Run(async () => await AddItemHelper(person, "Update"));
            });
            MessagingCenter.Subscribe<BaseViewModel, Person>(this, "Refresh", (sender, person) =>
            {
                Console.WriteLine("Refresh Helper");
                Task.Run(async () => await AddItemHelper(person, "Refresh"));
            });
            MessagingCenter.Subscribe<BaseViewModel, Person>(this, "SaveJson", (sender, person) =>
            {
                Console.WriteLine("Save Helper");
                Task.Run(async () => await AddItemHelper(person, "SaveJson"));
            });
            MessagingCenter.Subscribe<BaseViewModel, Person>(this, "LoadJson", (sender, person) =>
            {
                Console.WriteLine("Load Helper");
                Task.Run(async () => await AddItemHelper(person, "LoadJson"));
            });
        }

        async Task AddItemHelper(Person person,string type)
        {
            if (type == "Add")
            {
                await DataStore.AddItemAsync(person);
            }else if (type == "Update")
            {
                await DataStore.UpdateItemAsync(person);
            }
        }

        public Person SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
            }
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
