using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactMap3.Data;
using ContactMap3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactMap3.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestMultiItemView : ContentView
    {
        TestMultiViewModel vm;

        public bool IsDirty { get; set; }

        public TestMultiItemView()
        {
            InitializeComponent();
            //FillLocalCache();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            vm = BindingContext as TestMultiViewModel;
            ContactCollection.ItemsSource = vm.PeopleCollection;
            vm.IsDirty = true;
            
        }

    }

    public class TestMultiViewModel
    {
        public bool IsDirty { get; set; }
        List<Person> People = new List<Person>();
        public ObservableCollection<Person> PeopleCollection;
        PersonDataStore DataStore = new PersonDataStore();
        public ICommand RefreshCollectionCommand => new Command(RefreshCollection);

        public TestMultiViewModel()
        {
        }

        public TestMultiViewModel(string withParameters)
        {
            string p = withParameters;
            Console.WriteLine($"TestViewModel Constructor: {p}");
            PeopleCollection = new ObservableCollection<Person>();
            RefreshCollection();
        }

        private async void RefreshCollection()
        {
            List<Person> items = await DataStore.GetItemsAsync(false) as List<Person>;
            foreach (Person item in items)
            {
                PeopleCollection.Add(item);
            }
            Console.WriteLine($"Populated People{PeopleCollection[0].Name}");
            IsDirty = false;
        }
    }



}
