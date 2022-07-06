using DriveYou_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DriveYou_Mobile.Models
{
    public class LoginModel : BaseViewModel
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
    }
}
