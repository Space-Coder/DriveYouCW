using DriveYou_Mobile.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class EditCarPageViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command OpenImageCommand { get; }
        public EditCarPageViewModel()
        {   
        }
        public EditCarPageViewModel(UserModel model)
        {
            CarInfo = model;
            SaveCommand = new Command(SaveCommand_Click);
            OpenImageCommand = new Command(OpenImageCommand_Click);
        }

        private UserModel carInfo;

        public UserModel CarInfo
        {
            get { return carInfo; }
            set { carInfo = value;
                OnPropertyChanged("CarInfo");
            }
        }

        private async void OpenImageCommand_Click()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Shell.Current.DisplayAlert("Not supported", "Your device does not support this functionality", "Ok");
                return;
            }
            else
            {
                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                var selectedImage = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
                if (selectedImage == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Could not get image, please try again", "Ok");
                    return;
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        selectedImage.GetStream().CopyTo(ms);
                        byte[] byteImage = ms.ToArray();
                        CarInfo.CarImage = Convert.ToBase64String(byteImage);
                    }
                }

            }
        }

        private async void SaveCommand_Click()
        {
            CarInfo.ScheduledTrips = null;
            CarInfo.SubscribedOnTrips = null;
            string jsonContent = JsonSerializer.Serialize(CarInfo, typeof(UserModel));
            HttpContent postContent = new StringContent(jsonContent ,Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync("user/carphoto/set", postContent);
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.Navigation.PopModalAsync();
            }
        }
    }
}
