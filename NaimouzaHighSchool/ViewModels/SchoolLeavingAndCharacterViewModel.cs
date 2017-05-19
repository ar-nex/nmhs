using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models;

namespace NaimouzaHighSchool.ViewModels
{
    public class SchoolLeavingAndCharacterViewModel : BaseViewModel
    {
        public SchoolLeavingAndCharacterViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        
        #region property
        public string[] Exams { get; set; }
        public string[] GenerateType { get; set; }

        private int _examsIndex;
        public int ExamsIndex
        {
            get { return this._examsIndex; }
            set { this._examsIndex = value; this.OnPropertyChanged("ExamsIndex"); }
        }

        private int _generateTypeIndex;
        public int GenerateTypeIndex
        {
            get { return this._generateTypeIndex; }
            set 
            { 
                this._generateTypeIndex = value;
                switch (value)
                {
                    case 0:
                        this.VisibilePart = VisibilityType.individual;
                        break;
                    case 1:
                        this.VisibilePart = VisibilityType.individual;
                        break;
                    case 2:
                        this.VisibilePart = VisibilityType.bulk;
                        break;
                    default:
                        this.VisibilePart = VisibilityType.none;
                        break;
                }
                this.OnPropertyChanged("GenerateTypeIndex"); 
            }
        }

        private System.Windows.Visibility _individualPart;
        public System.Windows.Visibility IndividualPart 
        {
            get { return this._individualPart; }
            set { this._individualPart = value; this.OnPropertyChanged("IndividualPart"); }
        }
        private System.Windows.Visibility _bulkPart;
        public System.Windows.Visibility BulkPart 
        {
            get { return this._bulkPart; }
            set { this._bulkPart = value; this.OnPropertyChanged("BulkPart"); }
        }
        private System.Windows.Visibility _nonePart;
        public System.Windows.Visibility NonePart 
        {
            get { return this._nonePart; }
            set { this._nonePart = value; this.OnPropertyChanged("NonePart"); }
        }

        public enum VisibilityType { none, individual, bulk};
        public VisibilityType _visiblePart;
        public VisibilityType VisibilePart
        {
            get { return this._visiblePart; }
            set 
            { 
                this._visiblePart = value;
                if (value == VisibilityType.individual)
                {
                    this.NonePart = System.Windows.Visibility.Collapsed;
                    this.BulkPart = System.Windows.Visibility.Collapsed;
                    this.IndividualPart = System.Windows.Visibility.Visible;
                }
                else if (value == VisibilityType.bulk)
                {
                    this.NonePart = System.Windows.Visibility.Collapsed;
                    this.IndividualPart = System.Windows.Visibility.Collapsed;
                    this.BulkPart = System.Windows.Visibility.Visible;
                }
                else
                {
                    this.BulkPart = System.Windows.Visibility.Collapsed;
                    this.IndividualPart = System.Windows.Visibility.Collapsed;
                    this.NonePart = System.Windows.Visibility.Visible;
                
                }
                this.OnPropertyChanged("VisiblePart"); 
            }
        }

        #region student_property
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value.ToUpper(); this.OnPropertyChanged("Name"); }
        }
        private string _fname;
        public string Fname
        {
            get { return this._fname; }
            set { this._fname = value.ToUpper(); this.OnPropertyChanged("Fname"); }
        }

        private string _gender;
        public string Gender
        {
            get { return this._gender; }
            set { this._gender = value; this.OnPropertyChanged("Gender"); }
        }

        private string _address;
        public string Address
        {
            get { return this._address; }
            set { this._address = value; this.OnPropertyChanged("Address"); }
        }

        private int _marksObtained;
        public int MarksObtained
        {
            get { return this._marksObtained; }
            set { this._marksObtained = value; this.OnPropertyChanged("MarksObtained"); }
        }

        private string _grade;
        public string Grade
        {
            get { return this._grade; }
            set { this._grade = value; this.OnPropertyChanged("Grade"); }
        }

        private string _category;
        public string Category
        {
            get { return this._category; }
            set { this._category = value; this.OnPropertyChanged("Category"); }
        }

        private int _year;
        public int Year
        {
            get { return this._year; }
            set { this._year = value; this.OnPropertyChanged("Year"); }
        }
        #endregion

        private string _previewPara1;
        public string PreviewPara1
        {
            get { return this._previewPara1; }
            set { this._previewPara1 = value; }
        }

        private string _previewPara2;
        public string PreviewPara2
        {
            get { return this._previewPara2; }
            set { this._previewPara2 = value; }
        }

        public RelayCommand GeneratePreviewCommand { get; set; }
        #endregion


        #region Method
        private void StartUpInitializer()
        {
            this.Exams = new string[] { "Secondary", "Higher Secondary"};
            this.GenerateType = new string[] { "Add hoc", "By Board/Council RollNo", "Bulk" };
            this.GenerateTypeIndex = -1;
            this.ExamsIndex = -1;
            this.VisibilePart = VisibilityType.none;

            this.GeneratePreviewCommand = new RelayCommand(this.GeneratePreview, this.CanGeneratePreview);
        }

        private void GeneratePreview()
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            string StudentName = ti.ToTitleCase(this.Name);
            string Father = ti.ToTitleCase(this.Fname);
            string school = GlobalVar.SchoolName;
            string exam = this.Exams[this.ExamsIndex];
            string Board = string.Empty;
            if (this.ExamsIndex == 0)
            {
                Board = GlobalVar.ExamBoard;
            }
            else if (this.ExamsIndex == 1)
            {
                Board = GlobalVar.ExamCouncil;
            }
            string xchild = string.Empty;
            string Xhe = string.Empty;
            string Xhis = string.Empty;
            string xhim = string.Empty;
            if (this.Gender == "M")
            {
                xchild = "son";
                Xhe = "He";
                Xhis = "His";
                xhim = "him";
            }
            else if (this.Gender == "F")
            {
                xchild = "daughter";
                Xhe = "She";
                Xhis = "Her";
                xhim = "her";
            }

            this.PreviewPara1 = "This is to certify that "+StudentName+" "+xchild+" of "+Father+", resident of "+this.Address+" had been a student of "+school+". "+Xhe+ " passed at the "+exam+ " examination from the "+Board+" in the year "+this.Year+ " as a "+this.Category+" candidate from this institution. "+Xhis+" overall grade was "+this.Grade+" and obtained marks of "+this.MarksObtained+".";
            this.PreviewPara2 = Xhe + " bears a good moral character. I wish " + xhim + " success in life.";
            
        }

        private bool CanGeneratePreview()
        {
            bool existName = !string.IsNullOrEmpty(this.Name);
            bool existFname = !string.IsNullOrEmpty(this.Fname);
            bool existGender = !string.IsNullOrEmpty(this.Gender);
            bool existMarksObtained = this.MarksObtained > 0;
            bool examSelected = this.ExamsIndex > -1 && this.ExamsIndex < this.Exams.Length;
            return existName && existFname && existMarksObtained && existGender && examSelected;
        }
        #endregion
    }
}
