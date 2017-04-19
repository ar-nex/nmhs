using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.ViewModels.Helpers;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;

using MigraModel = MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

using System.Windows;

namespace NaimouzaHighSchool.ViewModels
{
    public class CharacterCertificateViewModel : BaseViewModel
    {
        public CharacterCertificateViewModel()
            : base()
        {
            this.GenerateCertificateCommand = new RelayCommand(GenerateCertificate, CanGenerateCertificate);
            this.GetStudentDataCommand = new RelayCommand(this.GetBtnClicked, this.CanGetBtnClicked);
            this.ResetCommand = new RelayCommand(this.Reset, this.CanReset);

            this.CertifHelper = new CertificateHelper();
            this.Session = DateTime.Today.Year.ToString();
            this.SessionEnd = DateTime.Today.Year.ToString();
            this.InitializeStartUpVisibility();
            this.InitializeStartUpComboList();
            this.IncludeHeader = true;
            this.SelectedSectionIndex = -1;
            this.SelectedClassIndex = -1;
            this.SearchTypeIndex = -1;
            this.GenderIndex = -1;
            this.GetBtnContent = "?";
            this.PreviewText = string.Empty;
            this.Slist = new List<string[]>();

        }

        #region fields
        private Visibility _visibilityAddhoc;
        private Visibility _visibilityUniqueIndividual;
        private Visibility _visibilityBulk;
        private List<string> _searchType;

        private CertificateHelper CertifHelper { get; set; }
        private string _selectedSearchType;
        private bool _includeHeader;

        private string _stdName;
        private string _fatherName;
        private string _vill;
        private string _po;
        private string _ps;
        private string _dist;
        private string _pin;
        private string _stdGender;
        private string _selectedClass;
        private string _selectedSection;
        private string _roll;
        private string _session;
        private string _dob;
        private int _totalStudent;

        private string _admNo;
        private int _admYear;
        private List<string[]> _slist;

        #endregion

        #region property
        public Visibility VisibilityAddhoc
        {
            get { return _visibilityAddhoc; }
            set { _visibilityAddhoc = value; this.OnPropertyChanged("VisibilityAddhoc"); }
        }
        public Visibility VisibilityUniqueIndividual
        {
            get { return _visibilityUniqueIndividual; }
            set { _visibilityUniqueIndividual = value; this.OnPropertyChanged("VisibilityUniqueIndividual"); }
        }
        public Visibility VisibilityBulk
        {
            get { return _visibilityBulk; }
            set { _visibilityBulk = value; this.OnPropertyChanged("VisibilityBulk"); }
        }
        public List<string> SearchType
        {
            get { return _searchType; }
            set { _searchType = value; this.OnPropertyChanged("SearchType"); }
        }

        public bool IncludeHeader
        {
            get { return _includeHeader; }
            set { _includeHeader = value; this.OnPropertyChanged("IncludeHeader"); }
        }


        private int _seachTypeIndex;
        public int SearchTypeIndex
        {
            get { return this._seachTypeIndex; }
            set 
            {
                this._seachTypeIndex = value;
                this.SelectedSearchType = (value > -1) ? this.SearchType[value] : string.Empty;
                this.Reset();
                this.OnPropertyChanged("SearchTypeIndex");
            }
        }
        private int _searchTypeFlag = 0;

        public string SelectedSearchType
        {
            get { return _selectedSearchType; }
            set 
            {
                _selectedSearchType = value;
                switch (value)
                {
                    case "Add hoc":
                        this.VisibilityUniqueIndividual = Visibility.Collapsed;
                        this.VisibilityBulk = Visibility.Collapsed;
                        this.VisibilityAddhoc = Visibility.Visible;
                        this._searchTypeFlag = 1;
                        this.GetBtnContent = "Preview";
                        break;
                    case "By Class, Section and Roll":
                        this.VisibilityBulk = Visibility.Collapsed;
                        this.VisibilityAddhoc = Visibility.Collapsed;
                        this.VisibilityUniqueIndividual = Visibility.Visible;
                        this._searchTypeFlag = 2;
                        this.GetBtnContent = "Get";
                        break;

                    case "Bulk":
                        this.VisibilityUniqueIndividual = Visibility.Collapsed;
                        this.VisibilityAddhoc = Visibility.Collapsed;
                        this.VisibilityBulk = Visibility.Visible;
                        this.GetBtnContent = "Get";
                        this._searchTypeFlag = 3;
                        break;
                    default:
                        this._searchTypeFlag = 0;
                        break;
                }
                this.OnPropertyChanged("SelectedSearchType");
            }
        }
        public List<string> VillList { get; set; }
        public List<string> POList { get; set; }
        public List<string> PSList { get; set; }
        public List<string> DistList { get; set; }
        public List<string> PinList { get; set; }
        public List<string> Gender { get; set; }
        public List<string> SchoolClass { get; set; }
        public List<string> SchoolSection { get; set; }

