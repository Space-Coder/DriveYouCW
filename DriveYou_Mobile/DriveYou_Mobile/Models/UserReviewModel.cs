using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveYou_Mobile.Models
{
    public class UserReviewModel : BaseViewModel
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value;
                OnPropertyChanged("ID");
            }
        }
        private int _endedTripsID;
        public int EndedTripsID 
        {
            get { return _endedTripsID; }
            set
            {
                _endedTripsID = value;
                OnPropertyChanged("EndedTrips");
            }
        }
        public EndedTripsModel EndedTrips { get; set; }

        private int _userId;
        public int UserID
        {
            get { return _userId; }
            set { _userId = value;
                OnPropertyChanged("UserID");
            }
        }
        public virtual UserModel User { get; set; }

        private int _toID;
        public int ToID
        {
            get { return _toID; }
            set { _toID = value;
                OnPropertyChanged("ToID");
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value;
                OnPropertyChanged("Date");
            }
        }


        private double _assessment;
        public double Assessment
        {
            get { return _assessment; }
            set { _assessment = value;
                OnPropertyChanged("Assessment");
            }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value;
                OnPropertyChanged("Comment");
            }
        }

    }
}
