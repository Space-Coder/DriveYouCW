using DriveYou_Mobile.Models;
using DriveYou_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class TripsDetailedPageViewModel : BaseViewModel
    {
        public Command ActionCommand { get; }
        public Command CallCommand { get; }
        public Command MessageCommand { get; }
        public Command BackToHomeTripsCommand { get; }
        public Command OpenDriverInfo { get; }
        private bool IsSubscribed = false;
        public TripsDetailedPageViewModel()
        {
            
        }

        public TripsDetailedPageViewModel(ScheduledTripsWithUserModel model, bool isCompanion)
        {
            IsTripCompanion = isCompanion;
            if (IsTripCompanion == true)
            {
                IsSubscribed_Check();
            }
            Trip = model;
            LoadDestination();
            
            ActionCommand = new Command(SubscribeUnsubscribeOnTrip);
            CallCommand = new Command(CallCommand_Click);
            OpenDriverInfo = new Command(OpenDriverInfo_Click);
            MessageCommand = new Command(MessageCommand_Click);
            BackToHomeTripsCommand = new Command(BackToHomeTripsNavigationClicked);
            
        }

        private string distance;

        public string Distance
        {
            get { return distance; }
            set { distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private double listHeight;
        public double ListHeight
        {
            get { return listHeight; }
            set { listHeight = value;
                OnPropertyChanged("ListHeight");
            }
        }


        private string carInfo;
        public string CarInfo
        {
            get { return carInfo; }
            set { carInfo = value;
                OnPropertyChanged("CarInfo");
            }
        }

        private string seatInfo;

        public string SeatInfo
        {
            get { return seatInfo; }
            set { seatInfo = value;
                OnPropertyChanged("SeatInfo");
            }
        }



        private bool istripCompanion;

        public bool IsTripCompanion
        {
            get { return istripCompanion; }
            set { istripCompanion = value;
                OnPropertyChanged("IsTripCompanion");
            }
        }

        private string actionCaption;

        public string ActionCaption
        {
            get { return actionCaption; }
            set { actionCaption = value;
                OnPropertyChanged("ActionCaption");
            }
        }

        private ScheduledTripsWithUserModel trip;

        public ScheduledTripsWithUserModel Trip
        {
            get { return trip; }
            set { trip = value;
                if (Trip.SubscribedOnTrips != null)
                {
                    ListHeight = value.SubscribedOnTrips.Count * 80;
                }
                OnPropertyChanged("Trip");
            }
        }

        private SubscribedOnTripsModel subscribedUser;

        public SubscribedOnTripsModel SubscribedUser
        {
            get { return subscribedUser; }
            set { subscribedUser = value;
                if (value != null)
                {
                    AppShell.Current.Navigation.PushAsync(new AccountPage(false, SubscribedUser.UserID));
                    SubscribedUser = null;
                }
                OnPropertyChanged("SubscribedUser");
            }
        }

        private async void OpenDriverInfo_Click()
        {
            await AppShell.Current.Navigation.PushAsync(new AccountPage(false, Trip.ScheduledTrips.UserID));
        }


        private async void IsSubscribed_Check()
        {
            HttpResponseMessage response = await App.client.GetAsync("trips/scheduled/subscribed");
            if (response.IsSuccessStatusCode)
            {
                using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    List<SubscribedOnTripsModel> model = JsonConvert.DeserializeObject<List<SubscribedOnTripsModel>>(jsonStr);
                    if (model.Count > 0)
                    {
                        foreach (var item in model)
                        {
                            IsSubscribed = item.ID == Trip.ID ? true : false;
                            ActionCaption = item.ID == Trip.ID ? "Отписаться" : "Подписаться";
                        }
                    }
                    else
                    {
                        IsSubscribed = false;
                        ActionCaption = "Подписаться";
                    }
                    
                }
                 
            }
        }

        private async void BackToHomeTripsNavigationClicked()
        {
            await AppShell.Current.Navigation.PopAsync();
        }

        private async void SubscribeUnsubscribeOnTrip()
        {
            string command = IsSubscribed == true ? "unsubscribe" : "subscribe";
            HttpResponseMessage response = await App.client.PostAsync($"trips/scheduled/{command}/{Trip.ScheduledTrips.ID}", null);
            if (response.IsSuccessStatusCode)
            {
                IsSubscribed = !IsSubscribed;
                ActionCaption = IsSubscribed == true ? "Отписаться" : "Подписаться";
            }
        }

        private void CallCommand_Click()
        {
            PhoneDialer.Open($"+{Trip.Number.ToString()}");
        }

        private async void MessageCommand_Click()
        {
            var message = new SmsMessage("Здравствуйте !", $"+{Trip.Number.ToString()}");
            await Sms.ComposeAsync(message);
        }

        private async void LoadDestination()
        {
            if (Trip.ScheduledTrips != null)
            {
                if (!string.IsNullOrEmpty(Trip.CarMark) && !string.IsNullOrEmpty(Trip.CarModel))
                {
                    CarInfo = $"{Trip.CarMark}, {Trip.CarModel}";
                }
                if (Trip.SubscribedOnTrips != null)
                {
                    SeatInfo = $"{Trip.ScheduledTrips.Seats - Trip.SubscribedOnTrips.Count} из {Trip.ScheduledTrips.Seats} свободно";
                }
                else
                {
                    SeatInfo = $"{Trip.ScheduledTrips.Seats} места свободно";
                }
            }
            var sourceLocation = await Geocoding.GetLocationsAsync(Trip.ScheduledTrips.From);
            var destinationLocation = await Geocoding.GetLocationsAsync(Trip.ScheduledTrips.To);
            var source = sourceLocation.FirstOrDefault();
            var destination = destinationLocation.FirstOrDefault();
            HttpClient geolocationApi = new HttpClient()
            {
                BaseAddress = new Uri("https://api.mapbox.com/directions/v5/mapbox/driving/", UriKind.RelativeOrAbsolute)
            };
            string geoStr = $"{source.Longitude}%2C{source.Latitude}%3B{destination.Longitude}%2C{destination.Latitude}" +
                $"?alternatives=false&continue_straight=false&geometries=geojson&overview=simplified&steps=false&" +
                $"access_token=pk.eyJ1Ijoic3BhY2Vjb2RlciIsImEiOiJjbDRnZnM2MHUwOGl1M2NuendscHRhM2IxIn0.AyPSVzxpvOxT3q0DrNpbdg";
            HttpResponseMessage response = await geolocationApi.GetAsync(geoStr);
            if (response.IsSuccessStatusCode)
            {
                using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(jsonStr);
                    var values = data["routes"];
                    for (int i = 0; i < values.Count; i++)
                    {
                        double distance = (double)values[i]["distance"];
                        distance = distance / 1000;
                        Distance = string.Format("~{0} км", Convert.ToInt32(distance));
                    }
                }
            }
        }

    }
}
