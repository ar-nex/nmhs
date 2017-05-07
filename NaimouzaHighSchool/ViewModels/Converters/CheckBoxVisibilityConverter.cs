using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class CheckBoxVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible && (string)parameter == "cls")
            {
                return true;
            }
            else if ((Visibility)value == Visibility.Visible && (string)parameter == "sec")
            {
                return true;
            }
            else if ((Visibility)value == Visibility.Visible && (string)parameter == "roll")
            {
                return true;
            }
            else if ((Visibility)value == Visibility.Visible && (string)parameter == "bNo")
            {
                return true;
            }
            else if ((Visibility)value == Visibility.Visible && (string)parameter == "bRoll")
            {
                return true;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
