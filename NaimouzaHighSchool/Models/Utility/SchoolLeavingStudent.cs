using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    class SchoolLeavingStudent : Student
    {
        public SchoolLeavingStudent()
        : base()
        {

        }

        #region property
        private int _marksObtained;
        public int MarksObtained
        {
            get { return this._marksObtained; }
            set { this._marksObtained = value; this.OnPropertyChanged("MarksObtained"); }
        }

        private int _passingYear;
        public int PassingYear
        {
            get { return this._passingYear; }
            set { this._passingYear = value; this.OnPropertyChanged("PassingYear"); }
        }

        private string _grade;
        public string Grade
        {
            get { return this._grade; }
            set { this._grade = value; this.OnPropertyChanged("Grade"); }
        }

        private string _candidateCategory;
        public string CandidateCategory
        {
            get { return this._candidateCategory; }
            set { this._candidateCategory = value; this.OnPropertyChanged("CandidateCategory"); }
        }
        #endregion
    }
}
