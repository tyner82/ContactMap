using System;
using System.Linq;
using System.Windows.Input;
using ContactMap3.Models;
using ContactMap3.Views;
using ContactMap3.Data;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ContactsDetailViewModel: BaseViewModel
    {

        Person person;
        string name;
        string street;

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
                    OnPropertyChanged();
                }
            }
        }
            //<Label Text = "{Binding Name}"
            //       HorizontalOptions="Center" />
            //<Label Text = "{Binding Street}"
            //       HorizontalOptions="Center" />
            //<Label Text = "{Binding City}"
            //       HorizontalOptions="Center" />
            //<Label Text = "{Binding State}"
            //       HorizontalOptions="Center" />
            //<Label Text = "{Binding ZipCode}"
            //       HorizontalOptions="Center" />

        public ICommand ModifyContactCommand => new Command(ModifyContact);
        private async void ModifyContact()
        {
            await Shell.Current.GoToAsync($"modifycontact?uid={person.Id}");
        }
    }
}
