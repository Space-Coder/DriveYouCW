using DriveYou_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class AddTripViewModel : BaseViewModel
    {

        //Loading Animation
        //https://assets2.lottiefiles.com/packages/lf20_tsxbtrcu.json
        //Loading done animation
        //https://assets7.lottiefiles.com/private_files/lf30_nrnx3s.json
        public Command AddTripCommand { get; }
        public Command HideBusyIndicator { get; }
        
        public AddTripViewModel()
        {
            AddTripCommand = new Command(AddTripCommand_Click);
            HideBusyIndicator = new Command(HideBusyIndicator_Event);
            IsBusy = false;
            Trip = new ScheduledTripsModel();
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        private string animationUrl;

        public string AnimationUrl
        {
            get { return animationUrl; }
            set { animationUrl = value;
                OnPropertyChanged("AnimationUrl");
            }
        }

        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time; }
            set { time = value;
                OnPropertyChanged("Time");
            }
        }


        public DateTime MinimumDate
        {
            get { return DateTime.Today; }
        }


        private ScheduledTripsModel trip;

        public ScheduledTripsModel Trip
        {
            get { return trip; }
            set { trip = value;
                OnPropertyChanged("Trip");
            }
        }

        private async void AddTripCommand_Click()
        {
            AnimationUrl = "https://assets2.lottiefiles.com/packages/lf20_tsxbtrcu.json";
            IsBusy = true;
            Trip.Date = Trip.Date.Add(Time);
            string jsonContent = JsonSerializer.Serialize(Trip, typeof(ScheduledTripsModel));
            HttpContent postContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync("trips/scheduled/new", postContent);
            if (response.IsSuccessStatusCode)
            {
                AnimationUrl = "https://assets7.lottiefiles.com/private_files/lf30_nrnx3s.json";
                //Messgae ok
            }
            else
            {
                //Message not ok
            }
        }

        private void HideBusyIndicator_Event()
        {
            IsBusy = false;
        }

    }
}
