using System;
using System.Windows.Data;


namespace NaimouzaHighSchool.ViewModels.Converters
{
    public class Bool1Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //throw new NotImplementedException();
            throw new NotSupportedException();
        }
    }
}
