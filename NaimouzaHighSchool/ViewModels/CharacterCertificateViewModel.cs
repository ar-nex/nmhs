using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.ViewModels.Helpers;

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
            this.CertifHelper = new CertificateHelper();
            this.InitializeStartUpVisibility();
            this.InitializeStartUpComboList();
            this.IncludeHeader = true;
            
        }

        #region fields
        private Visibility _visibilityAddhoc;
        private Visibility _visibilityUniqueIndividual;
        private Visibility _visibilityClassList;
        private Visibility _visibilityNameList;
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
        public Visibility VisibilityClassList
        {
            get { return _visibilityClassList; }
            set { _visibilityClassList = value; this.OnPropertyChanged("VisibilityClassList"); }
        }
        public Visibility VisibilityNameList
        {
            get { return _visibilityNameList; }
            set { _visibilityNameList = value; this.OnPropertyChanged("VisibilityNameList"); }
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
        // testing.
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
                        this.VisibilityClassList = Visibility.Collapsed;
                        this.VisibilityNameList = Visibility.Collapsed;
                        this.VisibilityAddhoc = Visibility.Visible;                      
                        break;
                    case "By Class, Section and Roll":
                        this.VisibilityClassList = Visibility.Collapsed;
                        this.VisibilityNameList = Visibility.Collapsed;
                        this.VisibilityAddhoc = Visibility.Collapsed;
                        this.VisibilityUniqueIndividual = Visibility.Visible;
                        break;

                    default:
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
                this.OnPropertyChanged("StdName");
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

        public string Session
        {
            get { return _session; }
            set { _session = value; this.OnPropertyChanged("Session"); }
        }
        public string Dob
        {
            get { return _dob; }
            set { _dob = value; this.OnPropertyChanged("Dob"); }
        }

        private string _textPreview;
        public string TextPreview
        {
            get { return this._textPreview; }
            set { this._textPreview = value; this.OnPropertyChanged("TextPreview"); }
        }

        public RelayCommand GenerateCertificateCommand { get; set; }
        #endregion



        #region method
        public void GenerateCertificate()
        {
            string[] cerficateData = new string[13];
            cerficateData[0] = this.StdName;
            cerficateData[1] = this.FatherName;
            cerficateData[2] = this.Vill;
            cerficateData[3] = this.PO;
            cerficateData[4] = this.Ps;
            cerficateData[5] = this.Dist;
            cerficateData[6] = this.Pin;
            cerficateData[7] = this.StdGender;
            cerficateData[8] = this.SelectedClass;
            cerficateData[9] = this.SelectedSection;
            cerficateData[10] = this.Roll;
            cerficateData[11] = this.Session;
            cerficateData[12] = this.Dob;

            try
            {
                 CertifHelper.CreateCharacterCertificatePDF(cerficateData);
            }
            catch (Exception em)
            {

                System.Windows.MessageBox.Show(em.Message);
            }


            

        }
        public bool CanGenerateCertificate()
        {
            return true;
        }
        private void InitializeStartUpVisibility()
        {
            this.VisibilityAddhoc = Visibility.Visible;
            this.VisibilityUniqueIndividual = Visibility.Collapsed;
            this.VisibilityClassList = Visibility.Collapsed;
            this.VisibilityNameList = Visibility.Collapsed;

           
        }
        private void InitializeStartUpComboList()
        {
            this.SearchType = new List<string>();
            this.SearchType.Add("Add hoc");
            this.SearchType.Add("By Class, Section and Roll");

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
        #endregion
      

      
    }
}
