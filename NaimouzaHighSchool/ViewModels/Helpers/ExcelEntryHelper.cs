using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.ViewModels;
using NaimouzaHighSchool.Models.Utility;
namespace NaimouzaHighSchool.ViewModels.Helpers
{
    public class ExcelEntryHelper
    {
        public ExcelEntryHelper()
        {

        }

        public bool isExcelColPositionUnique(List<ExcelColumnPosition> listOfExCol)
        {
            bool unique = false;
            int j = 0;
            int length = listOfExCol.Count;
            foreach (ExcelColumnPosition item in listOfExCol)
            {
                string pos = item.ColPosition;
                for (int i = ++j; i < length; i++)
                {
                    if (!String.IsNullOrWhiteSpace(pos))
                    {
                         if (listOfExCol[i].ColPosition == pos)
                         {
                            unique = false;
                            return unique;
                         }
                         else
                         {
                            unique = true;
                         }
                    }
                }

            }
            return unique;
        
        }
    }
}
