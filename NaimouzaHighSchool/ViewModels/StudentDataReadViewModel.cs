﻿using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Text;

namespace NaimouzaHighSchool.ViewModels
{
    public class StudentDataReadViewModel : StudentClassBaseViewModel
    {
        public StudentDataReadViewModel()
        : base()
        {
            try
            {
                this.StartUpInitializer();
            }
            catch (Exception nm2)
            {
                System.Windows.MessageBox.Show("nm2 : " + nm2.Message);
            }
        }

        #region property field

        private const string defaultEntry = "";
        private const string V = @"\\Ami-laptop\d\img\bbc.jpg";

        private const int DEFAULT_SEARCH_CLASS_INDEX = 0;
        private const int DEFAULT_SEARCH_SECTION_INDEX = 0;
        private const int DEFAULT_SEARCH_GENDER_INDEX = 0;
        private const int DEFAULT_SEARCH_SOCIALCAT_INDEX = 0;
        private const int DEFAULT_SEARCH_STREAM_INDEX = -1;
        private const int DEFAULT_SEARCH_SUB_INDEX = -1;
        

        private string profileImageFolder { get; set; }

        private string _backgroundImageSource;
        public string BackgroundImageSource
        {
            get { return _backgroundImageSource; }
            set { _backgroundImageSource = value; OnPropertyChanged("BackgroundImageSource"); }
        }

        #region search bar

        private string _searchText;
        public string SearchText
        {
            get { return this._searchText; }
            set
            {
                this._searchText = value.ToUpper();
                this.OnPropertyChanged("SearchText");
            }
        }

        private string _searchTextBoxLabel;
        public string SearchTextBoxLabel
        {
            get { return this._searchTextBoxLabel; }
            set { this._searchTextBoxLabel = value; this.OnPropertyChanged("SearchTextBoxLabel"); }
        }

        private string _selectedClass;
        private string SelectedClass
        {
            get { return this._selectedClass; }
            set { this._selectedClass = value; this.OnPropertyChanged("SelectedClass"); }
        }

        public string[] SchoolClasses { get; set; }

        private int _selectedClassIndex;
        public int SelectedClassIndex
        {
            get { return this._selectedClassIndex; }
            set
            {
                this._selectedClassIndex = value;
                this.SelectedClass = (value > -1) ? this.SchoolClasses[value] : string.Empty;
                this.OnPropertyChanged("SelectedClassIndex");
            }
        }

        private string _selectedSection;
        private string SelectedSection
        {
            get { return this._selectedSection; }
            set { this._selectedSection = value; this.OnPropertyChanged("SelectedSection"); }
        }

        public string[] SchoolSections { get; set; }

        private int _selectedSectionIndex;
        public int SelectedSectionIndex
        {
            get { return this._selectedSectionIndex; }
            set
            {
                this._selectedSectionIndex = value;
                this.SelectedSection = (value > -1) ? this.SchoolSections[value] : string.Empty;
                this.OnPropertyChanged("SelectedSectionIndex");
            }
        }

        private int _roll;
        public int Roll
        {
            get { return this._roll; }
            set { this._roll = value; this.OnPropertyChanged("Roll"); }
        }

        private string _searchType;
        public string SearchType
        {
            get { return _searchType; }
            set
            {
                _searchType = value;
                OnPropertyChanged("SearchType");
                if (value == "genericSearch")
                {
                    ClassSearch = System.Windows.Visibility.Collapsed;
                    GenericSearch = System.Windows.Visibility.Visible;
                }
                else if (value == "classSearch")
                {
                    GenericSearch = System.Windows.Visibility.Collapsed;
                    ClassSearch = System.Windows.Visibility.Visible;
                }
                else
                {
                    GenericSearch = System.Windows.Visibility.Collapsed;
                    ClassSearch = System.Windows.Visibility.Collapsed;
                }
                SearchSectionIndex = DEFAULT_SEARCH_SECTION_INDEX;
                SearchGenderIndex = DEFAULT_SEARCH_GENDER_INDEX;
                SearchSocialCategoryIndex = DEFAULT_SEARCH_SOCIALCAT_INDEX;
                SearchStreamIndex = DEFAULT_SEARCH_STREAM_INDEX;
                ActiveHsSubsIndex = DEFAULT_SEARCH_SUB_INDEX;
            }
        }

        public string[] SearchBy { get; set; }

        private int _searchByIndex;

        public int SearchByIndex
        {
            get { return _searchByIndex; }
            set
            {
                _searchByIndex = (value > -1 && value < SearchBy.Length) ? value : -1;
                OnPropertyChanged("SearchByIndex");
                DoSearchFilterIndexToDefault();
            }
        }

        private string _searchParam;
        public string SearchParam
        {
            get { return _searchParam; }
            set
            {
                _searchParam = value;
                // default filters
                OnPropertyChanged("SearchParam");
              //  Search();
            }
        }


        public string[] SearchClass { get; set; }
        public string[] SearchSection { get; set; }
        public string[] SearchGender { get; set; }
        public string[] SearchSocialCategory { get; set; }
        public string[] SearchStream { get; set; }

        private int _searchClassIndex;

        public int SearchClassIndex
        {
            get { return _searchClassIndex; }
            set
            {
                if (SearchClass != null)
                {
                    _searchClassIndex = (value > -1 && value < SearchClass.Length) ? value : -1;
                }
                else
                {
                    _searchClassIndex = -1;
                }
                OnPropertyChanged("SearchClassIndex");
                if (ActiveHsStream.Count > 0)
                {
                    ActiveHsStream.Clear();
                    ActiveHsSubsIndex = -1;
                }
                if (SearchClass[SearchClassIndex] == "XI" || SearchClass[SearchClassIndex] == "XII")
                {
                    foreach (string item in SearchStream)
                    {
                        ActiveHsStream.Add(item);
                    }
                }
                //if (UnFilteredSList.Count > 0)
                //{
                //    StudentList = DoFilterStudentList(UnFilteredSList);
                //}
            }
        }

        private int _searchSectionIndex;

        public int SearchSectionIndex
        {
            get { return _searchSectionIndex; }
            set
            {
                if (SearchSection != null)
                {
                    _searchSectionIndex = (value > -1 && value < SearchSection.Length) ? value : -1;
                }
                else
                {
                    _searchSectionIndex = -1;
                }
                OnPropertyChanged("SearchSectionIndex");
                //if (UnFilteredSList.Count > 0)
                //{
                //    StudentList = DoFilterStudentList(UnFilteredSList);
                //}
            }
        }

        private int _searchGenderIndex;

        public int SearchGenderIndex
        {
            get { return _searchGenderIndex; }
            set
            {
                if (SearchGender != null)
                {
                    _searchGenderIndex = (value > -1 && value < SearchGender.Length) ? value : -1;
                }
                else
                {
                    _searchSectionIndex = -1;
                }
                OnPropertyChanged("SearchGenderIndex");
                //if (UnFilteredSList.Count > 0)
                //{
                //    StudentList = DoFilterStudentList(UnFilteredSList);
                //}
            }
        }

