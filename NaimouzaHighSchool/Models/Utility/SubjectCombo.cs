using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class SubjectCombo:BaseModel
    {
        public SubjectCombo()
        : base()
        {

        }
        public SubjectCombo(string cd, string bc)
        {
            this.Code = cd;
            this.BelongingClass = bc;
        }
        public SubjectCombo(string i, string cd, string bc)
        {
            this.Id = i;
            this.Code = cd;
            this.BelongingClass = bc;
        }
        private string _id;
        private string _code;
        private string _belongingClass;

        public string Id
        {
            get { return _id; }
            set { _id = value; this.OnPropertyChanged("Id"); }
        }
        public string Code
        {
            get { return _code; }
            set { _code = value; this.OnPropertyChanged("Code"); }
        }
        public string BelongingClass
        {
            get { return _belongingClass; }
            set { _belongingClass = value; this.OnPropertyChanged("BelongingClass"); }
        }
    }


}
