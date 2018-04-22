using System;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using System.ComponentModel;

namespace NaimouzaHighSchool.ViewModels
{
    public class StudentDataWriteViewModel: BankClassBaseViewModel
    {
        public StudentDataWriteViewModel()
        :base()
        {
            this.StartUpInitialize();
        }

        #region general
        private string _stdName;
        public string StdName
        {
            get { return _stdName; }
            set
            {
                _stdName = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("StdName");
            }
        }

        private int _stdRoll;
        public int StdRoll
        {
            get { return _stdRoll; }
            set { _stdRoll = (value > 0 && value < 1500) ? value : 0; OnPropertyChanged("StdRoll"); }
        }

        private string [] _sex;
        public string [] Sex
        {
            get { return this._sex; }
            set { this._sex = value; this.OnPropertyChanged("Sex"); }
        }

        private int _sexIndex;
        public int SexIndex
        {
            get { return _sexIndex; }
            set { _sexIndex =(value > -1 && value < Sex.Length ) ? value : -1; OnPropertyChanged("SexIndia"); }
        }

        private int[] _yyyy;
        public int[] YYYY
        {
            get { return _yyyy; }
            set { _yyyy = value; OnPropertyChanged("YYYY"); }
        }

        private string[] _mm;
        public string[] MM
        {
            get { return _mm; }
            set { _mm = value; OnPropertyChanged("MM"); }
        }

        private int[] _dd;
        public int[] DD
        {
            get { return _dd; }
            set { _dd = value; OnPropertyChanged("DD"); }
        }

        private int[] _dd28;
        public int[] DD28
        {
            get { return _dd28; }
            set { _dd28 = value; OnPropertyChanged("DD28"); }
        }

        private int[] _dd29;
        public int[] DD29
        {
            get { return _dd29; }
            set { _dd29 = value; OnPropertyChanged("DD29"); }
        }

        private int[] _dd30;
        public int[] DD30
        {
            get { return _dd30; }
            set { _dd30 = value; OnPropertyChanged("DD30"); }
        }

        private int[] _dd31;
        public int[] DD31
        {
            get { return _dd31; }
            set { _dd31 = value; OnPropertyChanged("DD31"); }
        }

        private int _dobYYIndex;
        public int DobYYIndex
        {
            get { return _dobYYIndex; }
            set
            {
                _dobYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DobYYIndex");
                UpdateDaysInMonth();
            }
        }

        private int _dobMMIndex;
        public int DobMMIndex
        {
            get { return _dobMMIndex; }
            set
            {
                _dobMMIndex = (value > -1 && value < MM.Length) ? value : -1;
                OnPropertyChanged("DobMMIndex");
                UpdateDaysInMonth();
            }
        }

