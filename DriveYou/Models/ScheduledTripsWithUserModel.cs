using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DriveYou.Models
{
    public class ScheduledTripsWithUserModel
    {
        [JsonPropertyName("ScheduledTrips")]
        public ScheduledTripsModel ScheduledTrips { get; set; }

        [JsonPropertyName("ID")]
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
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
            set { name = value; }
        }

        [JsonPropertyName("Date")]
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [JsonPropertyName("Photo")]
        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        [JsonPropertyName("Rating")]
        private double rating;
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        [JsonPropertyName("CarMark")]
        private string carMark;
        public string CarMark
        {
            get { return carMark; }
            set { carMark = value; }
        }

        [JsonPropertyName("CarModel")]
        private string carModel;
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }

        [JsonPropertyName("CarImage")]
        private string carImage;
        public string CarImage
        {
            get { return carImage; }
            set { carImage = value; }
        }

        public virtual List<SubscribedOnTripsModel> SubscribedOnTrips { get; set; }

    }
}
