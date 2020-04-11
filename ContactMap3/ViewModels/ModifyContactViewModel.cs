using System;
using System.Collections.Generic;
using ContactMap3.Behaviors;
using ContactMap3.Data;

namespace ContactMap3.ViewModels
{
    public class ModifyContactViewModel : BaseViewModel
    {
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
        }
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
        string zipPlace;
        string stateTitle;
        string postalLabel;

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
                    Console.WriteLine("Postal Code Checksout?" + (isValidPostal?"True":"False"));

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
                        States = AddressData.States;
                        matchPostal = x => true;
                        postalFilter = new Filter(FilterFunctions.ZipCodesFilter);
                        ZipCode = "";
                        SelectedStateName = "";
                        ZipPlace = "12345";
                        StateTitle = "Select a State";
                        PostalLabel = "Zip Code";
                    }
                    else
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

        public List<string> Countries
        {

            get { return countries; }
            private set { countries = value; OnPropertyChanged(); }
        }


        public List<string> States
        {
            get { return states; }
            private set { states = value; OnPropertyChanged(); }
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
    }
}
