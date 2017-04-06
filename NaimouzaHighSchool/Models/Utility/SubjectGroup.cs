using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace NaimouzaHighSchool.Models.Utility
{
    public class SubjectGroup:BaseModel
    {
        public SubjectGroup()
        :base()
        {
            this.SubsList = new ObservableCollection<Subject>();
        }

        private string _groupTitle;
        private ObservableCollection<Subject> _subsList;

        public string GroupTitle
        {
            get { return _groupTitle; }
            set { _groupTitle = value; this.OnPropertyChanged("GroupTitle"); }
        }
        public ObservableCollection<Subject> SubsList
        {
            get { return _subsList; }
            set { _subsList = value; this.OnPropertyChanged("SubsList"); }
        }
    }
}