        private int _searchSocialCategoryIndex;
        public int SearchSocialCategoryIndex
        {
            get { return _searchSocialCategoryIndex; }
            set
            {
                if (SearchSocialCategory != null)
                {
                    _searchSocialCategoryIndex = (value > -1 && value < SearchSocialCategory.Length) ? value : -1;
                }
                else
                {
                    _searchSocialCategoryIndex = -1;
                }
                OnPropertyChanged("SearchSocialCategoryIndex");
                //if (UnFilteredSList.Count > 0)
                //{
                //    StudentList = DoFilterStudentList(UnFilteredSList);
                //}
            }
        }

        private int _searchStreamIndex;

        public int SearchStreamIndex
        {
            get { return _searchStreamIndex; }
            set
            {
                if (SearchStream != null)
                {
                    _searchStreamIndex = (value > -1 && value < SearchStream.Length) ? value : -1;
                }
                else
                {
                    _searchStreamIndex = -1;
                }
                OnPropertyChanged("SearchStreamIndex");
                ActiveHsSubsIndex = -1;
                if (_searchStreamIndex != -1)
                {
                    if (ActiveHsSubs.Count > 0)
                    {
                        ActiveHsSubs.Clear();
                    }
                    if (SearchStream[SearchStreamIndex] == "ARTS")
                    {
                        foreach (string item in GlobalVar.HsArtsSubs)
                        {
                            ActiveHsSubs.Add(item);
                        }
                        int r = 9;
                    }
                    else if (SearchStream[SearchStreamIndex] == "SCIENCE")
                    {
                        foreach (string item in GlobalVar.HsSciSubs)
                        {
                            ActiveHsSubs.Add(item);
                        }
                    }

                    //if (UnFilteredSList.Count > 0)
                    //{
                    //    StudentList = DoFilterStudentList(UnFilteredSList);
                    //}
                }
            }
        }

        private ObservableCollection<string> _activeHsStream;

        public ObservableCollection<string> ActiveHsStream
        {
            get { return _activeHsStream; }
            set { _activeHsStream = value; OnPropertyChanged("ActiveHsStream"); }
        }

        private ObservableCollection<string> _activeHsSubs;

        public ObservableCollection<string> ActiveHsSubs
        {
            get { return _activeHsSubs; }
            set { _activeHsSubs = value; OnPropertyChanged("ActiveHsSubs"); }
        }

        private int _activeHsSubsIndex;

        public int ActiveHsSubsIndex
        {
            get { return _activeHsSubsIndex; }
            set
            {
                if (ActiveHsSubs != null)
                {
                    _activeHsSubsIndex = (value > -1 && value < ActiveHsSubs.Count) ? value : -1; ;
                }
                else
                {
                    _activeHsSubsIndex = -1;
                }
                OnPropertyChanged("ActiveHsSubsIndex");
                //if (UnFilteredSList.Count > 0)
                //{
                //    StudentList = DoFilterStudentList(UnFilteredSList);
                //}
            }
        }

        private System.Windows.Visibility _genericSearch;

        public System.Windows.Visibility GenericSearch
        {
            get { return _genericSearch; }
            set { _genericSearch = value; OnPropertyChanged("GenericSearch"); }
        }

        private System.Windows.Visibility _classSearch;

        public System.Windows.Visibility ClassSearch
        {
            get { return _classSearch; }
            set { _classSearch = value; OnPropertyChanged("ClassSearch"); }
        }

        private BackgroundWorker bw = new BackgroundWorker();

        public RelayCommand SearchCommand { get; set; }

        #endregion search bar

        #region leftpane

        private ObservableCollection<Student> _studentList;
        public ObservableCollection<Student> StudentList
        {
            get { return this._studentList; }
            set { this._studentList = value; this.OnPropertyChanged("StudentList"); }
        }

        private List<Student> _slist;
        public List<Student> Slist
        {
            get { return this._slist; }
            set { this._slist = value; this.OnPropertyChanged("Slist"); }
        }

        private List<Student> _unFilteredSList;
        public List<Student> UnFilteredSList
        {
            get { return _unFilteredSList; }
            set { _unFilteredSList = value; OnPropertyChanged("UnFilteredSList"); }
        }


        private int _selectedStudentListIndex;

        public int SelectedStudentListIndex
        {
            get { return this._selectedStudentListIndex; }
            set
            {
                this._selectedStudentListIndex = value;
                this.OnPropertyChanged("SelectedStudentListIndex");
                this.StdDetailVisibility = (value > -1) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                if (value > -1)
                {
                    this.BuildStdDetailView(this.StudentList[value]);
                    this.SelectedStudent = this.StudentList[value];
                    this.TakenSubjects.Clear();
                }
            }
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return this._selectedStudent; }
            set { this._selectedStudent = value; this.OnPropertyChanged("SelectedStudent"); }
        }

        #endregion leftpane

        #region stdDetail

        #region gen

        private string _txbName;

        public string TxbName
        {
            get { return this._txbName; }
            set
            {
                this._txbName = value.ToUpper();
                this.OnPropertyChanged("TxbName");
            }
        }

        private string _claSecRoll;

        public string ClaSecRoll
        {
            get { return _claSecRoll; }
            set { _claSecRoll = value; OnPropertyChanged("ClaSecRoll"); }
        }

        private string _txbCls;

        public string TxbCls
        {
            get { return this._txbCls; }
            set
            {
                this._txbCls = value;
                this.OnPropertyChanged("TxbCls");
            }
        }

      

        private int _socialCatListIndex;
        public int SocialCatListIndex
        {
            get { return this._socialCatListIndex; }
            set
            {
                this._socialCatListIndex = value;
                this.OnPropertyChanged("SocialCatListIndex");
            }
        }

        private int _bloodGroupIndex;
        public int BloodGroupIndex
        {
            get { return this._bloodGroupIndex; }
            set
            {
                this._bloodGroupIndex = value;
                this.OnPropertyChanged("BloodGroupIndex");
            }
        }

        private int _classessForAdmissionIndex;

        public int ClassessForAdmissionIndex
        {
            get { return this._classessForAdmissionIndex; }
            set { this._classessForAdmissionIndex = value; this.OnPropertyChanged("ClassessForAdmissionIndex"); }
        }

        private string _txbSection;
        public string TxbSection { get { return this._txbSection; } set { this._txbSection = value; this.OnPropertyChanged("TxbSection"); } }

        private int _txbRoll;
        public int TxbRoll { get { return this._txbRoll; } set { this._txbRoll = value; this.OnPropertyChanged("TxbRoll"); } }

        private string _txbGen;

