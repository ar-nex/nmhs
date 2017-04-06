using System;
using System.Windows.Data;

namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class DateConverter : IValueConverter
    {
        public DateConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            return (dt.Year == 1) ? string.Empty : dt.Date.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = DateTime.Parse((string)value);
            }
            catch (Exception)
            {
                
                
            }
            return dt;
        }
    }
}
