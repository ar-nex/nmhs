using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;

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

        private const string fontcolor1 = "#053646";
        private const string fontcolor0 = "#053646";
        private const string defaultEntry = "";
        private const string V = @"\\Ami-laptop\d\img\bbc.jpg";

        private const int DEFAULT_SEARCH_CLASS_INDEX = 0;
        private const int DEFAULT_SEARCH_SECTION_INDEX = 0;
        private const int DEFAULT_SEARCH_GENDER_INDEX = 0;
        private const int DEFAULT_SEARCH_SOCIALCAT_INDEX = 0;
        private const int DEFAULT_SEARCH_STREAM_INDEX = -1;
        private const int DEFAULT_SEARCH_SUB_INDEX = -1;
        

        private string profileImageFolder { get; set; }

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
                DoSearchFilterIndexToDefault();
                OnPropertyChanged("SearchByIndex");
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
                Search();
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
                _searchClassIndex = (value > -1 && value < SearchClass.Length) ? value : -1;
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
                if (UnFilteredSList.Count > 0)
                {
                    StudentList = DoFilterStudentList(UnFilteredSList);
                }
            }
        }

        private int _searchSectionIndex;

        public int SearchSectionIndex
        {
            get { return _searchSectionIndex; }
            set
            {
                _searchSectionIndex = (value > -1 && value < SearchSection.Length) ? value : -1;
                OnPropertyChanged("SearchSectionIndex");
                if (UnFilteredSList.Count > 0)
                {
                    StudentList = DoFilterStudentList(UnFilteredSList);
                }
            }
        }

        private int _searchGenderIndex;

        public int SearchGenderIndex
        {
            get { return _searchGenderIndex; }
            set
            {
                _searchGenderIndex = (value > -1 && value < SearchGender.Length) ? value : -1;
                OnPropertyChanged("SearchGenderIndex");
                if (UnFilteredSList.Count > 0)
                {
                    StudentList = DoFilterStudentList(UnFilteredSList);
                }
            }
        }

        private int _searchSocialCategoryIndex;
        public int SearchSocialCategoryIndex
        {
            get { return _searchSocialCategoryIndex; }
            set
            {
                _searchSocialCategoryIndex = (value > -1 && value < SearchSocialCategory.Length) ? value : -1;
                OnPropertyChanged("SearchSocialCategoryIndex");
                if (UnFilteredSList.Count > 0)
                {
                    StudentList = DoFilterStudentList(UnFilteredSList);
                }
            }
        }

        private int _searchStreamIndex;

        public int SearchStreamIndex
        {
            get { return _searchStreamIndex; }
            set
            {
                _searchStreamIndex = (value > -1 && value < SearchStream.Length) ? value : -1;
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
                    }
                    else if (SearchStream[SearchStreamIndex] == "SCIENCE")
                    {
                        foreach (string item in GlobalVar.HsSciSubs)
                        {
                            ActiveHsSubs.Add(item);
                        }
                    }

                    if (UnFilteredSList.Count > 0)
                    {
                        StudentList = DoFilterStudentList(UnFilteredSList);
                    }
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
                _activeHsSubsIndex = (value > -1 && value < ActiveHsSubs.Count) ? value : -1; ;
                OnPropertyChanged("ActiveHsSubsIndex");
                if (UnFilteredSList.Count > 0)
                {
                    StudentList = DoFilterStudentList(UnFilteredSList);
                }
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

        private string _searchCategory;

        public string SearchCategory
        {
            get { return this._searchCategory; }
            set
            {
                this._searchCategory = value;
                if (value == "cls")
                {
                    this.SearchTextBoxLabel = "Roll ";
                }
                else if (value == "name")
                {
                    this.SearchTextBoxLabel = "Name ";
                }
                else if (value == "aadhar")
                {
                    this.SearchTextBoxLabel = "Aadhaar";
                }
                else if (value == "admissionNo")
                {
                    this.SearchTextBoxLabel = "Admission No.";
                }
                else if (value == "madhyamicRoll")
                {
                    this.SearchTextBoxLabel = "Madhyamic Roll";
                }
                else if (value == "madhyamicNo")
                {
                    this.SearchTextBoxLabel = "Madhyamic No.";
                }
                else
                {
                    this.SearchTextBoxLabel = "Search Text";
                }
                this.ResetSearchEntry();
                this.OnPropertyChanged("SearchCategory");
            }
        }

        private string _filterCategory;

        public string FilterCategory
        {
            get { return this._filterCategory; }
            set
            {
                this._filterCategory = value;
                this.UpdateLeftpaneList();
                this.OnPropertyChanged("FilterCategory");
            }
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

        private int _schoolClassessIndex;

        public int SchoolClassessIndex
        {
            get { return this._schoolClassessIndex; }
            set
            {
                this._schoolClassessIndex = value;

                this.OnPropertyChanged("SchoolClassessIndex");
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
        private string _txbAgeColor;
        public string TxbAgeColor { get { return this._txbAgeColor; } set { this._txbAgeColor = value; this.OnPropertyChanged("TxbAgeColor"); } }

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
        private string _txbFatherColor;
        public string TxbFatherColor { get { return this._txbFatherColor; } set { this._txbFatherColor = value; this.OnPropertyChanged("TxbFatherColor"); } }

        private string _txbMother;
        public string TxbMother { get { return this._txbMother; } set { this._txbMother = value.ToUpper(); this.OnPropertyChanged("TxbMother"); } }
        private string _txbMotherColor;
        public string TxbMotherColor { get { return this._txbMotherColor; } set { this._txbMotherColor = value; this.OnPropertyChanged("TxbMotherColor"); } }

        private string _txbGrd;
        public string TxbGrd { get { return this._txbGrd; } set { this._txbGrd = value.ToUpper(); this.OnPropertyChanged("TxbGrd"); } }
        private string _txbGrdColor;
        public string TxbGrdColor { get { return this._txbGrdColor; } set { this._txbGrdColor = value; this.OnPropertyChanged("TxbGrdColor"); } }

        private string _txbGrdRel;
        public string TxbGrdRel { get { return this._txbGrdRel; } set { this._txbGrdRel = value.ToUpper(); this.OnPropertyChanged("TxbGrdRel"); } }
        private string _txbGrdRelColor;
        public string TxbGrdRelColor { get { return this._txbGrdRelColor; } set { this._txbGrdRelColor = value; this.OnPropertyChanged("TxbGrdRelColor"); } }

        private string _txbGrdOcc;
        public string TxbGrdOcc { get { return this._txbGrdOcc; } set { this._txbGrdOcc = value; this.OnPropertyChanged("TxbGrdOcc"); } }
        private string _txbGrdOccColor;
        public string TxbGrdOccColor { get { return this._txbGrdOccColor; } set { this._txbGrdOccColor = value; this.OnPropertyChanged("TxbGrdOccColor"); } }

        private string _txbGrdAadhar;
        public string TxbGrdAadhar { get { return this._txbGrdAadhar; } set { this._txbGrdAadhar = value; this.OnPropertyChanged("TxbGrdAadhar"); } }
        private string _txbGrdAadharColor;
        public string TxbGrdAadharColor { get { return this._txbGrdAadharColor; } set { this._txbGrdAadharColor = value; this.OnPropertyChanged("TxbGrdAadharColor"); } }

        private string _txbGrdEpic;
        public string TxbGrdEpic { get { return this._txbGrdEpic; } set { this._txbGrdEpic = value; this.OnPropertyChanged("TxbGrdEpic"); } }
        private string _txbGrdEpicColor;
        public string TxbGrdEpicColor { get { return this._txbGrdEpicColor; } set { this._txbGrdEpicColor = value; this.OnPropertyChanged("TxbGrdEpicColor"); } }

        private string _txbAadhar;
        public string TxbAadhar { get { return this._txbAadhar; } set { this._txbAadhar = value; this.OnPropertyChanged("TxbAadhar"); } }
        private string _txbAadharColor;
        public string TxbAadharColor { get { return this._txbAadharColor; } set { this._txbAadharColor = value; this.OnPropertyChanged("TxbAadharColor"); } }

        private string _txbSocCat;
        public string TxbSocCat { get { return this._txbSocCat; } set { this._txbSocCat = value; this.OnPropertyChanged("TxbSocCat"); } }
        private string _txbSocCatColor;
        public string TxbSocCatColor { get { return this._txbSocCatColor; } set { this._txbSocCatColor = value; this.OnPropertyChanged("TxbSocCatColor"); } }

        private string _txbSbCat;
        public string TxbSbCat { get { return this._txbSbCat; } set { this._txbSbCat = value.ToUpper(); this.OnPropertyChanged("TxbSbCat"); } }
        private string _txbSbCatColor;
        public string TxbSbCatColor { get { return this._txbSbCatColor; } set { this._txbSbCatColor = value; this.OnPropertyChanged("TxbSbCatColor"); } }

        private bool _txbIsPh;
        public bool TxbIsPh { get { return this._txbIsPh; } set { this._txbIsPh = value; this.OnPropertyChanged("TxbIsPh"); } }
        private string _txbIsPhColor;
        public string TxbIsPhColor { get { return this._txbIsPhColor; } set { this._txbIsPhColor = value; this.OnPropertyChanged("TxbIsPhColor"); } }

        private string _txbPhType;
        public string TxbPhType { get { return this._txbPhType; } set { this._txbPhType = value; this.OnPropertyChanged("TxbPhType"); } }
        private string _txbPhTypeColor;
        public string TxbPhTypeColor { get { return this._txbPhTypeColor; } set { this._txbPhTypeColor = value; this.OnPropertyChanged("TxbPhTypeColor"); } }

        private bool _stdIsBpl;
        public bool StdIsBpl { get { return this._stdIsBpl; } set { this._stdIsBpl = value; this.OnPropertyChanged("StdIsBpl"); } }
        private string _stdIsBplColor;
        public string StdIsBplColor { get { return this._stdIsBplColor; } set { this._stdIsBplColor = value; this.OnPropertyChanged("StdIsBplColor"); } }

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
        private string _txbBplNoColor;
        public string TxbBplNoColor { get { return this._txbBplNoColor; } set { this._txbBplNoColor = value; this.OnPropertyChanged("TxbBplNoColor"); } }

        private string _txbReligion;
        public string TxbReligion { get { return this._txbReligion; } set { this._txbReligion = value.ToUpper(); this.OnPropertyChanged("TxbReligion"); } }
        private string _txbReligionColor;
        public string TxbReligionColor { get { return this._txbReligionColor; } set { this._txbReligionColor = value; this.OnPropertyChanged("TxbReligionColor"); } }

        public string[] BloodGroups { get; set; }
        private string _bloodGrp;

        public string BloodGrp
        {
            get { return this._bloodGrp; }
            set { this._bloodGrp = value; this.OnPropertyChanged("BloodGrp"); }
        }

        private string _bloodGrpColor;

        public string BloodGrpColor
        {
            get { return this._bloodGrpColor; }
            set { this._bloodGrpColor = value; this.OnPropertyChanged("BloodGrpColor"); }
        }

        #endregion personal

        #region contact

        private string _presentAddr;
        public string PresentAddr { get { return this._presentAddr; } set { this._presentAddr = value; this.OnPropertyChanged("PresentAddr"); } }
        private string _presentAddrColor;
        public string PresentAddrColor { get { return this._presentAddrColor; } set { this._presentAddrColor = value; this.OnPropertyChanged("PresentAddrColor"); } }

        private string _permanentAddr;
        public string PermanentAddr { get { return this._permanentAddr; } set { this._permanentAddr = value; this.OnPropertyChanged("PermanentAddr"); } }
        private string _permanentAddrColor;
        public string PermanentAddrColor { get { return this._permanentAddrColor; } set { this._permanentAddrColor = value; this.OnPropertyChanged("PermanentAddrColor"); } }

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
        private string _txbMobileColor;
        public string TxbMobileColor { get { return this._txbMobileColor; } set { this._txbMobileColor = value; this.OnPropertyChanged("TxbMobileColor"); } }

        private string _grdMobile;
        public string GrdMobile { get { return this._grdMobile; } set { this._grdMobile = value; this.OnPropertyChanged("GrdMobile"); } }
        private string _grdMobileColor;
        public string GrdMobileColor { get { return this._grdMobileColor; } set { this._grdMobileColor = value; this.OnPropertyChanged("GrdMobileColor"); } }

        private string _txbEmail;
        public string TxbEmail { get { return this._txbEmail; } set { this._txbEmail = value; this.OnPropertyChanged("TxbEmail"); } }
        private string _txbEmailColor;
        public string TxbEmailColor { get { return this._txbEmailColor; } set { this._txbEmailColor = value; this.OnPropertyChanged("TxbEmailColor"); } }

        #endregion contact

        #region bank

        private string _bankAcc;
        public string BankAcc { get { return this._bankAcc; } set { this._bankAcc = value; this.OnPropertyChanged("BankAcc"); } }
        private string _bankAccColor;
        public string BankAccColor { get { return this._bankAccColor; } set { this._bankAccColor = value; this.OnPropertyChanged("BankAccColor"); } }

        private string _bankName;
        public string BankName { get { return this._bankName; } set { this._bankName = value; this.OnPropertyChanged("BankName"); } }
        private string _bankNameColor;
        public string BankNameColor { get { return this._bankNameColor; } set { this._bankNameColor = value; this.OnPropertyChanged("BankNameColor"); } }

        private string _bankBranch;
        public string BankBranch { get { return this._bankBranch; } set { this._bankBranch = value; this.OnPropertyChanged("BankBranch"); } }
        private string _bankBranchColor;
        public string BankBranchColor { get { return this._bankBranchColor; } set { this._bankBranchColor = value; this.OnPropertyChanged("BankBranchColor"); } }

        private string _bankIfsc;
        public string BankIfsc { get { return this._bankIfsc; } set { this._bankIfsc = value; this.OnPropertyChanged("BankIfsc"); } }
        private string _bankIfscColor;
        public string BankIfscColor { get { return this._bankIfscColor; } set { this._bankIfscColor = value; this.OnPropertyChanged("BankIfscColor"); } }

        private string _bankMicr;
        public string BankMicr { get { return this._bankMicr; } set { this._bankMicr = value; this.OnPropertyChanged("BankMicr"); } }
        private string _bankMicrColor;
        public string BankMicrColor { get { return this._bankMicrColor; } set { this._bankMicrColor = value; this.OnPropertyChanged("BankMicrColor"); } }

        #endregion bank

        #region Admission

        private string _admissionNo;
        public string AdmissionNo { get { return this._admissionNo; } set { this._admissionNo = value; this.OnPropertyChanged("AdmissionNo"); } }
        private string _admissionNoColor;
        public string AdmissionNoColor { get { return this._admissionNoColor; } set { this._admissionNoColor = value; this.OnPropertyChanged("AdmissionNoColor"); } }

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
        private string _admittedClassColor;
        public string AdmittedClassColor { get { return this._admittedClassColor; } set { this._admittedClassColor = value; this.OnPropertyChanged("AdmittedClassColor"); } }

        private string _lastSchool;
        public string LastSchool { get { return this._lastSchool; } set { this._lastSchool = value; this.OnPropertyChanged("LastSchool"); } }
        private string _lastSchoolColor;
        public string LastSchoolColor { get { return this._lastSchoolColor; } set { this._lastSchoolColor = value; this.OnPropertyChanged("LastSchoolColor"); } }

        /*
        private DateTime _dateOfLeaving;
        public DateTime DateOfLeaving { get { return this._dateOfLeaving; } set { this._dateOfLeaving = value; this.OnPropertyChanged("DateOfLeaving"); } }
        private string _dateOfLeavingColor;
        public string DateOfLeavingColor { get { return this._dateOfLeavingColor; } set { this._dateOfLeavingColor = value; this.OnPropertyChanged("DateOfLeavingColor"); } }
        */

        private string _tc;
        public string Tc { get { return this._tc; } set { this._tc = value; this.OnPropertyChanged("Tc"); } }
        private string _tcColor;
        public string TcColor { get { return this._tcColor; } set { this._tcColor = value; this.OnPropertyChanged("TcColor"); } }

        public string[] ClassesForAdmission { get; set; }

        #endregion Admission

        #region other

        private string _txbMadhyamicRoll;
        public string TxbMadhyamicRoll { get { return this._txbMadhyamicRoll; } set { this._txbMadhyamicRoll = value; this.OnPropertyChanged("TxbMadhyamicRoll"); } }
        private string _txbMadhyamicRollColor;
        public string TxbMadhyamicRollColor { get { return this._txbMadhyamicRollColor; } set { this._txbMadhyamicRollColor = value; this.OnPropertyChanged("TxbMadhyamicRollColor"); } }

        private string _txbMadhyamicNo;
        public string TxbMadhyamicNo { get { return this._txbMadhyamicNo; } set { this._txbMadhyamicNo = value; this.OnPropertyChanged("TxbMadhyamicNo"); } }
        private string _txbMadhyamicNoColor;
        public string TxbMadhyamicNoColor { get { return this._txbMadhyamicNoColor; } set { this._txbMadhyamicNoColor = value; this.OnPropertyChanged("TxbMadhyamicNoColor"); } }

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
        private string _txbCouncilRollColor;
        public string TxbCouncilRollColor { get { return this._txbCouncilRollColor; } set { this._txbCouncilRollColor = value; this.OnPropertyChanged("TxbCouncilRollColor"); } }

        private string _txbCouncilNo;
        public string TxbCouncilNo { get { return this._txbCouncilNo; } set { this._txbCouncilNo = value; this.OnPropertyChanged("TxbCouncilNo"); } }
        private string _txbCouncilNoColor;
        public string TxbCouncilNoColor { get { return this._txbCouncilNoColor; } set { this._txbCouncilNoColor = value; this.OnPropertyChanged("TxbCouncilNoColor"); } }

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
            // get { return System.Windows.Visibility.Visible; }
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

        private int _selecStdSessonStartYear;

        public int SelecStdSessionStartYear
        {
            get { return _selecStdSessonStartYear; }
            set { _selecStdSessonStartYear = value; OnPropertyChanged("SelecStdSessionStartYear"); }
        }

        private int _selecStdSessonEndYear;

        public int SelecStdSessionEndYear
        {
            get { return _selecStdSessonEndYear; }
            set { _selecStdSessonEndYear = value; OnPropertyChanged("SelecStdSessionEndYear"); }
        }

        #region edit

        public string[] SocialCatList { get; set; }

        private string _headerBackground;

        public string HeaderBackground
        {
            get { return this._headerBackground; }
            set { this._headerBackground = value; this.OnPropertyChanged("HeaderBackground"); }
        }

        private string _headerBGgen;

        public string HeaderBGgen
        {
            get { return _headerBGgen; }
            set { this._headerBGgen = value; this.OnPropertyChanged("HeaderBGgen"); }
        }

        private string _headerBGpar;

        public string HeaderBGpar
        {
            get { return _headerBGpar; }
            set { this._headerBGpar = value; this.OnPropertyChanged("HeaderBGpar"); }
        }

        private string _headerBGsoc;

        public string HeaderBGsoc
        {
            get { return _headerBGsoc; }
            set { this._headerBGsoc = value; this.OnPropertyChanged("HeaderBGsoc"); }
        }

        private string _headerBGadd;

        public string HeaderBGadd
        {
            get { return _headerBGadd; }
            set { this._headerBGadd = value; this.OnPropertyChanged("HeaderBGadd"); }
        }

        private string _headerBGbnk;

        public string HeaderBGbnk
        {
            get { return _headerBGbnk; }
            set { this._headerBGbnk = value; this.OnPropertyChanged("HeaderBGbnk"); }
        }

        private string _headerBGadm;

        public string HeaderBGadm
        {
            get { return _headerBGadm; }
            set { this._headerBGadm = value; this.OnPropertyChanged("HeaderBGadm"); }
        }

        private string _headerBGoth;

        public string HeaderBGoth
        {
            get { return _headerBGoth; }
            set { this._headerBGoth = value; this.OnPropertyChanged("HeaderBGoth"); }
        }

        private bool _hitTestGeneral;

        public bool HitTestGeneral
        {
            get { return this._hitTestGeneral; }
            set { this._hitTestGeneral = value; this.OnPropertyChanged("HitTestGeneral"); }
        }

        private bool _isReadOnlyGen;

        public bool IsReadOnlyGen
        {
            get { return this._isReadOnlyGen; }
            set { this._isReadOnlyGen = value; this.OnPropertyChanged("IsReadOnlyGen"); }
        }

        private bool _isReadOnlyPar;

        public bool IsReadOnlyPar
        {
            get { return this._isReadOnlyPar; }
            set { this._isReadOnlyPar = value; this.OnPropertyChanged("IsReadOnlyPar"); }
        }

        private bool _hitTestSoc;

        public bool HitTestSoc
        {
            get { return this._hitTestSoc; }
            set { this._hitTestSoc = value; this.OnPropertyChanged("HitTestSoc"); }
        }

        private bool _isReadOnlySoc;

        public bool IsReadOnlySoc
        {
            get { return this._isReadOnlySoc; }
            set { this._isReadOnlySoc = value; this.OnPropertyChanged("IsReadOnlySoc"); }
        }

        private bool _isReadOnlyAdd;

        public bool IsReadOnlyAdd
        {
            get { return this._isReadOnlyAdd; }
            set { this._isReadOnlyAdd = value; this.OnPropertyChanged("IsReadOnlyAdd"); }
        }

        private bool _isReadOnlyBnk;

        public bool IsReadOnlyBnk
        {
            get { return this._isReadOnlyBnk; }
            set { this._isReadOnlyBnk = value; this.OnPropertyChanged("IsReadOnlyBnk"); }
        }

        private bool _hitTestAdm;

        public bool HitTestAdm
        {
            get { return this._hitTestAdm; }
            set { this._hitTestAdm = value; this.OnPropertyChanged("HitTestAdm"); }
        }

        private bool _isReadOnlyAdm;

        public bool IsReadOnlyAdm
        {
            get { return this._isReadOnlyAdm; }
            set { this._isReadOnlyAdm = value; this.OnPropertyChanged("IsReadOnlyAdm"); }
        }

        private bool _isReadOnlyOth;

        public bool IsReadOnlyOth
        {
            get { return this._isReadOnlyOth; }
            set { this._isReadOnlyOth = value; this.OnPropertyChanged("IsReadOnlyOth"); }
        }

        #endregion edit

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand SaveEditCommand { get; set; }

        public RelayCommand SortByNameCommand { get; set; }
        public RelayCommand SortByClassCommand { get; set; }
        public RelayCommand SortBySectionCommand { get; set; }
        public RelayCommand SortByRollCommand { get; set; }
        public RelayCommand GenUpdateCommand { get; set; }

        #endregion property field

        #region method

        private void StartUpInitializer()
        {
            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            this.SchoolSections = new string[] { "A", "B", "C", "D", "E" };
            this.BloodGroups = new string[] { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };
            this.SocialCatList = new string[] { "GEN", "SC", "ST", "OBC-A", "OBC-B" };
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
            // 0=> student'sName, 1=>ID, 2=>Aadhar, 3=>FatherName, 4=>Village, 5=>SocialCategory
            SearchBy = new string[] { "Student's Name", "Student's ID", "Aadhaar", "Father's Name", "Village", "Social Category" };
            SearchClass = new string[] { "All", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "Undefined" };
            SearchSection = new string[] { "All", "A", "B", "C", "D", "E", "Undefined" };
            SearchGender = new string[] { "All", "M", "F", "Undefined" };
            SearchSocialCategory = new string[] { "All", "GEN", "SC", "ST", "OBC", "OBC-A", "OBC-B", "Undefined" };
            SearchStream = new string[] { "All", "ARTS", "SCIENCE", "Undefined" };
            ActiveHsStream = new ObservableCollection<string>();
            ActiveHsSubs = new ObservableCollection<string>();
            DoSearchFilterIndexToDefault();

            this.SearchCategory = "cls";
            this.SearchTextBoxLabel = "Roll ";
            this.FilterCategory = "none";
            this.SchoolClassessIndex = -1;
            this.SchoolSectionIndex = -1;
            this.SocialCatListIndex = -1;
            this.BloodGroupIndex = -1;
            this.SelectedStudentListIndex = -1;
            this.ClassessForAdmissionIndex = -1;

            /*
            profileImageFolder = ConfigurationManager.AppSettings["profileImageFolder"];
            ProfileImageSource = profileImageFolder + "20140828_142911.jpg";
            */

            this.MakeReadOnly();

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
            this.SearchCommand = new RelayCommand(this.Search, this.CanSearch);

            this.DeleteCommand = new RelayCommand(this.Delete, this.CanDelete);
            this.EditCommand = new RelayCommand(this.Edit, this.CanEdit);
            this.SaveEditCommand = new RelayCommand(this.SaveEdit, this.CanSaveEdit);

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

        private void Search_old()
        {
            //hide the std detail panel
            this.StdDetailVisibility = System.Windows.Visibility.Collapsed;
            //  List<Student> slist = new List<Student>();
            if (this.SearchCategory == "name" || this.SearchCategory == "aadhar" || this.SearchCategory == "admissionNo" || this.SearchCategory == "madhyamicNo" || this.SearchCategory == "madhyamicRoll")
            {
                this.Slist = db.GetStudentList(this.SearchCategory, this.SearchText, StartYear, EndYear);
            }
            else if (this.SearchCategory == "cls")
            {
                //if roll not exist.
                if (string.IsNullOrEmpty(this.SearchText))
                {
                    if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex == -1)
                    {
                        this.Slist = db.GetStudentListByClass(SelectedClass, StartYear, EndYear);
                    }
                    else if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex > -1)
                    {
                        this.Slist = db.GetStudentListByClass(this.SelectedClass, this.SelectedSection, StartYear, EndYear);
                    }
                }
                // if roll exist verify it.
                else
                {
                    int rl;
                    bool bl = Int32.TryParse(this.SearchText, out rl);
                    if (bl)
                    {
                        if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex > -1)
                        {
                            this.Slist = db.GetStudentListByClass(this.SelectedClass, this.SelectedSection, rl, StartYear, EndYear);
                        }
                        else if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex == -1)
                        {
                            this.Slist = db.GetStudentListByClass(this.SelectedClass, rl, StartYear, EndYear);
                        }
                        else if (this.SelectedClassIndex == -1 && this.SelectedSectionIndex == -1)
                        {
                            this.Slist = db.GetStudentListByClass(rl, StartYear, EndYear);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Only digits are allowed in roll number.");
                        return;
                    }
                }
            }

            this.UpdateLeftpaneList();
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
                default:
                    SType = Models.SearchType.Name;
                    break;
            }
            if (SearchByIndex != -1)
            {
                UnFilteredSList = db.GetStudentList(searchParam: SearchParam, sType: SType, startYear: StartYear, endYear: EndYear);
                StudentList = new ObservableCollection<Student>(UnFilteredSList);
            }
        }

        private bool CanSearch()
        {
            return SearchByIndex != -1 && !string.IsNullOrEmpty(SearchParam);
        }

        private bool CanSearch_old()
        {
            bool rs = false;
            if (string.IsNullOrEmpty(this.SearchCategory))
            {
                rs = false;
                return rs;
            }
            else
            {
                switch (this.SearchCategory)
                {
                    case "name":
                        rs = (string.IsNullOrEmpty(this.SearchText)) ? false : true;
                        break;

                    case "aadhar":
                        rs = (string.IsNullOrEmpty(this.SearchText)) ? false : true;
                        break;

                    case "admissionNo":
                        rs = (string.IsNullOrEmpty(this.SearchText)) ? false : true;
                        break;

                    case "cls":
                        int rl;
                        bool bl = Int32.TryParse(this.SearchText, out rl);
                        rs = (this.SelectedClassIndex == -1 && this.SelectedSectionIndex == -1 && !bl) ? false : true;
                        break;

                    case "clsName":
                        rs = ((this.SelectedClassIndex == -1) || (string.IsNullOrEmpty(this.SearchText))) ? false : true;
                        break;

                    case "madhyamicNo":
                        rs = (string.IsNullOrEmpty(this.SearchText)) ? false : true;
                        break;

                    case "madhyamicRoll":
                        rs = (string.IsNullOrEmpty(this.SearchText)) ? false : true;
                        break;

                    default:
                        rs = false;
                        break;
                }
            }
            return rs;
        }

        private void ResetSearchEntry()
        {
            this.SearchText = string.Empty;
            this.Roll = 0;
            this.SelectedClassIndex = -1;
            this.SelectedSectionIndex = -1;
        }

        private void BuildStdDetailView(Student s)
        {
            ProfileImageSource = profImage[Convert.ToInt32(s.Id) % 2];

            this.TxbGen = s.Sex;
            this.TxbName = s.Name;

            this.TxbCls = s.StudyingClass;
            this.SchoolClassessIndex = Array.IndexOf(this.SchoolClasses, s.StudyingClass);
            this.TxbSection = s.Section;
            this.SchoolSectionIndex = Array.IndexOf(this.SchoolSections, s.Section);
            this.TxbRoll = s.Roll;

            ClaSecRoll = TxbCls + "-" + TxbSection + "-" + TxbRoll;

            SelecStdSessionStartYear = s.StartSessionYear;
            SelecStdSessionEndYear = s.EndSessionYear;

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
            this.TxbGrdAadhar = (string.IsNullOrEmpty(s.GuardianAadhar)) ? defaultEntry : s.GuardianAadhar;
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

            this.TxbAadhar = (string.IsNullOrEmpty(s.Aadhar)) ? defaultEntry : s.Aadhar;
            this.TxbAadharColor = (string.IsNullOrEmpty(s.Aadhar)) ? fontcolor0 : fontcolor1;
            this.TxbSocCat = (string.IsNullOrEmpty(s.SocialCategory)) ? defaultEntry : s.SocialCategory;
            this.SocialCatListIndex = Array.IndexOf(this.SocialCatList, s.SocialCategory);
            this.TxbSocCatColor = (string.IsNullOrEmpty(s.SocialCategory)) ? fontcolor0 : fontcolor1;
            this.TxbSbCat = (string.IsNullOrEmpty(s.SubCast)) ? defaultEntry : s.SubCast;
            this.TxbIsPh = s.IsPH;
            IsStudentPH = (s.IsPH) ? "YES" : "NO";
            this.TxbPhType = s.PhType;
            this.StdIsBpl = s.IsBpl;
            IsStudentBPL = (s.IsBpl) ? "YES" : "NO";
            this.TxbBplNo = s.BplNo;
            this.TxbReligion = (string.IsNullOrEmpty(s.Religion)) ? defaultEntry : s.Religion;

            this.PresentAddr = (string.IsNullOrEmpty(s.PresentAdrress)) ? defaultEntry : s.PresentAdrress;
            this.PermanentAddr = (string.IsNullOrEmpty(s.PermanentAddress)) ? defaultEntry : s.PermanentAddress;

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

            this.TxbMobile = (string.IsNullOrEmpty(s.Mobile)) ? defaultEntry : s.Mobile;
            this.GrdMobile = (string.IsNullOrEmpty(s.GuardianMobile)) ? defaultEntry : s.GuardianMobile;
            this.TxbEmail = (string.IsNullOrEmpty(s.Email)) ? defaultEntry : s.Email;

            this.BankAcc = (string.IsNullOrEmpty(s.BankAcc)) ? defaultEntry : s.BankAcc;
            this.BankName = (string.IsNullOrEmpty(s.BankName)) ? defaultEntry : s.BankName;
            this.BankBranch = (string.IsNullOrEmpty(s.BankBranch)) ? defaultEntry : s.BankBranch;
            this.BankIfsc = (string.IsNullOrEmpty(s.Ifsc)) ? defaultEntry : s.Ifsc;
            this.BankMicr = (string.IsNullOrEmpty(s.MICR)) ? defaultEntry : s.MICR;

            this.AdmissionNo = (string.IsNullOrEmpty(s.AdmissionNo)) ? defaultEntry : s.AdmissionNo;

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
            this.TxbMadhyamicNoColor = (string.IsNullOrEmpty(s.BoardNo)) ? fontcolor0 : fontcolor1;
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

        private void Edit()
        {
            // System.Windows.MessageBox.Show("Working");
        }

        private bool CanEdit()
        {
            return (this.SelectedStudentListIndex > -1);
        }

        private void SaveEdit()
        {
            // if dates are valid go ahead or not
            if (!isDatesValid())
            {
                System.Windows.MessageBox.Show("Please check the dates you have selected.");
                return;
            }
            else
            {
                Student EditedStudent = this.BuildNewStudent();
                if (EditedStudent.Roll > 0 && (!string.IsNullOrEmpty(EditedStudent.StudyingClass)) && (!string.IsNullOrEmpty(EditedStudent.Section)))
                {
                    //change the code specially for session
                    int syear = EditedStudent.StartSessionYear;
                    int eyear = EditedStudent.EndSessionYear;
                    string[] rdata = new string[2];
                    rdata = db.IsRollExists(syear, eyear, EditedStudent.StudyingClass, EditedStudent.Section, EditedStudent.Roll, EditedStudent.Id);
                    if (rdata[0] != "0")
                    {
                        string msg = string.Empty;
                        if (rdata[0] == "1")
                        {
                            msg = "This roll no. already assigned to " + rdata[1];
                        }
                        else
                        {
                            msg = "This roll no. already assigned to " + rdata[1] + " and other " + rdata[0].ToString() + " student(s)";
                        }
                        System.Windows.MessageBox.Show("Error msg : " + msg);
                        return;
                    }
                }
                if (db.UpdateStudentInfo(EditedStudent))
                {
                    System.Windows.MessageBox.Show("Saved");
                    this.MakeReadOnly();
                    this.UpdateEditedStd(this.StudentList[this.SelectedStudentListIndex], EditedStudent);
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed :(");
                }
            }
        }

        public bool CanSaveEdit()
        {
            // check for valid date for date of birth and date of admission
            bool allDobdtSelected = (DobDDIndex > 0 && DobMMIndex > 0 && DobYYIndex > 0);
            bool allDoadtSelected = (DoaDDIndex > 0 && DoaMMIndex > 0 && DoaYYIndex > 0);

            bool allDobdtNotSelected = (DobDDIndex == 0 && DobMMIndex == 0 && DobYYIndex == 0);
            bool allDoadtNotSelected = (DoaDDIndex == 0 && DoaMMIndex == 0 && DoaYYIndex == 0);

            bool dtSelectedOrNot = (allDobdtSelected || allDobdtNotSelected) && (allDoadtSelected || allDoadtNotSelected);

            return (SelectedStudentListIndex > -1 && dtSelectedOrNot);
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

        private void UpdateLeftpaneList()
        {
            if (this.Slist.Count > 0)
            {
                ObservableCollection<Student> oslist = new ObservableCollection<Student>(this.Slist);
                this.StudentList.Clear();
                switch (this.FilterCategory)
                {
                    case "none":
                        this.StudentList = oslist;
                        break;

                    case "male":
                        var stdlst = from std in oslist
                                     where std.Sex == "M"
                                     select std;
                        foreach (Student item in stdlst)
                        {
                            this.StudentList.Add(item);
                        }
                        break;

                    case "female":
                        var stdlst2 = from std in oslist
                                      where std.Sex == "F"
                                      select std;
                        foreach (Student item in stdlst2)
                        {
                            this.StudentList.Add(item);
                        }
                        break;

                    default:
                        break;
                }

                this.NumberOfMatches = this.StudentList.Count;
                // this.ResetSearchEntry();
                this.SelectedStudentListIndex = -1;
            }
            else
            {
                this.StudentList.Clear();
                this.NumberOfMatches = 0;
            }
        }

        private Student BuildNewStudent()
        {
            Student ns = new Student();
            ns.Id = this.StudentList[this.SelectedStudentListIndex].Id;
            ns.StartSessionYear = this.StudentList[this.SelectedStudentListIndex].StartSessionYear;
            ns.EndSessionYear = this.StudentList[this.SelectedStudentListIndex].EndSessionYear;

            ns.Name = this.getVal(this.TxbName);
            ns.FatherName = this.getVal(this.TxbFather);
            ns.MotherName = this.getVal(this.TxbMother);
            ns.GuardianName = this.getVal(this.TxbGrd);
            ns.GuardianRelation = this.getVal(this.TxbGrdRel);
            ns.GuardianOccupation = this.getVal(this.TxbGrdOcc);

            ns.Dob = getDate("dob");
            ns.Sex = this.getVal(this.TxbGen);
            ns.BloodGroup = this.getVal(this.BloodGrp);
            ns.Religion = this.getVal(this.TxbReligion);
            // ns.SocialCategory = this.getVal(this.TxbSocCat);
            ns.SocialCategory = (this.SocialCatListIndex > -1) ? this.SocialCatList[this.SocialCatListIndex] : string.Empty;
            ns.SubCast = this.getVal(this.TxbSbCat);
            ns.IsPH = this.TxbIsPh;
            ns.PhType = this.getVal(this.TxbPhType);
            ns.IsBpl = this.StdIsBpl;
            ns.BplNo = this.getVal(this.TxbBplNo);
            ns.BloodGroup = (this.BloodGroupIndex > -1) ? this.BloodGroups[this.BloodGroupIndex] : string.Empty;
            ns.PresentAdrress = this.getVal(this.PresentAddr);
            ns.PermanentAddress = this.getVal(this.PermanentAddr);
            ns.Mobile = this.getVal(this.TxbMobile);
            ns.GuardianMobile = this.getVal(this.GrdMobile);
            ns.Email = this.getVal(this.TxbEmail);
            ns.Aadhar = this.getVal(this.TxbAadhar);
            ns.GuardianAadhar = this.getVal(this.TxbGrdAadhar);
            ns.GuardianEpic = this.getVal(this.TxbGrdEpic);
            ns.BankAcc = this.getVal(this.BankAcc);
            ns.BankName = this.getVal(this.BankName);
            ns.BankBranch = this.getVal(this.BankBranch);
            ns.Ifsc = this.getVal(this.BankIfsc);
            ns.MICR = this.getVal(this.BankMicr);
            //ns.StudyingClass = this.getVal(this.TxbCls);
            ns.StudyingClass = (this.SchoolClassessIndex > -1) ? this.SchoolClasses[this.SchoolClassessIndex] : string.Empty;
            // ns.Section = this.getVal(this.TxbSection);
            ns.Section = (this.SchoolSectionIndex > -1) ? this.SchoolSections[this.SchoolSectionIndex] : string.Empty;
            ns.Roll = this.TxbRoll;

            ns.BoardRoll = this.getVal(this.TxbMadhyamicRoll);
            ns.BoardNo = this.getVal(this.TxbMadhyamicNo);
            ns.CouncilRoll = this.getVal(this.TxbCouncilRoll);
            ns.CouncilNo = this.getVal(this.TxbCouncilNo);
            ns.AdmissionNo = this.getVal(this.AdmissionNo);
            ns.AdmDate = getDate("doa");
            ns.LastSchool = this.getVal(this.LastSchool);
            // ns.AdmittedClass = this.getVal(this.AdmittedClass);
            ns.AdmittedClass = (this.ClassessForAdmissionIndex > -1) ? this.ClassesForAdmission[this.ClassessForAdmissionIndex] : string.Empty;
            //  ns.DateOfLeaving = this.DateOfLeaving;
            ns.TC = this.getVal(this.Tc);

            return ns;
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

        private void UpdateEditedStd(Student taker, Student giver)
        {
            taker.Name = giver.Name;
            taker.StudyingClass = giver.StudyingClass;
            taker.Section = giver.Section;
            taker.Roll = giver.Roll;
            taker.Dob = giver.Dob;
            taker.Sex = giver.Sex;
            taker.FatherName = giver.FatherName;
            taker.MotherName = giver.MotherName;
            taker.GuardianName = giver.GuardianName;
            taker.GuardianRelation = giver.GuardianRelation;
            taker.GuardianAadhar = giver.GuardianAadhar;
            taker.GuardianEpic = giver.GuardianEpic;
            taker.GuardianOccupation = giver.GuardianOccupation;
            taker.BloodGroup = giver.BloodGroup;
            taker.Aadhar = giver.Aadhar;
            taker.SocialCategory = giver.SocialCategory;
            taker.SubCast = giver.SubCast;
            taker.IsPH = giver.IsPH;
            taker.PhType = giver.PhType;
            taker.IsBpl = giver.IsBpl;
            taker.BplNo = giver.BplNo;
            taker.Religion = giver.Religion;
            taker.PresentAdrress = giver.PresentAdrress;
            taker.PermanentAddress = giver.PermanentAddress;
            taker.Mobile = giver.Mobile;
            taker.GuardianMobile = giver.GuardianMobile;
            taker.Email = giver.Email;
            taker.BankAcc = giver.BankAcc;
            taker.BankName = giver.BankName;
            taker.BankBranch = giver.BankBranch;
            taker.Ifsc = giver.Ifsc;
            taker.MICR = giver.MICR;
            taker.AdmissionNo = giver.AdmissionNo;
            taker.AdmDate = giver.AdmDate;
            taker.AdmittedClass = giver.AdmittedClass;
            taker.LastSchool = giver.LastSchool;
            taker.DateOfLeaving = giver.DateOfLeaving;
            taker.TC = giver.TC;
            taker.BoardNo = giver.BoardNo;
            taker.BoardRoll = giver.BoardRoll;
            taker.CouncilNo = giver.CouncilNo;
            taker.CouncilRoll = giver.CouncilRoll;
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

        #region editbtns

        private void MakeReadOnly()
        {
            this.HeaderBGgen = this.HeaderBGpar = this.HeaderBGsoc = this.HeaderBGadd = this.HeaderBGbnk = this.HeaderBGadm = this.HeaderBGoth = "#FFD3EEDD";
            this.HitTestGeneral = false;
            this.IsReadOnlyGen = true;
            this.IsReadOnlyPar = true;

            this.HitTestSoc = false;
            this.IsReadOnlySoc = true;

            this.IsReadOnlyAdd = true;

            this.IsReadOnlyBnk = true;

            this.IsReadOnlyAdm = true;
            this.HitTestAdm = false;

            this.IsReadOnlyOth = true;
        }

        #endregion editbtns

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
        }

        private ObservableCollection<Student> DoFilterStudentList(List<Student> sList)
        {
            List<Student> stdList = new List<Student>(sList);
            ObservableCollection<Student> FilteredList = new ObservableCollection<Student>();
            if (stdList.Count == 0)
            {
                return FilteredList;
            }
            else
            {
                if (SearchClassIndex > 0 && SearchClassIndex < SearchClass.Length)
                {
                    if (SearchClassIndex == SearchClass.Length -1)
                    {
                        stdList.RemoveAll(std => !string.IsNullOrEmpty(std.StudyingClass));
                    }
                    else
                    {
                        stdList.RemoveAll(std => std.StudyingClass != SearchClass[SearchClassIndex]);
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
                        stdList.RemoveAll(std => std.Sex != SearchGender[SearchGenderIndex]);
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
                if (ActiveHsSubsIndex > 0 && ActiveHsSubsIndex < ActiveHsSubs.Count)
                {
                    /*
                    if (ActiveHsSubsIndex == ActiveHsSubs.Count - 1)
                    {
                        stdList.RemoveAll(std => {
                            int cnt = 0;
                            if (!string.IsNullOrEmpty(std.HsSub1))
                            {
                                cnt++;
                            }
                            if (!string.IsNullOrEmpty(std.HsSub2))
                            {
                                cnt++;
                            }
                            if (!string.IsNullOrEmpty(std.HsSub3))
                            {
                                cnt++;
                            }
                            if (!string.IsNullOrEmpty(std.HsAdlSub))
                            {
                                cnt++;
                            }

                            return cnt > 2;
                        });
                    }
                    else
                    {
                        stdList.RemoveAll(std => (std.HsSub1 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsSub2 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsSub3 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsAdlSub != ActiveHsSubs[ActiveHsSubsIndex]));
                    }
                    */
                    stdList.RemoveAll(std => (std.HsSub1 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsSub2 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsSub3 != ActiveHsSubs[ActiveHsSubsIndex] && std.HsAdlSub != ActiveHsSubs[ActiveHsSubsIndex]));
                }
            }
            return FilteredList = new ObservableCollection<Student>(stdList);
        }

        #endregion method
    }
}