using System;
using Xamarin.Forms;

namespace ContactMap3.ViewModels
{
    public class MapViewModel:BaseViewModel
    {
        string[] currentIds;

        public string[] CurrentIds
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
            MessagingCenter.Send<MapViewModel>(this, "SendContacts");
            MessagingCenter.Subscribe<AppShellViewModel, string[]>(this, "contacts", (sender, arg) =>
            {
                CurrentIds = arg;
            });
        }
    }
}