        public string TxbGen
        {
            get { return this._txbGen; }
            set
            {
                this._txbGen = value;
                if (value == "M")
                {
                    GenVisibilityFemale = System.Windows.Visibility.Collapsed;
                    GenVisibilityMale = System.Windows.Visibility.Visible;
                }
                else if (value == "F")
                {
                    GenVisibilityMale = System.Windows.Visibility.Collapsed;
                    GenVisibilityFemale = System.Windows.Visibility.Visible;
                }
                this.OnPropertyChanged("TxbGen");
            }
        }

        public string[] DD { get; set; }
        public string[] MM { get; set; }
        public string[] YYYY { get; set; }

        private int _dobDDIndex;
        public int DobDDIndex
        {
            get => _dobDDIndex;
            set
            {
                _dobDDIndex = value;
                OnPropertyChanged("DobDDIndex");
            }
        }

        private int _dobMMIndex;
        public int DobMMIndex
        {
            get => _dobMMIndex;
            set
            {
                _dobMMIndex = value;
                OnPropertyChanged("DobMMIndex");
            }
        }

        private int _dobYYIndex;
        public int DobYYIndex
        {
            get => _dobYYIndex;
            set
            {
                _dobYYIndex = value;
                OnPropertyChanged("DobYYIndex");
            }
        }

        private DateTime _dob;
        public DateTime Dob { get { return this._dob; } set { this._dob = value; this.OnPropertyChanged("Dob"); } }

        private string _dobString;
        public string DobString
        {
            get { return _dobString; }
            set { _dobString = value; OnPropertyChanged("DobString"); }
        }

        private string _studentAge;
        public string StudentAge
        {
            get { return _studentAge; }
            set { _studentAge = value; OnPropertyChanged("StudentAge"); }
        }

        private string _txbAge;
        public string TxbAge { get { return this._txbAge; } set { this._txbAge = value; this.OnPropertyChanged("TxbAge"); } }
        

        private string _subjGroupHeader;
        public string SubjGroupHeader
        {
            get { return _subjGroupHeader; }
            set { _subjGroupHeader = value; OnPropertyChanged("SubjGroupHeader"); }
        }

        private string _hsStream;
        public string HsStream
        {
            get { return _hsStream; }
            set { _hsStream = value; OnPropertyChanged("HsStream"); }
        }

        private string _hsSub1;
        public string HsSub1
        {
            get => _hsSub1;
            set
            {
                _hsSub1 = value;
                OnPropertyChanged("HsSub1");
            }
        }

        private string _hsSub2;
        public string HsSub2
        {
            get => _hsSub2;
            set
            {
                _hsSub2 = value;
                OnPropertyChanged("HsSub2");
            }
        }

        private string _hsSub3;
        public string HsSub3
        {
            get => _hsSub3;
            set
            {
                _hsSub3 = value;
                OnPropertyChanged("HsSub3");
            }
        }

        private string _hsSub4;
        public string HsSub4
        {
            get => _hsSub4;
            set
            {
                _hsSub4 = value;
                OnPropertyChanged("HsSub4");
            }
        }

        private ObservableCollection<string> _takenSubjects;

        public ObservableCollection<string> TakenSubjects
        {
            get { return this._takenSubjects; }
            set { this._takenSubjects = value; this.OnPropertyChanged("TakenSubjects"); }
        }

        private System.Collections.ArrayList _arrayOfSubs;

        public System.Collections.ArrayList ArrayOfSubs
        {
            get { return this._arrayOfSubs; }
            set { this._arrayOfSubs = value; this.OnPropertyChanged("ArrayOfSubs"); }
        }

        private Dictionary<string, System.Collections.ArrayList> _subDictionary;

        public Dictionary<string, System.Collections.ArrayList> SubDictionary
        {
            get { return this._subDictionary; }
            set { this._subDictionary = value; this.OnPropertyChanged("SubDictionary"); }
        }

        #endregion gen

        #region personal

        private string _txbFather;
        public string TxbFather { get { return this._txbFather; } set { this._txbFather = value.ToUpper(); this.OnPropertyChanged("TxbFather"); } }

        private string _txbMother;
        public string TxbMother { get { return this._txbMother; } set { this._txbMother = value.ToUpper(); this.OnPropertyChanged("TxbMother"); } }

        private string _txbGrd;
        public string TxbGrd { get { return this._txbGrd; } set { this._txbGrd = value.ToUpper(); this.OnPropertyChanged("TxbGrd"); } }

        private string _txbGrdRel;
        public string TxbGrdRel { get { return this._txbGrdRel; } set { this._txbGrdRel = value.ToUpper(); this.OnPropertyChanged("TxbGrdRel"); } }

        private string _txbGrdOcc;
        public string TxbGrdOcc { get { return this._txbGrdOcc; } set { this._txbGrdOcc = value; this.OnPropertyChanged("TxbGrdOcc"); } }

        private string _txbGrdAadhar;
        public string TxbGrdAadhar { get { return this._txbGrdAadhar; } set { this._txbGrdAadhar = value; this.OnPropertyChanged("TxbGrdAadhar"); } }

        private string _txbGrdEpic;
        public string TxbGrdEpic { get { return this._txbGrdEpic; } set { this._txbGrdEpic = value; this.OnPropertyChanged("TxbGrdEpic"); } }

        private string _txbAadhar;
        public string TxbAadhar { get { return this._txbAadhar; } set { this._txbAadhar = value; this.OnPropertyChanged("TxbAadhar"); } }

        private string _txbSocCat;
        public string TxbSocCat { get { return this._txbSocCat; } set { this._txbSocCat = value; this.OnPropertyChanged("TxbSocCat"); } }

        private string _txbSbCat;
        public string TxbSbCat { get { return this._txbSbCat; } set { this._txbSbCat = value.ToUpper(); this.OnPropertyChanged("TxbSbCat"); } }

        private bool _txbIsPh;
        public bool TxbIsPh { get { return this._txbIsPh; } set { this._txbIsPh = value; this.OnPropertyChanged("TxbIsPh"); } }

        private string _txbPhType;
        public string TxbPhType { get { return this._txbPhType; } set { this._txbPhType = value; this.OnPropertyChanged("TxbPhType"); } }

        private bool _stdIsBpl;
        public bool StdIsBpl { get { return this._stdIsBpl; } set { this._stdIsBpl = value; this.OnPropertyChanged("StdIsBpl"); } }

        private string _isStudentBPL;
        public string IsStudentBPL
        {
            get { return _isStudentBPL; }
            set { _isStudentBPL = value; OnPropertyChanged("IsStudentBPL"); }
        }

        private string _isStudentPH;
        public string IsStudentPH
        {
            get { return _isStudentPH; }
            set { _isStudentPH = value; OnPropertyChanged("IsStudentPH"); }
        }

        private string _txbBplNo;
        public string TxbBplNo { get { return this._txbBplNo; } set { this._txbBplNo = value; this.OnPropertyChanged("TxbBplNo"); } }

        private string _txbReligion;
        public string TxbReligion { get { return this._txbReligion; } set { this._txbReligion = value.ToUpper(); this.OnPropertyChanged("TxbReligion"); } }

