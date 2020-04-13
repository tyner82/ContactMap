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
            //filtered = new string[FilterLimit];
            BindingContext = vm = new ContactsViewModel();
            //MessagingCenter.Subscribe<ContactsDetailViewModel, string[]>(this, "filtered", (sender, arg) =>
            //{

            //    Console.WriteLine("Got a message Length" + arg.Length);
            //    Console.WriteLine($"In ExecuteOnQuantityChangedCommand\nlocation:{this.GetHashCode()}");
            //    filtered = arg;
            //});
        }
    }
}
