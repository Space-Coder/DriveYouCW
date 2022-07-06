using DriveYou_Mobile.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using DriveYou_Mobile.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Net;
using Xamarin.Essentials;
using System.Linq;
using Java.Security;

namespace DriveYou_Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command GoToRegisterCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            GoToRegisterCommand = new Command(OnToRegisterClicked);
            LoginUser = new LoginModel();
        }

        private LoginModel _loginUser;
        public LoginModel LoginUser
        {
            get { return _loginUser; }
            set 
            {
                _loginUser = value;
                OnPropertyChanged("LoginUser");
            }
        }

        private async void OnToRegisterClicked()
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }

        private async void OnLoginClicked()
        {
            string jsonContent = JsonSerializer.Serialize(LoginUser, typeof(LoginModel));
            HttpContent postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync("login/signin", postContent);
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync("HomePage", true);
                (AppShell.Current as AppShell).DisableLogin();
            }
        }
    }
}