        private int _dobDDIndex;
        public int DobDDIndex
        {
            get { return _dobDDIndex; }
            set { _dobDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DobDDIndex"); }
        }

        public string[] StreamList { get; set; }

        private int _streamListIndex;
        public int StreamListIndex
        {
            get { return _streamListIndex; }
            set
            {
                _streamListIndex = (value > -1 && value < StreamList.Length) ? value : -1;
                OnPropertyChanged("StreamListIndex");
                UpdateHsSubs(value);
            }
        }

        private string[] _hsArtsSubs;
        public string[] HsArtsSubs
        {
            get { return _hsArtsSubs; }
            set { _hsArtsSubs = value; OnPropertyChanged("HsArtsSubs"); }
        }

        private string[] _hsSciSubs;
        public string[] HsSciSubs
        {
            get { return _hsSciSubs; }
            set { _hsSciSubs = value; OnPropertyChanged("HsSciSubs"); }
        }

        private string[] _hsActiveSubs;
        public string[] HsActiveSubs
        {
            get { return _hsActiveSubs; }
            set { _hsActiveSubs = value; OnPropertyChanged("HsActiveSubs"); }
        }

        private string[] _hsActiveSubs1;
        public string[] HsActiveSubs1
        {
            get { return _hsActiveSubs1; }
            set { _hsActiveSubs1 = value; OnPropertyChanged("HsActiveSubs1"); }
        }

        private ObservableCollection<string> _hsActiveSubs2;
        public ObservableCollection<string> HsActiveSubs2
        {
            get { return _hsActiveSubs2; }
            set { _hsActiveSubs2 = value; OnPropertyChanged("HsActiveSubs2"); }
        }

        private ObservableCollection<string> _hsActiveSubs3;
        public ObservableCollection<string> HsActiveSubs3
        {
            get { return _hsActiveSubs3; }
            set { _hsActiveSubs3 = value; OnPropertyChanged("HsActiveSubs3"); }
        }

        private ObservableCollection<string> _hsActiveSubs4;
        public ObservableCollection<string> HsActiveSubs4
        {
            get { return _hsActiveSubs4; }
            set { _hsActiveSubs4 = value; OnPropertyChanged("HsActiveSubs4"); }
        }

        private int _hsSub1Index;
        public int HsSub1Index
        {
            get { return _hsSub1Index; }
            set { _hsSub1Index = value; OnPropertyChanged("HsSub1Index"); TrimHsSubs(2); }
        }

        private int _hsSub2Index;
        public int HsSub2Index
        {
            get { return _hsSub2Index; }
            set { _hsSub2Index = value; OnPropertyChanged("HsSub2Index"); TrimHsSubs(3); }
        }

        private int _hsSub3Index;
        public int HsSub3Index
        {
            get { return _hsSub3Index; }
            set { _hsSub3Index = value; OnPropertyChanged("HsSub3Index"); TrimHsSubs(4); }
        }

        private int _hsSub4Index;
        public int HsSub4Index
        {
            get { return _hsSub4Index; }
            set { _hsSub4Index = value; OnPropertyChanged("HsSub4Index"); }
        }

        #endregion

        #region personal

        private string _txbAadhar;
        public string TxbAadhar
        {
            get { return this._txbAadhar; }
            set
            {
                _txbAadhar = value;
                this.OnPropertyChanged("TxbAadhar");
            }
        }

        public string[] ReligionList { get; set; }

        private int _religionIndex;
        public int ReligionIndex
        {
            get { return this._religionIndex; }
            set
            {
                this._religionIndex = value;
                OnPropertyChanged("ReligionIndex");
            }
        }

        public string[] SocialCatList { get; set; }

        private int _socialCatIndex;
        public int SocialCatIndex
        {
            get { return _socialCatIndex; }
            set
            {
                _socialCatIndex = (value > -1 && value < SocialCatList.Length) ? value : -1;
                this.OnPropertyChanged("SocialCatIndex");
            }
        }

        

        public string[] BloodGroups { get; set; }

        private int _bloodGroupIndex;
        public int BloodGroupIndex
        {
            get { return _bloodGroupIndex; }
            set
            {
                this._bloodGroupIndex = (value > -1 && value < BloodGroups.Length) ? value : -1;
                this.OnPropertyChanged("BloodGroupIndex");
            }
        }

        private bool _isbpl;
        public bool Isbpl
        {
            get { return this._isbpl; }
            set 
            { 
                this._isbpl = value;
                if (!value)
                {
                    this.BplNo = string.Empty;
                }
                this.BplReadOnly = !value;
                this.OnPropertyChanged("Isbpl"); 
            }
        }

        private bool _bplReadOnly;
        public bool BplReadOnly
        {
            get { return _bplReadOnly; }
            set { this._bplReadOnly = value; this.OnPropertyChanged("BplReadOnly"); }
        }

        private string _bplNo;
        public string BplNo
        {
            get { return this._bplNo; }
            set { this._bplNo = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("BplNo"); }
        }

        private bool _isPh;
        public bool IsPh
        {
            get { return this._isPh; }
            set
            {
                this._isPh = value;
                if (!value)
                {
                    this.PhDetail = string.Empty;
                }
                this.OnPropertyChanged("IsPh");
                this.ReadOnlyPhTxb = !value;
            }
        }

        private bool _readOnlyPhTxb;
        public bool ReadOnlyPhTxb
        {
            get { return this._readOnlyPhTxb; }
            set { this._readOnlyPhTxb = value; this.OnPropertyChanged("ReadOnlyPhTxb"); }
        }

        private string _phDetail;
        public string PhDetail
        {
            get { return this._phDetail; }
            set { this._phDetail = value; this.OnPropertyChanged("PhDetail"); }
        }


        #endregion

        #region guardian
        private string _txbFatherName;
        public string TxbFatherName
        {
            get { return this._txbFatherName; }
            set
            {
                this._txbFatherName = (value != null) ? value.ToUpper() : value;
                this.OnPropertyChanged(string.Empty);
            }
        }

        private string _txbMotherName;
        public string TxbMotherName
        {
            get { return this._txbMotherName; }
            set { this._txbMotherName = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("TxbMotherName"); }
        }

        private string _guardianName;
        public string GuardianName
        {
            get { return this._guardianName; }
            set { this._guardianName = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("GuardianName"); }
        }

        private bool _isGuardianFather;
        public bool IsGuardianFather
        {
            get { return _isGuardianFather; }
            set
            {
                _isGuardianFather = value;
                OnPropertyChanged("IsGuardianFather");
                if (value)
                {
                    GuardianName = TxbFatherName;
                    RelationWithGuardian = "Father";
                }
                else
                {
                    GuardianName = RelationWithGuardian = string.Empty;
                }
            }
        }

        private string _relationWithGuardian;
        public string RelationWithGuardian
        {
            get { return this._relationWithGuardian; }
            set
            {
                this._relationWithGuardian = (value != null) ? value.ToUpper() : value;
                if (value != null)
                {
                    if (value.ToLower() == "fa")
                    {
                        _relationWithGuardian = "FATHER";
                    }
                    else if (value.ToLower() == "mo")
                    {
                        _relationWithGuardian = "MOTHER";
                    }

                }
                this.OnPropertyChanged("RelationWithGuardian");
            }
        }

        private string _occupation;
        public string Occupation
        {
            get { return this._occupation; }
            set
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                this._occupation = myTI.ToTitleCase(value);
                this.OnPropertyChanged("Occupation");
            }
        }

