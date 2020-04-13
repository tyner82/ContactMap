using System;
using System.Linq;
using System.Windows.Input;
using ContactMap3.Models;
using ContactMap3.Views;
using ContactMap3.Data;
using Xamarin.Forms;
using ContactMap3.Services;

namespace ContactMap3.ViewModels
{
    public class ContactsDetailViewModel: BaseViewModel
    {
        public ICommand OnAppearingCommand => new Command(Load);

        public ICommand OnDisappearingCommand => new Command(UnLoad);

        private void Load()
        {
            MessagingCenter.Subscribe<ContactsDetailViewModel, ActiveFilter>(this, "sendFilters", (sender, aFilter) =>
            {

                Console.WriteLine($"Adding Filters from detailview\n{this.GetHashCode()}\nSender:{sender}");
                if (person != null)
                {
                    aFilter.AddFilter(person.Id);
                    //Console.WriteLine($"Found Id\nIt is:{person.Id}");
                }
                else
                {
                    aFilter.AddFilter("NoFilter");
                    //Console.WriteLine("SelectedItem is null");
                }
            });
            Console.WriteLine($"Subscribed details view\nHash:{this.GetHashCode()}");
        }
        private void UnLoad()
        {
            MessagingCenter.Unsubscribe<ContactsDetailViewModel>(this, "sendFilters");
            Console.WriteLine($"Unsubscribed details view\nHash:{this.GetHashCode()}");
        }
        Person person;

        public ContactsDetailViewModel()
        {
            
            MessagingCenter.Subscribe<ContactsDetailPage, string>(this, "uid", (sender,arg)=>
            {

                Person = ContactsData.Contacts.FirstOrDefault(p => p.Id == arg);
                
            });
        }


        public Person Person
        {
            get { return person; }
            set
            {
                if (person != value)
                {
                    person = value;
                    //MessagingCenter.Send<ContactsDetailViewModel, string[]>(this, "filtered", new string[] { person.Id });
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ModifyContactCommand => new Command(ModifyContact);
        private async void ModifyContact()
        {
            await Shell.Current.GoToAsync($"modifycontact?uid={person.Id}");
        }
    }
}
