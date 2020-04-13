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
        string[] filtered;

        public AppShellViewModel()
        {
            if (firstRun)
            {
                RegisterRoutes();


                MessagingCenter.Subscribe<ContactsDetailPage, string>(this, "uid", (sender, arg) =>
                {
                    Console.WriteLine($"New Filter Item\nlocation:{this.GetHashCode()}");
                    filtered = new string[] { arg };

                });

                MessagingCenter.Subscribe<MapPage, string>(this, "uid", (sender, arg) =>
                {
                    Console.WriteLine($"New Filter Item\nlocation:{this.GetHashCode()}");
                    filtered = new string[] { arg };

                });
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
