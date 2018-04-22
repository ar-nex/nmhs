using System;
using System.Globalization;
using System.Windows.Data;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class SearchTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "genericSearch" && (string)parameter == "genericSearch")
            {
                return true;
            }
            else if ((string)value == "classSearch" && (string)parameter == "classSearch")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value && (string)parameter == "genericSearch")
            {
                return "genericSearch";
            }
            else if ((bool)value && (string)parameter == "classSearch")
            {
                return "classSearch";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
