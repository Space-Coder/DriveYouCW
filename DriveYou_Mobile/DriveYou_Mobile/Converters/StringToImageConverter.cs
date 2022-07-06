using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace DriveYou_Mobile.Converters
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageSource = string.Empty;
            if (value != null)
            {
                byte[] imageBytes = System.Convert.FromBase64String(value.ToString());
                return ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
            imageSource = parameter.ToString() == "account" ? "account.png" : "car.png";
            return ImageSource.FromFile(imageSource);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageSource = string.Empty;
            if (value !=null)
            {
                return System.Convert.ToBase64String((byte[])value);
            }
            imageSource = parameter.ToString() == "account" ? "account.png" : "car.png";
            return ImageSource.FromFile(imageSource); ;
        }
    }
}
