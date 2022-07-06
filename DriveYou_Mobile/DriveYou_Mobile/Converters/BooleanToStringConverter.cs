using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DriveYou_Mobile.Converters
{
    public class BooleanToStringConverter : IValueConverter
    {
        private object _value;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty; 
            if ((bool)value == true)
            {
                switch (parameter.ToString())
                {
                    case "animal":
                        {
                            result = "Можно ехать с животными";
                            break;
                        }
                    case "bagage":
                        {
                            result = "Большой: средний или большой чемодан";
                            break;
                        }
                    case "smoking":
                        {
                            result = "Можно курить в машине";
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                switch (parameter.ToString())
                {
                    case "animal":
                        {
                            result = "Без животных";
                            break;
                        }
                    case "bagage":
                        {
                            result = "Маленький: рюкзак или дамская сумка";
                            break;
                        }
                    case "smoking":
                        {
                            result = "Нельзя курить в машине";
                            break;
                        }
                    default:
                        break;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _value;
        }
    }
}
