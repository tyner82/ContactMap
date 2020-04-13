using System;
using System.Collections.Generic;
using ContactMap3.Views;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class AppShellViewModel:BaseViewModel
    {

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        bool firstRun = true;
        //string[] filtered;
        public string[] Filtered { get; set; }
        public AppShellViewModel()
        {
            if (firstRun)
            {
                RegisterRoutes();

                // Moved this to Contacts, condensed to one subscriber
                //MessagingCenter.Subscribe<ContactsDetailPage, string>(this, "uid", (sender, arg) =>
                //{
                //    Console.WriteLine($"New Filter Item\nlocation:{this.GetHashCode()}");
                //    Console.WriteLine($"UID: {arg}");
                //    Filtered = new string[] { arg };
                //    Console.WriteLine($"Saved in Filtered{Filtered[0]}");

                //});

                //MessagingCenter.Subscribe<MapViewModel>(this, "SendContacts", (sender) =>
                //{
                //    Console.WriteLine($"Got Request,\n Filtered={0}\nLength: {1}",Filtered[0],Filtered.Length);
                //    //MessagingCenter.Send(this, "contacts", filtered);
                //});
                firstRun = false;
            };
        }


        void RegisterRoutes()
        {
            routes.Add("contactdetails", typeof(ContactsDetailPage));
            routes.Add("modifycontact", typeof(ModifyContactPage));
            routes.Add("contacts", typeof(ContactsPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
