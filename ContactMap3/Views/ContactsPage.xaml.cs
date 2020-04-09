using System;
using System.Collections.Generic;
using System.Linq;
using ContactMap3.Models;
using Xamarin.Forms;

namespace ContactMap3.Views
{

    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string personName = (e.CurrentSelection.FirstOrDefault() as Person).Name;
            // This works because route names are unique in this application.
            await Shell.Current.GoToAsync($"contactdetails?name={personName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        }
    }
}
