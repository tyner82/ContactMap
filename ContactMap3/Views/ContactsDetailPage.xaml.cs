using System;
using System.Collections.Generic;
using System.Linq;
using ContactMap3.Data;

using Xamarin.Forms;

namespace ContactMap3.Views
{
    [QueryProperty("Uid","uid")]
    public partial class ContactsDetailPage : ContentPage
    {
        
        public string Uid
        {
            set
            {
                BindingContext = ContactsData.Contacts.FirstOrDefault(p => p.Id == Uri.UnescapeDataString(value));
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
