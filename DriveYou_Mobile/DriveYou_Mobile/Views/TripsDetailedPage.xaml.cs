using DriveYou_Mobile.Models;
using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveYou_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripsDetailedPage : ContentPage
    {
        public TripsDetailedPage(ScheduledTripsWithUserModel model, bool isCompanion)
        {
            InitializeComponent();
            this.BindingContext = new TripsDetailedPageViewModel(model, isCompanion);
        }
    }
}