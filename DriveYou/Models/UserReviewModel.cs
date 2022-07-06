using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveYou.Models
{
    public class UserReviewModel
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int EndedTripsID { get; set; }
        //public EndedTripsModel EndedTrips { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        private int _toID;
        public int ToID
        {
            get { return _toID; }
            set { _toID = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }


        private double _assessment;
        public double Assessment
        {
            get { return _assessment; }
            set { _assessment = value; }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

    }
}