        public string[] BloodGroups { get; set; }
        private string _bloodGrp;

        public string BloodGrp
        {
            get { return this._bloodGrp; }
            set { this._bloodGrp = value; this.OnPropertyChanged("BloodGrp"); }
        }


        #endregion personal

        #region contact

        private string _addrLane1;
        public string AddrLane1
        {
            get { return _addrLane1; }
            set { _addrLane1 = value; OnPropertyChanged("AddrLane1"); }
        }

        private string _addrLane2;
        public string AddrLane2
        {
            get { return _addrLane2; }
            set { _addrLane2 = value; OnPropertyChanged("AddrLane2"); }
        }

        private string _addrPO;
        public string AddrPO
        {
            get { return _addrPO; }
            set { _addrPO = value; OnPropertyChanged("AddrPO"); }
        }

        private string _addrPS;
        public string AddrPS
        {
            get { return _addrPS; }
            set { _addrPS = value; OnPropertyChanged("AddrPS"); }
        }

        private string _addrDist;
        public string AddrDist
        {
            get { return _addrDist; }
            set { _addrDist = value; OnPropertyChanged("AddrDist"); }
        }

        private string _addrPIN;
        public string AddrPIN
        {
            get { return _addrPIN; }
            set { _addrPIN = value; OnPropertyChanged("AddrPIN"); }
        }

        private string _paddrLane1;
        public string PaddrLane1
        {
            get { return _paddrLane1; }
            set { _paddrLane1 = value; OnPropertyChanged("PaddrLane1"); }
        }

        private string _paddrLane2;
        public string PaddrLane2
        {
            get { return _paddrLane2; }
            set { _paddrLane2 = value; OnPropertyChanged("PaddrLane2"); }
        }

        private string _paddrPO;
        public string PaddrPO
        {
            get { return _paddrPO; }
            set { _paddrPO = value; OnPropertyChanged("PaddrPO"); }
        }

        private string _paddrPS;
        public string PaddrPS
        {
            get { return _paddrPS; }
            set { _paddrPS = value; OnPropertyChanged("PaddrPS"); }
        }

        private string _paddrDist;
        public string PaddrDist
        {
            get { return _paddrDist; }
            set { _paddrDist = value; OnPropertyChanged("PaddrDist"); }
        }

        private string _paddrPIN;
        public string PaddrPIN
        {
            get { return _paddrPIN; }
            set { _paddrPIN = value; OnPropertyChanged("PaddrPIN"); }
        }

        private string _txbMobile;
        public string TxbMobile { get { return this._txbMobile; } set { this._txbMobile = value; this.OnPropertyChanged("TxbMobile"); } }
      
        private string _grdMobile;
        public string GrdMobile { get { return this._grdMobile; } set { this._grdMobile = value; this.OnPropertyChanged("GrdMobile"); } }
      

        private string _txbEmail;
        public string TxbEmail { get { return this._txbEmail; } set { this._txbEmail = value; this.OnPropertyChanged("TxbEmail"); } }
      

        #endregion contact

        #region bank

        private string _bankAcc;
        public string BankAcc { get { return this._bankAcc; } set { this._bankAcc = value; this.OnPropertyChanged("BankAcc"); } }

        private string _bankName;
        public string BankName { get { return this._bankName; } set { this._bankName = value; this.OnPropertyChanged("BankName"); } }

        private string _bankBranch;
        public string BankBranch { get { return this._bankBranch; } set { this._bankBranch = value; this.OnPropertyChanged("BankBranch"); } }

        private string _bankIfsc;
        public string BankIfsc { get { return this._bankIfsc; } set { this._bankIfsc = value; this.OnPropertyChanged("BankIfsc"); } }
       
        private string _bankMicr;
        public string BankMicr { get { return this._bankMicr; } set { this._bankMicr = value; this.OnPropertyChanged("BankMicr"); } }
     

        #endregion bank

        #region Admission

        private string _admissionNo;
        public string AdmissionNo { get { return this._admissionNo; } set { this._admissionNo = value; this.OnPropertyChanged("AdmissionNo"); } }
  

        /*
        private DateTime _admissionDate;
        public DateTime AdmissionDate { get { return this._admissionDate; } set { this._admissionDate = value; this.OnPropertyChanged("AdmissionDate"); } }
        private string _admissionDateColor;
        public string AdmissionDateColor { get { return this._admissionDateColor; } set { this._admissionDateColor = value; this.OnPropertyChanged("AdmissionDateColor"); } }
        */

        private int _doaDDIndex;
        public int DoaDDIndex
        {
            get => _doaDDIndex;
            set
            {
                _doaDDIndex = value;
                OnPropertyChanged("DoaDDIndex");
            }
        }

        private int _doaMMIndex;
        public int DoaMMIndex
        {
            get => _doaMMIndex;
            set
            {
                _doaMMIndex = value;
                OnPropertyChanged("DoaMMIndex");
            }
        }

        private int _doaYYIndex;
        public int DoaYYIndex
        {
            get => _doaYYIndex;
            set
            {
                _doaYYIndex = value;
                OnPropertyChanged("DoaYYIndex");
            }
        }

        private string _admittedClass;
        public string AdmittedClass { get { return this._admittedClass; } set { this._admittedClass = value; this.OnPropertyChanged("AdmittedClass"); } }
        

        private string _lastSchool;
        public string LastSchool { get { return this._lastSchool; } set { this._lastSchool = value; this.OnPropertyChanged("LastSchool"); } }
       

        /*
        private DateTime _dateOfLeaving;
        public DateTime DateOfLeaving { get { return this._dateOfLeaving; } set { this._dateOfLeaving = value; this.OnPropertyChanged("DateOfLeaving"); } }
        private string _dateOfLeavingColor;
        public string DateOfLeavingColor { get { return this._dateOfLeavingColor; } set { this._dateOfLeavingColor = value; this.OnPropertyChanged("DateOfLeavingColor"); } }
        */

        private string _tc;
        public string Tc { get { return this._tc; } set { this._tc = value; this.OnPropertyChanged("Tc"); } }
        

        public string[] ClassesForAdmission { get; set; }

        #endregion Admission

        #region other

        private string _txbMadhyamicRoll;
        public string TxbMadhyamicRoll { get { return this._txbMadhyamicRoll; } set { this._txbMadhyamicRoll = value; this.OnPropertyChanged("TxbMadhyamicRoll"); } }
       

        private string _txbMadhyamicNo;
        public string TxbMadhyamicNo { get { return this._txbMadhyamicNo; } set { this._txbMadhyamicNo = value; this.OnPropertyChanged("TxbMadhyamicNo"); } }
       

        private string _txbMPRegisNo;

        public string TxbMPRegisNo
        {
            get => _txbMPRegisNo;
            set
            {
                _txbMPRegisNo = value;
                OnPropertyChanged("TxbMPRegisNo");
            }
        }

        private string _txbCouncilRoll;
        public string TxbCouncilRoll { get { return this._txbCouncilRoll; } set { this._txbCouncilRoll = value; this.OnPropertyChanged("TxbCouncilRoll"); } }
       

