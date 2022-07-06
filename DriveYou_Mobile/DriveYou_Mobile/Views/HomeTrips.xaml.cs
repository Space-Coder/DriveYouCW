using DriveYou_Mobile.Models;
using DriveYou_Mobile.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveYou_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTrips : ContentPage
    {
        public HomeTrips(FindTripModel model)
        {
            InitializeComponent();
            this.BindingContext = new HomeTripsViewModel(model);
        }
    }
}