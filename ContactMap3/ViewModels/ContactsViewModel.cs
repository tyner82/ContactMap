using System;
using System.Linq;
using System.Windows.Input;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsViewModel: BaseViewModel
    {
        public Person _selectedItem;

        public Person SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
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
            await Shell.Current.GoToAsync($"modifycontact?uid={"0"}");
        }
    }
}
