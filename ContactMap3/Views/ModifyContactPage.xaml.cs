using System.Linq;
using System.Collections.Generic;
using ContactMap3.Data;
using ContactMap3.ViewModels;
using ContactMap3.Models;
using Xamarin.Forms;
using System;

namespace ContactMap3.Views
{

    [QueryProperty("UId", "uid")]
    public partial class ModifyContactPage : ContentPage
    {
        Person person;
        public ModifyContactPage()
        {
            InitializeComponent();
            BindingContext = new ModifyContactViewModel();
        }

        public string UId
        {
            set
            {
                person = ContactsData.Contacts.FirstOrDefault(p => p.Id == Uri.UnescapeDataString(value));
            }
        }

    }
}
