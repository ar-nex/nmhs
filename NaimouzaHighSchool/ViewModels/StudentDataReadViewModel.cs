using System;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.ViewModels
{
    public class StudentDataReadViewModel : BaseViewModel
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

                System.Windows.MessageBox.Show("nm2 : "+nm2.Message);
            }
        }

        #region property field
        private const string fontcolor1 = "#053646";
        private const string fontcolor0 = "#053646";
        private const string defaultEntry = "";
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
                else if(value == "name")
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
                else if(value == "madhyamicRoll")
                {
                    this.SearchTextBoxLabel = "Madhyamic Roll";
                }
                else if(value == "madhyamicNo")
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



        public RelayCommand SearchCommand { get; set; }
        #endregion

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
                    if (!string.IsNullOrEmpty(this.StudentList[value].SubjectComboId))
                    {
                        this.SetSubjects(this.StudentList[value].SubjectComboId);
                    }
                    // set selectedCombocode
                    foreach (SubjectCombo item in this.ComboCodeList)
                    {
                        if (item.Id == this.StudentList[value].SubjectComboId)
                        {
                            this.SelectedComboCode = item.Code;
                            break;
                        }
                    }
                   
                }
                
            }
        }



        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return this._selectedStudent; }
            set { this._selectedStudent = value; this.OnPropertyChanged("SelectedStudent"); }
        }
        #endregion

        #region stdDetail

        #region gen
        private string _txbName;
        public string TxbName { get { return this._txbName; } set { this._txbName = value; this.OnPropertyChanged("TxbName"); } }
        private string _txbNameColor;
        public string TxbNameColor { get { return this._txbNameColor; } set { this._txbNameColor = value; this.OnPropertyChanged("TxbNameColor"); } }

        private string _txbCls;
        public string TxbCls 
        { 
            get { return this._txbCls; } 
            set 
            { 
                this._txbCls = value;
                if (Array.IndexOf(this.SchoolClasses, value) > -1)
                {
                    var cmbList = from n in this.ComboCodeList
                                  where n.BelongingClass == value
                                  select n.Code;
                    this.FilteredComboCode.Clear();
                    foreach (string item in cmbList)
                    {
                        this.FilteredComboCode.Add(item);
                    }
                    
                }
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

        private int _schoolSectionIndex;
        public int SchoolSectionIndex
        {
            get { return this._schoolSectionIndex; }
            set 
            {
                this._schoolSectionIndex = value;
                this.OnPropertyChanged("SchoolSectionIndex");
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

        private string _txbClsColor;
        public string TxbClsColor { get { return this._txbClsColor; } set { this._txbClsColor = value; this.OnPropertyChanged("TxbClsColor"); } }

        private string _txbSection;
        public string TxbSection { get { return this._txbSection; } set { this._txbSection = value; this.OnPropertyChanged("TxbSection"); } }
        private string _txbSectionColor;
        public string TxbSectionColor { get { return this._txbSectionColor; } set { this._txbSectionColor = value; this.OnPropertyChanged("TxbSectionColor"); } }

        private int _txbRoll;
        public int TxbRoll { get { return this._txbRoll; } set { this._txbRoll = value; this.OnPropertyChanged("TxbRoll"); } }
        private string _txbRollColor;
        public string TxbRollColor { get { return this._txbRollColor; } set { this._txbRollColor = value; this.OnPropertyChanged("TxbRollColor"); } }

        private string _txbGen;
        public string TxbGen 
        { 
            get { return this._txbGen; } 
            set 
            { 
                this._txbGen = value;
                this.OnPropertyChanged("TxbGen"); 
            } 
        }
        
        private string _txbGenColor;
        public string TxbGenColor { get { return this._txbGenColor; } set { this._txbGenColor = value; this.OnPropertyChanged("TxbGenColor"); } }

        private DateTime _dob;
        public DateTime Dob { get { return this._dob; } set { this._dob = value; this.OnPropertyChanged("Dob"); } }
        private string _dobColor;
        public string DobColor { get { return this._dobColor; } set { this._dobColor = value; this.OnPropertyChanged("DobColor"); } }

        private string _txbAge;
        public string TxbAge { get { return this._txbAge; } set { this._txbAge = value; this.OnPropertyChanged("TxbAge"); } }
        private string _txbAgeColor;
        public string TxbAgeColor { get { return this._txbAgeColor; } set { this._txbAgeColor = value; this.OnPropertyChanged("TxbAgeColor"); } }

        private string _txbSubComboId;
        public string TxbSubComboId { get { return this._txbSubComboId; } set { this._txbSubComboId = value; this.OnPropertyChanged("TxbSubComboId"); } }
        private string _txbSubComboIdColor;
        public string TxbSubComboIdColor { get { return this._txbSubComboIdColor; } set { this._txbSubComboIdColor = value; this.OnPropertyChanged("TxbSubComboIdColor"); } }

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

      
        #endregion

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

        private bool _txbIsBpl;
        public bool TxbIsBpl { get { return this._txbIsBpl; } set { this._txbIsBpl = value; this.OnPropertyChanged("TxbIsBpl"); } }
        private string _txbIsBplColor;
        public string TxbIsBplColor { get { return this._txbIsBplColor; } set { this._txbIsBplColor = value; this.OnPropertyChanged("TxbIsBplColor"); } }

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
        #endregion

        #region contact
        private string _presentAddr;
        public string PresentAddr { get { return this._presentAddr; } set { this._presentAddr = value; this.OnPropertyChanged("PresentAddr"); } }
        private string _presentAddrColor;
        public string PresentAddrColor { get { return this._presentAddrColor; } set { this._presentAddrColor = value; this.OnPropertyChanged("PresentAddrColor"); } }

        private string _permanentAddr;
        public string PermanentAddr { get { return this._permanentAddr; } set { this._permanentAddr = value; this.OnPropertyChanged("PermanentAddr"); } }
        private string _permanentAddrColor;
        public string PermanentAddrColor { get { return this._permanentAddrColor; } set { this._permanentAddrColor = value; this.OnPropertyChanged("PermanentAddrColor"); } }

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
        #endregion

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

        #endregion
        private System.Windows.Visibility _stdDetailVisibility;
        public System.Windows.Visibility StdDetailVisibility
        {
            get { return this._stdDetailVisibility; }
           // get { return System.Windows.Visibility.Visible; }
            set { this._stdDetailVisibility = value; this.OnPropertyChanged("StdDetailVisibility"); }
        }
        #region Admission
        private string _admissionNo;
        public string AdmissionNo { get { return this._admissionNo; } set { this._admissionNo = value; this.OnPropertyChanged("AdmissionNo"); } }
        private string _admissionNoColor;
        public string AdmissionNoColor { get { return this._admissionNoColor; } set { this._admissionNoColor = value; this.OnPropertyChanged("AdmissionNoColor"); } }

        private DateTime _admissionDate;
        public DateTime AdmissionDate { get { return this._admissionDate; } set { this._admissionDate = value; this.OnPropertyChanged("AdmissionDate"); } }
        private string _admissionDateColor;
        public string AdmissionDateColor { get { return this._admissionDateColor; } set { this._admissionDateColor = value; this.OnPropertyChanged("AdmissionDateColor"); } }

        private string _admittedClass;
        public string AdmittedClass { get { return this._admittedClass; } set { this._admittedClass = value; this.OnPropertyChanged("AdmittedClass"); } }
        private string _admittedClassColor;
        public string AdmittedClassColor { get { return this._admittedClassColor; } set { this._admittedClassColor = value; this.OnPropertyChanged("AdmittedClassColor"); } }

        private string _lastSchool;
        public string LastSchool { get { return this._lastSchool; } set { this._lastSchool = value; this.OnPropertyChanged("LastSchool"); } }
        private string _lastSchoolColor;
        public string LastSchoolColor { get { return this._lastSchoolColor; } set { this._lastSchoolColor = value; this.OnPropertyChanged("LastSchoolColor"); } }

        private DateTime _dateOfLeaving;
        public DateTime DateOfLeaving { get { return this._dateOfLeaving; } set { this._dateOfLeaving = value; this.OnPropertyChanged("DateOfLeaving"); } }
        private string _dateOfLeavingColor;
        public string DateOfLeavingColor { get { return this._dateOfLeavingColor; } set { this._dateOfLeavingColor = value; this.OnPropertyChanged("DateOfLeavingColor"); } }

        private string _tc;
        public string Tc { get { return this._tc; } set { this._tc = value; this.OnPropertyChanged("Tc"); } }
        private string _tcColor;
        public string TcColor { get { return this._tcColor; } set { this._tcColor = value; this.OnPropertyChanged("TcColor"); } }

        public string[] ClassesForAdmission { get; set; }
        #endregion

        #region other
        private string _txbMadhyamicRoll;
        public string TxbMadhyamicRoll { get { return this._txbMadhyamicRoll; } set { this._txbMadhyamicRoll = value; this.OnPropertyChanged("TxbMadhyamicRoll"); } }
        private string _txbMadhyamicRollColor;
        public string TxbMadhyamicRollColor { get { return this._txbMadhyamicRollColor; } set { this._txbMadhyamicRollColor = value; this.OnPropertyChanged("TxbMadhyamicRollColor"); } }

        private string _txbMadhyamicNo;
        public string TxbMadhyamicNo { get { return this._txbMadhyamicNo; } set { this._txbMadhyamicNo = value; this.OnPropertyChanged("TxbMadhyamicNo"); } }
        private string _txbMadhyamicNoColor;
        public string TxbMadhyamicNoColor { get { return this._txbMadhyamicNoColor; } set { this._txbMadhyamicNoColor = value; this.OnPropertyChanged("TxbMadhyamicNoColor"); } }

        private string _txbCouncilRoll;
        public string TxbCouncilRoll { get { return this._txbCouncilRoll; } set { this._txbCouncilRoll = value; this.OnPropertyChanged("TxbCouncilRoll"); } }
        private string _txbCouncilRollColor;
        public string TxbCouncilRollColor { get { return this._txbCouncilRollColor; } set { this._txbCouncilRollColor = value; this.OnPropertyChanged("TxbCouncilRollColor"); } }

        private string _txbCouncilNo;
        public string TxbCouncilNo { get { return this._txbCouncilNo; } set { this._txbCouncilNo = value; this.OnPropertyChanged("TxbCouncilNo"); } }
        private string _txbCouncilNoColor;
        public string TxbCouncilNoColor { get { return this._txbCouncilNoColor; } set { this._txbCouncilNoColor = value; this.OnPropertyChanged("TxbCouncilNoColor"); } }
        #endregion
       
        #endregion
        private StudentDataReadDb db { get; set; }
        private int _numberOfMatches;
        public int NumberOfMatches
        {
            get { return this._numberOfMatches; }
            set { this._numberOfMatches = value; this.OnPropertyChanged("NumberOfMatches"); }
        }

        #region edit
        public string[] SocialCatList { get; set; }
        public List<SubjectCombo> ComboCodeList { get; set; }

        private ObservableCollection<string> _filteredComboCode;
        public ObservableCollection<string> FilteredComboCode
        {
            get { return this._filteredComboCode; }
            set { this._filteredComboCode = value; this.OnPropertyChanged("FilteredComboCode"); }
        }

        private string _selectedComboCode;
        public string SelectedComboCode
        {
            get { return this._selectedComboCode; }
            set 
            { 
                this._selectedComboCode = value;
                string cmbId = string.Empty;
                foreach (SubjectCombo item in this.ComboCodeList)
                {
                    if (item.Code == value)
                    {
                        cmbId = item.Id;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(cmbId))
                {
                    this.TakenSubjects.Clear();
                    this.SetSubjects(cmbId);
                }
                this.OnPropertyChanged("SelectedComboCode"); 
            }
        }

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
        #endregion

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand SaveEditCommand { get; set; }

        public RelayCommand SortByNameCommand { get; set; }
        public RelayCommand SortByClassCommand { get; set; }
        public RelayCommand SortBySectionCommand { get; set; }
        public RelayCommand SortByRollCommand { get; set; }

        public RelayCommand GenEditBtnCommand { get; set; }
        public RelayCommand ParEditBtnCommand { get; set; }
        public RelayCommand SocEditBtnCommand { get; set; }
        public RelayCommand AddrEditBtnCommand { get; set; }
        public RelayCommand BnkEditBtnCommand { get; set; }
        public RelayCommand AdmEditBtnCommand { get; set; }
        public RelayCommand OthEditBtnCommand { get; set; }
        #endregion

        #region method
        private void StartUpInitializer()
        {

            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            this.SchoolSections = new string[] { "A", "B", "C", "D", "E"};
            this.BloodGroups = new string[] { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };
            this.SocialCatList = new string[] { "GEN", "SC", "ST", "OBC-A", "OBC-B" };
            this.ClassesForAdmission = new string[] { "V", "VI", "VII", "VIII", "IX", "XI" };

            this.Slist = new List<Student>();
            this.StudentList = new ObservableCollection<Student>();
            this.db = new StudentDataReadDb();

            this.SearchCategory = "cls";
            this.SearchTextBoxLabel = "Roll ";
            this.FilterCategory = "none";
            this.SchoolClassessIndex = -1;
            this.SchoolSectionIndex = -1;
            this.SocialCatListIndex = -1;
            this.BloodGroupIndex = -1;
            this.SelectedStudentListIndex = -1;
            this.ClassessForAdmissionIndex = -1;

            this.MakeReadOnly();


            this.ComboCodeList = new List<SubjectCombo>();
            this.ComboCodeList = db.GetComobCodeList();
            this.FilteredComboCode = new ObservableCollection<string>();

            this.TakenSubjects = new ObservableCollection<string>();
            this.ArrayOfSubs = new System.Collections.ArrayList();
            this.SubDictionary = new Dictionary<string, System.Collections.ArrayList>();

            this.CommandInitializer();
           
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

            this.GenEditBtnCommand = new RelayCommand(this.GenEditBtnClicked, this.CanEditBtnClicked);
            this.ParEditBtnCommand = new RelayCommand(this.ParEditBtnClicked, this.CanEditBtnClicked);
            this.SocEditBtnCommand = new RelayCommand(this.SocEditBtnClicked, this.CanEditBtnClicked);
            this.AddrEditBtnCommand = new RelayCommand(this.AddEditBtnClicked, this.CanEditBtnClicked);
            this.BnkEditBtnCommand = new RelayCommand(this.BnkEditBtnClicked, this.CanEditBtnClicked);
            this.AdmEditBtnCommand = new RelayCommand(this.AdmEditBtnClicked, this.CanEditBtnClicked);
            this.OthEditBtnCommand = new RelayCommand(this.OthEditBtnClicked, this.CanEditBtnClicked);
        }

        private void Search()
        {
            //hide the std detail panel
            this.StdDetailVisibility = System.Windows.Visibility.Collapsed;
          //  List<Student> slist = new List<Student>();
            if (this.SearchCategory == "name" || this.SearchCategory == "aadhar" || this.SearchCategory == "admissionNo" || this.SearchCategory == "madhyamicNo" || this.SearchCategory == "madhyamicRoll")
            {
                this.Slist = db.GetStudentList(this.SearchCategory, this.SearchText);
            }
            else if(this.SearchCategory == "cls")
            { 
                
                //if roll not exist.
                if (string.IsNullOrEmpty(this.SearchText))
                {
                    if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex == -1)
                    {
                        this.Slist = db.GetStudentListByClass(this.SelectedClass);
                    }
                    else if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex > -1)
                    {
                        this.Slist = db.GetStudentListByClass(this.SelectedClass, this.SelectedSection);
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
                            this.Slist = db.GetStudentListByClass(this.SelectedClass, this.SelectedSection, rl);
                        }
                        else if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex == -1)
                        {
                            this.Slist = db.GetStudentListByClass(this.SelectedClass, rl);
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

        private bool CanSearch()
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
                        rs = (this.SelectedClassIndex == -1) ? false : true;
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
            this.TxbGen = s.Sex;
            this.TxbName = s.Name;
            
            this.TxbNameColor = fontcolor1;
            this.TxbCls = s.StudyingClass;
            this.SchoolClassessIndex = Array.IndexOf(this.SchoolClasses, s.StudyingClass);
            this.TxbClsColor = fontcolor1;
            this.TxbSection = s.Section;
            this.SchoolSectionIndex = Array.IndexOf(this.SchoolSections, s.Section);
            this.TxbSectionColor = fontcolor1;
            this.TxbRoll = s.Roll;
            this.TxbRollColor = (s.Roll != 0) ? fontcolor1 : fontcolor0; 
            string sdob_temp = s.Dob.ToString("dd-MM-yyyy");
            this.Dob = s.Dob;
            this.DobColor = (sdob_temp == "01-01-0001") ? fontcolor0 : fontcolor1;
           

            this.TxbGenColor = (string.IsNullOrEmpty(s.Sex)) ? fontcolor0 : fontcolor1;
            //not implemented yet
            this.TxbAge = "Not implemented yet.";
            this.TxbAgeColor = (sdob_temp == "01-01-0001") ? fontcolor0 : fontcolor1;

            this.TxbFather = (string.IsNullOrEmpty(s.FatherName)) ? defaultEntry : s.FatherName;
            this.TxbFatherColor = (string.IsNullOrEmpty(s.FatherName)) ? fontcolor0 : fontcolor1;
            this.TxbMother = (string.IsNullOrEmpty(s.MotherName)) ? defaultEntry : s.MotherName;
            this.TxbMotherColor = (string.IsNullOrEmpty(s.MotherName)) ? fontcolor0 : fontcolor1;
            this.TxbGrd = (string.IsNullOrEmpty(s.GuardianName)) ? defaultEntry : s.GuardianName;
            this.TxbGrdColor = (string.IsNullOrEmpty(s.GuardianName)) ? fontcolor0 : fontcolor1;
            this.TxbGrdRel = (string.IsNullOrEmpty(s.GuardianRelation)) ? defaultEntry : s.GuardianRelation;
            this.TxbGrdRelColor = (string.IsNullOrEmpty(s.GuardianRelation)) ? fontcolor0 : fontcolor1;
            this.TxbGrdAadhar= (string.IsNullOrEmpty(s.GuardianAadhar)) ? defaultEntry : s.GuardianAadhar;
            this.TxbGrdAadharColor = (string.IsNullOrEmpty(s.GuardianAadhar)) ? fontcolor0 : fontcolor1;
            this.TxbGrdEpic = (string.IsNullOrEmpty(s.GuardianEpic)) ? defaultEntry : s.GuardianEpic;
            this.TxbGrdEpicColor = (string.IsNullOrEmpty(s.GuardianEpic)) ? fontcolor0 : fontcolor1;
            this.TxbGrdOcc = (string.IsNullOrEmpty(s.GuardianOccupation)) ? defaultEntry : s.GuardianOccupation;
            this.TxbGrdOccColor = (string.IsNullOrEmpty(s.GuardianOccupation)) ? fontcolor0 : fontcolor1;
            this.BloodGrp = (string.IsNullOrEmpty(s.BloodGroup)) ? defaultEntry : s.BloodGroup;
            this.BloodGroupIndex = Array.IndexOf(this.BloodGroups, s.BloodGroup);
            this.BloodGrpColor = (string.IsNullOrEmpty(s.BloodGroup)) ? fontcolor0 : fontcolor1;

            this.TxbAadhar = (string.IsNullOrEmpty(s.Aadhar)) ? defaultEntry : s.Aadhar;
            this.TxbAadharColor = (string.IsNullOrEmpty(s.Aadhar)) ? fontcolor0 : fontcolor1;
            this.TxbSocCat = (string.IsNullOrEmpty(s.SocialCategory)) ? defaultEntry : s.SocialCategory;
            this.SocialCatListIndex = Array.IndexOf(this.SocialCatList, s.SocialCategory);
            this.TxbSocCatColor = (string.IsNullOrEmpty(s.SocialCategory)) ? fontcolor0 : fontcolor1;
            this.TxbSbCat = (string.IsNullOrEmpty(s.SubCast)) ? defaultEntry : s.SubCast;
            this.TxbSbCatColor = (string.IsNullOrEmpty(s.SubCast)) ? fontcolor0 : fontcolor1;
            this.TxbIsPh = s.IsPH;
            this.TxbIsPhColor = fontcolor1;
            this.TxbPhType = s.PhType;
            this.TxbPhTypeColor = fontcolor1;
            this.TxbIsBpl = (s.IsBpl);
            this.TxbIsBplColor = fontcolor1;
            this.TxbBplNo = s.BplNo;
            this.TxbBplNoColor = fontcolor1;
            this.TxbReligion = (string.IsNullOrEmpty(s.Religion)) ? defaultEntry : s.Religion;
            this.TxbReligionColor = (string.IsNullOrEmpty(s.Religion)) ? fontcolor0 : fontcolor1;

            this.PresentAddr = (string.IsNullOrEmpty(s.PresentAdrress)) ? defaultEntry : s.PresentAdrress;
            this.PresentAddrColor = (string.IsNullOrEmpty(s.PresentAdrress)) ? fontcolor0 : fontcolor1;
            this.PermanentAddr = (string.IsNullOrEmpty(s.PermanentAddress)) ? defaultEntry : s.PermanentAddress;
            this.PermanentAddrColor = (string.IsNullOrEmpty(s.PermanentAddress)) ? fontcolor0 : fontcolor1;
            this.TxbMobile = (string.IsNullOrEmpty(s.Mobile)) ? defaultEntry : s.Mobile;
            this.TxbMobileColor = (string.IsNullOrEmpty(s.Mobile)) ? fontcolor0 : fontcolor1;
            this.GrdMobile = (string.IsNullOrEmpty(s.GuardianMobile)) ? defaultEntry : s.GuardianMobile;
            this.GrdMobileColor = (string.IsNullOrEmpty(s.GuardianMobile)) ? fontcolor0 : fontcolor1;
            this.TxbEmail = (string.IsNullOrEmpty(s.Email)) ? defaultEntry : s.Email;
            this.TxbEmailColor = (string.IsNullOrEmpty(s.Email)) ? fontcolor0 : fontcolor1;

            this.BankAcc = (string.IsNullOrEmpty(s.BankAcc)) ? defaultEntry : s.BankAcc;
            this.BankAccColor = (string.IsNullOrEmpty(s.BankAcc)) ? fontcolor0 : fontcolor1;
            this.BankName = (string.IsNullOrEmpty(s.BankName)) ? defaultEntry : s.BankName;
            this.BankNameColor = (string.IsNullOrEmpty(s.BankName)) ? fontcolor0 : fontcolor1;
            this.BankBranch = (string.IsNullOrEmpty(s.BankBranch)) ? defaultEntry : s.BankBranch;
            this.BankBranchColor = (string.IsNullOrEmpty(s.BankBranch)) ? fontcolor0 : fontcolor1;
            this.BankIfsc = (string.IsNullOrEmpty(s.Ifsc)) ? defaultEntry : s.Ifsc;
            this.BankIfscColor = (string.IsNullOrEmpty(s.Ifsc)) ? fontcolor0 : fontcolor1;
            this.BankMicr = (string.IsNullOrEmpty(s.MICR)) ? defaultEntry : s.MICR;
            this.BankMicrColor = (string.IsNullOrEmpty(s.MICR)) ? defaultEntry : fontcolor1;

            this.AdmissionNo = (string.IsNullOrEmpty(s.AdmissionNo)) ? defaultEntry : s.AdmissionNo;
            this.AdmissionNoColor = (string.IsNullOrEmpty(s.AdmissionNo)) ? fontcolor0 : fontcolor1;
            string doa_temp = s.AdmDate.ToString("dd-MM-yyyy");
            this.AdmissionDate = s.AdmDate;
            this.AdmissionDateColor = (doa_temp == "01-01-0001") ? fontcolor0 : fontcolor1;
            this.AdmittedClass = (string.IsNullOrEmpty(s.AdmittedClass)) ? defaultEntry : s.AdmittedClass;
            this.ClassessForAdmissionIndex = Array.IndexOf(this.ClassesForAdmission, s.AdmittedClass);
            this.AdmittedClassColor = (string.IsNullOrEmpty(s.AdmittedClass)) ? fontcolor0 : fontcolor1;
            this.LastSchool = (string.IsNullOrEmpty(s.LastSchool)) ? defaultEntry : s.LastSchool;
            this.LastSchoolColor = (string.IsNullOrEmpty(s.LastSchool)) ? fontcolor0 : fontcolor1;
            string dol_temp = s.DateOfLeaving.ToString("dd-MM-yyyy");
            this.DateOfLeavingColor = (dol_temp == "01-01-0001") ? fontcolor0 : fontcolor1;
            this.DateOfLeaving = s.DateOfLeaving;
            this.Tc = (string.IsNullOrEmpty(s.TC)) ? defaultEntry : s.TC;
            this.TcColor = (string.IsNullOrEmpty(s.TC)) ? fontcolor0 : fontcolor1;

            this.TxbMadhyamicRoll = (string.IsNullOrEmpty(s.BoardRoll)) ? defaultEntry : s.BoardRoll;
            this.TxbMadhyamicRollColor = (string.IsNullOrEmpty(s.BoardRoll)) ? fontcolor0 : fontcolor1;
            this.TxbMadhyamicNo = (string.IsNullOrEmpty(s.BoardNo)) ? defaultEntry : s.BoardNo;
            this.TxbMadhyamicNoColor = (string.IsNullOrEmpty(s.BoardNo)) ? fontcolor0 : fontcolor1;
            this.TxbCouncilRoll = (string.IsNullOrEmpty(s.CouncilRoll)) ? defaultEntry : s.CouncilRoll;
            this.TxbCouncilRollColor = (string.IsNullOrEmpty(s.CouncilRoll)) ? fontcolor0 : fontcolor1;
            this.TxbCouncilNo = (string.IsNullOrEmpty(s.CouncilNo)) ? defaultEntry : s.CouncilNo;
            this.TxbCouncilNoColor = (string.IsNullOrEmpty(s.CouncilNo)) ? fontcolor0 : fontcolor1;         

        }

        private void Delete()
        {
            System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Delete "+this.SelectedStudent.Name+"?", "", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
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
            Student EditedStudent = this.BuildNewStudent();
            if (EditedStudent.Roll > 0 && (!string.IsNullOrEmpty(EditedStudent.StudyingClass)) && (!string.IsNullOrEmpty(EditedStudent.Section)))
            {
                //change the code specially for session
                int syear = DateTime.Today.Year;
                int eyear = DateTime.Today.Year;
                string [] rdata = new string[2];
                rdata = db.IsRollExists(syear, eyear, EditedStudent.StudyingClass, EditedStudent.Section, EditedStudent.Roll, EditedStudent.Id);
                if (rdata[0] != "0")
                {
                    string msg = string.Empty;
                    if (rdata[0] == "1")
                    {
                        msg = "This roll no. already assigned to "+rdata[1];
                    }
                    else
                    {
                        msg = "This roll no. already assigned to " + rdata[1] + " and other " + rdata[0].ToString() + " student(s)";
                    }
                    System.Windows.MessageBox.Show("Error msg : "+msg);
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

        public bool CanSaveEdit()
        {
            return (this.SelectedStudentListIndex > -1);
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
                this.ResetSearchEntry();
                this.SelectedStudentListIndex = -1;
            }
            else
            {
                this.StudentList.Clear();
                this.NumberOfMatches = 0;
            }
        
        }

        private void SetSubjects(string comboId)
        {
            if (this.SubDictionary.ContainsKey(comboId))
            {
                this.ArrayOfSubs = this.SubDictionary[comboId];
            }
            else
            {
                try
                {
                    this.ArrayOfSubs = this.db.GetComboSubjects(comboId);
                    
                    this.SubDictionary.Add(comboId, this.ArrayOfSubs);
                }
                catch (Exception ex4)
                {
                    System.Windows.MessageBox.Show("ex4 : "+ex4.ToString());
                }
            }
            if (this.ArrayOfSubs.Count > 0)
            {
                foreach (string item in this.ArrayOfSubs)
                {
                    this.TakenSubjects.Add(item);
                }
            }
        }

        private Student BuildNewStudent()
        {
            Student ns = new Student();
            ns.Id = this.StudentList[this.SelectedStudentListIndex].Id;

            ns.Name = this.getVal(this.TxbName);
            ns.FatherName = this.getVal(this.TxbFather);
            ns.MotherName = this.getVal(this.TxbMother);
            ns.GuardianName = this.getVal(this.TxbGrd);
            ns.GuardianRelation = this.getVal(this.TxbGrdRel);
            ns.GuardianOccupation = this.getVal(this.TxbGrdOcc);
            ns.Dob = this.Dob;
            ns.Sex = this.getVal(this.TxbGen);
            ns.BloodGroup = this.getVal(this.BloodGrp);
            ns.Religion = this.getVal(this.TxbReligion);
           // ns.SocialCategory = this.getVal(this.TxbSocCat);
            ns.SocialCategory =(this.SocialCatListIndex > -1) ? this.SocialCatList[this.SocialCatListIndex] : string.Empty;
            ns.SubCast = this.getVal(this.TxbSbCat);
            ns.IsPH = this.TxbIsPh;
            ns.PhType = this.getVal(this.TxbPhType);
            ns.IsBpl = this.TxbIsBpl;
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
            //ns.SubjectComboId
            foreach (SubjectCombo item in this.ComboCodeList)
            {
                if (item.Code == this.SelectedComboCode)
                {
                    ns.SubjectComboId = item.Id;
                    break;
                }
            }
            
            ns.BoardRoll = this.getVal(this.TxbMadhyamicRoll);
            ns.BoardNo = this.getVal(this.TxbMadhyamicNo);
            ns.CouncilRoll = this.getVal(this.TxbCouncilRoll);
            ns.CouncilNo = this.getVal(this.TxbCouncilNo);
            ns.AdmissionNo = this.getVal(this.AdmissionNo);
            ns.AdmDate = this.AdmissionDate;
            ns.LastSchool = this.getVal(this.LastSchool);
           // ns.AdmittedClass = this.getVal(this.AdmittedClass);
            ns.AdmittedClass = (this.ClassessForAdmissionIndex > -1) ? this.ClassesForAdmission[this.ClassessForAdmissionIndex] : string.Empty;
            ns.DateOfLeaving = this.DateOfLeaving;
            ns.TC = this.getVal(this.Tc);
            
            return ns;
        }

        private string getVal(string valInp)
        {
            return (valInp == defaultEntry || valInp == defaultEntry.ToUpper()) ? string.Empty : valInp;
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
        #endregion

        #region editbtns
        private void GenEditBtnClicked()
        {
            this.HitTestGeneral = true;
            this.HeaderBGgen = "#f22550";
            this.IsReadOnlyGen = false;
        }

        private void ParEditBtnClicked()
        {
            this.IsReadOnlyPar = false;
            this.HeaderBGpar = "#f22550";
        }

        private void SocEditBtnClicked()
        {
            this.IsReadOnlySoc = false;
            this.HeaderBGsoc = "#f22550";
            this.HitTestSoc = true;
        }

        private void AddEditBtnClicked()
        {
            this.IsReadOnlyAdd = false;
            this.HeaderBGadd = "#f22550";
        }

        private void BnkEditBtnClicked()
        {
            this.IsReadOnlyBnk = false;
            this.HeaderBGbnk = "#f22550";
        }

        private void AdmEditBtnClicked()
        {
            this.IsReadOnlyAdm = false;
            this.HeaderBGadm = "#f22550";
            this.HitTestAdm = true;
        }

        private void OthEditBtnClicked()
        {
            this.IsReadOnlyOth = false;
            this.HeaderBGoth = "#f22550";
        }

        private bool CanEditBtnClicked()
        {
            return true;
        }

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
        #endregion
        #endregion
    }
}
