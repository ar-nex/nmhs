using System;
using System.Windows.Data;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class SearchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((string)value == "name" && (string)parameter == "name")
            {
                return true;
            }
            else if ((string)value == "aadhar" && (string)parameter == "aadhar")
            {
                return true;
            }
            else if ((string)value == "admissionNo" && (string)parameter == "admissionNo")
            {
                return true;
            }
            else if ((string)value == "cls" && (string)parameter == "cls")
            {
                return true;
            }
            else if ((string)value == "clsName" && (string)parameter == "clsName")
            {
                return true;
            }
            else if ((string)value == "madhyamicNo" && (string)parameter == "madhyamicNo")
            {
                return true;
            }
            else if ((string)value == "madhyamicRoll" && (string)parameter == "madhyamicRoll")
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
            if ((bool)value && (string)parameter == "name")
            {
                return "name";
            }
            else if ((bool)value && (string)parameter == "aadhar")
            {
                return "aadhar";
            }
            else if ((bool)value && (string)parameter == "admissionNo")
            {
                return "admissionNo";
            }
            else if ((bool)value && (string)parameter == "cls")
            {
                return "cls";
            }
            else if ((bool)value && (string)parameter == "clsName")
            {
                return "clsName";
            }
            else if ((bool)value && (string)parameter == "madhyamicNo")
            {
                return "madhyamicNo";
            }
            else if ((bool)value && (string)parameter == "madhyamicRoll")
            {
                return "madhyamicRoll";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