        private int _annualIncome;
        public int AnnualIncome
        {
            get { return this._annualIncome; }
            set { this._annualIncome = value; this.OnPropertyChanged("AnnualIncome"); }
        }

        private string _guardianAadhar;
        public string GuardianAadhar
        {
            get { return this._guardianAadhar; }
            set { this._guardianAadhar = value; this.OnPropertyChanged("GuardianAadhar"); }
        }

        private string _voterCardNo;
        public string VoterCardNo
        {
            get { return this._voterCardNo; }
            set
            {
                this._voterCardNo = (value != null) ? value.ToUpper() : value;
                this.OnPropertyChanged("VoterCardNo");
            }
        }
        #endregion

        #region contact

        private string _presentAddr1;
        public string PresentAddr1
        {
            get { return this._presentAddr1; }
            set 
            {
                _presentAddr1 = (value != null) ? value.ToUpper() : value;
            }
        }

        private string _presentAddr2;
        public string PresentAddr2
        {
            get { return this._presentAddr2; }
            set 
            {
                _presentAddr2 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PresentAddr2");
            }
        }

        private string _presentPostOffice;
        public string PresentPostOffice
        {
            get { return this._presentPostOffice; }
            set 
            { 
                _presentPostOffice = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PresentPostOffice"); }
        }

        private string _presentPs;
        public string PresentPs
        {
            get { return this._presentPs; }
            set 
            {
                _presentPs = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PresentPs"); 
            }
        }

        private string _presentDist;
        public string PresentDist
        {
            get { return this._presentDist; }
            set 
            { 
                _presentDist = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PresentDist"); 
            }
        }

        private string _presentPin;
        public string PresentPin
        {
            get { return this._presentPin; }
            set 
            { 
                _presentPin = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PresentPin"); 
            }
        }

        private bool _same2Address;
        public bool Same2Address
        {
            get { return this._same2Address; }
            set 
            {
                this._same2Address = value;
                if (value)
                {
                    this.CopyPresetnAddrToPermAddr();
                }
                else
                {
                    PermAddr1 = PermAddr2 = PermPO = PermPs = PermDist = PermPin = string.Empty;
                }
                this.OnPropertyChanged("Same2Address");
            }
        }

        private string _permAddr1;
        public string PermAddr1
        {
            get { return this._permAddr1; }
            set { this._permAddr1 = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("PermAddr1"); }
        }

        private string _permAddr2;
        public string PermAddr2
        {
            get { return this._permAddr2; }
            set { this._permAddr2 = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("PermAddr2"); }
        }

        private string _permPO;
        public string PermPO
        {
            get { return this._permPO; }
            set { this._permPO = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("PermPO"); }
        }

        private string _permPs;
        public string PermPs
        {
            get { return this._permPs; }
            set { this._permPs = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("PermPs"); }
        }

        private string _permDist;
        public string PermDist
        {
            get { return this._permDist; }
            set { this._permDist = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("PermDist"); }
        }

        private string _permPin;
        public string PermPin
        {
            get { return this._permPin; }
            set { this._permPin = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("PermPin"); }
        }

        private string _stdMobile;
        public string StdMobile
        {
            get { return this._stdMobile; }
            set { this._stdMobile = value; this.OnPropertyChanged("StdMobile"); }
        }

        private string _grdMobile;
        public string GrdMobile
        {
            get { return this._grdMobile; }
            set { this._grdMobile = value; this.OnPropertyChanged("GrdMobile"); }
        }

        private string _email;
        public string Email
        {
            get { return this._email; }
            set { this._email = value; this.OnPropertyChanged("Email"); }
        }

        public string[] VillList { get; set; }
        public string[] PostOfficeList { get; set; }
        public string[] PSList { get; set; }
        public string[] DistList { get; set; }
        public string[] PinList { get; set; }
        #endregion

        #region addmission
        private string _admissionNo;
        public string AdmissionNo
        {
            get { return this._admissionNo; }
            set { this._admissionNo = value; this.OnPropertyChanged("AdmissionNo"); }
        }

        public string[] ClassessForAdmission { get; set; }
        private int _indexOfAdmittedClass;
        public int IndexOfAdmittedClass
        {
            get { return this._indexOfAdmittedClass; }
            set 
            {
                this._indexOfAdmittedClass = value;
                this.OnPropertyChanged("IndexOfAdmittedClass");
            }
        }

        private string _lastSchool;
        public string LastSchool
        {
            get { return this._lastSchool; }
            set 
            { 
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                this._lastSchool = myTI.ToTitleCase(value);
                this.OnPropertyChanged("LastSchool"); 
            }
        }

        public string[] LastClasses { get; set; }

        private int _lastClassIndex;
        public int LastClassIndex
        {
            get { return this._lastClassIndex; }
            set 
            { 
                this._lastClassIndex = value; 
                this.OnPropertyChanged("LastClassIndex");
            }
        }

        public int[] YearOfPassingArray { get; set; }

        private int _indexOfLastClassYear;
        public int IndexOfLastClassYear
        {
            get { return this._indexOfLastClassYear; }
            set
            {
                this._indexOfLastClassYear = value;
                this.LastClassYear = (value > -1) ? this.YearOfPassingArray[value] : 0;
                this.OnPropertyChanged("IndexOfLastClassYear");
            }
        }

        private int _lastClassYear;
        public int LastClassYear
        {
            get { return this._lastClassYear; }
            set { this._lastClassYear = value; this.OnPropertyChanged("LastClassYears"); }
        }

        private float _lastPercentage;
        public float LastPercentage
        {
            get { return this._lastPercentage; }
            set { this._lastPercentage = value; this.OnPropertyChanged("LastPercentage"); }
        }

        private string _tc;
        public string Tc
        {
            get { return this._tc; }
            set { this._tc = value; this.OnPropertyChanged("Tc"); }
        }

        private DateTime _dateOfLeaving;
        public DateTime DateOfLeaving
        {
            get { return this._dateOfLeaving; }
            set { this._dateOfLeaving = value; this.OnPropertyChanged("DateOfLeaving"); }
        }
        #endregion

        #region other

        private string _mpRegisNo;
        public string MpRegisNo
        {
            get { return _mpRegisNo; }
            set { _mpRegisNo = value; OnPropertyChanged("MpRegisNo"); }
        }


        private string _boardNo;
        public string BoardNo
        {
            get { return this._boardNo; }
            set { this._boardNo = value.ToUpper(); this.OnPropertyChanged("BoardNo"); }
        }

        private string _boardRoll;
        public string BoardRoll
        {
            get { return this._boardRoll; }
            set { this._boardRoll = value.ToUpper(); this.OnPropertyChanged("BoardRoll"); }
        }

        private string _hsRegisNo;
        public string HsRegisNo
        {
            get { return _hsRegisNo; }
            set { _hsRegisNo = value; OnPropertyChanged("HsRegisNo"); }
        }

        private string _councilNo;
        public string CouncilNo
        {
            get { return this._councilNo; }
            set { this._councilNo = value.ToUpper(); this.OnPropertyChanged("ConuncilNo"); }
        }

        private string _councilRoll;
        public string CouncilRoll
        {
            get { return this._councilRoll; }
            set { this._councilRoll = value; this.OnPropertyChanged("CouncilRoll"); }
        }

        private bool _otherTabEnabled;
        public bool OtherTabEnabled
        {
            get { return _otherTabEnabled; }
            set { _otherTabEnabled = value; OnPropertyChanged("OtherTabEnabled"); }
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; OnPropertyChanged("Msg"); }
        }

