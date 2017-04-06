using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models;
using System.Text.RegularExpressions;
using System.Windows;
namespace NaimouzaHighSchool.Models.Utility
{
    public class ExcelColumnPosition : BaseModel
    {
        public ExcelColumnPosition(string name)
            : base()
        {
            this.ColName = name;
        }

        public ExcelColumnPosition(string name, string pos)
        {
            this.ColName = name;
            this.ColPosition = pos;
        }
        public string ColName { get; set; }
        private string _colPosition;
        public string ColPosition
        {
            get { return _colPosition; }
            set
            {              
                Regex rgx = new Regex(@"(^[a-zA-Z]{1}$)|(^[aA][a-zA-Z]{1}$)");
                if (rgx.IsMatch(value))
                {
                    _colPosition = value.ToUpper();
                   
                }
                else
                {
                    _colPosition = "";
                }
                this.OnPropertyChanged("ColPosition");               
            }
        }
       
    }
}
