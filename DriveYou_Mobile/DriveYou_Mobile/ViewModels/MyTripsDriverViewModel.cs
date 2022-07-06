using DriveYou_Mobile.Models;
using DriveYou_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class MyTripsDriverViewModel : BaseViewModel
    {
        public Command LoadMyTrips { get; }
        public MyTripsDriverViewModel()
        {
            IsBusy = false;
            LoadMyTrips = new Command(LoadMyTrips_Command);
            LoadMyTrips_Command();
        }

        private ObservableCollection<ScheduledTripsWithUserModel> _myTrips;

        public ObservableCollection<ScheduledTripsWithUserModel> MyTrips
        {
            get { return _myTrips; }
            set { _myTrips = value;
                OnPropertyChanged("MyTrips");
            }
        }

        private ScheduledTripsWithUserModel selectedTrip;
        public ScheduledTripsWithUserModel SelectedTrip
        {
            get { return selectedTrip; }
            set { selectedTrip = value;
                OnPropertyChanged("SelectedTrip");
                if (value != null)
                {
                    AppShell.Current.Navigation.PushAsync(new TripsDetailedPage(SelectedTrip, false));
                    SelectedTrip = null;
                }
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private async void LoadMyTrips_Command()
        {
            IsBusy = true;
            HttpResponseMessage response = await App.client.GetAsync("trips/scheduled/my");
            if (response.IsSuccessStatusCode)
            {
                using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    MyTrips = JsonConvert.DeserializeObject<ObservableCollection<ScheduledTripsWithUserModel>>(jsonStr);
                }
                IsBusy = false;
            }
        }



    }
}
