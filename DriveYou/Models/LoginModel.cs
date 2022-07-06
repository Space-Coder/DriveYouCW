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
    [JsonNumberHandling(JsonNumberHandling.Strict)]
    public class LoginModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [JsonPropertyName("Number")]
        private long _number;
        public long Number
        {
            get { return _number; }
            set { _number = value; }
        }

        [Required]
        [DataType(DataType.Password)]
        [JsonPropertyName("Password")]
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