        private enum maskedTextType { Aadhaar, Mobile};
        #endregion

        #region visibility
        private System.Windows.Visibility _sub5Visibility;
        public System.Windows.Visibility Sub5Visibility
        {
            get { return _sub5Visibility; }
            //  get { return System.Windows.Visibility.Visible; }
            set { _sub5Visibility = value; OnPropertyChanged("Sub5Visibility"); }
        }

        private System.Windows.Visibility _subHsVisibility;
        public System.Windows.Visibility SubHsVisibility
        {
            get { return _subHsVisibility; }
            set { _subHsVisibility = value; OnPropertyChanged("SubHsVisibility"); }
        }
        #endregion

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
       
        private void StartUpInitialize()
        {
            Sex = new string[] { "Male", "Female" };
            SexIndex = -1;
            this.ClassessForAdmission = new string[] { "V", "VI", "VII", "VIII", "IX", "XI" };
            this.LastClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI" };
            this.ReligionList = new string[] { "ISLAM", "HINDUISM", "OTHER" };
            this.StreamList = new string[] { "ARTS", "SCIENCE" };
            this.SocialCatList = new string[] { "GEN", "SC", "ST", "OBC-A", "OBC-B" };
            this.BloodGroups = new string[] { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };
            this.VillList = new string[] { "BAKHARPUR", "BAMONGRAM", "BROHMOTTOR", "CHAMAGRAM", "CHASPARA", "GOYESHBARI", "HARUGRAM", "JALALPUR", "MOSIMPUR", "NAZIRPUR", "PAHARPUR", "SUJAPUR" };
            this.PostOfficeList = new string[] { "BAKHARPUR", "BAMONGRAM", "CHASPARA", "CHHOTO SUJAPUR", "FATEHKHANI", "GAYESHBARI", "JALALPUR", "MOSIMPUR", "SUJAPUR" };
            this.PSList = new string[] { "KALIACHAK" };
            this.DistList = new string[] { "MALDA" };
            this.PinList = new string[] { "732206" };

            int CurrentYear = DateTime.Today.Year;
            this.YearOfPassingArray = new int[] { CurrentYear, CurrentYear - 1, CurrentYear - 2, CurrentYear - 3, CurrentYear - 4, CurrentYear - 5, CurrentYear - 6, CurrentYear - 7, CurrentYear - 8, CurrentYear - 9 };

            this.BloodGroupIndex = -1;
            this.SocialCatIndex = -1;
            this.IndexOfAdmittedClass = -1;
            this.LastClassIndex = -1;
            this.IndexOfLastClassYear = -1;
            this.ReligionIndex = -1;

            ComboCalendarInitializer();

            Sub5Visibility = SubHsVisibility = System.Windows.Visibility.Collapsed;
            StreamListIndex = -1;

            HsSubsInitializer();

            BplReadOnly = ReadOnlyPhTxb = true;

            this.SaveCommand = new RelayCommand(this.SaveData, this.CanSaveData);
            this.ResetCommand = new RelayCommand(this.ResetData, this.CanResetData);
        }

