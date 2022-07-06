using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveYou_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
        public AccountPage()
        {
            InitializeComponent();
            
        }
        public AccountPage(bool isOwner, int id = -1)
        {
            InitializeComponent();
            this.BindingContext = new AccountViewModel(isOwner, id);
        }
    }
}