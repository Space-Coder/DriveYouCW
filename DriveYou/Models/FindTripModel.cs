using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace DriveYou.Models
{
    [JsonNumberHandling(JsonNumberHandling.Strict)]
    public class FindTripModel
    {

        [JsonPropertyName("From")]
        private string from;
        public string From
        {
            get { return from; }
            set { from = value; }
        }

        [JsonPropertyName("To")]
        private string to;
        public string To
        {
            get { return to; }
            set { to = value; }
        }

        [JsonPropertyName("Date")]
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }




    }
}