        private void HsSubsInitializer()
        {
            HsArtsSubs = GlobalVar.HsArtsSubs;
            HsSciSubs = GlobalVar.HsSciSubs;
            HsActiveSubs = new string[] { };
            HsActiveSubs1 = new string[] { };
            HsActiveSubs2 = new ObservableCollection<string>();
            HsActiveSubs3 = new ObservableCollection<string>();
            HsActiveSubs4 = new ObservableCollection<string>();

            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;
        }

        private void ComboCalendarInitializer()
        {
            MM = new string[] { "JAN (01)", "FEB (02)", "MAR (03)", "APR (04)", "MAY (05)", "JUN (06)", "JUL (07)", "AUG (08)", "SEP (09)", "OCT (10)", "NOV (11)", "DEC (12)" };
            DD = new int[] { };
            DD28 = new int[28];
            for (int i = 0; i < 28; i++)
            {
                DD28[i] = i + 1;
            }

            DD29 = new int[29];
            for (int i = 0; i < 29; i++)
            {
                DD29[i] = i + 1;
            }

            DD30 = new int[30];
            for (int i = 0; i < 30; i++)
            {
                DD30[i] = i + 1;
            }

            DD31 = new int[31];
            for (int i = 0; i < 31; i++)
            {
                DD31[i] = i + 1;
            }

            YYYY = new int[20];
            int dobStartYear = DateTime.Today.Year - 5;
            for (int i = 0; i <= 19; i++)
            {
                YYYY[i] = dobStartYear - i;
            }
            DobYYIndex = DobMMIndex = DobDDIndex = -1;
        }

        private void CopyPresetnAddrToPermAddr()
        {
            if (!string.IsNullOrEmpty(this.PresentAddr1))
            {
                this.PermAddr1 = this.PresentAddr1;
            }
             if (!string.IsNullOrEmpty(this.PresentAddr2))
            {
                this.PermAddr2 = this.PresentAddr2;
            }
             if (!string.IsNullOrEmpty(this.PresentPostOffice))
            {
                this.PermPO = this.PresentPostOffice;
            }
             if (!string.IsNullOrEmpty(this.PresentPs))
            {
                this.PermPs = this.PresentPs;
            }
             if (!string.IsNullOrEmpty(this.PresentDist))
            {
                this.PermDist = this.PresentDist;
            }
             if (!string.IsNullOrEmpty(this.PresentPin))
             {
                 this.PermPin = this.PresentPin;
             }
        }

