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

        public ContactsDetailViewModel()
        {
            
            MessagingCenter.Subscribe<ContactsDetailPage, string>(this, "uid", async (sender,arg)=>
            {

                Person = await DataStore.GetItemAsync(arg);
                
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
