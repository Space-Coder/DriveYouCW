using DriveYou_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        public Command GoToLoginCommand { get; }
        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            GoToLoginCommand = new Command(OnToLoginClicked);
            RegisterUser = new RegisterModel();
        }

        private RegisterModel _registerUser;

        public RegisterModel RegisterUser
        {
            get { return _registerUser; }
            set { _registerUser = value; }
        }

        private async void OnToLoginClicked()
        {
            await Shell.Current.GoToAsync("LoginPage");
        }

        private async void OnRegisterClicked()
        {
            string jsonContent =  JsonSerializer.Serialize(RegisterUser, typeof(RegisterModel));
            HttpContent postContent = new StringContent(jsonContent);
            HttpResponseMessage response = await App.client.PostAsync("register", postContent);
            if (response.IsSuccessStatusCode)
            {
                //Return to LoginPage
            }
        }
    }
}
