using System;
using System.Collections.Generic;
using System.Linq;
using ContactMap3.Data;

using Xamarin.Forms;

namespace ContactMap3.Views
{
    [QueryProperty("Name","name")]
    public partial class ContactsDetailPage : ContentPage
    {
        public string Name
        {
            set
            {
                BindingContext = ContactsData.Contacts.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
            }
        }

        public ContactsDetailPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
