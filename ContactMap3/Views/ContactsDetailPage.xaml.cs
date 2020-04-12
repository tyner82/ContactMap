using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ContactMap3.Data;
using ContactMap3.ViewModels;
using Xamarin.Forms;

namespace ContactMap3.Views
{
    [QueryProperty("UId","uid")]
    public partial class ContactsDetailPage : ContentPage
    {
        public string UId
        {
            set
            {
                string uid = Uri.UnescapeDataString(value);
                //Console.WriteLine("got uid from contacts page" + Uri.UnescapeDataString(value));
                //Console.WriteLine("Name: "+person.Name);
                MessagingCenter.Send<ContactsDetailPage, string>(this, "uid", uid);
            }
        }
        public ContactsDetailPage()
        {
            InitializeComponent();
            BindingContext = new ContactsDetailViewModel();
            //Console.WriteLine("Have I got user id yet?" + person.Id);
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

    }
}
