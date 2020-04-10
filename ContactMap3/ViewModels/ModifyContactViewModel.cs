using System;
using System.Collections.Generic;
using ContactMap3.Data;

namespace ContactMap3.ViewModels
{
    public class ModifyContactViewModel : BaseViewModel
    {
        public ModifyContactViewModel()
        {
            countries = AddressData.Countries;
            states = AddressData.States;
        }
        public string selectedCountryName;
        public string selectedStateName;
        public List<string> states;
        public List<string> countries;

        public string SelectedCountryName
        {
            get { return selectedCountryName; }
            set
            {
                if (selectedCountryName != value)
                {
                    selectedCountryName = value;
                    OnPropertyChanged();
                    Console.WriteLine(value);
                    if (value == AddressData.Countries[0])
                    {
                        States = AddressData.States;
                        SelectedStateName = states[0];
                    }
                    else
                    {
                        States = AddressData.Provinces;
                        SelectedStateName = states[0];
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
