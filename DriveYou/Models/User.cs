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
    public class User
    {
        [JsonPropertyName("ID")]
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        [DataType(DataType.PhoneNumber)]
        private long _number;
        public long Number
        {
            get { return _number; }
            set { _number = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        [NotMapped]
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [Required]
        [DataType(DataType.Text)]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataType(DataType.Text)]
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        [Required]
        [DataType(DataType.Date)]
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [DataType(DataType.ImageUrl)]
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private double _rating;
        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        [DataType(DataType.Text)]
        private string _carMark;
        public string CarMark
        {
            get { return _carMark; }
            set { _carMark = value; }
        }

        [DataType(DataType.Text)]
        private string _carModel;
        public string CarModel
        {
            get { return _carModel; }
            set { _carModel = value; }
        }

        [DataType(DataType.ImageUrl)]
        private string _carImage;
        public string CarImage
        {
            get { return _carImage; }
            set { _carImage = value; }
        }
        public virtual List<ScheduledTripsModel> ScheduledTrips { get; set; }
        public virtual List<EndedTripsModel> EndedTrips { get; set; }
        public virtual List<UserReviewModel> UserReviews { get; set; }
        public virtual List<SubscribedOnTripsModel> SubscribedOnTrips { get; set; }
    }
}
