using ContactMap3.ViewModels;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.Views
{
    public partial class ContactsPage : ContentPage
    {
        public Person _SelectedItem;
        public ContactsPage()
        {
            InitializeComponent();

            BindingContext = new ContactsViewModel();
        }
        /* moved to viewmodel
        public Person SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
        }
        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string personName = (e.CurrentSelection.FirstOrDefault() as Person).Name;
            await Shell.Current.GoToAsync($"contactdetails?name={personName}");
        }*/
    }
}
