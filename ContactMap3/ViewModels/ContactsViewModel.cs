using System;
using System.Linq;
using System.Windows.Input;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsViewModel: BaseViewModel
    {
        public Person selectedItem;

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
