using System;
using System.Collections.Generic;
using ContactMap3.Data;
using ContactMap3.Views;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class AppShellViewModel:BaseViewModel
    {

        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShellViewModel()
        {
            RegisterRoutes();
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
