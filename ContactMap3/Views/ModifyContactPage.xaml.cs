using System.Linq;
using System.Collections.Generic;
using ContactMap3.Data;
using Xamarin.Forms;
using System;

namespace ContactMap3.Views
{

    [QueryProperty("UId", "uid")]
    public partial class ModifyContactPage : ContentPage
    {
        public string UId
        {
            set
            {
                BindingContext = ContactsData.Contacts.FirstOrDefault(p => p.Id == Uri.UnescapeDataString(value));
            }
        }

        public ModifyContactPage()
        {
            InitializeComponent();
        }
    }
}
