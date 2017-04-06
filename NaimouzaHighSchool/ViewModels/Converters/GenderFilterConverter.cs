using System;
using System.Windows.Data;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class GenderFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((string)value == "none" && (string)parameter == "none")
            {
                return true;
            }
            else if ((string)value == "male" && (string)parameter == "male")
            {
                return true;
            }
            else if ((string)value == "female" && (string)parameter == "female")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value && (string)parameter == "none")
            {
                return "none";
            }
            else if ((bool)value && (string)parameter == "male")
            {
                return "male";
            }
            else if ((bool)value && (string)parameter == "female")
            {
                return "female";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
