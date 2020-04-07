using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace ContactMap
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public List<Models.Person> People = new List<Models.Person>();

        public AppShell()
        {
            InitializeComponent();
        }
    }
}
