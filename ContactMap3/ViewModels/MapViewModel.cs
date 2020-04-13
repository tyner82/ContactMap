using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactMap3.Models;
using ContactMap3.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class MapViewModel:BaseViewModel
    {
        List<Person> contacts = new List<Person>();
        List<string> currentIds;

        public List<string> CurrentIds
        {
            get
            {
                return currentIds;
            }
            set
            {
                if (currentIds != value)
                {
                    currentIds = value;
                    OnPropertyChanged();
                }
            }
        }

        public MapViewModel()
        {
        }

        public ICommand UpdateViewCommand => new Command(RequestUpdate);

        private async void RequestUpdate()
        {

            ActiveFilter activeFilters = new ActiveFilter();
            MessagingCenter.Send(this, "sendFilters", activeFilters);//Send this instance of activefilters to be updated fromInfoHost
            var currentFilters = await activeFilters.Filters();
            Console.WriteLine("I'm Back");
            if (currentFilters != null)
            {
                CurrentIds.Clear();
                foreach (string filter in currentFilters)
                {
                    if (filter != null)
                    {
                        CurrentIds.Add(filter);
                    }
                }
            }
            else
            {

                Console.WriteLine("Got Null");
            }
        }

        private async void populateMap(List<Person> people, List<string> ids)
        {
            List<Location> locs = new List<Location>();
            foreach (Person person in people)
            {
                //Person person = people.FirstOrDefault(p => p.Id == id);
                string address = person.Address.ToString();
                try
                {

                    Location location = await GeocodeThis(address);
                    locs.Add(location);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception:{ex} Outside Geocoding");
                }
                Console.WriteLine($"Check Formating: \n{address}");
            }
        }

        async Task<Location> GeocodeThis(string address)
        {
            Location location = new Location();
            try
            {
                //var address = "Microsoft Building 25 Redmond WA USA";
                var locations = await Geocoding.GetLocationsAsync(address);
                if (locations.Count() > 1)
                {
                    Console.WriteLine($"ManyLocations, {locations.Count()}");
                }
                location = locations?.FirstOrDefault();
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine($"Exception:{fnsEx} \nGeocoding Feature Not Supported");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex} \nInside Geocoding");
            }
            return location;
        }
    }
}
