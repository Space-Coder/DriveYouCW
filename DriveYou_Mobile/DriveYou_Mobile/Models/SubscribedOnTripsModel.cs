using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace DriveYou_Mobile.Models
{
    public class SubscribedOnTripsModel : BaseViewModel
    {
        [JsonPropertyName("ID")]
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [JsonPropertyName("UserID")]
        public int UserID { get; set; }
        [JsonPropertyName("ScheduledTripsModelID")]
        public virtual UserModel User { get; set; }
        public virtual int ScheduledTripsModelID { get; set; }
        //[JsonPropertyName("ScheduledTripsWithUserModelID")]
        //public int ScheduledTripsWithUserModelID { get; set; }
        //public virtual ScheduledTripsModel ScheduledTrips { get; set; }

    }
}
