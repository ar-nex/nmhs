using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Subject:BaseModel
    {
        public Subject()
            : base()
        { 
        
        }
        
        public Subject(string id, string nm, string sname, string grp)
        {
            this.ID = id;
            this.SubName = nm;
            this.ShortName = sname;
            this.BelongingGroup = grp;          
        }

        protected string _id;
        protected string _subName;
        protected string _shortName;
        protected string _belongingGroup;

        public string ID
        {
            get { return _id; }
            set { _id = value; this.OnPropertyChanged(String.Empty); }
        }
        public string SubName
        {
            get { return _subName; }
            set { _subName = value; this.OnPropertyChanged(String.Empty); }
        }
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value.ToUpper(); this.OnPropertyChanged(String.Empty); }
        }
        public string BelongingGroup
        {
            get { return _belongingGroup; }
            set { _belongingGroup = value; this.OnPropertyChanged(String.Empty); }
        }
       
    }
}
