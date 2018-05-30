using System;

namespace NaimouzaHighSchool.ViewModels.Helpers
{
    public static class DateHelper
    {
        public static int [] FillMonthDates(int year, int month)
        {
            // Initialize the possible dates in a month
            int[] DD28 = new int[28];
            int[] DD29 = new int[29];
            int[] DD30 = new int[30];
            int[] DD31 = new int[31];
            for (int i = 0; i < 28; i++)
            {
                DD28[i] = i + 1;
            }
            for (int i = 0; i < 29; i++)
            {
                DD29[i] = i + 1;
            }
            for (int i = 0; i < 30; i++)
            {
                DD30[i] = i + 1;
            }
            for (int i = 0; i < 31; i++)
            {
                DD31[i] = i + 1;
            }

            // other than feb
            int[] month30 = new int[] { 4, 6, 9, 11 };
            int[] month31 = new int[] { 1, 3, 5, 7, 8, 10, 12};
            int[] dd = new int[] { };

            if (DateTime.IsLeapYear(year))
            {
                if (month == 2)
                {
                    dd = DD29;
                }
                else
                {
                    if (Array.IndexOf(month30, month) != -1)
                    {
                        dd = DD30;
                    }
                    else if (Array.IndexOf(month31, month) != -1)
                    {
                        dd = DD31;
                    }
                    else
                    {
                        dd = new int[] { };
                    }
                }
            }
            else
            {
                if (month == 2)
                {
                    dd = DD28;
                }
                else
                {
                    if (Array.IndexOf(month30, month) != -1)
                    {
                        dd = DD30;
                    }
                    else if (Array.IndexOf(month31, month) != -1)
                    {
                        dd = DD31;
                    }
                    else
                    {
                        dd = new int[] { };
                    }
                }
            }
            return dd;
        }

        public static DateTime GetDate(int[] yyyy, int[] dd, int yyIndex, int mm, int ddIndex)
        {
            DateTime dt = default(DateTime);
            if (yyyy.Length < 1 || dd.Length < 1 || yyIndex == -1 || mm == -1 || ddIndex == -1)
            {
                return dt;
            }
            else
            {
                try
                {
                    dt = new DateTime(yyyy[yyIndex], mm, dd[ddIndex]);
                }
                catch (Exception)
                {

                    throw;
                }
                return dt;
            }
        }
    }
}
