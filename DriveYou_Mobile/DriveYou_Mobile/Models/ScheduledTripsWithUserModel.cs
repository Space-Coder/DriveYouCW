using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DriveYou_Mobile.Models
{
    public class ScheduledTripsWithUserModel : BaseViewModel
    {
        [JsonPropertyName("ScheduledTrips")]
        public ScheduledTripsModel ScheduledTrips { get; set; }
        

        [JsonPropertyName("ID")]
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("ID");
            }
        }

        [JsonPropertyName("Number")]
        private long _number;
        public long Number
        {
            get { return _number; }
            set { _number = value; }
        }

        [JsonPropertyName("Name")]
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
            }
        }

        [JsonPropertyName("Date")]
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; 
                OnPropertyChanged("Date");
            }
        }

        [JsonPropertyName("Photo")]
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value;
                OnPropertyChanged("Photo");
            }
        }

        [JsonPropertyName("Rating")]
        private double rating;
        public double Rating
        {
            get { return rating; }
            set { rating = value;
                OnPropertyChanged("Rating");
            }
        }

        [JsonPropertyName("CarMark")]
        private string carMark;
        public string CarMark
        {
            get { return carMark; }
            set { carMark = value;
                OnPropertyChanged("CarMark");
            }
        }

        [JsonPropertyName("CarModel")]
        private string carModel;
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value;
                OnPropertyChanged("CarModel");
            }
        }
        [JsonPropertyName("CarImage")]
        private string carImage;
        public string CarImage
        {
            get { return carImage; }
            set { carImage = value;
                OnPropertyChanged("CarImage");
            }
        }

        public virtual List<SubscribedOnTripsModel> SubscribedOnTrips { get; set; }
    }
}
