using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using System.ComponentModel;

namespace NaimouzaHighSchool.ViewModels
{
    public class StudentDataWriteViewModel: BaseViewModel
    {
        public StudentDataWriteViewModel()
        :base()
        {
            this.StartUpInitialize();
            this.StdModel = new StudentDataWriteModel();
            
        }


        #region new
        #region basic
        private string _txbFirstName;

        public string TxbFirstName
        {
            get { return this._txbFirstName; }
            set { this._txbFirstName = value.ToUpper(); this.OnPropertyChanged("TxbFristname"); }
        }

        private string _txbMidName;

        public string TxbMidName
        {
            get { return this._txbMidName; }
            set { this._txbMidName = value.ToUpper(); this.OnPropertyChanged("TxbMidName"); }
        }

        private string _txbLastName;

        public string TxbLastName
        {
            get { return this._txbLastName; }
            set { this._txbLastName = value.ToUpper(); this.OnPropertyChanged("TxbLastName"); }
        }


        private int _classSelectedIndex;
        /// <summary>
        /// Contain the seleted index of class used to Update the selected class of student here.
        /// </summary>
        public int ClassSelectedIndex
        {
            get { return _classSelectedIndex; }
            set
            {
                _classSelectedIndex = value;
                this.SelectedClass = (value > -1) ? this.SchoolClass[value] : string.Empty;
                /*
                if (value > -1)
                {
                    this.UpdateComboList();
                }
                this.OnPropertyChanged("ClassSelectedIndex");

                 */ 
             }
        }
        
        
        private string _selectedClass;

        public string SelectedClass
        {
            get { return this._selectedClass; }
            set { this._selectedClass = value; this.OnPropertyChanged("SelectedClass"); }
        }

        private int _sectionSelectedIndex;
        /// <summary>
        /// Contain the seleted index of section used to Update the selected section of student here.
        /// </summary>
        public int SectionSelectedIndex
        {
            get { return _sectionSelectedIndex; }
            set
            {
                _sectionSelectedIndex = value;
                this.SelectedSection = (value > -1) ? this.SchoolSection[value] : string.Empty;
                this.OnPropertyChanged("SectionSeletedIndex");
            }
        }

        private string _selectedSection;

        public string SelectedSection
        {
            get { return this._selectedSection; }
            set { this._selectedSection = value; this.OnPropertyChanged("SelectedSection"); }
        }

        private int _roll;
        public int Roll
        {
            get { return _roll; }
            set { _roll = value; this.OnPropertyChanged("Roll"); }
        }

        private int _comboIndex;
        /// <summary>
        /// Combo code (name) index
        /// </summary>
        public int ComboIndex
        {
            get { return _comboIndex; }
            set
            {
                _comboIndex = value;
                /*
                if (value > -1)
                {
                    this.SetComboCode();
                }
                else
                {
                    this.SbComboCode = string.Empty;
                }
                */
                this.OnPropertyChanged("ComboIndex");
            }
        }
        
        private string _sbComboCode;
        public string SbComboCode
        {
            get { return _sbComboCode; }
            set 
            { 
                _sbComboCode = value;
                this.OnPropertyChanged("SbComboCode"); 
            }
        }

        private string _sex;

        public string Sex
        {
            get { return this._sex; }
            set { this._sex = value; this.OnPropertyChanged("Sex"); }
        }

        private DateTime _dob;
        public DateTime Dob
        {
            get { return this._dob; }
            set { this._dob = value; this.OnPropertyChanged("Dob"); }
        }

        private string _txbAadhar;
        public string TxbAadhar
        {
            get { return this._txbAadhar; }
            set { this._txbAadhar = value; this.OnPropertyChanged("TxbAadhar"); }
        }


        private int _socialCatIndex;
        /// <summary>
        /// Social category Index
        /// </summary>
        public int SocialCatIndex
        {
            get { return _socialCatIndex; }
            set
            {
                _socialCatIndex = value;
                this.SocialCat = (value > -1) ? this.SocialCatList[value] : string.Empty;
                this.OnPropertyChanged("SocialCatIndex");
            }
        }

        private string _socialCat;

        public string SocialCat
        {
            get { return this._socialCat; }
            set { this._socialCat = value; this.OnPropertyChanged("SocialCat"); }
        }

        private string _socialSubCat;

