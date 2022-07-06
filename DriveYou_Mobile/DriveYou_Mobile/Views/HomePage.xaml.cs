using Android.Widget;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveYou_Mobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void Click(object sendre, EventArgs e)
        {
            Shell.Current.GoToAsync("//AccountPage");
            
        }
    }
}