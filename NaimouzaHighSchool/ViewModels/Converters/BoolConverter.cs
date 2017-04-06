using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value && (string)parameter == "yes")
            {
                return true;
            }
            else if (!(bool)value && (string)parameter == "no")
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
            if ((bool)value && (string)parameter == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