        public List<string[]> Slist
        {
            get { return this._slist; }
            set { this._slist = value; this.OnPropertyChanged("Slist"); }
        }

        public string StdName
        {
            get { return _stdName; }
            set 
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _stdName = ti.ToTitleCase(value);
                }
                else
                {
                    _stdName = value;
                }
                this.OnPropertyChanged("StdName");
            }
        }

        public string FatherName
        {
            get { return _fatherName; }
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _fatherName = ti.ToTitleCase(value);
                }
                else
                {
                    _fatherName = value;
                }
                this.OnPropertyChanged("FatherName");
            }
        }

        public string Vill
        {
            get { return _vill; }
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _vill = ti.ToTitleCase(value);
                }
                else
                {
                    _vill = value;
                }
                this.OnPropertyChanged("Vill");
            }
        }
        public string PO
        {
            get { return _po; }
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _po = ti.ToTitleCase(value);
                }
                else
                {
                    _po = value;
                }
                this.OnPropertyChanged("PO");
            }
        }
        public string Ps
        {
            get { return _ps; }
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _ps = ti.ToTitleCase(value);
                }
                else
                {
                    _ps = value;
                }
                this.OnPropertyChanged("Ps");
            }
        }
        public string Dist
        {
            get { return _dist; }
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _dist = ti.ToTitleCase(value);
                }
                else
                {
                    _dist = value;
                }
                this.OnPropertyChanged("Dist");
            }
        }
        public string Pin
        {
            get { return _pin; }
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                if (!String.IsNullOrEmpty(value))
                {
                    _pin = ti.ToTitleCase(value);
                }
                else
                {
                    _pin = value;
                }
                this.OnPropertyChanged("Pin");
            }
        }

        public string StdGender
        {
            get { return _stdGender; }
            set
            {
                _stdGender = value;
                this.OnPropertyChanged("StdGender");
            }
        }

        private int _genderIndex;
        public int GenderIndex
        {
            get { return this._genderIndex; }
            set
            {
                this._genderIndex = value;
                this.StdGender = (value > -1) ? this.Gender[value] : string.Empty;
                this.OnPropertyChanged("GenderIndex");
            }
        }
        public string SelectedClass
        {
            get { return _selectedClass; }
            set { _selectedClass = value; this.OnPropertyChanged("SelectedClass"); }
        }
        public string SelectedSection
        {
            get { return _selectedSection; }
            set { _selectedSection = value; this.OnPropertyChanged("SelectedSection"); }
        }

        public string Roll
        {
            get { return _roll; }
            set { _roll = value; this.OnPropertyChanged("Roll"); }
        }

        public int TotalStudent
        {
            get { return this._totalStudent; }
            set { this._totalStudent = value; this.OnPropertyChanged("TotalStudent"); }
        }



        public string Session
        {
            get { return _session; }
            set { _session = value; this.OnPropertyChanged("Session"); }
        }

        private string _getBtnContent;
        public string GetBtnContent
        {
            get { return this._getBtnContent; }
            set { this._getBtnContent = value; this.OnPropertyChanged("GetBtnContent"); }
        }
        public string Dob
        {
            get { return _dob; }
            set { _dob = value; this.OnPropertyChanged("Dob"); }
        }

        private string _address;
        public string Address
        {
            get { return this._address; }
            set
            {
                this._address = value;
                if (!string.IsNullOrEmpty(value) && (this.SelectedClassIndex > -1) && (this.SelectedSectionIndex > -1))
                {
                    this.BuildPreview();
                }
                this.OnPropertyChanged("Address");
            }
        }

        private string _sessionEnd;
        public string SessionEnd
        {
            get { return this._sessionEnd; }
            set
            {
                this._sessionEnd = value;
                this.OnPropertyChanged("SessionEnd");
            }
            
        }

        private int _selectedClassIndex;
        public int SelectedClassIndex
        {
            get { return this._selectedClassIndex; }
            set
            {
                this._selectedClassIndex = value;
                this.SelectedClass = (value > -1) ? this.SchoolClass[value] : string.Empty;
                this.OnPropertyChanged("SelectedClassIndex");
            }
        }

        private int _selectedSectionIndex;
        public int SelectedSectionIndex
        {
            get { return this._selectedSectionIndex; }
            set 
            {
                this._selectedSectionIndex = value;
                this.SelectedSection = (value > -1) ? this.SchoolSection[value] : string.Empty;
                this.OnPropertyChanged("SelectedSectionIndex");
            }
        }

        private string _previewText;
        public string PreviewText
        {
            get { return this._previewText; }
            set { this._previewText = value; this.OnPropertyChanged("PreviewText"); }
        }
        public RelayCommand GenerateCertificateCommand { get; set; }
        public RelayCommand GetStudentDataCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        #endregion



        #region method
        public void GenerateCertificate()
        {
            switch (this._searchTypeFlag)
            {
                case 1:
                    string[] certificateData = new string[5];
                    char[] seps = { '\n'};
                    string[] data_temp = this.PreviewText.Split(seps);
                    for (int i = 0; i < data_temp.Length; i++)
                    {
                        certificateData [i] = data_temp[i];
                    }
                    certificateData[4] = this.StdName;

                    try
                    {
                        CertifHelper.CreateCharacterCertificatePDF(certificateData, "NIL", 0);
                        this.Reset();
                    }
                    catch (Exception em)
                    {
                        System.Windows.MessageBox.Show(em.Message);
                    }
                    break;
                
                case 2 :
                    string[] certificateData2 = new string[5];
                    char[] seps2 = { '\n'};
                    string[] data_temp2 = this.PreviewText.Split(seps2);
                    for (int i = 0; i < data_temp2.Length; i++)
                    {
                        certificateData2 [i] = data_temp2[i];
                    }
                    certificateData2[4] = this.StdName;
                    try
                    {                       
                        CertifHelper.CreateCharacterCertificatePDF(certificateData2, this._admNo, this._admYear);
                        this.Reset();
                    }
                    catch (Exception em)
                    {
                        System.Windows.MessageBox.Show(em.Message);
                    }

                    break;

                case 3:
                    try
                    {
                        CertifHelper.CreateCharacterCertificatePDF(this.Slist, this.SelectedClass+this.SelectedSection);
                    }
                    catch (Exception ex7)
                    {
                        MessageBox.Show("ex7 : "+ex7.Message);
                    }
                    
                    break;

                default:
                    break;
            }
           

        }

        public bool CanGenerateCertificate()
        {
            bool r = false;
            switch (this._searchTypeFlag)
            {
                case 1:
                    r = (string.IsNullOrEmpty(this.StdName) || string.IsNullOrEmpty(this.FatherName) || string.IsNullOrEmpty(this.Vill) || string.IsNullOrEmpty(this.PO) || string.IsNullOrEmpty(this.Ps) || string.IsNullOrEmpty(this.Dist) || string.IsNullOrEmpty(this.Pin) || string.IsNullOrEmpty(this.StdGender) || string.IsNullOrEmpty(this.Dob) || string.IsNullOrEmpty(this.Roll) || (this.SelectedClassIndex == -1) || (this.SelectedSectionIndex == -1) || (string.IsNullOrEmpty(this.Session)) || (string.IsNullOrEmpty(this.SessionEnd))) ? false : true;
                    break;
                case 2:
                    r = (string.IsNullOrEmpty(this.Roll) || (this.SelectedClassIndex == -1) || (this.SelectedSectionIndex == -1) || (string.IsNullOrEmpty(this.Session)) || (string.IsNullOrEmpty(this.SessionEnd))) ? false : true;
                    break;
                case 3:
                    r = this.TotalStudent > 0;
                    break;
                default:
                    r = false;
                    break;
            }
            return r;
        }
        private void InitializeStartUpVisibility()
        {
            this.VisibilityAddhoc = Visibility.Collapsed;
            this.VisibilityUniqueIndividual = Visibility.Collapsed;
            this.VisibilityBulk = Visibility.Collapsed;
        }
        private void InitializeStartUpComboList()
        {
            this.SearchType = new List<string>();
            this.SearchType.Add("Add hoc");
            this.SearchType.Add("By Class, Section and Roll");
            this.SearchType.Add("Bulk");

            this.VillList = new List<string>();
            VillList.Add("Bakharpur");
            VillList.Add("Bamongram");
            VillList.Add("Chamagram");
            VillList.Add("Chaspara");
            VillList.Add("Goyeshbari");
            VillList.Add("Harugram");
            VillList.Add("Jalalpur");
            VillList.Add("Mosimpur");
            VillList.Add("Nazirpur");
            VillList.Add("Paharpur");
            VillList.Add("Sujapur");

            this.POList = new List<string>();
            POList.Add("Bakharpur");
            POList.Add("Bamongram");
            POList.Add("Chaspara");
            POList.Add("Chhoto Sujapur");
            POList.Add("Fatehkhani");
            POList.Add("Gayeshbari");
            POList.Add("Jalalpur");
            POList.Add("Mosimpur");
            POList.Add("Sujapur");

            this.PSList = new List<string>();
            PSList.Add("Kaliachak");

            this.DistList = new List<string>();
            DistList.Add("Malda");

            this.PinList = new List<string>();
            PinList.Add("732206");

            this.Gender = new List<string>();
            Gender.Add("Boy");
            Gender.Add("Girl");

            this.SchoolClass = new List<string>();
            SchoolClass.Add("V");
            SchoolClass.Add("VI");
            SchoolClass.Add("VII");
            SchoolClass.Add("VIII");
            SchoolClass.Add("IX");
            SchoolClass.Add("X");
            SchoolClass.Add("XI");
            SchoolClass.Add("XII");

            this.SchoolSection = new List<string>();
            SchoolSection.Add("A");
            SchoolSection.Add("B");
            SchoolSection.Add("C");
            SchoolSection.Add("D");
            SchoolSection.Add("E");
        }

        private void GetBtnClicked()
        {
            switch (this._searchTypeFlag)
            {
                case 1:
                    this.BuildPreview();
                    break;

                case 2:
                    string[] searchData = new string[] { this.SelectedClass, this.SelectedSection, this.Roll, this.Session, this.SessionEnd};
                    CharacterCertificateDb db = new CharacterCertificateDb();
                    Student s = db.GetData(searchData);
                    if (string.IsNullOrEmpty(s.Name))
                    {
                        MessageBox.Show("No such student found.");
                        return;
                    }
                    else
                    {
                        this.StdName = s.Name;
                        this.FatherName = s.FatherName;
                        this.Address = s.PresentAdrress;
                        if (s.Sex == "M")
                        {
                            this.GenderIndex = 0;
                        }
                        else if (s.Sex == "F")
                        {
                            this.GenderIndex = 1;
                        }
                        else
                        {
                            this.GenderIndex = -1;
                        }
                        this.Dob = s.Dob.ToString("dd-MM-yyyy");
                        this._admNo = string.IsNullOrEmpty(s.AdmissionNo) ? "NIL" : s.AdmissionNo;
                        this._admYear = (s.AdmDate.Year == 1) ? 0 : s.AdmDate.Year;
                        this.BuildPreview();      
                     }
                    break;
                case 3:
                    string[] searchData3 = new string[] { this.SelectedClass, this.SelectedSection, this.Session, this.SessionEnd};
                    CharacterCertificateDb db3 = new CharacterCertificateDb();
                    this.Slist.Clear();
                    this.Slist = db3.GetDataList(searchData3);
                    this.Slist = this.GenerateChrData(this.Slist);
                    this.TotalStudent = this.Slist.Count();
                    break;
                default:
                    break;
            }
           
        }

        private bool CanGetBtnClicked()
        {
            bool r = false;
            switch (this._searchTypeFlag)
            {
                case 1:
                    r = (string.IsNullOrEmpty(this.StdName) || string.IsNullOrEmpty(this.FatherName) || string.IsNullOrEmpty(this.Vill) || string.IsNullOrEmpty(this.PO) || string.IsNullOrEmpty(this.Ps) || string.IsNullOrEmpty(this.Dist) || string.IsNullOrEmpty(this.Pin) || string.IsNullOrEmpty(this.StdGender) || string.IsNullOrEmpty(this.Dob) || string.IsNullOrEmpty(this.Roll) || (this.SelectedClassIndex == -1) || (this.SelectedSectionIndex == -1) || (string.IsNullOrEmpty(this.Session)) || (string.IsNullOrEmpty(this.SessionEnd))) ? false : true;
                    break;
                case 2:
                    r = (string.IsNullOrEmpty(this.Roll) || (this.SelectedClassIndex == -1) || (this.SelectedSectionIndex == -1) || (string.IsNullOrEmpty(this.Session)) || (string.IsNullOrEmpty(this.SessionEnd))) ? false : true;
                    break;
                case 3:
                    r = (this.SelectedClassIndex == -1) || (this.SelectedSectionIndex == -1) || (string.IsNullOrEmpty(this.Session)) || (string.IsNullOrEmpty(this.SessionEnd)) ? false : true;
                    break;
                default:
                    r = false;
                    break;
            }
            return r;
        }

        private void BuildPreview()
        {
            string xchild = (this.StdGender == "Boy") ? "son" : "daughter";
            string xhe = (this.StdGender == "Boy") ? "he" : "she";
            string Xhe = (this.StdGender == "Boy") ? "He" : "She";
            string Hir = (this.StdGender == "Boy") ? "His" : "Her";
            string hir = (this.StdGender == "Boy") ? "his" : "her";

            int currentYear = DateTime.Today.Year;
            int sessStart = 0;
            int sessEnd = 0;
            try 
	            {	        
		             sessStart = Int32.Parse(this.Session);
                     sessEnd = Int32.Parse(this.SessionEnd);
	            }
	            catch (Exception year)
	            {
		            MessageBox.Show("Year conversion : "+year.Message); 
	            }
            string wis = (sessStart == currentYear || sessEnd == currentYear) ? "is" : "was";
            string preview1 = string.Empty;
            if (this._searchTypeFlag == 1)
            {
                preview1 = "  This is to certify that " + this.StdName + ", " + xchild + " of " + this.FatherName + ", Vill. " + this.Vill + ", P.O. " + this.PO + ", P.S. " + this.Ps + ", Dist. " + this.Dist + ", PIN-" + this.Pin + ", is personally known to me.";
            }
            else if(this._searchTypeFlag == 2)
            {
                preview1 = "  This is to certify that " + this.StdName + ", " + xchild + " of " + this.FatherName + ", " + this.Address + ", is personally known to me.";
            }
            string preview2 = Xhe + " comes of a respectable family. " + Xhe + " " + wis + " reading in Class " + this.SelectedClass + ", Sec. " + this.SelectedSection + ", Roll " + this.Roll + ", Session " + this.Session + "-"+this.SessionEnd+".";
            string preview3 = Hir + " date of birth as per School records is " + this.Dob + ".";
            string preview4 = "So far I know, " + xhe + " bears a good moral character. I wish " + hir + " every success in life.";
            this.PreviewText = preview1 + "\n  " + preview2 + "\n  " + preview3 + "\n  "+preview4;
        }

        private List<string[]> GenerateChrData(List<string[]> slist)
        {
            List<string[]> rSlist = new List<string[]>();
            foreach (string[] item in slist)
            {
                string xchild = (item[2] == "M") ? "son" : "daughter";
                string xhe = (item[2] == "M") ? "he" : "she";
                string Xhe = (item[2] == "M") ? "He" : "She";
                string Hir = (item[2] == "M") ? "His" : "Her";
                string hir = (item[2] == "M") ? "his" : "her";

                int currentYear = DateTime.Today.Year;
                int sessStart = 0;
                int sessEnd = 0;
                try
                {
                    sessStart = Int32.Parse(this.Session);
                    sessEnd = Int32.Parse(this.SessionEnd);
                }
                catch (Exception year)
                {
                    MessageBox.Show("Year conversion : " + year.Message);
                }
                string wis = (sessStart == currentYear || sessEnd == currentYear) ? "is" : "was";
                string preview1 = string.Empty;
                preview1 = "  This is to certify that " + item[0] + ", " + xchild + " of " + item[1] + ", " + item[4] + ", is personally known to me.";
                string preview2 = Xhe + " comes of a respectable family. " + Xhe + " " + wis + " reading in Class " + this.SelectedClass + ", Sec. " + this.SelectedSection + ", Roll " + item[7] + ", Session " + this.Session + "-" + this.SessionEnd + ".";
                string preview3 = Hir + " date of birth as per School records is " + DateTime.Parse(item[3]).ToString("dd-MM-yyyy") +".";
                string preview4 = "So far I know, " + xhe + " bears a good moral character. I wish " + hir + " every success in life.";
                string admNo = string.IsNullOrEmpty(item[8].ToString()) ? "NIL" : item[8].ToString();
                DateTime adD = (string.IsNullOrEmpty(item[9].ToString())) ? default(DateTime) : DateTime.Parse(item[9].ToString());
                string admD = (adD.Year == 1) ? "0000" : adD.Year.ToString();
                rSlist.Add(new string[] {preview1, preview2, preview3, preview4, admNo, admD});
            }
            return rSlist;
        }

        private void Reset()
        {
            this.StdName = this.FatherName = this.Vill = this.PO = this.Ps = this.Dist = this.Pin = this.Address = this.Roll = this.PreviewText = string.Empty;
            this.GenderIndex = this.SelectedClassIndex = this.SelectedSectionIndex = -1;
            this.TotalStudent = 0;
        }

        private bool CanReset()
        {
            return true;
        }


        #endregion   
    }
}
