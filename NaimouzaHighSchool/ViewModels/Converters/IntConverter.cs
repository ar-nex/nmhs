using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class IntConverter : IValueConverter
    {

        public IntConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Int32)value == 0)
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }



        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace((string)value))
            {
                return 0;
            }
            else
            {
                int t;
                Int32.TryParse((string)value, out t);
                return t;
            }
        }
    }
}
