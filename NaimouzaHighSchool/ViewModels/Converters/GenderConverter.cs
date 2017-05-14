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
           
            if (parameter.Equals(value))
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
            if ((bool)value)
            {
                return (string)parameter;
            }
            else
            {
                return Binding.DoNothing;
            }
        }
    }
}
