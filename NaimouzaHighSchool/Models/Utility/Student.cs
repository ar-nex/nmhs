using System;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Student : BaseModel
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
                _name = (string.IsNullOrEmpty(value)) ? value : value.ToUpper(); this.OnPropertyChanged("Name");
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
                this.OnPropertyChanged("Sex");
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
            set { _studyingClass = value; this.OnPropertyChanged("StudyingClass"); }
        }
        public string Section
        {
            get { return _section; }
            set { _section = value; this.OnPropertyChanged("Section"); }
        }
        public int Roll
        {
            get { return _roll; }
            set { _roll = value; this.OnPropertyChanged("Roll"); }
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

        #region newlyAdded

        private string _stream;
        public string Stream
        {
            get => _stream;
            set => _stream = value;
        }

        private string _hsSub1;
        public string HsSub1
        {
            get => _hsSub1;
            set => _hsSub1 = value;
        }

        private string _hsSub2;
        public string HsSub2
        {
            get => _hsSub2;
            set => _hsSub2 = value;
        }

        private string _hsSub3;
        public string HsSub3
        {
            get => _hsSub3;
            set => _hsSub3 = value;
        }

        private string _hsAdlSub;
        public string HsAdlSub
        {
            get => _hsAdlSub;
            set => _hsAdlSub = value;
        }

        private string _thirdLang;
        public string ThirdLang
        {
            get => _thirdLang;
            set => _thirdLang = value;
        }

        private string _registrationNoMp;
        public string RegistrationNoMp
        {
            get => _registrationNoMp;
            set
            {
                _registrationNoMp = value;
                OnPropertyChanged("RegistrationNoMp");
            }
        }

        private string _registrationNoHs;
        public string RegistrationNoHs
        {
            get => _registrationNoHs;
            set
            {
                _registrationNoHs = value;
                OnPropertyChanged("RegistrationNoHs");
            }
        }

        #region address
        private string _pstAddrLane1;
        public string PstAddrLane1
        {
            get { return _pstAddrLane1; }
            set
            {
                _pstAddrLane1 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PstAddrLane1");
            }
        }

        private string _pstAddrLane2;
        public string PstAddrLane2
        {
            get => _pstAddrLane2;
            set
            {
                _pstAddrLane2 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PstAddrLane2");
            }
        }
        private string _pstAddrPO;
        public string PstAddrPO
        {
            get { return _pstAddrPO; }
            set
            {
                _pstAddrPO = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PstAddrPO");
            }
        }

        private string _pstAddrPS;
        public string PstAddrPS
        {
            get { return _pstAddrPS; }
            set
            {
                _pstAddrPS = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PstAddrPS");
            }
        }

        private string _pstAddrDist;
        public string PstAddrDist
        {
            get { return _pstAddrDist; }
            set
            {
                _pstAddrDist = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PstAddrDist");
            }
        }

        private string _pstAddrPin;
        public string PstAddrPin
        {
            get { return _pstAddrPin; }
            set
            {
                _pstAddrPin = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PstAddrPin");
            }
        }

        private string _pmtAddrLane1;
        public string PmtAddrLane1
        {
            get { return _pmtAddrLane1; }
            set
            {
                _pmtAddrLane1 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PmtAddrLane1");
            }
        }

        private string _pmtAddrLane2;
        public string PmtAddrLane2
        {
            get => _pmtAddrLane2;
            set
            {
                _pmtAddrLane2 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PmtAddrLane2");
            }
        }
        private string _pmtAddrPO;
        public string PmtAddrPO
        {
            get { return _pmtAddrPO; }
            set
            {
                _pmtAddrPO = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PmtAddrPO");
            }
        }

        private string _pmtAddrPS;
        public string PmtAddrPS
        {
            get { return _pmtAddrPS; }
            set
            {
                _pmtAddrPS = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PmtAddrPS");
            }
        }

        private string _pmtAddrDist;
        public string PmtAddrDist
        {
            get { return _pmtAddrDist; }
            set
            {
                _pmtAddrDist = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PmtAddrDist");
            }
        }

        private string _pmtAddrPin;
        public string PmtAddrPin
        {
            get { return _pmtAddrPin; }
            set
            {
                _pmtAddrPin = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PmtAddrPin");
            }
        }

        private int _startSessionYear;
        public int StartSessionYear
        {
            get { return _startSessionYear; }
            set { _startSessionYear = value; OnPropertyChanged("StartSessionYear"); }
        }

        private int _endSessionYear;
        public int EndSessionYear
        {
            get { return _endSessionYear; }
            set { _endSessionYear = value; OnPropertyChanged("EndSessionYear"); }
        }


        #endregion

        #endregion
    }
}
