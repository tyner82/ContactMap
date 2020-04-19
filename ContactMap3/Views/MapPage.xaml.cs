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
            BindingContext = new MapViewModel(map);
            Console.WriteLine("Loaded Map");
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}
