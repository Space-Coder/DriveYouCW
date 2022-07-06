using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DriveYou_Mobile.Models
{
    [JsonNumberHandling(JsonNumberHandling.Strict)]
    public class RegisterModel
    {

        [JsonPropertyName("Number")]
        private long _number;
        public long Number
        {
            get { return _number; }
            set { _number = value; }
        }


        [JsonPropertyName("Password")]
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [JsonPropertyName("Email")]
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [JsonPropertyName("Name")]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [JsonPropertyName("Surname")]
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
    }
}
