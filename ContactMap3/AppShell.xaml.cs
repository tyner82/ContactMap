using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using ContactMap3.Views;
using ContactMap3.ViewModels;

namespace ContactMap3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
        }

    }
}