        public void SaveData()
        {
            if (!HasError())
            {
                Student std = buildStudentObject();
                StudentDataWriteDb db = new StudentDataWriteDb();
                bool dataInserted = db.InsertStudentData(std);
                if (dataInserted)
                {
                    Msg = std.Name + " details saved successfully.";
                    ResetData();
                }
                else
                {
                    Msg = "Sorry! failed to save data.";
                }
            }
        }

        public bool CanSaveData()
        {
            return (!string.IsNullOrEmpty(StdName) && SchoolClassIndex > -1 && SchoolClassIndex < SchoolClass.Length);
        }

        public void ResetData()
        {
            StdName = string.Empty;
            SchoolClassIndex = SchoolSectionIndex = -1;
            StdRoll = 0;
            SexIndex = -1;
            DobYYIndex = -1;
            DobMMIndex = -1;
            DobDDIndex = -1;
            StreamListIndex = -1;
            HsSub1Index = -1;
            HsSub2Index = -1;
            HsSub3Index = -1;
            HsSub4Index = -1;

            TxbAadhar = string.Empty;
            ReligionIndex = -1;
            SocialCatIndex = -1;
            BloodGroupIndex = -1;
            IsPh = false;
            Isbpl = false;
            PhDetail = string.Empty;
            BplNo = string.Empty;


            TxbFatherName = string.Empty;
            TxbMotherName = string.Empty;
            GuardianName = string.Empty;
            RelationWithGuardian = string.Empty;
            Occupation = string.Empty;
            GuardianAadhar = string.Empty;
            VoterCardNo = string.Empty;
            IsGuardianFather = false;

            PresentAddr1 = string.Empty;
            PresentAddr2 = string.Empty;
            PresentPostOffice = string.Empty;
            PresentPs = string.Empty;
            PresentDist = string.Empty;
            PresentPin = string.Empty;
            PermAddr1 = PermAddr2 = PermPO = PermPs = PermDist = PermPin = string.Empty;
            StdMobile = GrdMobile = string.Empty;
            Email = string.Empty;

            AccNo = BankName = BranchName = Micr = Ifsc = string.Empty;
            BoardNo = BoardRoll = CouncilNo = CouncilRoll = string.Empty;
            IndexOfAdmittedClass = -1;
            LastSchool = string.Empty;
            Tc = string.Empty;

        }

        public bool CanResetData()
        {
            return true;
        }

        private bool HasError()
        {
            bool rs = false;

            if (string.IsNullOrEmpty(StdName))
            {
                System.Windows.MessageBox.Show("Sorry! Student name can't be blank.");
                rs = true;
                return rs;
            }

            if (SchoolClassIndex <= -1 || SchoolClassIndex > SchoolClass.Length)
            {
                System.Windows.MessageBox.Show("Sorry! Class isn't selected");
                rs = true;
                return rs;
            }

            // aadhaar
            if (!IsMaskedTextNullOrValid(TxbAadhar, maskedTextType.Aadhaar))
            {
                System.Windows.MessageBox.Show("Sorry! Aadhaar has some invalid entries.");
                return true;
            }

            if (!IsMaskedTextNullOrValid(GuardianAadhar, maskedTextType.Aadhaar))
            {
                System.Windows.MessageBox.Show("Sorry! Guardian's Aadhaar has some invalid entries.");
                return true;
            }

            // mobile
            if (!IsMaskedTextNullOrValid(StdMobile, maskedTextType.Mobile))
            {
                System.Windows.MessageBox.Show("Sorry!  Mobile no. has some invalid entries.");
                return true;
            }

            if (!IsMaskedTextNullOrValid(GrdMobile, maskedTextType.Mobile))
            {
                System.Windows.MessageBox.Show("Sorry! Guardian Mobile no. has some invalid entries.");
                return true;
            }
            return rs;
        }

