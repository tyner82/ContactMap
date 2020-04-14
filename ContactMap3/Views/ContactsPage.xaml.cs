using ContactMap3.ViewModels;
using ContactMap3.Models;
using Xamarin.Forms;
using System;

namespace ContactMap3.Views
{
    public partial class ContactsPage : ContentPage
    {
        ContactsViewModel vm;

        //int FilterLimit { get; set; } = 10;
        public ContactsPage()
        {
            InitializeComponent();
            BindingContext = vm = new ContactsViewModel();
        }
    }
}
