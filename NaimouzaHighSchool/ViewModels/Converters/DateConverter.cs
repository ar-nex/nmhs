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
            //try
            //{
            //    //System.Windows.MessageBox.Show((string)value);
            //    dt = DateTime.Parse((string)value);
            //}
            //catch (Exception)
            //{
                
                
            //}
            string dt_str = (string)value;
            if (!string.IsNullOrEmpty(dt_str))
            {
                if (dt_str.IndexOf('-') > -1)
                {
                   
                    try
                    {
                        dt = DateTime.ParseExact(dt_str, "dd-MM-yyyy", null);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else if (dt_str.IndexOf('/') > -1)
                {
                    try
                    {
                        dt = DateTime.ParseExact(dt_str, "dd-MM-yyyy", null);
                    }
                    catch (Exception)
                    {


                    }
                }
                else
                {

                    try
                    {
                        dt = DateTime.Parse(dt_str);
                    }
                    catch (Exception)
                    {
                        
                        
                    }
                }
                
            }
            return dt;
        }
    }
}
