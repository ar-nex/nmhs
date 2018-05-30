using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Promotion : ViewModels.BaseViewModel
    {
        public Promotion()
            : base()
        {

        }

        private string _studentId;
        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        private int _oldStartYear;
        public int OldStartYear
        {
            get { return _oldStartYear; }
            set { _oldStartYear = value; }
        }

        private int _oldEndYear;
        public int OldEndYear
        {
            get { return _oldEndYear; }
            set { _oldEndYear = value; }
        }

        private int _newStartYear;
        public int NewStartYear
        {
            get { return _newStartYear; }
            set { _newStartYear = value; }
        }

        private int _newEndYear;
        public int NewEndYear
        {
            get { return _newEndYear; }
            set { _newEndYear = value; }
        }

        private string _oldStudyClass;
        public string OldStudyClass
        {
            get { return _oldStudyClass; }
            set { _oldStudyClass = value; }
        }

        private string _oldSection;
        public string OldSection
        {
            get { return _oldSection; }
            set { _oldSection = value; }
        }

        private int _oldRoll;
        public int OldRoll
        {
            get { return _oldRoll; }
            set { _oldRoll = value; }
        }

        private string _oldCombined;
        public string OldCombined
        {
            get { return _oldCombined; }
            set { _oldCombined = value; }
        }

        private string _newStudyClass;
        public string NewStudyClass
        {
            get { return _newStudyClass; }
            set { _newStudyClass = value; OnPropertyChanged("NewStudyClass"); }
        }

        private string _newSection;
        public string NewSection
        {
            get { return _newSection; }
            set
            {
                if (value != null)
                {
                    string vl = value.ToUpper();
                    if (vl == "A" || vl == "B" || vl == "C" || vl == "D" || vl == "E")
                    {
                        _newSection = vl;
                    }
                }
                OnPropertyChanged("NewSection");
                EventConnector.OnRollUpdateEvent();
            }
        }

        private int _newRoll;
        public int NewRoll
        {
            get { return _newRoll; }
            set
            {
                _newRoll = value; OnPropertyChanged("NewRoll");
                EventConnector.OnRollUpdateEvent();
            }
        }

        private bool _isAlreadyExist;
        public bool IsAlreadyExist
        {
            get { return _isAlreadyExist; }
            set { _isAlreadyExist = value; }
        }

        /*
         * 0 => No duplicates
         * 1 => Duplicates in the viewmodel
         * 2 => Duplicates in the database
         */
        private int _duplicateCode;
        public int DuplicateCode
        {
            get { return _duplicateCode; }
            set { _duplicateCode = (value == 0 || value == 1 || value == 2) ? value : 0; OnPropertyChanged("DuplicateCode"); }
        }
    }
}
