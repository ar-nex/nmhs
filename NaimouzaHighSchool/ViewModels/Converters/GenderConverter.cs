using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class GenderConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if ((string)value == "M" && (string)parameter == "M")
            {
                return true;
            }
            else if ((string)value == "F" && (string)parameter == "F")
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
            if ((bool)value && (string)parameter == "M")
            {
                return "M";
            }
            else
            {
                return "F";
            }
        }
    }
}
