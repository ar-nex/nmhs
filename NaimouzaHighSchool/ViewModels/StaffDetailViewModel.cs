using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class StaffDetailViewModel : BaseViewModel
    {
        public StaffDetailViewModel()
        : base()
        {
            this.StartUpInitialzer();
        }

        #region property

        private enum buttonClick { none, add, save };
        private buttonClick bclick;

        private ObservableCollection<Staff> _staffList;
        public ObservableCollection<Staff> StaffList
        {
            get { return this._staffList; }
            set { this._staffList = value; this.OnPropertyChanged("StaffList"); }
        }

        private ObservableCollection<string> _criteriaList;
        public ObservableCollection<string> CriteriaList
        {
            get { return this._criteriaList; }
            set { this._criteriaList = value; this.OnPropertyChanged("CriteriaList"); }
        }

        private List<string> _uniqueSubjects;
        public List<string> UniqueSubjects
        {
            get { return this._uniqueSubjects; }
            set { this._uniqueSubjects = value; this.OnPropertyChanged("UniqueSubjects"); }
        }

        private List<string> _uniqueDesignations;
        public List<string> UniqueDesignations
        {
            get { return this._uniqueDesignations; }
            set { this._uniqueDesignations = value; this.OnPropertyChanged("UniqueDesignations"); }
        }

        private List<string> _uniqueQualifications;
        public List<string> UniqueQualifications
        {
            get { return this._uniqueQualifications; }
            set { this._uniqueQualifications = value; this.OnPropertyChanged("UniqueQualifications"); }
        }

        private List<string> _uniqueProfQualificatins;
        public List<string> UniqueProfQualifications
        {
            get { return this._uniqueProfQualificatins; }
            set { this._uniqueProfQualificatins = value; this.OnPropertyChanged("UniqueProfQualifications"); }
        }

        public string[] CriteriaType { get; set; }
        private int _cirteriaTypeIndex;
        public int CriteriaTypeIndex
        {
            get { return this._cirteriaTypeIndex; }
            set
            {
                this._cirteriaTypeIndex = value;
                this.UpdateCriteriaList();
                this.OnPropertyChanged("CriteriaTypeIndex");
            }
        }

        private int _staffListIndex;
        public int StaffListIndex
        {
            get { return this._staffListIndex; }
            set 
            {
                this._staffListIndex = value;
                this.UpdateDetailView();
                this.OnPropertyChanged("StaffListIndex");
            }
        }

        #region detailpane
        private string _txbName;
        public string TxbName
        {
            get { return this._txbName; }
            set { this._txbName = value.ToUpper(); this.OnPropertyChanged("TxbName"); }
        }

        private string _txbDesignation;
        public string TxbDesignation
        {
            get { return this._txbDesignation; }
            set { this._txbDesignation = value.ToUpper(); this.OnPropertyChanged("TxbDesignation"); }
        }

        private string _txbSubject;
        public string TxbSubject
        {
            get { return this._txbSubject; }
            set { this._txbSubject = value.ToUpper(); this.OnPropertyChanged("TxbSubject"); }
        }

        private string _txbQualification;
        public string TxbQualification
        {
            get { return this._txbQualification; }
            set { this._txbQualification = value.ToUpper(); this.OnPropertyChanged("TxbQualification"); }
        }

        private string _txbProfQualificassion;
        public string TxbProfQualification
        {
            get { return this._txbProfQualificassion; }
            set { this._txbProfQualificassion = value.ToUpper(); this.OnPropertyChanged("TxbProfQualification"); }
        }

        private string _gender;
        public string Gender
        {
            get { return this._gender; }
            set { this._gender = value.ToUpper(); this.OnPropertyChanged("Gender"); }
        }

        private DateTime _doj;
        public DateTime Doj
        {
            get { return this._doj; }
            set { this._doj = value; this.OnPropertyChanged("Doj"); }
        }

        private string _mobile;
        public string Mobile
        {
            get { return this._mobile; }
            set { this._mobile = value; this.OnPropertyChanged("Mobile"); }
        }

        private string _altMobile;
        public string AltMobile
        {
            get { return this._altMobile; }
            set { this._altMobile = value; this.OnPropertyChanged("AltMobile"); }
        }

        private string _email;
        public string Email
        {
            get { return this._email; }
            set { this._email = value; this.OnPropertyChanged("Email"); }
        }

        private string _bankAcc;
        public string BankAcc
        {
            get { return this._bankAcc; }
            set { this._bankAcc = value; this.OnPropertyChanged("BankAcc"); }
        }

        private string _ifsc;
        public string Ifsc
        {
            get { return this._ifsc; }
            set { this._ifsc = value.ToUpper(); this.OnPropertyChanged("Ifsc"); }
        }

        private string _bankName;
        public string BankName
        {
            get { return this._bankName; }
            set { this._bankName = value.ToUpper(); this.OnPropertyChanged("BankName"); }
        }

        private string _bankBranch;
        public string BankBranch
        {
            get { return this._bankBranch; }
            set { this._bankBranch = value.ToUpper(); this.OnPropertyChanged("BankBranch"); }
        }

        private string _micr;
        public string Micr
        {
            get { return this._micr; }
            set { this._micr = value; this.OnPropertyChanged("Micr"); }
        }

        private string _status;
        public string Status
        {
            get { return this._status; }
            set { this._status = value; this.OnPropertyChanged("Status"); }
        }

        private DateTime _dor;
        public DateTime Dor
        {
            get { return this._dor; }
            set { this._dor = value; this.OnPropertyChanged("Dor"); }
        }

        private string _saveBtnContent;
        public string SaveBtnContent
        {
            get { return this._saveBtnContent; }
            set { this._saveBtnContent = value; this.OnPropertyChanged("SaveBtnContent"); }
        }
        #endregion
        private StaffDetailDb db { get; set; }

        public RelayCommand AddStaffClickedCommand { get; set; }
        public RelayCommand SaveBtnClickedCommand { get; set; }
        public RelayCommand DeleteBtnClickedCommand { get; set; }
        #endregion

        #region method
        private void StartUpInitialzer()
        {
            this.bclick = buttonClick.none;

            this.StaffListIndex = -1;
            this.CriteriaTypeIndex = -1;
            this.CriteriaType = new string[] { "Subject", "Designation", "Qualification", "Prof. Qualification"};
            this.db = new StaffDetailDb();
            this.StaffList = new ObservableCollection<Staff>(db.GetStaffList());

            this.UniqueDesignations = db.GetDistinct("DESIGNATION");
            this.UniqueSubjects = db.GetDistinct("SUBJECT");
            this.UniqueQualifications = db.GetDistinct("QUALIFICATION");
            this.UniqueProfQualifications = db.GetDistinct("PROFFESIONALQ");

            this.AddStaffClickedCommand = new RelayCommand(this.AddStaffClicked, this.CanAddStaffClicked);
            this.SaveBtnClickedCommand = new RelayCommand(this.SaveBtnClicked, this.CanSaveBtnClicked);
            this.DeleteBtnClickedCommand = new RelayCommand(this.DeleteBtnClicked, this.CanDeleteBtnClicked);
        }

        private void UpdateCriteriaList()
        {
            if (this.CriteriaTypeIndex < 0 || this._cirteriaTypeIndex >= this.CriteriaType.Length)
            {
                return;
            }
            else
            { 
                string crType = this.CriteriaType[this.CriteriaTypeIndex];
                if (this.CriteriaList.Count > 0)
                {
                    this.CriteriaList.Clear();
                }
                
                switch (crType)
                {
                    case "Subject":
                        ObservableCollection<string> clist = new ObservableCollection<string>(this.UniqueSubjects);
                        this.CriteriaList = clist;
                        break;
                    case "Designation":
                        ObservableCollection<string> clist1 = new ObservableCollection<string>(this.UniqueDesignations);
                        this.CriteriaList = clist1;
                        break;
                    case "Qualification":
                        ObservableCollection<string> clist2 = new ObservableCollection<string>(this.UniqueQualifications);
                        this.CriteriaList = clist2;
                        break;
                    case "Prof. Qualification":
                        ObservableCollection<string> clist3 = new ObservableCollection<string>(this.UniqueProfQualifications);
                        this.CriteriaList = clist3;
                        break;
                    default:
                        break;
                }

            }
        }

        private void UpdateDetailView()
        {
            if (this.StaffListIndex < 0 || this.StaffListIndex >= this.StaffList.Count)
            {
                this.TxbName = string.Empty;
                this.TxbSubject = string.Empty;
                this.TxbDesignation = string.Empty;
                this.TxbQualification = string.Empty;
                this.TxbProfQualification = string.Empty;
                this.Gender = string.Empty;
                this.Doj = default(DateTime);
                this.BankAcc = string.Empty;
                this.Ifsc = string.Empty;
                this.BankBranch = string.Empty;
                this.BankName = string.Empty;
                this.Micr = string.Empty;
                this.Status = "ACTIVE";
                this.Dor = default(DateTime);

                this.SaveBtnContent = "save new";
            }
            else
            { 
                Staff s = this.StaffList[this.StaffListIndex];
                this.TxbName = s.Name;
                this.TxbDesignation = s.Designation;
                this.TxbSubject = s.Subject;
                this.TxbQualification = s.Qualification;
                this.TxbProfQualification = s.ProfessionalQualification;
                this.Gender = s.Sex;
                this.Doj = s.DateOfJoining;
                this.Mobile = s.Mobile;
                this.AltMobile = s.AltMobile;
                this.Email = s.Email;
                this.BankAcc = s.BankAcc;
                this.Ifsc = s.Ifsc;
                this.BankBranch = s.BankBranch;
                this.BankName = s.BankName;
                this.Micr = s.Micr;

                this.SaveBtnContent = "update";
            
            }
        }

        private Staff GetStaffBuild()
        {
            Staff s = new Staff();
            s.Name = this.TxbName;
            s.Subject = this.TxbSubject;
            s.Designation = this.TxbDesignation;
            s.Qualification = this.TxbQualification;
            s.ProfessionalQualification = this.TxbProfQualification;
            s.Sex = this.Gender;
            s.DateOfJoining = this.Doj;
            s.Mobile = this.Mobile;
            s.AltMobile = this.AltMobile;
            s.Email = this.Email;
            s.BankAcc = this.BankAcc;
            s.Ifsc = this.Ifsc;
            s.BankBranch = this.BankBranch;
            s.BankName = this.BankName;
            s.Micr = this.Micr;
            s.Status = this.Status;
            s.RetireDate = this.Dor;

            return s;
        }

        private void AddStaffClicked()
        {
            this.bclick = buttonClick.add;
            this.SaveBtnContent = "save new";
            this.StaffListIndex = -1;
        }

        private bool CanAddStaffClicked()
        {
            return true;
        }

        private void SaveBtnClicked()
        {
            if (this.bclick == buttonClick.add)
            {
                Staff newStaff = this.GetStaffBuild();
                int insertId = this.db.InsertStaff(newStaff);
                if (insertId > 0)
                {
                    newStaff.Id = insertId.ToString();
                    this.StaffList.Add(newStaff);
                    this.StaffListIndex = this.StaffList.IndexOf(newStaff);
                    System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Data inserted successfully. Insert more?", "", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
                    if (result == System.Windows.MessageBoxResult.No)
                    {
                        this.bclick = buttonClick.none;
                        this.SaveBtnContent = "update";
                    }
                    else
                    {
                        this.StaffListIndex = -1;
                    }

                }
            }
            else
            {
                bool rs = this.db.UpdateStaff(this.StaffList[this.StaffListIndex]);
                if (rs)
                {
                    System.Windows.MessageBox.Show("Updated");
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to update");
                }
            }
        }

        private bool CanSaveBtnClicked()
        {
            if (this.bclick == buttonClick.add)
            {
                if (string.IsNullOrEmpty(this.TxbName))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return (this.StaffListIndex > -1) && (!(string.IsNullOrEmpty(this.TxbName)));
            }
        }

        private void DeleteBtnClicked()
        {
            bool rs = db.DeleteStaff(this.StaffList[this.StaffListIndex].Id);
            if (rs)
            {
                this.StaffListIndex = -1;
                System.Windows.MessageBox.Show("Deleted successfully.");
            }
            else
            {
                System.Windows.MessageBox.Show("Failed to Delete.");
            }
        }

        private bool CanDeleteBtnClicked()
        {
            return this.StaffListIndex > -1;
        }
        #endregion
    }
}
