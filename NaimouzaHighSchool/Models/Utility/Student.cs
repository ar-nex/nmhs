using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Student
    {
        public Student()
        {

        }
        public Student(string nm)
        {
            this.Name = nm;
        }

        #region fields
        private string _id;
        private string _name;
        private string _fatherName;
        private string _motherName;
        private string _guardianName;
        private string _guardianRelation;
        private string _guardianOccupation;
        private DateTime _dob;
        private string _sex;
        private string _bloodGroup;
        private string _religion;
        private string _socialCategory;
        private string _subCast;
        private bool _isPH;
        private string _phType;
        private bool _isBpl;
        private string _bplNo;
        private string _presentAddress;
        private string _permanentAddress;
        private string _mobile;
        private string _guardianMobile;
        private string _email;
        private string _aadhar;
        private string _guardianAadhar;
        private string _guardianEpic;
        private string _bankAcc;
        private string _bankName;
        private string _bankBranch;
        private string _ifsc;
        private string _micr;

        private string _studyingClass;
        private string _section;
        private int _roll;
        private string _subjectCombId;

        private string _boardRoll;
        private string _boardNo;
        private string _councilRoll;
        private string _councilNo;
        
        private string _admissionNo;
        private DateTime _admDate;
        private string _lastSchool;
        private string _admittedClass;
        private DateTime _dateOfLeaving;
        private string _tc;
        #endregion fields

        #region properties
        public string Id { get { return this._id; } set { this._id = value; } }
        public string Name
        {
            get { return _name; }
            set 
            {
                _name = (string.IsNullOrEmpty(value)) ? value : value.ToUpper();
            }
        }
        public string FatherName
        {
            get { return _fatherName; }
            set { _fatherName = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); }
        }
        public string MotherName
        {
            get { return _motherName; }
            set { _motherName = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); }
        }
        public string GuardianName
        {
            get { return _guardianName; }
            set { _guardianName = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); }
        }
        public string GuardianRelation
        {
            get { return _guardianRelation; }
            set { _guardianRelation = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); }
        }
        public string GuardianOccupation
        {
            get { return _guardianOccupation; }
            set { _guardianOccupation = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); }
        }
        public DateTime Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }
        public string Sex
        {
            get { return _sex; }
            set 
            {
                string sx = value.ToUpper();
                if (sx == "M" || sx == "MALE" || sx == "BOY" || sx == "BOYS" || sx == "B" || sx == "BY")
                {
                    _sex = "M";
                }
                else if (sx == "F" || sx == "FEMALE" || sx == "GIRL" || sx == "GIRLS" || sx == "GRL" || sx == "G")
                {
                    _sex = "F";
                }
                else
                {
                    _sex = string.Empty;
                }
              
            }
        }
        public string BloodGroup
        {
            get { return _bloodGroup; }
            set { _bloodGroup = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); }
        }
        public string Religion
        {
            get { return _religion; }
            set { _religion = (value.ToUpper() == "MUSLIM" || value.ToUpper() == "ISL") ? "ISLAM" : value.ToUpper(); }
        }
        public string SocialCategory
        {
            get { return _socialCategory; }
            set 
            {
                string cat = value.ToUpper();
                if (cat == "GENERAL" || cat == "GEN" || cat == "G")
                {
                    _socialCategory = "GEN";
                }
                else if (cat == "SC" || ((cat.Contains("SCHEDUL")) && (cat.Contains("CAST"))))
                {
                    _socialCategory = "SC";
                }
                else if (cat == "ST" || ((cat.Contains("SCHEDUL")) && (cat.Contains("TRIBE"))))
                {
                    _socialCategory = "ST";
                }
                else if(cat == "OBC_A" || cat=="OBC A" || cat == "OBC-A" || cat == "OBCA")
                {
                    _socialCategory = "OBC-A";
                }
                else if (cat == "OBC_B" || cat == "OBC B" || cat == "OBC-B" || cat == "OBCB")
                {
                    _socialCategory = "OBC-B";
                }
                else if (cat == "OBC")
                {
                    _socialCategory = cat;
                }
                else
                {
                    _socialCategory = "";
                }
            }
        }
        public string SubCast
        {
            get { return _subCast; }
            set { _subCast = value; }
        }
        public bool IsPH
        {
            get { return _isPH; }
            set { _isPH = value; }
        }
        public string PhType
        {
            get { return _phType; }
            set { _phType = value; }
        }
        public bool IsBpl
        { 
            get {return _isBpl;}
            set { _isBpl = value; }
        }
        public string BplNo
        {
            get { return _bplNo; }
            set { _bplNo = value; }
        }
        public string PresentAdrress
        {
            get { return _presentAddress; }
            set { _presentAddress = value; }
        }
        public string PermanentAddress
        {
            get { return _permanentAddress; }
            set { _permanentAddress = value; }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public string GuardianMobile
        {
            get { return _guardianMobile; }
            set { _guardianMobile = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Aadhar
        {
            get { return _aadhar; }
            set { _aadhar = value; }
        }
        public string GuardianAadhar
        {
            get { return _guardianAadhar; }
            set { _guardianAadhar = value; }
        }
        public string GuardianEpic
        {
            get { return _guardianEpic; }
            set { _guardianEpic = value; }
        }
        public string BankAcc
        {
            get { return _bankAcc; }
            set { _bankAcc = value; }
        }
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }
        public string BankBranch
        {
            get { return _bankBranch; }
            set { _bankBranch = value; }
        }
        public string Ifsc
        {
            get { return _ifsc; }
            set { _ifsc = value; }
        }
        public string MICR
        {
            get { return _micr; }
            set { _micr = value; }
        }
        public string StudyingClass
        {
            get { return _studyingClass; }
            set { _studyingClass = value; }
        }
        public string Section
        {
            get { return _section; }
            set { _section = value; }
        }
        public int Roll
        {
            get { return _roll; }
            set { _roll = value; }
        }
        public string SubjectComboId
        {
            get { return _subjectCombId; }
            set { _subjectCombId = value; }
        }
        public string BoardNo
        {
            get { return _boardNo; }
            set { _boardNo = value; }
        }
        public string BoardRoll
        {
            get { return _boardRoll; }
            set { _boardRoll = value; }
        }
        public string CouncilNo
        {
            get { return _councilNo; }
            set { _councilNo = value; }
        }
        public string CouncilRoll
        {
            get { return _councilRoll; }
            set { _councilRoll = value; }
        }
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

        #endregion properties
    }
}
