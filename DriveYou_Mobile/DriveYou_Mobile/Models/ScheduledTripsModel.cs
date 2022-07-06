﻿using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveYou_Mobile.Models
{
    public class ScheduledTripsModel : BaseViewModel
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { 
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        private int _userID;
        public int UserID
        {
            get { return _userID; }
            set { _userID = value;
                OnPropertyChanged("UserID");
            }
        }
        public UserModel User { get; set; }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { 
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        private string _from;
        public string From
        {
            get { return _from; }
            set { _from = value;
                OnPropertyChanged("From");
            }
        }

        private string _to;
        public string To
        {
            get { return _to; }
            set { _to = value;
                OnPropertyChanged("To");
            }
        }

        private int seats;
        public int Seats
        {
            get { return seats; }
            set { seats = value;
                OnPropertyChanged("Seats");
            }
        }

        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set { _cost = value;
                OnPropertyChanged("Cost");
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

        private bool isAnimals;
        public bool IsAnimals
        {
            get { return isAnimals; }
            set { isAnimals = value;
                OnPropertyChanged("IsAnimals");
            }
        }

        private bool isSmoking;
        public bool IsSmoking
        {
            get { return isSmoking; }
            set { isSmoking = value;
                OnPropertyChanged("IsSmoking");
            }
        }

        private bool isBagage;
        public bool IsBagage
        {
            get { return isBagage; }
            set { isBagage = value;
                OnPropertyChanged("IsBagage");
            }
        }

        public virtual List<SubscribedOnTripsModel> SubscribedOnTrips { get; set; }
    }
}