        private Student buildStudentObject()
        {
            Student std = new Student();

            std.Name = StdName.Trim();
            std.StudyingClass = SchoolClass[SchoolClassIndex];
            if (SchoolSectionIndex > -1 && SchoolSectionIndex < SchoolSection.Length)
            {
                std.Section = SchoolSection[SchoolSectionIndex];
            }
            std.Roll = StdRoll;
            if (SexIndex > -1 && SexIndex < Sex.Length)
            {
                std.Sex = Sex[SexIndex];
            }
            if (DobYYIndex != -1 && DobMMIndex != -1 && DobDDIndex != -1)
            {
                try
                {
                    std.Dob = new DateTime(YYYY[DobYYIndex], DobMMIndex+1, DD[DobDDIndex]);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Sorry! You have invalid Date of Birth.: "+ex.Message);
                }
            }
            std.StartSessionYear = StartYear;
            std.EndSessionYear = EndYear;
            if (std.StudyingClass == "V")
            {

            }
            else if (std.StudyingClass == "XI" || std.StudyingClass == "XII")
            {
                if (StreamListIndex != -1)
                {
                    std.Stream = StreamList[StreamListIndex];

                    if (HsSub1Index != -1)
                    {
                        std.HsSub1 = HsActiveSubs1[HsSub1Index];
                    }
                    if (HsSub2Index != -1)
                    {
                        std.HsSub2 = HsActiveSubs2[HsSub2Index];
                    }
                    if (HsSub3Index != -1)
                    {
                        std.HsSub3 = HsActiveSubs3[HsSub3Index];
                    }
                    if (HsSub4Index != -1)
                    {
                        std.HsAdlSub = HsActiveSubs4[HsSub4Index];
                    }
                }
            }

            string pat_aadhaar = @"^\d{4}[-]\d{4}[-]\d{4}$";
            if (!string.IsNullOrEmpty(TxbAadhar) && Regex.IsMatch(TxbAadhar, pat_aadhaar))
            {
                std.Aadhar = TxbAadhar.Replace(@"-", string.Empty);
            }
            if (ReligionIndex > -1 && ReligionIndex < ReligionList.Length)
            {
                std.Religion = ReligionList[ReligionIndex];
            }
            if (SocialCatIndex > -1 && SocialCatIndex < SocialCatList.Length)
            {
                std.SocialCategory = SocialCatList[SocialCatIndex];
            }
            if (BloodGroupIndex > -1 && BloodGroupIndex < BloodGroups.Length)
            {
                std.BloodGroup = BloodGroups[BloodGroupIndex];
            }
            std.IsBpl = Isbpl;
            if (Isbpl)
            {
                std.BplNo = BplNo;
            }
            std.IsPH = IsPh;
            if (IsPh)
            {
                std.PhType = PhDetail;
            }

            std.FatherName = TxbFatherName;
            std.MotherName = TxbMotherName;
            std.GuardianName = GuardianName;
            std.GuardianRelation = RelationWithGuardian;
            std.GuardianOccupation = Occupation;
            if (!string.IsNullOrEmpty(GuardianAadhar) && Regex.IsMatch(GuardianAadhar, pat_aadhaar))
            {
                std.GuardianAadhar = GuardianAadhar.Replace(@"-", string.Empty);
            }
            std.GuardianEpic = VoterCardNo;

            std.PstAddrLane1 = PresentAddr1;
            std.PstAddrLane2 = PresentAddr2;
            std.PstAddrPO = PresentPostOffice;
            std.PstAddrPS = PresentPs;
            std.PstAddrDist = PresentDist;
            std.PstAddrPin = PresentPin;

            std.PmtAddrLane1 = PermAddr1;
            std.PmtAddrLane2 = PermAddr2;
            std.PmtAddrPO = PermPO;
            std.PmtAddrPS = PermPs;
            std.PmtAddrDist = PermDist;
            std.PmtAddrPin = PermPin;
            string pat_mob1 = @"^\d{3}[-]\d{3}[-]\d{4}$";
            if (!string.IsNullOrEmpty(StdMobile) && Regex.IsMatch( StdMobile, pat_mob1))
            {
                std.Mobile = StdMobile.Replace(@"-", string.Empty);
            }
            if (!string.IsNullOrEmpty(GrdMobile) && Regex.IsMatch(GrdMobile, pat_mob1))
            {
                std.GuardianMobile = GrdMobile.Replace(@"-", string.Empty);
            }
            std.Email = Email;

            std.BankAcc = this.AccNo;
            std.BankName = this.BankName;
            std.BankBranch = this.BranchName;
            std.Ifsc = this.Ifsc;
            std.MICR = this.Micr;

            std.LastSchool = this.LastSchool;
            std.TC = this.Tc;
            std.AdmissionNo = this.AdmissionNo;
            if (IndexOfAdmittedClass > -1 && IndexOfAdmittedClass < ClassessForAdmission.Length)
            {
                std.AdmittedClass = ClassessForAdmission[IndexOfAdmittedClass];
            }

            std.RegistrationNoMp = MpRegisNo;
            std.BoardNo = this.BoardNo;
            std.BoardRoll = this.BoardRoll;
            std.RegistrationNoHs = HsRegisNo;
            std.CouncilNo = this.CouncilNo;
            std.CouncilRoll = this.CouncilRoll;

            return std;
        }

