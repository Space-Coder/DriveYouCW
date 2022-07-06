using DriveYou_Mobile.Models;
using DriveYou_Mobile.Views;
using Lottie.Forms;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;

namespace DriveYou_Mobile.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public Command EditCarInfoCommand { get; }
        public Command LoadUserPhotoCommand { get; }
        public Command RefreshCommand { get; }
        public Command HideBusyIndicator { get; }
        private int userID = -1;
        public AccountViewModel()
        {
            IsOwner = true;
            IsBusyLoading = true;
            LoadUserInfo(-1);
            EditCarInfoCommand = new Command(EditCarInfoCommand_Click);
            LoadUserPhotoCommand = new Command(LoadUserPhotoCommand_Click);
            RefreshCommand = new Command(RefreshCommand_Action);
            HideBusyIndicator = new Command(HideBusyIndicator_Event);
            RepCounter = 20;
        }
        
        public AccountViewModel(bool isOwner, int id = -1)
        {
            LoadUserInfo(id);
            IsBusyLoading = true;
            userID = id;
            IsOwner = isOwner;
            EditCarInfoCommand = new Command(EditCarInfoCommand_Click);
            LoadUserPhotoCommand = new Command(LoadUserPhotoCommand_Click);
            HideBusyIndicator = new Command(HideBusyIndicator_Event);
            RepCounter = 20;
        }

        private bool isBusyLoading;

        public bool IsBusyLoading
        {
            get { return isBusyLoading; }
            set { isBusyLoading = value;
                OnPropertyChanged("IsBusyLoading");
            }
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }


        private string animationUrl;
        public string AnimationUrl
        {
            get { return animationUrl; }
            set
            {
                animationUrl = value;
                if (value == "https://assets7.lottiefiles.com/private_files/lf30_nrnx3s.json")
                {
                    RepCounter = 0;
                }
                OnPropertyChanged("AnimationUrl");
            }
        }

        private string carInfo;

        public string CarInfo
        {
            get { return carInfo; }
            set { carInfo = value;
                OnPropertyChanged("CarInfo");
            }
        }

        private double listHeight;

        public double ListHeight
        {
            get { return listHeight; }
            set { listHeight = value;
                OnPropertyChanged("ListHeight");
            }
        }


        public bool IsOwner { get; set; }

        private UserModel _selectedUser;
        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value;
                if (value != null)
                {
                    AppShell.Current.Navigation.PushAsync(new AccountPage(false, SelectedUser.ID));
                }
                SelectedUser = null;
                OnPropertyChanged("SelectedUser");
            }
        }

        private UserModel _currentUser;
        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                if (CurrentUser.UserReviews != null)
                {
                    ListHeight = 80 * CurrentUser.UserReviews.Count;
                }
                OnPropertyChanged("CurrentUser");
            }
        }


        private async void EditCarInfoCommand_Click()
        {
            await Shell.Current.Navigation.PushModalAsync(new EditCarPage(CurrentUser));
        }

        private void RefreshCommand_Action()
        {
            IsRefreshing = true;
            LoadUserInfo(userID);
            IsRefreshing = false;
        }

        private async void LoadUserPhotoCommand_Click()
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
                        CurrentUser.Photo = Convert.ToBase64String(byteImage);
                    }
                }

            }
            CurrentUser.ScheduledTrips = null;
            CurrentUser.SubscribedOnTrips = null;
            string jsonContent = System.Text.Json.JsonSerializer.Serialize(CurrentUser, typeof(UserModel));
            HttpContent postContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await App.client.PostAsync("user/userphoto/set", postContent);
            if (response.IsSuccessStatusCode)
            {
                await Shell.Current.DisplayAlert("Done", "Completed post metod", "Ok");
            }
        }


        private int repCounter;

        public int RepCounter
        {
            get { return repCounter; }
            set { repCounter = value;
                OnPropertyChanged("RepCounter");
            }
        }

        private void HideBusyIndicator_Event()
        {
            if (AnimationUrl == "https://assets7.lottiefiles.com/private_files/lf30_nrnx3s.json")
            {
                
                IsBusyLoading = false;
            }            
        }

        private async void LoadUserInfo(int id)
        {
            IsBusyLoading = true;
            AnimationUrl = "https://assets2.lottiefiles.com/packages/lf20_tsxbtrcu.json";
            HttpResponseMessage response;
            if (id < 0)
            {
                response =  await App.client.GetAsync("user/my");
            }
            else
            {
                response = await App.client.GetAsync($"user/{id}");
            }
            if (response.IsSuccessStatusCode)
            {
                using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
                {
                    string jsonStr = reader.ReadToEnd();
                    CurrentUser = JsonConvert.DeserializeObject<UserModel>(jsonStr);
                    CarInfo = string.Format("{0}, {1}", CurrentUser.CarMark, CurrentUser.CarModel);
                }
            }
            AnimationUrl = "https://assets7.lottiefiles.com/private_files/lf30_nrnx3s.json";

        }
    }
}
