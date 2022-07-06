using Android.App;
using DriveYou_Mobile.ViewModels;
using DriveYou_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriveYou_Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Sharpnado.MaterialFrame.Initializer.Initialize(loggerEnable: false, true);
            LoginStatusCheck();
            //Login & Register Case
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            //Add Trip Case
            Routing.RegisterRoute(nameof(AddTripPage), typeof(AddTripPage));
            //Find, Explore and Subscribe Trips Case
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(HomeTrips), typeof(HomeTrips));
            Routing.RegisterRoute(nameof(TripsDetailedPage), typeof(TripsDetailedPage));
            //My trips case
            Routing.RegisterRoute(nameof(MyTripsPage), typeof(MyTripsPage));
            //Account case
            Routing.RegisterRoute(nameof(AccountPage), typeof(AccountPage));
            Routing.RegisterRoute(nameof(EditCarPage), typeof(EditCarPage));
           
        }

        public void DisableLogin()
        {
            this.CurrentItem.CurrentItem = ShellHomePage;
            ShellLoginPage.IsEnabled = false;
            ShellLoginPage.IsVisible = false;
        }
        private async void LoginStatusCheck()
        {
           /* HttpResponseMessage response = await App.client.GetAsync("user");
            if (SecureStorage.GetAsync("auth_cookie").Result != null)
            {
                var cookie = SecureStorage.GetAsync("auth_cookie").Result;
                App.client.DefaultRequestHeaders.Add("Cookie", cookie.ToString());
            }
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync("HomePage");
                ShellLoginPage.IsEnabled = false;
                ShellLoginPage.IsVisible = false;
            }
            else
            {
                ShellLoginPage.IsEnabled = true;
                ShellLoginPage.IsVisible = true;
            }*/
        }

        private async void OnAccountItemClick(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AccountPage");   
        }
    }
}
