using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using Android.Webkit;
using DriveYou_Mobile.Models;
using DriveYou_Mobile.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class HomeTripsViewModel : BaseViewModel
    {
        

        private FindTripModel _findTrip;
        private ObservableCollection<ScheduledTripsWithUserModel> trips;
        public Command UpdateCommand { get; }
        public Command BackToHomeCommand { get; }
        public Command OpenTripDetails { get; }

        public HomeTripsViewModel()
        {

        }
        public HomeTripsViewModel(FindTripModel model)
        {
            _findTrip = model;
            UpdateCommand = new Command(LoadTrips);
            BackToHomeCommand = new Command(BackToHomeCommandClicked);
            LoadTrips();
        }

        public ObservableCollection<ScheduledTripsWithUserModel> Trips
        {
            get { return trips; }
            set
            {
                trips = value;
                OnPropertyChanged("Trips");
            }
        }

        private ScheduledTripsWithUserModel _selectedTrip;
        public ScheduledTripsWithUserModel SelectedTrip
        {
            get { return _selectedTrip; }
            set 
            { 
                _selectedTrip = value;
                OnPropertyChanged("SelectedTrip");
                if (value != null)
                {
                    AppShell.Current.Navigation.PushAsync(new TripsDetailedPage(SelectedTrip, true));
                    SelectedTrip = null;
                }
            }
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { 
                isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }


        private async void BackToHomeCommandClicked()
        {
            await AppShell.Current.Navigation.PopAsync();
        }

        public async void LoadTrips()
        {
            
            string jsonContent = System.Text.Json.JsonSerializer.Serialize(_findTrip, typeof(FindTripModel));
            HttpContent postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync("trips/scheduled", postContent);
            if (response.IsSuccessStatusCode)
            {
                using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    Trips = JsonConvert.DeserializeObject<ObservableCollection<ScheduledTripsWithUserModel>>(jsonStr);
                };
                IsRefreshing = false;
            }
        }
    }
}
