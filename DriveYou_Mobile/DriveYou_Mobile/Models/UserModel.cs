using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace DriveYou_Mobile.Models
{
    public class UserModel : BaseViewModel
    {
        [JsonPropertyName("ID")]
        private int id;
        public int ID
        {
            get { return id; }
            set { 
                id = value;
                OnPropertyChanged("ID");
            }
        }

        [JsonPropertyName("Number")]
        private long _number;
        public long Number
        {
            get { return _number; }
            set { _number = value;
                OnPropertyChanged("Number"); 
            }
        }
        [JsonPropertyName("Password")]
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        [JsonPropertyName("Email")]
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value;
                OnPropertyChanged("Email");
            }
        }

        [JsonPropertyName("Name")]
        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [JsonPropertyName("Surname")]
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { 
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        [JsonPropertyName("Date")]
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [JsonPropertyName("Photo")]
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        [JsonPropertyName("Rating")]
        private double _rating;
        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        [JsonPropertyName("CarMark")]
        private string _carMark;
        public string CarMark
        {
            get { return _carMark; }
            set { _carMark = value; }
        }

        [JsonPropertyName("CarModel")]
        private string _carModel;
        public string CarModel
        {
            get { return _carModel; }
            set { _carModel = value; }
        }

        [JsonPropertyName("CarImage")]
        private string _carImage;
        public string CarImage
        {
            get { return _carImage; }
            set { _carImage = value; }
        }

        [JsonPropertyName("ScheduledTrips")]
        public virtual List<ScheduledTripsModel> ScheduledTrips { get; set; }
        [JsonPropertyName("EndedTrips")]
        public virtual List<EndedTripsModel> EndedTrips { get; set; }
        [JsonPropertyName("UserReviews")]
        public virtual List<UserReviewModel> UserReviews { get; set; }
        [JsonPropertyName("SubscribedOnTrips")]
        public virtual List<SubscribedOnTripsModel> SubscribedOnTrips { get; set; }

    }
}
