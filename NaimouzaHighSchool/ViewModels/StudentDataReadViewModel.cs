using System;
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
            this.StartUpInitializer();
        }

        #region property field
        #region search bar
        private string _searchText;
        public string SearchText
        {
            get { return this._searchText; }
            set { this._searchText = value.ToUpper(); this.OnPropertyChanged("SearchText"); }
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
                this.StdDetailVisibility = (value > -1) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                if (value > -1)
                {
                    this.BuildStdDetailView(this.StudentList[value]);
                    this.SelectedStudent = this.StudentList[value];
                }
                this.OnPropertyChanged("SelectedStudentListIndex");
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

        private string _txbCls;
        public string TxbCls { get { return this._txbCls; } set { this._txbCls = value; this.OnPropertyChanged("TxbCls"); } }

        private string _txbSection;
        public string TxbSection { get { return this._txbSection; } set { this._txbSection = value; this.OnPropertyChanged("TxbSection"); } }

        private string _txbRoll;
        public string TxbRoll { get { return this._txbRoll; } set { this._txbRoll = value; this.OnPropertyChanged("TxbRoll"); } }

        private string _txbGen;
        public string TxbGen { get { return this._txbGen; } set { this._txbGen = value; this.OnPropertyChanged("TxbGen"); } }

        private string _txbDob;
        public string TxbDob { get { return this._txbDob; } set { this._txbDob = value; this.OnPropertyChanged("TxbDob"); } }

        private string _txbAge;
        public string TxbAge { get { return this._txbAge; } set { this._txbAge = value; this.OnPropertyChanged("TxbAge"); } }
        #endregion

        #region personal
        private string _txbFather;
        public string TxbFather { get { return this._txbFather; } set { this._txbFather = value; this.OnPropertyChanged("TxbFather"); } }

        private string _txbMother;
        public string TxbMother { get { return this._txbMother; } set { this._txbMother = value; this.OnPropertyChanged("TxbMother"); } }

        private string _txbGrd;
        public string TxbGrd { get { return this._txbGrd; } set { this._txbGrd = value; this.OnPropertyChanged("TxbGrd"); } }

        private string _txbGrdRel;
        public string TxbGrdRel { get { return this._txbGrdRel; } set { this._txbGrdRel = value; this.OnPropertyChanged("TxbGrdRel"); } }

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
        public string TxbSbCat { get { return this._txbSbCat; } set { this._txbSbCat = value; this.OnPropertyChanged("TxbSbCat"); } }

        private string _txbIsPh;
        public string TxbIsPh { get { return this._txbIsPh; } set { this._txbIsPh = value; this.OnPropertyChanged("TxbIsPh"); } }

        private string _txbPhType;
        public string TxbPhType { get { return this._txbPhType; } set { this._txbPhType = value; this.OnPropertyChanged("TxbPhType"); } }

        private string _txbIsBpl;
        public string TxbIsBpl { get { return this._txbIsBpl; } set { this._txbIsBpl = value; this.OnPropertyChanged("TxbIsBpl"); } }

        private string _txbBplNo;
        public string TxbBplNo { get { return this._txbBplNo; } set { this._txbBplNo = value; this.OnPropertyChanged("TxbBplNo"); } }

        private string _txbReligion;
        public string TxbReligion { get { return this._txbReligion; } set { this._txbReligion = value; this.OnPropertyChanged("TxbReligion"); } }

   
        #endregion

        #region contact
        private string _presentAddr;
        public string PresentAddr { get { return this._presentAddr; } set { this._presentAddr = value; this.OnPropertyChanged("PresentAddr"); } }

        private string _permanentAddr;
        public string PermanentAddr { get { return this._permanentAddr; } set { this._permanentAddr = value; this.OnPropertyChanged("PermanentAddr"); } }

        private string _txbMobile;
        public string TxbMobile { get { return this._txbMobile; } set { this._txbMobile = value; this.OnPropertyChanged("TxbMobile"); } }

        private string _txbEmail;
        public string TxbEmail { get { return this._txbEmail; } set { this._txbEmail = value; this.OnPropertyChanged("TxbEmail"); } }
        #endregion

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

        #endregion
        private System.Windows.Visibility _stdDetailVisibility;
        public System.Windows.Visibility StdDetailVisibility
        {
            get { return this._stdDetailVisibility; }
            set { this._stdDetailVisibility = value; this.OnPropertyChanged("StdDetailVisibility"); }
        }
        #region Admission
        private string _admissionNo;
        public string AdmissionNo { get { return this._admissionNo; } set { this._admissionNo = value; this.OnPropertyChanged("AdmissionNo"); } }

        private string _admissionDate;
        public string AdmissionDate { get { return this._admissionDate; } set { this._admissionDate = value; this.OnPropertyChanged("AdmissionDate"); } }

        private string _admittedClass;
        public string AdmittedClass { get { return this._admittedClass; } set { this._admittedClass = value; this.OnPropertyChanged("AdmittedClass"); } }

        private string _lastSchool;
        public string LastSchool { get { return this._lastSchool; } set { this._lastSchool = value; this.OnPropertyChanged("LastSchool"); } }

        private string _dateOfLeaving;
        public string DateOfLeaving { get { return this._dateOfLeaving; } set { this._dateOfLeaving = value; this.OnPropertyChanged("DateOfLeaving"); } }

        private string _tc;
        public string Tc { get { return this._tc; } set { this._tc = value; this.OnPropertyChanged("Tc"); } } 
        #endregion

        #region other

        #endregion

        #endregion
        private StudentDataReadDb db { get; set; }
        private int _numberOfMatches;
        public int NumberOfMatches
        {
            get { return this._numberOfMatches; }
            set { this._numberOfMatches = value; this.OnPropertyChanged("NumberOfMatches"); }
        }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        #endregion

        #region method
        private void StartUpInitializer()
        {

            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            this.SchoolSections = new string[] { "A", "B", "C", "D", "E"};

            this.Slist = new List<Student>();
            this.StudentList = new ObservableCollection<Student>();
            this.db = new StudentDataReadDb();

            this.SearchCategory = "name";
            this.FilterCategory = "none";
            this.SelectedClassIndex = -1;
            this.SelectedSectionIndex = -1;
            this.SelectedStudentListIndex = -1;

            this.SearchCommand = new RelayCommand(this.Search, this.CanSearch);

            this.DeleteCommand = new RelayCommand(this.Delete, this.CanDelete);
            this.EditCommand = new RelayCommand(this.Edit, this.CanEdit);

            
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
                //search only by class
                if (this.SelectedClassIndex > -1 && this.SelectedSectionIndex == -1 && this.Roll == 0)
                {
                    this.Slist = db.GetStudentListByClass(this.SelectedClass);
                }
                // search by class and section
                else if(this.SelectedClassIndex > -1 && this.SelectedSectionIndex > -1 && this.Roll == 0)
                {
                    this.Slist = db.GetStudentListByClass(this.SelectedClass, this.SelectedSection);
                }
                    // serach by class, section and roll
                else if(this.SelectedClassIndex > -1 && this.SelectedSectionIndex > -1 && this.Roll > 0)
                {
                    this.Slist = db.GetStudentListByClass(this.SelectedClass, this.SelectedSection, this.Roll);
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
            this.TxbName = s.Name;
            this.TxbCls = s.StudyingClass;
            this.TxbSection = s.Section;
            this.TxbRoll = s.Roll.ToString();
            string sdob_temp = s.Dob.ToString("dd-MM-yyyy");
            this.TxbDob = (sdob_temp == "01-01-0001") ? "Not found" : sdob_temp;
            this.TxbGen = (string.IsNullOrEmpty(s.Sex)) ? "Not found" : s.Sex;
            //not implemented yet
            this.TxbAge = "Not implemented yet.";

            this.TxbFather = s.FatherName;
            this.TxbMother = (string.IsNullOrEmpty(s.MotherName)) ? "Not found" : s.MotherName;
            this.TxbGrd = (string.IsNullOrEmpty(s.GuardianName)) ? "Not found" : s.GuardianName;
            this.TxbGrdRel = (string.IsNullOrEmpty(s.GuardianRelation)) ? "Not found" : s.GuardianRelation;
            this.TxbGrdAadhar= (string.IsNullOrEmpty(s.GuardianAadhar)) ? "Not found" : s.GuardianAadhar;
            this.TxbGrdEpic = (string.IsNullOrEmpty(s.GuardianEpic)) ? "Not found" : s.GuardianEpic;
            this.TxbGrdOcc = (string.IsNullOrEmpty(s.GuardianOccupation)) ? "Not found" : s.GuardianOccupation;

            this.TxbAadhar = (string.IsNullOrEmpty(s.Aadhar)) ? "Not found" : s.Aadhar;
            this.TxbSocCat = (string.IsNullOrEmpty(s.SocialCategory)) ? "Not found" : s.SocialCategory;
            this.TxbSbCat = (string.IsNullOrEmpty(s.SubCast)) ? "Not found" : s.SubCast;
            this.TxbIsPh = (s.IsPH) ? "Yes" : "No";
            this.TxbPhType = s.PhType;
            this.TxbIsBpl = (s.IsBpl) ? "Yes" : "No";
            this.TxbBplNo = s.BplNo;
            this.TxbReligion = (string.IsNullOrEmpty(s.Religion)) ? "Not found" : s.Religion;

            this.PresentAddr = (string.IsNullOrEmpty(s.PresentAdrress)) ? "Not found" : s.PresentAdrress;
            this.PermanentAddr = (string.IsNullOrEmpty(s.PermanentAddress)) ? "Not found" : s.PermanentAddress;
            this.TxbMobile = (string.IsNullOrEmpty(s.Mobile)) ? "Not found" : s.Mobile;
            this.TxbEmail = (string.IsNullOrEmpty(s.Email)) ? "Not found" : s.Email;

            this.BankAcc = (string.IsNullOrEmpty(s.BankAcc)) ? "Not found" : s.BankAcc;
            this.BankName = (string.IsNullOrEmpty(s.BankName)) ? "Not found" : s.BankName;
            this.BankBranch = (string.IsNullOrEmpty(s.BankBranch)) ? "Not found" : s.BankBranch;
            this.BankIfsc = (string.IsNullOrEmpty(s.Ifsc)) ? "Not found" : s.Ifsc;
            this.BankMicr = (string.IsNullOrEmpty(s.MICR)) ? "Not found" : s.MICR;

            this.AdmissionNo = (string.IsNullOrEmpty(s.AdmissionNo)) ? "Not found" : s.AdmissionNo;
            string doa_temp = s.AdmDate.ToString("dd-MM-yyyy");
            this.AdmissionDate = (doa_temp == "01-01-0001") ? "Not found" : doa_temp;
            this.AdmittedClass = (string.IsNullOrEmpty(s.AdmittedClass)) ? "Not found" : s.AdmittedClass;
            this.LastSchool = (string.IsNullOrEmpty(s.LastSchool)) ? "Not found" : s.LastSchool;
            string dol_temp = s.DateOfLeaving.ToString("dd-MM-yyyy");
            this.DateOfLeaving = (dol_temp == "01-01-0001") ? "Not found" : dol_temp;
            this.Tc = (string.IsNullOrEmpty(s.TC)) ? "Not found" : s.TC;

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
        
        }

        private bool CanEdit()
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

        #endregion
    }
}
