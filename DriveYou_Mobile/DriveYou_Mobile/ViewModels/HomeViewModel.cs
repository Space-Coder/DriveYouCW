using DriveYou_Mobile.Models;
using DriveYou_Mobile.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command FindCommand { get; }
       
        public HomeViewModel()
        {
            FindCommand = new Command(FindCommandClicked);
           
            FindTrip = new FindTripModel();
        }

        private FindTripModel findTrip;
        public FindTripModel FindTrip
        {
            get { return findTrip; }
            set
            {
                findTrip = value;
                OnPropertyChanged("FindTrip");
            }
        }

        private async void FindCommandClicked()
        {
            await AppShell.Current.Navigation.PushAsync(new HomeTrips(FindTrip));
        }

        public DateTime MinimumDate
        {
            get { return DateTime.Today; }
        }


        
    }
}