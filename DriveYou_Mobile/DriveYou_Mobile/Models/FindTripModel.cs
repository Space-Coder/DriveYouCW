using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace DriveYou_Mobile.Models
{
    public class FindTripModel : BaseViewModel
    {

        [JsonPropertyName("From")]
        private string from;
        public string From
        {
            get { return from; }
            set { from = value;
                OnPropertyChanged("From");
            }
        }

        [JsonPropertyName("To")]
        private string to;
        public string To
        {
            get { return to; }
            set { to = value;
                OnPropertyChanged("To");
            }
        }

        [JsonPropertyName("Date")]
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value;
                OnPropertyChanged("To");
            }
        }




    }
}
