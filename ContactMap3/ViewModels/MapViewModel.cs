using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactMap3.Views;
using ContactMap3.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ContactMap3.ViewModels
{
    public class MapViewModel:BaseViewModel
    {
        string[] currentIds;
        List<Person> Contacts { get; set; }
        public ICommand LoadContactsCommand { get; private set; }
        public ICommand PageAppearingCommand { get; private set; }
        public ICommand PageDisappearingCommand { get; private set; }
        List<Location> locs;
        List<MapLocation> mapLocsProperties;
        Xamarin.Forms.Maps.Map mapRef;

        public MapViewModel(Xamarin.Forms.Maps.Map map)
        {
            mapRef = map;
            Contacts = new List<Person>();
            PageAppearingCommand = new Command(async () => await ExecuteLoadContacts());
            //PageAppearingCommand = new Command(OnPageAppearing);
            PageDisappearingCommand = new Command(OnPageDisappearing);
            locs = new List<Location>();
            mapLocsProperties = new List<MapLocation> ();
            if (Application.Current.Properties.ContainsKey("id"))
            {
                currentIds = Application.Current.Properties["id"] as string[];

            }


        }
        public void OnPageDisappearing()
        {

        }

        async Task ExecuteLoadContacts()
        {
            Console.WriteLine("Invocation Must have work LoadContactsCommand");
            if (IsBusy)
                return;
            IsBusy = true;

            if (Application.Current.Properties.ContainsKey("id"))
            {
                currentIds = Application.Current.Properties["id"] as string[];

            }
            try
            {
                Contacts.Clear();
                Console.WriteLine($"Contacts.Clear succeeded ArrayIds:/n{currentIds}");
                if (currentIds != null)
                {
                    foreach (string id in currentIds)
                    {
                        if (id != null)
                        {
                            var contact = await DataStore.GetItemAsync(id);
                            Contacts.Add(contact);
                        }
                    }
                }
                else
                {
                    var result = await DataStore.GetItemsAsync(true);
                    foreach(Person p in result)
                    {
                        Console.WriteLine(p.Name);
                        Contacts.Add(p);
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine($"Caught this error Loading Contacts from mockstore:\n{e}");
            }
            finally
            {
                Console.WriteLine(Contacts);
                Console.WriteLine(currentIds);
                await populateMap(Contacts);
                IsBusy = false;
            }

        }

        private async Task populateMap(List<Person> people)
        {
            foreach (Person person in people)
            {
            //Person person = await DataStore.GetItemAsync(ids[0]);

            //Person person = people.FirstOrDefault(p => p.Id == id);
                string address = person.Address.ToString();
                double avgLat=0;
                double avgLong=0;
                double minLat = 90;
                double maxLat = -90;
                double minLong = 180;
                double maxLong = -180;
                try
                {

                    Location location = await GeocodeThis(address);
                    locs.Add(location);
                    Pin apin = new Pin()
                    {
                        Position = new Position(location.Latitude, location.Longitude),
                        Label = person.Name
                    };
                    avgLat += location.Latitude;
                    avgLong += location.Longitude;
                    mapRef.Pins.Add(apin);
                    mapLocsProperties.Add(new MapLocation(address, person.Name, new Position(location.Latitude, location.Longitude)));
                    //TODO Map by name
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception:{ex} Outside Geocoding");
                }

                avgLat /= mapLocsProperties.Count;
                avgLong /= mapLocsProperties.Count;
                Console.WriteLine($"{avgLat}, {avgLong}");
                //new Position(avgLat, avgLong);
                mapRef.MoveToRegion(MapSpan.FromCenterAndRadius(mapLocsProperties[0].Position, Distance.FromKilometers(50* mapLocsProperties.Count)));
                //Console.WriteLine($"Check Formating: \n{address}");
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
                //if (location != null)
                //{
                //    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                //}
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
