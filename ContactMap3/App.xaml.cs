using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactMap3.Data;

namespace ContactMap3
{
    public partial class App : Application
    {
        public bool UseMockDataStore = true;
        public App()
        {
            InitializeComponent();
            if (UseMockDataStore)
                DependencyService.Register<PersonDataStore>();
            else
                Console.Write("Placeholder for alternate service");


            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