        private string _txbCouncilNo;
        public string TxbCouncilNo { get { return this._txbCouncilNo; } set { this._txbCouncilNo = value; this.OnPropertyChanged("TxbCouncilNo"); } }

        private string _txbHSRegisNo;

        public string TxbHSRegisNo
        {
            get => _txbHSRegisNo;
            set
            {
                _txbHSRegisNo = value;
                OnPropertyChanged("TxbHSRegisNo");
            }
        }

        #endregion other

        #region visibility

        private System.Windows.Visibility _stdDetailVisibility;
        public System.Windows.Visibility StdDetailVisibility
        {
            get { return this._stdDetailVisibility; }
           //  get { return System.Windows.Visibility.Visible; }
            set { this._stdDetailVisibility = value; this.OnPropertyChanged("StdDetailVisibility"); }
        }

        private System.Windows.Visibility _genVisibilityMale;

        public System.Windows.Visibility GenVisibilityMale
        {
            get { return _genVisibilityMale; }
            set { _genVisibilityMale = value; OnPropertyChanged("GenVisibilityMale"); }
        }

        private System.Windows.Visibility _genVisibilityFemale;

        public System.Windows.Visibility GenVisibilityFemale
        {
            get { return _genVisibilityFemale; }
            set { _genVisibilityFemale = value; OnPropertyChanged("GenVisibilityFemale"); }
        }

        private System.Windows.Visibility _subjVisibility;

        public System.Windows.Visibility SubjVisibility
        {
            get { return _subjVisibility; }
            set { _subjVisibility = value; OnPropertyChanged("SubjVisibility"); }
        }

        private System.Windows.Visibility _subj5Visibility;

        public System.Windows.Visibility Subj5Visibility
        {
            get { return _subj5Visibility; }
            set { _subj5Visibility = value; OnPropertyChanged("Subj5Visibility"); }
        }

        private System.Windows.Visibility _subjHsVisibility;

        public System.Windows.Visibility SubjHsVisibility
        {
            get { return _subjHsVisibility; }
            set { _subjHsVisibility = value; OnPropertyChanged("SubjHsVisibility"); }
        }

        #endregion visibility

        #endregion stdDetail

        private StudentDataReadDb db { get; set; }
        private int _numberOfMatches;

        public int NumberOfMatches
        {
            get { return this._numberOfMatches; }
            set { this._numberOfMatches = value; this.OnPropertyChanged("NumberOfMatches"); }
        }

        private string _profileImageSource;

        public string ProfileImageSource
        {
            get { return _profileImageSource; }
            set { _profileImageSource = value; OnPropertyChanged("ProfileImageSource"); }
        }

        private string[] profImage = { "f://prof//UN.jpg", "f://prof//chear.png" };

        private string _session;
        public string Session
        {
            get { return _session; }
            set { _session = value; OnPropertyChanged("Session"); }
        }


        public RelayCommand FindCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public RelayCommand SortByNameCommand { get; set; }
        public RelayCommand SortByClassCommand { get; set; }
        public RelayCommand SortBySectionCommand { get; set; }
        public RelayCommand SortByRollCommand { get; set; }
        public RelayCommand GenUpdateCommand { get; set; }

        #endregion property field

        #region method

