using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace ContactMap3.Views
{
    public partial class MapPage : ContentPage
    {
<<<<<<< HEAD:ContactMap3/Views/MapPage.xaml.cs
        public MapPage()
=======
        public List<Models.Person> People = new List<Models.Person>();

        public AppShell()
>>>>>>> Add Person and AddressCl Class:ContactMap/AppShell.xaml.cs
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
