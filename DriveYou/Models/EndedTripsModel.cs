using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DriveYou.Models
{
    public class EndedTripsModel
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int tripID;
        public int TripID
        {
            get { return tripID; }
            set { tripID = value; }
        }


        public int UserID { get; set; }
        public User User { get; set; }

        [DataType(DataType.DateTime)]
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        [DataType(DataType.Text)]
        private string _from;
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        [DataType(DataType.Text)]
        private string _to;
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        [DataType(DataType.MultilineText)]
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private bool isAnimals;
        public bool IsAnimals
        {
            get { return isAnimals; }
            set { isAnimals = value; }
        }

        private bool isSmoking;
        public bool IsSmoking
        {
            get { return isSmoking; }
            set { isSmoking = value; }
        }

        private bool isBagage;
        public bool IsBagage
        {
            get { return isBagage; }
            set { isBagage = value; }
        }

        public List<UserReviewModel> UserReviews { get; set; }

    }
}