        public string SocialSubCat
        {
            get { return this._socialSubCat; }
            set { this._socialSubCat = value; this.OnPropertyChanged("SocialSubCat"); }
        }

        private int _bloodGroupIndex;
        /// <summary>
        /// Blood grp index
        /// </summary>
        public int BloodGroupIndex
        {
            get { return _bloodGroupIndex; }

            set
            {
                this._bloodGroupIndex = value;
                this.BloodGroup = (value > -1) ? this.BloodGroups[value] : string.Empty;
                this.OnPropertyChanged("BloodGroupIndex");
            }
        }

        private string _bloodGroup;

        public string BloodGroup
        {
            get { return this._bloodGroup; }
            set { this._bloodGroup = value; this.OnPropertyChanged("BloodGroup"); }
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
                this.EnableBplTxb = value;
                this.OnPropertyChanged("Isbpl"); 
            }
        }

        private bool _enableBplTxb;

        public bool EnableBplTxb
        {
            get { return _enableBplTxb; }
            set { this._enableBplTxb = value; this.OnPropertyChanged("EnableBplTxb"); }
        }

        private string _bplNo;

        public string BplNo
        {
            get { return this._bplNo; }
            set { this._bplNo = value; this.OnPropertyChanged("BplNo"); }
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
                this.EnablePhTxb = value;
                this.OnPropertyChanged("IsPh");
            }
        }

        private bool _enablePhTxb;

        public bool EnablePhTxb
        {
            get { return this._enablePhTxb; }
            set { this._enablePhTxb = value; this.OnPropertyChanged("EnablePhTxb"); }
        }

        private string _phDetail;

        public string PhDetail
        {
            get { return this._phDetail; }
            set { this._phDetail = value; this.OnPropertyChanged("PhDetail"); }
        }

        public string[] ReligionList { get; set; }
        private string _religion;
        public string Religion
        {
            get { return this._religion; }
            set { this._religion = value; this.OnPropertyChanged("Religion"); }
        }

        private int _religionIndex;
        public int ReligionIndex
        {
            get { return this._religionIndex; }
            set
            {
                this._religionIndex = value;
                if (value > -1)
                {
                    this.Religion = this.ReligionList[value];
                }
                else
                {
                    this.Religion = string.Empty;
                }
            }
        }
        #endregion

        #region contact
        private string _txbFatherName;

        public string TxbFatherName
        {
            get { return this._txbFatherName; }
            set 
            { 
                this._txbFatherName = value.ToUpper();
                if (this.IsSameGuardian)
                {
                    this.GuardianName = this._txbFatherName;
                }
                this.OnPropertyChanged(string.Empty);
            }
        }

        private string _txbMotherName;

        public string TxbMotherName
        {
            get { return this._txbMotherName; }
            set { this._txbMotherName = value.ToUpper(); this.OnPropertyChanged("TxbMotherName"); }
        }

        private bool _isSameGuardian;

        public bool IsSameGuardian
        {
            get { return this._isSameGuardian; }
            set 
            { 
                this._isSameGuardian = value;
                if (value && !string.IsNullOrEmpty(this.TxbFatherName))
                {
                    this.GuardianName = this.TxbFatherName;
                }
                if (value)
                {
                    this.RelationWithGuardian = "FATHER";
                }
                this.OnPropertyChanged("IsSameGuardian"); 
            }
        }

        private string _guardianName;

        public string GuardianName
        {
            get { return this._guardianName; }
            set { this._guardianName = value.ToUpper(); this.OnPropertyChanged("GuardianName"); }
        }

        private string _relationWithGuardian;

        public string RelationWithGuardian
        {
            get { return this._relationWithGuardian; }
            set { this._relationWithGuardian = value.ToUpper(); this.OnPropertyChanged("RelationWithGuardian"); }
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

        private string _voterCardNo;

        public string VoterCardNo
        {
            get { return this._voterCardNo; }
            set { this._voterCardNo = value; this.OnPropertyChanged("VoterCardNo"); }
        }

        private string _guardianAadhar;

        public string GuardianAadhar
        {
            get { return this._guardianAadhar; }
            set { this._guardianAadhar = value; this.OnPropertyChanged("GuardianAadhar"); }
        }

        private string _presentAddr1;
        public string PresentAddr1
        {
            get { return this._presentAddr1; }
            set 
            { 
                this._presentAddr1 = value.ToUpper();
                if (this.Same2Address)
                {
                    this.PermAddr1 = value.ToUpper();
                }
                this.OnPropertyChanged("PresentAddr1"); 
            
            }
        }

        private string _presentAddr2;
        public string PresentAddr2
        {
            get { return this._presentAddr2; }
            set 
            { 
                this._presentAddr2 = value.ToUpper();
                if (this.Same2Address)
                {
                    this.PermAddr2 = value.ToUpper();
                }
                this.OnPropertyChanged("PresentAddr2"); 
            
            }
        }

        private string _presentPostOffice;

        public string PresentPostOffice
        {
            get { return this._presentPostOffice; }
            set 
            { 
                this._presentPostOffice = value.ToUpper();
                if (Same2Address)
                {
                    this.PermPO = value.ToUpper();
                }
                this.OnPropertyChanged("PresentPostOffice"); }
        }

        private string _presentPs;

        public string PresentPs
        {
            get { return this._presentPs; }
            set 
            { 
                this._presentPs = value.ToUpper();
                if (Same2Address)
                {
                    this.PermPs = value.ToUpper();
                }
                this.OnPropertyChanged("PresentPs"); 
            }
        }

        private string _presentDist;

        public string PresentDist
        {
            get { return this._presentDist; }
            set 
            { 
                this._presentDist = value.ToUpper();
                if (Same2Address)
                {
                    this.PermDist = value.ToUpper();
                }
                this.OnPropertyChanged("PresentDist"); 
            }
        }

        private string _presentPin;

        public string PresentPin
        {
            get { return this._presentPin; }
            set 
            { 
                this._presentPin = value;
                if (Same2Address)
                {
                    this.PermPin = value.ToUpper();
                }
                this.OnPropertyChanged("PresentPin"); 
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
                this.OnPropertyChanged("Same2Address");
            }
        }

        private string _permAddr1;

        public string PermAddr1
        {
            get { return this._permAddr1; }
            set { this._permAddr1 = value.ToUpper(); this.OnPropertyChanged("PermAddr1"); }
        }

        private string _permAddr2;

        public string PermAddr2
        {
            get { return this._permAddr2; }
            set { this._permAddr2 = value.ToUpper(); this.OnPropertyChanged("PermAddr2"); }
        }
        private string _permPO;

        public string PermPO
        {
            get { return this._permPO; }
            set { this._permPO = value.ToUpper(); this.OnPropertyChanged("PermPO"); }
        }
        private string _permPs;

        public string PermPs
        {
            get { return this._permPs; }
            set { this._permPs = value.ToUpper(); this.OnPropertyChanged("PermPs"); }
        }
        private string _permDist;

        public string PermDist
        {
            get { return this._permDist; }
            set { this._permDist = value.ToUpper(); this.OnPropertyChanged("PermDist"); }
        }
        private string _permPin;
        public string PermPin
        {
            get { return this._permPin; }
            set { this._permPin = value.ToUpper(); this.OnPropertyChanged("PermPin"); }
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

        private DateTime _admissionDate;

        public DateTime AdmissionDate
        {
            get { return this._admissionDate; }
            set { this._admissionDate = value; this.OnPropertyChanged("AdmissionDate"); }
        }

        public string[] ClassessForAdmission { get; set; }

        private int _indexOfAdmittedClass;

        public int IndexOfAdmittedClass
        {
            get { return this._indexOfAdmittedClass; }
            set 
            {
                this._indexOfAdmittedClass = value;
                this.AdmittedClass = (value > -1) ? this.ClassessForAdmission[value] : string.Empty;
                this.OnPropertyChanged("IndexOfAdmittedClass");
            }
        }

        private string _admittedClass;

        public string AdmittedClass
        {
            get { return this._admittedClass; }
            set { this._admittedClass = value; this.OnPropertyChanged("AdmittedClass"); }
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
                this.LastClass = (value > -1) ? this.LastClasses[value] : string.Empty;
                this.OnPropertyChanged("LastClassIndex");
            }
        }

        private string _lastClass;

        public string LastClass
        {
            get { return this._lastClass; }
            set { this._lastClass = value; this.OnPropertyChanged("LastClass"); }
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

        #region bank
       

        private ObservableCollection<string> _banks;
        public ObservableCollection<string> Banks
        {
            get { return this._banks; }
            set { this._banks = value; this.OnPropertyChanged("Banks"); }
        }

        private string _bankName;
        public string BankName
        {
            get { return this._bankName; }
            set { this._bankName = value.ToUpper(); this.OnPropertyChanged("BankName"); }
        }



        private ObservableCollection<string> _branchs;
        public ObservableCollection<string> Branchs
        {
            get { return this._branchs; }
            set { this._branchs = value; this.OnPropertyChanged("Branchs"); }
        }

        private string _branchName;
        public string BranchName
        {
            get { return this._branchName; }
            set { this._branchName = value.ToUpper(); this.OnPropertyChanged("BranchName"); }
        }

        private string _accNo;
        public string AccNo
        {
            get { return this._accNo; }
            set { this._accNo = value; this.OnPropertyChanged("AccNo"); }
        }

        private ObservableCollection<string> _ifcrList;
        public ObservableCollection<string> IfcrList
        {
            get { return this._ifcrList; }
            set { this._ifcrList = value; this.OnPropertyChanged("IfcrList"); }
        }

        private string _ifcr;
        public string Ifcr
        {
            get { return this._ifcr; }
            set { this._ifcr = value.ToUpper(); this.OnPropertyChanged("Ifcr"); }
        }

        private string _micr;
        public string Micr
        {
            get { return this._micr; }
            set { this._micr = value; this.OnPropertyChanged("Micr"); }
        }

        private ObservableCollection<string> _micrList;
        public ObservableCollection<string> MICRList
        {
            get { return this._micrList; }
            set { this._micrList = value; this.OnPropertyChanged("MICRList"); }
        }
        #endregion

        #region other
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
        #endregion
        #endregion

        #region fields
        private StudentDataWriteModel _StdModel;
        private bool _enableStrem;
        private string _stdClass;


        private ObservableCollection<string> _filteredComboCode;
        /// <summary>
        /// Contains the Combo code according to the selection of class.
        /// </summary>
        public ObservableCollection<string> FilteredComboCode
        {
            get { return _filteredComboCode; }
            set { _filteredComboCode = value; this.OnPropertyChanged("FilteredComboCode"); }
        }
  
        
        #endregion

        #region property
        public StudentDataWriteModel StdModel
        {
            get { return _StdModel; }
            set { _StdModel = value; this.OnPropertyChanged("Student"); }
        }
        public string[] SchoolClass { get; set; }
        public string[] SchoolSection { get; set; }
        public string[] StreamList { get; set; }
        public string[] SocialCatList { get; set; }
        public string[] BloodGroups { get; set; }
        public bool EnableStream
        {
            get { return _enableStrem; }
            set { _enableStrem = value; this.OnPropertyChanged("EnableStream"); }
        }
        public string StdClass
        {
            get { return _stdClass; }
            set 
            {
                this._stdClass = value;
                if (value == "XI" || value == "XII")
                {
                    this.EnableStream = true;
                }
                else
                {
                    // remove the selection and then disabled it.
                    this.ClassSelectedIndex = -1;
                    this.EnableStream = false;
                }
                this.OnPropertyChanged(string.Empty);
            }
        }

        private StudentDataWriteDb db { get; set; }
        private List<SubjectCombo> AllCombo { get; set; }

        public RelayCommand SaveDataCommand { get; set; }
        public RelayCommand PreviewCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        #endregion

        private void StartUpInitialize()
        {
            this.StdModel = new StudentDataWriteModel();
            this.SchoolClass = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            this.ClassessForAdmission = new string[] { "V", "VI", "VII", "VIII", "IX", "XI"};
            this.LastClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI" };
            this.SchoolSection = new string[] { "A", "B", "C", "D", "E" };
            this.ReligionList = new string[] { "ISLAM", "HINDU", "OTHER" };
            this.StreamList = new string[] { "Arts", "Science" };
            this.SocialCatList = new string[] { "GEN", "SC", "ST", "OBC-A", "OBC-B"};
            this.BloodGroups = new string[] { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };
            this.VillList = new string[] { "BAKHARPUR", "BAMONGRAM", "BROHMOTTOR", "CHAMAGRAM", "CHASPARA", "GOYESHBARI", "HARUGRAM", "JALALPUR", "MOSIMPUR", "NAZIRPUR", "PAHARPUR", "SUJAPUR" };
            this.PostOfficeList = new string[] { "BAKHARPUR", "BAMONGRAM", "CHASPARA", "CHHOTO SUJAPUR", "FATEHKHANI", "GAYESHBARI", "JALALPUR", "MOSIMPUR", "SUJAPUR" };
            this.PSList = new string[] { "KALIACHAK" };
            this.DistList = new string[] { "MALDA" };
            this.PinList = new string[] { "732206" };

            int CurrentYear = DateTime.Today.Year;
            this.YearOfPassingArray = new int[] { CurrentYear, CurrentYear - 1, CurrentYear - 2, CurrentYear - 3, CurrentYear - 4, CurrentYear - 5, CurrentYear - 6, CurrentYear - 7, CurrentYear -8, CurrentYear - 9};


            this.ClassSelectedIndex = -1;
            this.SectionSelectedIndex = -1;
            this.ComboIndex = -1;
            this.BloodGroupIndex = -1;
            this.SocialCatIndex = -1;
            this.IndexOfAdmittedClass = -1;
            this.LastClassIndex = -1;
            this.IndexOfLastClassYear = -1;
            this.ReligionIndex = -1;
            

            this.db = new StudentDataWriteDb();
            //this.AllCombo = db.GetCombo();
            
            this.FilteredComboCode = new ObservableCollection<string>();
            this.Banks = new ObservableCollection<string>();
            this.Banks.Add("STATE BANK OF INDIA");
            this.Branchs = new ObservableCollection<string>();
            this.Branchs.Add("SUJAPUR");
            this.IfcrList = new ObservableCollection<string>();
            this.IfcrList.Add("SBIN0006810");
            this.MICRList = new ObservableCollection<string>();
            this.MICRList.Add("732002506");


            this.SaveDataCommand = new RelayCommand(this.SaveData, this.CanSaveData);
            this.PreviewCommand = new RelayCommand(this.PreviewData, this.CanPreview);
            this.ResetCommand = new RelayCommand(this.ResetData, this.CanResetData);
        }

        private void UpdateComboList()
        {
            /*
            if (this.FilteredComboCode.Count > 0)
            {
                this.FilteredComboCode.Clear();
            }
            if (this.ClassSelectedIndex > -1)
            {
                var combs = from cm in this.AllCombo
                           where cm.BelongingClass == this.SchoolClass[this.ClassSelectedIndex]
                           select cm.Code;
                foreach (string item in combs)
                {
                    this.FilteredComboCode.Add(item);
                }
            }
             */
        }
        
        private void SetComboCode()
        {
            var comboId = from c in AllCombo
                             where c.Code == this.FilteredComboCode[this.ComboIndex]
                             select c.Id;
            foreach (string item in comboId)
            {
                this.SbComboCode = item;
            }
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
            Student std = this.buildStudentObject();
            string sYear = DateTime.Today.Year.ToString();
            string eYear = DateTime.Today.Year.ToString();
            bool inserted = db.InsertStudentData(std, sYear, eYear);
            if (inserted)
            {
                System.Windows.MessageBox.Show("Inserted.");
                this.ResetData();
            }
            else
            {
                System.Windows.MessageBox.Show("Failed");
            }
        }
        public bool CanSaveData()
        {
           bool basicNotEntered = string.IsNullOrWhiteSpace(this.TxbFirstName) || (this.ClassSelectedIndex == -1) || (this.SectionSelectedIndex == -1) || string.IsNullOrEmpty(this.Sex);
           bool FatherNameNotEntered = string.IsNullOrEmpty(this.TxbFatherName);
           return !basicNotEntered && !FatherNameNotEntered;
           
        }

        public void PreviewData()
        {
            NaimouzaHighSchool.Views.StudentEntryPreviewView preview = new Views.StudentEntryPreviewView();
            preview.ShowDialog();
        }
        public bool CanPreview()
        {
            return true;
        }

        public void ResetData()
        {
            this.TxbFirstName = this.TxbMidName = this.TxbLastName = string.Empty;
            this.TxbFatherName = string.Empty;
            this.TxbMotherName = string.Empty;
            this.GuardianName = string.Empty;
            this.RelationWithGuardian = string.Empty;
            this.Occupation = string.Empty;
            this.Dob = default(DateTime);
            this.Sex = string.Empty;
            this.BloodGroupIndex = -1;
            this.ReligionIndex = -1;
            this.SocialCatIndex = -1;
            this.SocialSubCat = string.Empty;
            this.IsPh = false;
            this.Isbpl = false;
            this.PhDetail = string.Empty;
            this.BplNo = string.Empty;
            this.PresentAddr1 = string.Empty;
            this.PresentAddr2 = string.Empty;
            this.PresentPostOffice = string.Empty;
            this.PresentPs = string.Empty;
            this.PresentDist = string.Empty;
            this.PresentPin = string.Empty;
            this.PermAddr1 = this.PermAddr2 = this.PermPO = this.PermPs = this.PermDist = this.PermPin = string.Empty;
            this.StdMobile = this.GrdMobile = string.Empty;
            this.Email = string.Empty;
            this.TxbAadhar = this.GuardianAadhar = this.VoterCardNo = string.Empty;
            this.AccNo = this.BankName = this.BranchName = this.Micr = this.Ifcr = string.Empty;
            this.ClassSelectedIndex = -1;
            this.SectionSelectedIndex = -1;
            this.Roll = 0;
            this.BoardNo = this.BoardRoll = this.CouncilNo = this.CouncilRoll = string.Empty;
            this.AdmissionDate = this.DateOfLeaving = default(DateTime);
            this.LastClassIndex = -1;
            this.LastSchool = string.Empty;
            this.Tc = string.Empty;

        }

        public bool CanResetData()
        {
            return true;
        }

        private Student buildStudentObject()
        {
            Student std = new Student();
            string fullName = this.TxbFirstName + " " + this.TxbMidName + " " + this.TxbLastName;

            string PresetnAddress = this.PresentAddr1 + " " + this.PresentAddr2 + "P.O. " + this.PresentPostOffice + "PS " + this.PresentPs + "Dist. " + this.PresentDist + "PIN " + this.PresentPin;
            string PermanentAddress = this.PermAddr1 + " " + this.PermAddr2 + "P.O. " + this.PermPO + "PS " + this.PermPs + "Dist. " + this.PermDist + "PIN " + this.PermPin;
           
            std.Name = fullName.Trim();
            std.FatherName = this.TxbFatherName;
            std.MotherName = this.TxbMotherName;
            std.GuardianName = this.GuardianName;
            std.GuardianRelation = this.RelationWithGuardian;
            std.GuardianOccupation = this.Occupation;
            std.Dob = this.Dob;
            std.Sex = this.Sex;
            std.BloodGroup = this.BloodGroup;
            std.Religion = this.Religion;
            std.SocialCategory = this.SocialCat;
            std.SubCast = this.SocialSubCat;
            std.IsPH = this.IsPh;
            std.PhType = this.PhDetail;
            std.IsBpl = this.Isbpl;
            std.BplNo = this.BplNo;
            std.PresentAdrress = PresetnAddress.Trim();
            std.PermanentAddress = PermanentAddress.Trim();
            std.Mobile = this.StdMobile;
            std.GuardianMobile = this.GrdMobile;
            std.Email = this.Email;
            std.Aadhar = this.TxbAadhar;
            std.GuardianAadhar = this.GuardianAadhar;
            std.GuardianEpic = this.VoterCardNo;
            std.BankAcc = this.AccNo;
            std.BankName = this.BankName;
            std.BankBranch = this.BranchName;
            std.Ifsc = this.Ifcr;
            std.MICR = this.Micr;
            std.StudyingClass = this.SelectedClass;
            std.Section = this.SelectedSection;
            std.Roll = this.Roll;
           // std.SubjectComboId = this.SbComboCode;
            std.BoardNo = this.BoardNo;
            std.BoardRoll = this.BoardRoll;
            std.CouncilNo = this.CouncilNo;
            std.CouncilRoll = this.CouncilRoll;
            std.AdmissionNo = this.AdmissionNo;
            std.AdmDate = this.AdmissionDate;
            std.LastSchool = this.LastSchool;
            std.AdmittedClass = this.AdmittedClass;
            std.DateOfLeaving = this.DateOfLeaving;
            std.TC = this.Tc;

            return std;
        
        }
    }
}
