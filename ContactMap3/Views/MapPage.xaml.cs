using System;
using System.Collections.Generic;
using ContactMap3.ViewModels;
using Xamarin.Forms;

namespace ContactMap3.Views
{
    public partial class MapPage : ContentPage
    {

        public MapPage()
        {
            InitializeComponent();
            BindingContext = new MapViewModel();
            Console.WriteLine("Loaded Map");
        }
    }
}
