using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactMap3.Models;
using ContactMap3.Services;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        bool isFirstLoad = true;
        public ContactsViewModel()
        {
            if (isFirstLoad)
            {

                MessagingCenter.Subscribe<MapViewModel, ActiveFilter>(this, "sendFilters", (sender, aFilter) =>
                {

                    Console.WriteLine($"Adding Filters from contactsview\n{this.GetHashCode()}\nSender:{sender}");
                    if (filteredList != null)
                    {
                        Console.WriteLine($"Filtered list count{filteredList.Count}");
                        foreach (Person person in filteredList)
                        {
                            aFilter.AddFilter(person.Id);
                        }
                    }
                    else
                    {
                        aFilter.AddFilter("NoFilter");
                        Console.WriteLine("SelectedItem is null");
                    }
                });
                Console.WriteLine($"Subscribed contactsview\nHash:{this.GetHashCode()}");
                filteredList = new List<Person>();
                isFirstLoad = false;
            }
        }
        List<Person> filteredList;
        public Person selectedItem;

        public Person SelectedItem
        {
            get { return selectedItem; }
            set
            {
                filteredList.Clear();
                filteredList.Add(selectedItem);
                SetProperty(ref selectedItem, value);

            }
        }

        public ICommand OnAppearingCommand => new Command(Load);

        public ICommand OnDisappearingCommand => new Command(UnLoad);

        private void Load()
        {
        }
        private void UnLoad()
        {
            /*
            MessagingCenter.Unsubscribe<ContactsViewModel>(this, "sendFilters") ;
            Console.WriteLine($"Unsubscribed contactsview\nHash:{this.GetHashCode()}");
            */
        }


        public ICommand SelectionCommand => new Command(ItemSelected);
        private async void ItemSelected()
        {
            if (SelectedItem != null)
            {
                string personId = SelectedItem.Id;
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
