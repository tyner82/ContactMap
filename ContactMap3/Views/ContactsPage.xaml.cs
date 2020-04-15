using ContactMap3.ViewModels;
using ContactMap3.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
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
            BindingContext = vm = new ContactsViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnBindingContextChanged()
        {

            base.OnBindingContextChanged();
        }

    }
}
