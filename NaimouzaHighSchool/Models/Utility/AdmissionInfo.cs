using System;

namespace NaimouzaHighSchool.Models.Utility
{
    public class AdmissionInfo
    {
        public AdmissionInfo()
        {

        }

        #region field
        private string _admissionNo;
        private DateTime _admDate;
        private string _lastSchool;
        private string _admittedClass;
        private DateTime _dateOfLeaving;
        private string _tc;
        #endregion

        #region property
        public string AdmissionNo
        {
            get { return _admissionNo; }
            set { _admissionNo = value; }
        }
        public DateTime AdmDate
        {
            get { return _admDate; }
            set { _admDate = value; }
        }
        public string LastSchool
        {
            get { return _lastSchool; }
            set { _lastSchool = value; }
        }
        public string AdmittedClass
        {
            get { return _admittedClass; }
            set { _admittedClass = value; }
        }
        public DateTime DateOfLeaving
        {
            get { return _dateOfLeaving; }
            set { _dateOfLeaving = value; }
        }
        public string TC
        {
            get { return _tc; }
            set { _tc = value; }
        }
        #endregion
    }
}