        private void StartUpInitializer()
        {
            BackgroundImageSource = Helpers.BackgroundImageHelper.GetRandomImagePath();

            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            this.SchoolSections = new string[] { "A", "B", "C", "D", "E" };
            this.BloodGroups = new string[] { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };
            this.ClassesForAdmission = new string[] { "V", "VI", "VII", "VIII", "IX", "XI" };
            StartYear = DateTime.Today.Year;
            EndYear = DateTime.Today.Year;

            DD = new string[] { "DD", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            MM = new string[] { "MM", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            int yy = DateTime.Now.Year;
            YYYY = new string[26];
            YYYY[0] = "YYYY";
            for (int i = 0; i < 25; i++)
            {
                YYYY[i + 1] = (yy - i).ToString();
            }

            this.Slist = new List<Student>();
            this.StudentList = new ObservableCollection<Student>();
            UnFilteredSList = new List<Student>();
            this.db = new StudentDataReadDb();

            SearchType = "genericSearch";
            //  SearchType = "classSearch";
            // 0=> student'sName, 1=>ID, 2=>Aadhar, 3=>FatherName, 4=>Village, 5=>SocialCategory, 6=>RollNumber
            SearchBy = new string[] { "Student's Name", "Student's ID", "Aadhaar", "Father's Name", "Village", "Social Category", "Roll Number" };
            SearchClass = new string[] { "All", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "Undefined" };
            SearchSection = new string[] { "All", "A", "B", "C", "D", "E", "Undefined" };
            SearchGender = new string[] { "All", "Boy", "Girl", "Undefined" };
            SearchSocialCategory = new string[] { "All", "GEN", "SC", "ST", "OBC", "OBC-A", "OBC-B", "Undefined" };
            SearchStream = new string[] { "All", "ARTS", "SCIENCE", "Undefined" };
            ActiveHsStream = new ObservableCollection<string>();
            ActiveHsSubs = new ObservableCollection<string>();
            DoSearchFilterIndexToDefault();

           
            this.SchoolSectionIndex = -1;
            this.SocialCatListIndex = -1;
            this.BloodGroupIndex = -1;
            this.SelectedStudentListIndex = -1;
            this.ClassessForAdmissionIndex = -1;

            /*
            profileImageFolder = ConfigurationManager.AppSettings["profileImageFolder"];
            ProfileImageSource = profileImageFolder + "20140828_142911.jpg";
            */

            this.TakenSubjects = new ObservableCollection<string>();
            this.ArrayOfSubs = new System.Collections.ArrayList();
            this.SubDictionary = new Dictionary<string, System.Collections.ArrayList>();

            this.CommandInitializer();
            EventConnector.StudentUpdated += RefreshUpdatedStudentDetails;
        }

        private void DoSearchFilterIndexToDefault()
        {
            SearchClassIndex = DEFAULT_SEARCH_CLASS_INDEX;
            SearchSectionIndex = DEFAULT_SEARCH_SECTION_INDEX;
            SearchGenderIndex = DEFAULT_SEARCH_GENDER_INDEX;
            SearchSocialCategoryIndex = DEFAULT_SEARCH_SOCIALCAT_INDEX;
            SearchStreamIndex = DEFAULT_SEARCH_STREAM_INDEX;
            ActiveHsSubsIndex = DEFAULT_SEARCH_SUB_INDEX;
        }

        private void CommandInitializer()
        {
            FindCommand = new RelayCommand(Find, CanFind);
            this.SearchCommand = new RelayCommand(this.Search, this.CanSearch);
            this.DeleteCommand = new RelayCommand(this.Delete, this.CanDelete);
            this.SortByNameCommand = new RelayCommand(this.SortByName, this.CanSortByName);
            this.SortByClassCommand = new RelayCommand(this.SortByClass, this.CanSortByClass);
            this.SortBySectionCommand = new RelayCommand(this.SortBySection, this.CanSortBySection);
            this.SortByRollCommand = new RelayCommand(this.SortByRoll, this.CanSortByRoll);
            GenUpdateCommand = new RelayCommand(GenUpdate, CanGenUpdate);
        }

        private void RefreshUpdatedStudentDetails(object sender, EventArgs e)
        {
            // hold the selectedIndex
            int retainIndex = SelectedStudentListIndex;
            // replace the old student with new one
            string selectedStdId = StudentList[SelectedStudentListIndex].Id;
            Student UpdatedStudent = db.GetStudent(selectedStdId);
            StudentList[SelectedStudentListIndex] = UpdatedStudent;
            // rebuild stdDetailView
            BuildStdDetailView(UpdatedStudent);
            SelectedStudentListIndex = retainIndex;
        }

 

        private void Search()
        {
            SearchType SType;
            switch (SearchByIndex)
            {
                case 0:
                    SType = Models.SearchType.Name;
                    break;
                case 1:
                    SType = Models.SearchType.ID;
                    break;
                case 2:
                    SType = Models.SearchType.Aadhaar;
                    break;
                case 3:
                    SType = Models.SearchType.Father;
                    break;
                case 4:
                    SType = Models.SearchType.Village;
                    break;
                case 5:
                    SType = Models.SearchType.SocialCategory;
                    break;
                case 6:
                    SType = Models.SearchType.Roll;
                    break;
                default:
                    SType = Models.SearchType.Name;
                    break;
            }
            if (SearchByIndex != -1)
            {
                UnFilteredSList = db.GetStudentList(searchParam: SearchParam, sType: SType, startYear: StartYear, endYear: EndYear);
                // StudentList = new ObservableCollection<Student>(UnFilteredSList);
                StudentList = DoFilterStudentList(UnFilteredSList);
                NumberOfMatches = StudentList.Count;
            }
        }

        private bool CanSearch()
        {
            return SearchByIndex != -1 && !string.IsNullOrEmpty(SearchParam);
        }


        private void BuildStdDetailView(Student s)
        {
            ProfileImageSource = Helpers.BackgroundImageHelper.GetRandomImagePath();

            this.TxbGen = s.Sex;
            this.TxbName = s.Name;

            this.TxbCls = s.StudyingClass;
            this.TxbSection = s.Section;
          //  this.SchoolSectionIndex = Array.IndexOf(this.SchoolSections, s.Section);
            this.TxbRoll = s.Roll;

            ClaSecRoll = TxbCls + "-" + TxbSection + "-" + TxbRoll;
            Session = s.StartSessionYear + "-" + s.EndSessionYear;

            DobString = s.Dob.ToLongDateString();

            if (s.Dob.Year == 1)
            {
                StudentAge = string.Empty;
            }
            else
            {
                Age sAge = new Age(s.Dob);
                sAge.Count(s.Dob);
                string ageYear = (sAge.Years > 1) ? " years " : " year ";
                string ageMonth = (sAge.Months > 1) ? " months " : " month ";
                string ageDay = (sAge.Days > 1) ? " days" : " day";
                StudentAge = sAge.Years.ToString() + ageYear + sAge.Months.ToString() + ageMonth + sAge.Days.ToString() + ageDay;
            }

            if (s.Dob.Year == 1)
            {
                DobDDIndex = DobMMIndex = DobYYIndex = 0;
            }
            else
            {
                int dIndex = Array.IndexOf(DD, s.Dob.Day.ToString("00"));
                DobDDIndex = (dIndex == -1) ? 0 : dIndex;
                int mIndex = Array.IndexOf(MM, s.Dob.Month.ToString("00"));
                DobMMIndex = (mIndex == -1) ? 0 : mIndex;
                int yIndex = Array.IndexOf(YYYY, s.Dob.Year.ToString());
                DobYYIndex = (yIndex == -1) ? 0 : yIndex;
            }

            this.TxbFather = (string.IsNullOrEmpty(s.FatherName)) ? defaultEntry : s.FatherName;
            this.TxbMother = (string.IsNullOrEmpty(s.MotherName)) ? defaultEntry : s.MotherName;
            this.TxbGrd = (string.IsNullOrEmpty(s.GuardianName)) ? defaultEntry : s.GuardianName;
            this.TxbGrdRel = (string.IsNullOrEmpty(s.GuardianRelation)) ? defaultEntry : s.GuardianRelation;
            this.TxbGrdAadhar = OutputFormatter.GetText(s.GuardianAadhar, IdNumberType.Aadhaar);
            this.TxbGrdEpic = (string.IsNullOrEmpty(s.GuardianEpic)) ? defaultEntry : s.GuardianEpic;
            this.TxbGrdOcc = (string.IsNullOrEmpty(s.GuardianOccupation)) ? defaultEntry : s.GuardianOccupation;
            this.BloodGrp = (string.IsNullOrEmpty(s.BloodGroup)) ? defaultEntry : s.BloodGroup;
            this.BloodGroupIndex = Array.IndexOf(this.BloodGroups, s.BloodGroup);

            if (s.StudyingClass == "V" || s.StudyingClass == "XI" || s.StudyingClass == "XII")
            {
                SubjVisibility = System.Windows.Visibility.Visible;
                if (s.StudyingClass == "V")
                {
                    SubjGroupHeader = "3rd Language Subject";
                    SubjHsVisibility = System.Windows.Visibility.Collapsed;
                    Subj5Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    SubjGroupHeader = "Subjects taken";
                    Subj5Visibility = System.Windows.Visibility.Collapsed;
                    SubjHsVisibility = System.Windows.Visibility.Visible;
                    HsStream = s.Stream.ToUpper();
                }
            }
            else
            {
                SubjVisibility = System.Windows.Visibility.Collapsed;
            }

            this.HsSub1 = (string.IsNullOrEmpty(s.HsSub1)) ? string.Empty : "1. " + s.HsSub1;
            this.HsSub2 = (string.IsNullOrEmpty(s.HsSub2)) ? string.Empty : "2. " + s.HsSub2;
            this.HsSub3 = (string.IsNullOrEmpty(s.HsSub3)) ? string.Empty : "3. " + s.HsSub3;
            this.HsSub4 = (string.IsNullOrEmpty(s.HsAdlSub)) ? string.Empty : "4. " + s.HsAdlSub;

            this.TxbAadhar = OutputFormatter.GetText(s.Aadhar, IdNumberType.Aadhaar);
            this.TxbSocCat = (string.IsNullOrEmpty(s.SocialCategory)) ? defaultEntry : s.SocialCategory;
            this.TxbSbCat = (string.IsNullOrEmpty(s.SubCast)) ? defaultEntry : s.SubCast;
            this.TxbIsPh = s.IsPH;
            IsStudentPH = (s.IsPH) ? "YES" : "NO";
            this.TxbPhType = s.PhType;
            this.StdIsBpl = s.IsBpl;
            IsStudentBPL = (s.IsBpl) ? "YES" : "NO";
            this.TxbBplNo = s.BplNo;
            this.TxbReligion = (string.IsNullOrEmpty(s.Religion)) ? defaultEntry : s.Religion;

            AddrLane1 = s.PstAddrLane1;
            AddrLane2 = s.PstAddrLane2;
            AddrPO = s.PstAddrPO;
            AddrPS = s.PstAddrPS;
            AddrDist = s.PstAddrDist;
            AddrPIN = s.PstAddrPin;

            PaddrLane1 = s.PmtAddrLane1;
            PaddrLane2 = s.PmtAddrLane2;
            PaddrPO = s.PmtAddrPO;
            PaddrPS = s.PmtAddrPS;
            PaddrDist = s.PmtAddrDist;
            PaddrPIN = s.PmtAddrPin;

            this.TxbMobile = OutputFormatter.GetText(s.Mobile, IdNumberType.Mobile);
            this.GrdMobile = OutputFormatter.GetText(s.GuardianMobile, IdNumberType.Mobile);
            this.TxbEmail = (string.IsNullOrEmpty(s.Email)) ? defaultEntry : s.Email;

            this.BankAcc = s.BankAcc;
            this.BankName = s.BankName;
            this.BankBranch = s.BankBranch;
            this.BankIfsc = s.Ifsc;
            this.BankMicr = s.MICR;

            this.AdmissionNo = OutputFormatter.GetText(s.AdmissionNo, IdNumberType.StudentId);

            if (s.AdmDate.Year == 1)
            {
                DoaDDIndex = DoaMMIndex = DoaYYIndex = 0;
            }
            else
            {
                int dIndex = Array.IndexOf(DD, s.AdmDate.Day.ToString("00"));
                DoaDDIndex = (dIndex == -1) ? 0 : dIndex;
                int mIndex = Array.IndexOf(MM, s.AdmDate.Month.ToString("00"));
                DoaMMIndex = (mIndex == -1) ? 0 : mIndex;
                int yIndex = Array.IndexOf(YYYY, s.AdmDate.Year.ToString());
                DoaYYIndex = (yIndex == -1) ? 0 : yIndex;
            }

            this.AdmittedClass = (string.IsNullOrEmpty(s.AdmittedClass)) ? defaultEntry : s.AdmittedClass;
            this.ClassessForAdmissionIndex = Array.IndexOf(this.ClassesForAdmission, s.AdmittedClass);
            this.LastSchool = (string.IsNullOrEmpty(s.LastSchool)) ? defaultEntry : s.LastSchool;

            this.Tc = (string.IsNullOrEmpty(s.TC)) ? defaultEntry : s.TC;

            TxbMPRegisNo = (string.IsNullOrEmpty(s.RegistrationNoMp)) ? defaultEntry : s.RegistrationNoMp;
            TxbHSRegisNo = (string.IsNullOrEmpty(s.RegistrationNoHs)) ? defaultEntry : s.RegistrationNoHs;

            this.TxbMadhyamicRoll = (string.IsNullOrEmpty(s.BoardRoll)) ? defaultEntry : s.BoardRoll;
            this.TxbMadhyamicNo = (string.IsNullOrEmpty(s.BoardNo)) ? defaultEntry : s.BoardNo;
            this.TxbCouncilRoll = (string.IsNullOrEmpty(s.CouncilRoll)) ? defaultEntry : s.CouncilRoll;
            this.TxbCouncilNo = (string.IsNullOrEmpty(s.CouncilNo)) ? defaultEntry : s.CouncilNo;
        }

        private void Delete()
        {
            System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Delete " + this.SelectedStudent.Name + "?", "", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
            if (result == System.Windows.MessageBoxResult.Yes)
            {
                if (db.DeleteStudent(this.SelectedStudent.Id))
                {
                    System.Windows.MessageBox.Show("Deleted");
                    int temp_index = this.SelectedStudentListIndex;
                    this.SelectedStudentListIndex = -1;
                    this.StudentList.RemoveAt(temp_index);
                }
            }
            else
            {
            }
        }

        private bool CanDelete()
        {
            return (this.SelectedStudentListIndex > -1);
        }


        private bool isDatesValid()
        {
            bool valid = false;
            if (DobDDIndex > 0 && DobMMIndex > 0 && DobYYIndex > 0)
            {
                string dt_str = YYYY[DobYYIndex].ToString() + MM[DobMMIndex].ToString() + DD[DobDDIndex];
                DateTime dt;
                valid = DateTime.TryParseExact(dt_str, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
            }
            if (DoaDDIndex > 0 && DoaMMIndex > 0 && DoaYYIndex > 0)
            {
                string dt_str2 = YYYY[DoaYYIndex].ToString() + MM[DoaMMIndex].ToString() + DD[DoaDDIndex];
                DateTime dt2;
                valid = DateTime.TryParseExact(dt_str2, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt2);
            }
            return valid;
        }

        private void EnableDisableSearchControl()
        {
        }

        private string getVal(string valInp)
        {
            return (valInp == defaultEntry || valInp == defaultEntry.ToUpper()) ? string.Empty : valInp;
        }

        private DateTime getDate(string propertyName)
        {
            if (propertyName == "dob")
            {
                if (DobDDIndex == 0 && DobMMIndex == 0 && DobYYIndex == 0)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    string dt_str = YYYY[DobYYIndex].ToString() + MM[DobMMIndex].ToString() + DD[DobDDIndex];
                    DateTime dt;
                    bool valid = DateTime.TryParseExact(dt_str, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
                    return dt;
                }
            }
            else if (propertyName == "doa")
            {
                if (DoaDDIndex == 0 && DoaMMIndex == 0 && DoaYYIndex == 0)
                {
                    return DateTime.MinValue;
                }
                else
                {
                    string dt_str2 = YYYY[DoaYYIndex].ToString() + MM[DoaMMIndex].ToString() + DD[DoaDDIndex];
                    DateTime dt2;
                    bool valid = DateTime.TryParseExact(dt_str2, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt2);
                    return dt2;
                }
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        private void GenUpdate()
        {
            GenUpdateViewModel.EditableStudent = StudentList[SelectedStudentListIndex];
            Views.GenUpdateView genUpdateWindow = new Views.GenUpdateView();
            genUpdateWindow.ShowDialog();
        }

        private bool CanGenUpdate()
        {
            return SelectedStudentListIndex > -1;
        }

        #region sort

        private void SortByName()
        {
            ObservableCollection<Student> tobj = new ObservableCollection<Student>(this.StudentList.ToList<Student>());
            var tempStdList = from s in tobj
                              orderby s.Name
                              select s;
            this.StudentList.Clear();
            foreach (Student item in tempStdList)
            {
                this.StudentList.Add(item);
            }
        }

        private bool CanSortByName()
        {
            return this.StudentList.Count > 0;
        }

        private void SortByClass()
        {
            ObservableCollection<Student> tobj = new ObservableCollection<Student>(this.StudentList.ToList<Student>());
            var tempStdList = from s in tobj
                              orderby s.StudyingClass
                              select s;
            this.StudentList.Clear();
            foreach (Student item in tempStdList)
            {
                this.StudentList.Add(item);
            }
        }

        private bool CanSortByClass()
        {
            return this.StudentList.Count > 0;
        }

        private void SortBySection()
        {
            ObservableCollection<Student> tobj = new ObservableCollection<Student>(this.StudentList.ToList<Student>());
            var tempStdList = from s in tobj
                              orderby s.Section
                              select s;
            this.StudentList.Clear();
            foreach (Student item in tempStdList)
            {
                this.StudentList.Add(item);
            }
        }

        private bool CanSortBySection()
        {
            return this.StudentList.Count > 0;
        }

        private void SortByRoll()
        {
            ObservableCollection<Student> tobj = new ObservableCollection<Student>(this.StudentList.ToList<Student>());
            var tempStdList = from s in tobj
                              orderby s.Roll
                              select s;
            this.StudentList.Clear();
            foreach (Student item in tempStdList)
            {
                this.StudentList.Add(item);
            }
        }

        private bool CanSortByRoll()
        {
            return this.StudentList.Count > 0;
        }

        #endregion sort


        
        protected override void OnSelectedClassChange()
        {
            if (ActiveHsSubs.Count > 0)
            {
                ActiveHsSubs.Clear();
            }
            if (ActiveHsStream.Count > 0)
            {
                ActiveHsStream.Clear();
            }
            if (SchoolClass[SchoolClassIndex] == "XI" || SchoolClass[SchoolClassIndex] == "XII")
            {
                foreach (string item in SearchStream)
                {
                    ActiveHsStream.Add(item);
                }
            }
            //if (SchoolClassIndex != -1)
            //{
            //    UnFilteredSList = db.GetStudentListByClass(cls: SchoolClass[SchoolClassIndex], startYear: StartYear, endYear: EndYear);
            //    StudentList = new ObservableCollection<Student>(UnFilteredSList);
            //    NumberOfMatches = StudentList.Count;
            //}
        }
        
        private void SearchByClass()
        {
            //if (ActiveHsSubs.Count > 0)
            //{
            //    ActiveHsSubs.Clear();
            //}
            //if (ActiveHsStream.Count > 0)
            //{
            //    ActiveHsStream.Clear();
            //}
            //if (SchoolClass[SchoolClassIndex] == "XI" || SchoolClass[SchoolClassIndex] == "XII")
            //{
            //    foreach (string item in SearchStream)
            //    {
            //        ActiveHsStream.Add(item);
            //    }
            //}
            if (SchoolClassIndex != -1)
            {
                UnFilteredSList = db.GetStudentListByClass(cls: SchoolClass[SchoolClassIndex], startYear: StartYear, endYear: EndYear);
                // StudentList = new ObservableCollection<Student>(UnFilteredSList);
                StudentList = DoFilterStudentList(UnFilteredSList);
                NumberOfMatches = StudentList.Count;
            }
        }

        private ObservableCollection<Student> DoFilterStudentList(List<Student> sList)
        {
            List<Student> stdList = new List<Student>(sList);
            ObservableCollection<Student> FilteredList = new ObservableCollection<Student>();
            if (stdList.Count == 0)
            {
                NumberOfMatches = 0;
                return FilteredList;
            }
            else
            {
                if (SearchType == "genericSearch")
                {
                    if (SearchClassIndex > 0 && SearchClassIndex < SearchClass.Length)
                    {
                        if (SearchClassIndex == SearchClass.Length - 1)
                        {
                            stdList.RemoveAll(std => !string.IsNullOrEmpty(std.StudyingClass));
                        }
                        else
                        {
                            stdList.RemoveAll(std => std.StudyingClass != SearchClass[SearchClassIndex]);
                        }
                    }
                }
                if (SearchSectionIndex > 0 && SearchSectionIndex < SearchSection.Length)
                {
                    if (SearchSectionIndex == SearchSection.Length - 1)
                    {
                        stdList.RemoveAll(std => !string.IsNullOrEmpty(std.Section));
                    }
                    else
                    {
                        stdList.RemoveAll(std => std.Section != SearchSection[SearchSectionIndex]);
                    }
                }
                if (SearchGenderIndex > 0 && SearchGenderIndex < SearchGender.Length)
                {
                    if (SearchGenderIndex == SearchGender.Length - 1)
                    {
                        stdList.RemoveAll(std => !string.IsNullOrEmpty(std.Sex));
                    }
                    else
                    {
                        string sx = string.Empty;
                        if (SearchGender[SearchGenderIndex] == "Boy")
                        {
                            sx = "M";
                        }
                        else if (SearchGender[SearchGenderIndex] == "Girl")
                        {
                            sx = "F";
                        }
                        stdList.RemoveAll(std => std.Sex != sx);
                    }
                }
                if (SearchSocialCategoryIndex > 0 && SearchSocialCategoryIndex < SearchSocialCategory.Length)
                {
                    if (SearchSocialCategoryIndex == SearchSocialCategory.Length - 1)
                    {
                        stdList.RemoveAll(std => !string.IsNullOrEmpty(std.SocialCategory));
                    }
                    else
                    {
                        stdList.RemoveAll(std => std.SocialCategory != SearchSocialCategory[SearchSocialCategoryIndex]);
                    }
                }
                if (SearchStreamIndex > 0 && SearchStreamIndex < SearchStream.Length)
                {
                    if (SearchStreamIndex == SearchStream.Length - 1)
                    {
                        stdList.RemoveAll(std => !string.IsNullOrEmpty(std.Stream));
                    }
                    else
                    {
                        
                        stdList.RemoveAll(std => std.Stream != SearchStream[SearchStreamIndex]);
                    }
                }
                if (ActiveHsSubsIndex >= 0 && ActiveHsSubsIndex < ActiveHsSubs.Count)
                {
                    stdList.RemoveAll(std => (std.HsSub1 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsSub2 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsSub3 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsAdlSub != ActiveHsSubs[ActiveHsSubsIndex]));
                }
            }
            FilteredList = new ObservableCollection<Student>(stdList);
            NumberOfMatches = FilteredList.Count;
            return FilteredList;
        }

        private void Find()
        {
            if (SearchType == "genericSearch")
            {
                Search();
            }
            else if (SearchType == "classSearch")
            {
                SearchByClass();
            }
            else
            {
                
            }
        }

        private bool CanFind()
        {
            if (SearchType == "genericSearch")
            {
                return !string.IsNullOrEmpty(SearchParam);
            }
            else if (SearchType == "classSearch")
            {
                return SchoolClassIndex != -1;
            }
            else
            {
                return false;
            }
        }

        #endregion method
    }
}