        protected override void OnSelectedClassChange()
        {
            if (SchoolClass[SchoolClassIndex] == "V")
            {
                SubHsVisibility = System.Windows.Visibility.Collapsed;
                Sub5Visibility = System.Windows.Visibility.Visible;
                OtherTabEnabled = false;
            }
            else if (SchoolClass[SchoolClassIndex] == "XI" || SchoolClass[SchoolClassIndex] == "XII")
            {
                Sub5Visibility = System.Windows.Visibility.Collapsed;
                SubHsVisibility = System.Windows.Visibility.Visible;
                OtherTabEnabled = true;
            }
            else
            {
                Sub5Visibility = SubHsVisibility = System.Windows.Visibility.Collapsed;
                OtherTabEnabled = false;
            }
        }

        private void UpdateHsSubs(int value)
        {
            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;
            if (value == -1)
            {
              //  Array.Clear(HsActiveSubs, 0, HsActiveSubs.Length);
            }
            else
            {
                if (StreamList[StreamListIndex] == "ARTS")
                {
                    HsActiveSubs = HsArtsSubs;
                }
                else if (StreamList[StreamListIndex] == "SCIENCE")
                {
                    HsActiveSubs = HsSciSubs;
                }
                else
                {
                    Array.Clear(HsActiveSubs, 0, HsActiveSubs.Length);
                }
                HsActiveSubs1 = HsActiveSubs;
            }
        }

        private void TrimHsSubs(int subNo)
        {
            switch(subNo)
            {
                case 2:
                    if (HsActiveSubs2 != null && HsActiveSubs2.Count > 0)
                    {
                        HsActiveSubs2.Clear();
                    }
                    if (HsSub1Index != -1)
                    {
                        string sub1 = HsActiveSubs1[HsSub1Index];
                        if (sub1 == "ARABIC" || sub1 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs1)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs2.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs1)
                            {
                                if (item == sub1)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs2.Add(item);
                                }
                            }
                        }
                    }
                    break;

                case 3:
                    if (HsActiveSubs3 != null && HsActiveSubs3.Count > 0)
                    {
                        HsActiveSubs3.Clear();
                    }
                    if (HsSub2Index != -1)
                    {
                        string sub2 = HsActiveSubs2[HsSub2Index];
                        if (sub2 == "ARABIC" || sub2 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs2)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs3.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs2)
                            {
                                if (item == sub2)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs3.Add(item);
                                }
                            }
                        }
                    }
                    break;

                case 4:
                    if (HsActiveSubs4 != null && HsActiveSubs4.Count > 0)
                    {
                        HsActiveSubs4.Clear();
                    }
                    if (HsSub3Index != -1)
                    {
                        string sub3 = HsActiveSubs3[HsSub3Index];
                        if (sub3 == "ARABIC" || sub3 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs3)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs4.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs3)
                            {
                                if (item == sub3)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs4.Add(item);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void UpdateDaysInMonth()
        {
            if (DobYYIndex == -1 || DobMMIndex == -1)
            {
                DD = new int[] { };
            }
            else
            {
                int selecYear = YYYY[DobYYIndex];
                int selecMonth = DobMMIndex + 1;
                int [] month30 = new int[] { 4, 6, 9, 11};
                int[] month31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
                if (DateTime.IsLeapYear(selecYear))
                {
                    if (selecMonth == 2)
                    {
                        DD = DD29;
                    }
                    else
                    {
                        SetNonFebDays(selecMonth, month30, month31);
                    }
                }
                else
                {
                    if (selecMonth == 2)
                    {
                        DD = DD28;
                    }
                    else
                    {
                        SetNonFebDays(selecMonth, month30, month31);
                    }
                }
            }
        }

        private void SetNonFebDays(int selecMonth, int[] month30, int[] month31)
        {
            if (Array.IndexOf(month30, selecMonth) != -1)
            {
                DD = DD30;
            }
            else if (Array.IndexOf(month31, selecMonth) != -1)
            {
                DD = DD31;
            }
            else
            {
                DD = new int[] { };
            }
        }

        private bool IsMaskedTextNullOrValid(string inpAadhaar, maskedTextType mt)
        {
            // if null return true
            if (string.IsNullOrEmpty(inpAadhaar))
            {
                return true;
            }
            // if white space return true
            else if (string.IsNullOrWhiteSpace(inpAadhaar))
            {
                return true;
            }
            //
            else
            {
                string pat1 = string.Empty;
                string pat2 = string.Empty;

                if (mt == maskedTextType.Aadhaar)
                {
                    pat1 = @"^\d{4}[-]\d{4}[-]\d{4}$";
                    pat2 = @"^[_]{4}[-][_]{4}[-][_]{4}$";
                }
                else if(mt == maskedTextType.Mobile)
                {
                    pat1 = @"^\d{3}[-]\d{3}[-]\d{4}$";
                    pat2 = @"^[_]{3}[-][_]{3}[-][_]{4}$";
                }

                if (Regex.IsMatch(inpAadhaar, pat1) || Regex.IsMatch(inpAadhaar, pat2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
