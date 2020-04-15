using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Content.Res;
using ContactMap3.Behaviors;
using ContactMap3.Data;
using ContactMap3.Models;
using ContactMap3.Views;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class ModifyContactViewModel : BaseViewModel
    {
        Person person;
        string selectedCountryName;
        string selectedStateName;
        List<string> states;
        List<string> countries;
        string phone;
        bool isValidPostal;
        string zipCode;
        Filter phoneFilter;
        Filter postalFilter;
        Func<string, bool> matchPostal;
        Filter wordFilter = new Filter(FilterFunctions.WordFilter);
        string zipPlace;
        string stateTitle;
        string postalLabel;
        string name;
        string street;
        string city;
        string id = "0";
        bool isUpdate = false;
        bool isDataSaved = false;

        public ModifyContactViewModel()
        {
            countries = AddressData.Countries;
            states = AddressData.States;
            phoneFilter = new Filter(FilterFunctions.PhoneFilter);
            postalFilter = new Filter(FilterFunctions.ZipCodesFilter);
            matchPostal = x => true;
            zipPlace = "12345";
            stateTitle = "Select a State";
            postalLabel = "Zip Code";
            isUpdate = false;
            isDataSaved = false;


            MessagingCenter.Subscribe<ModifyContactPage, string>(this, "uid", async (sender, arg) =>
            {
                if (arg != "0")
                {
                    person = await DataStore.GetItemAsync(arg);// ContactsData.Contacts.FirstOrDefault(p => p.Id == arg);
                    id = person.Id;
                    Name = person.Name;
                    FiltPhone = person.Phone;
                    string combineStreet = person.Address.Number+" " + person.Address.Street;
                    Street = combineStreet;
                    City = person.Address.City;
                    SelectedCountryName = person.Address.Country;
                    SelectedStateName = person.Address.State;
                    ZipCode = person.Address.Postal;
                    isUpdate = true;
                }

                //Console.WriteLine("@ modifyviewmodel" + arg);
            });
        }

        string[] UnCombine(string street)
        {
            var parts = street.Split(" "[0]);
            string number = parts[0];
            street = street.TrimStart((number + " ").ToCharArray());
            string[] result = new string[2] { number, street };
            return result;
        }

        Person BuildPerson()
        {
            Address address = new Address();
            address.Number = UnCombine(Street)[0];
            address.Street = UnCombine(Street)[1];
            address.City = City;
            address.State = SelectedStateName;
            address.Postal = ZipCode;
            address.Country = selectedCountryName;
            Console.WriteLine($"Created address{ address.ToString()}");
            Person person = new Person();
            person.Id = id;
            person.Name = Name;
            person.Phone = FiltPhone;
            person.Address=address;
            Console.WriteLine($"Created Person {person.ToString()}");
            return person;
        }

        public string FiltPhone
        {
            get { return phone; }
            set
            {
                if (value != phone)
                {
                    phone = phoneFilter(value);
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = wordFilter(value);
                    OnPropertyChanged();
                }
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (value != street)
                {
                    street = wordFilter(value);
                    OnPropertyChanged();
                }
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (value != city)
                {
                    city = wordFilter(value);
                    OnPropertyChanged();
                }
            }
        }

        public string PostalLabel
        {
            get { return postalLabel; }
            set
            {
                if (value != postalLabel)
                {
                    postalLabel = value;
                    OnPropertyChanged();
                }
            }
        }

        public string StateTitle
        {
            get { return stateTitle; }
            set
            {
                if (value != stateTitle)
                {
                    stateTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ZipPlace
        {
            get { return zipPlace; }
            set
            {
                if (value != zipPlace)
                {
                    zipPlace = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                if (zipCode != value)
                {
                    zipCode = postalFilter(value);
                    OnPropertyChanged();
                    isValidPostal = matchPostal(zipCode);
                    //TODO: implement verification of data
                    Console.WriteLine("Postal Code Checksout?" + (isValidPostal ? "True" : "False"));

                }
            }
        }

        public string SelectedCountryName
        {
            get { return selectedCountryName; }
            set
            {
                if (selectedCountryName != value)
                {
                    selectedCountryName = value;
                    OnPropertyChanged();
                    if (value == AddressData.Countries[0])
                    {
                        //TODO fix State disappearing
                        if (States != AddressData.States)
                        {
                            States = AddressData.States;
                            matchPostal = x => true;
                            postalFilter = new Filter(FilterFunctions.ZipCodesFilter);
                            ZipCode = "";

                            SelectedStateName = "";
                            ZipPlace = "12345";
                            StateTitle = "Select a State";
                            PostalLabel = "Zip Code";
                        }
                    }
                    else
                    {
                        if (States != AddressData.Provinces)
                        {
                            States = AddressData.Provinces;
                            matchPostal = x => FilterFunctions.MatchesPostalCode(x);
                            postalFilter = new Filter(FilterFunctions.PostalCodesFilter);
                            ZipCode = "";
                            SelectedStateName = "";
                            ZipPlace = "A0A 1B1";
                            StateTitle = "Select a Province";
                            PostalLabel = "Postal Code";
                        }
                    }
                }
            }
        }

        public List<string> Countries
        {

            get { return countries; }
            private set
            {
                countries = value;
                //OnPropertyChanged();
            }
        }


        public List<string> States
        {
            get { return states; }
            private set
            {
                    states = value;
                    OnPropertyChanged();
            }
        }

        public string SelectedStateName
        {

            get { return selectedStateName; }
            set
            {
                if (selectedStateName != value)
                {
                    selectedStateName = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveContactCommand => new Command(SaveContact);
        private async void SaveContact()
        {
            person = BuildPerson();
            if (IsValid(person))
            {
                if (isUpdate)
                {
                    Console.WriteLine("Update");
                    MessagingCenter.Send<ModifyContactViewModel, Person>(this, "UpdateItem", person);
                }
                else
                {
                    Console.WriteLine("New Item");
                    MessagingCenter.Send<ModifyContactViewModel, Person>(this, "AddItem", person);
                }
                isDataSaved = true;
                await Shell.Current.Navigation.PopToRootAsync();
            }
        }

        private bool IsValid(Person person)
        {
            return true; //TODO: should check stuff Better
        }

    }
}