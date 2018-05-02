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
           // this.StartUpInitialzer();
        }

        #region property

        private enum buttonClick { none, add, edit, save };
        private buttonClick bclick;
        private buttonClick Bclick
        {
            get => bclick;
            set
            {
                bclick = value;
                OnPropertyChanged("Bclick");
            }
        }

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

        private ObservableCollection<string> _uniqueSubjects;
        public ObservableCollection<string> UniqueSubjects
        {
            get { return this._uniqueSubjects; }
            set { this._uniqueSubjects = value; this.OnPropertyChanged("UniqueSubjects"); }
        }

        private ObservableCollection<BankBranch> _branchList;
        public ObservableCollection<BankBranch> BranchList
        {
            get => _branchList;
            set
            {
                _branchList = value;
                OnPropertyChanged("BranchList");
            }
        }

        private ObservableCollection<string> _uniqueDesignations;
        public ObservableCollection<string> UniqueDesignations
        {
            get { return this._uniqueDesignations; }
            set { this._uniqueDesignations = value; this.OnPropertyChanged("UniqueDesignations"); }
        }

        private ObservableCollection<string> _ifscList;
        public ObservableCollection<string> IfscList
        {
            get => _ifscList;
            set
            {
                _ifscList = value;
                OnPropertyChanged("IfscList");
            }
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
               // this.UpdateCriteriaList();
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
               // this.UpdateDetailView();
                this.OnPropertyChanged("StaffListIndex");
            }
        }

        private Staff _selectedStaff;
        public Staff SelectedStaff
        {
            get => _selectedStaff;
            set
            {
                _selectedStaff = value;
                OnPropertyChanged("SelectedStaff");
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
            set { this._txbDesignation = value.ToUpper(); OnPropertyChanged("TxbDesignation"); }
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

        public string[] DD { get; set; }
        public string[] MM { get; set; }
        public string[] YYYY { get; set; }

        private int _dojDDIndex;
        public int DojDDIndex
        {
            get => _dojDDIndex;
            set
            {
                _dojDDIndex = value;
                OnPropertyChanged("DojDDIndex");
            }
        }

        private int _dojMMIndex;
        public int DojMMIndex
        {
            get => _dojMMIndex;
            set
            {
                _dojMMIndex = value;
                OnPropertyChanged("DojMMIndex");
            }
        }

        private int _dojYYIndex;
        public int DojYYIndex
        {
            get => _dojYYIndex;
            set
            {
                _dojYYIndex = value;
                OnPropertyChanged("DojYYIndex");
            }
        }

        private int _dorDDIndex;
        public int DorDDIndex
        {
            get => _dorDDIndex;
            set
            {
                _dorDDIndex = value;
                OnPropertyChanged("DorDDIndex");
            }
        }

        private int _dorMMIndex;
        public int DorMMIndex
        {
            get => _dorMMIndex;
            set
            {
                _dorMMIndex = value;
                OnPropertyChanged("DorMMIndex");
            }
        }

        private int _dorYYIndex;
        public int DorYYIndex
        {
            get => _dorYYIndex;
            set
            {
                _dorYYIndex = value;
                OnPropertyChanged("DorYYIndex");
            }
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
            set
            {
                this._ifsc = value.ToUpper();
                if (!string.IsNullOrEmpty(value))
                {
                   // setBankDetails(value);
                }
                OnPropertyChanged("Ifsc");
            }
        }

        private bool _isBankDetailReadOnly;
        public bool IsBankDetailReadOnly
        {
            get => _isBankDetailReadOnly;
            set
            {
                _isBankDetailReadOnly = value;
                OnPropertyChanged("IsBankDetailReadOnly");
            }
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
        public RelayCommand EditBtnClickedCommand { get; set; }
        public RelayCommand DeleteBtnClickedCommand { get; set; }
        public RelayCommand CancelBtnClickedCommand { get; set; }
        #endregion

        #region method
        //private void StartUpInitialzer()
        //{
        //    this.Bclick = buttonClick.none;

        //    StaffListIndex = -1;
        //    CriteriaTypeIndex = -1;
        //    CriteriaType = new string[] { "Subject", "Designation", "Qualification", "Prof. Qualification"};
        //    db = new StaffDetailDb();
        //    StaffList = new ObservableCollection<Staff>(db.GetStaffList());

        //    UniqueDesignations = new ObservableCollection<string>(db.GetDistinct("DESIGNATION"));
        //    UniqueSubjects = new ObservableCollection<string>(db.GetDistinct("SUBJECT"));
        //    UniqueQualifications = db.GetDistinct("QUALIFICATION");
        //    UniqueProfQualifications = db.GetDistinct("PROFFESIONALQ");
        //    BranchList = new ObservableCollection<BankBranch>(db.getBankBranchList());
        //    IfscList = new ObservableCollection<string>();
        //    updateIfscList();


        //    DD = new string[] { "DD", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        //    MM = new string[] { "MM", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        //    int yy = DateTime.Now.Year;
        //    YYYY = new string[41];
        //    YYYY[0] = "YYYY";
        //    for (int i = 0; i < 40; i++)
        //    {
        //        YYYY[i + 1] = (yy - i).ToString();
        //    }
        //    DojDDIndex = DojMMIndex = DojYYIndex = 0;
        //    DorDDIndex = DorMMIndex = DorYYIndex = 0;

        //    AddStaffClickedCommand = new RelayCommand(this.AddStaffClicked, this.CanAddStaffClicked);
        //    SaveBtnClickedCommand = new RelayCommand(this.SaveBtnClicked, this.CanSaveBtnClicked);
        //    EditBtnClickedCommand = new RelayCommand(editBtnClicked, canEditBtnClicked);
        //    DeleteBtnClickedCommand = new RelayCommand(this.DeleteBtnClicked, this.CanDeleteBtnClicked);
        //    CancelBtnClickedCommand = new RelayCommand(cancelBtnClicked, canCancelBtnClicked);
        //}

        //private void UpdateCriteriaList()
        //{
        //    if (this.CriteriaTypeIndex < 0 || this._cirteriaTypeIndex >= this.CriteriaType.Length)
        //    {
        //        return;
        //    }
        //    else
        //    { 
        //        string crType = this.CriteriaType[this.CriteriaTypeIndex];
        //        if (this.CriteriaList.Count > 0)
        //        {
        //            this.CriteriaList.Clear();
        //        }
                
        //        switch (crType)
        //        {
        //            case "Subject":
        //                ObservableCollection<string> clist = new ObservableCollection<string>(this.UniqueSubjects);
        //                this.CriteriaList = clist;
        //                break;
        //            case "Designation":
        //                ObservableCollection<string> clist1 = new ObservableCollection<string>(this.UniqueDesignations);
        //                this.CriteriaList = clist1;
        //                break;
        //            case "Qualification":
        //                ObservableCollection<string> clist2 = new ObservableCollection<string>(this.UniqueQualifications);
        //                this.CriteriaList = clist2;
        //                break;
        //            case "Prof. Qualification":
        //                ObservableCollection<string> clist3 = new ObservableCollection<string>(this.UniqueProfQualifications);
        //                this.CriteriaList = clist3;
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //}

        //private void UpdateDetailView()
        //{
        //    if (this.StaffListIndex < 0 || this.StaffListIndex >= this.StaffList.Count)
        //    {
        //        this.TxbName = string.Empty;
        //        this.TxbSubject = string.Empty;
        //        this.TxbDesignation = string.Empty;
        //        this.TxbQualification = string.Empty;
        //        this.TxbProfQualification = string.Empty;
        //        this.Gender = string.Empty;
        //        DojDDIndex = DojMMIndex = DojYYIndex = 0;
        //        DorDDIndex = DorMMIndex = DorYYIndex = 0;
        //        this.BankAcc = string.Empty;
        //        this.Ifsc = string.Empty;
        //        this.BankBranch = string.Empty;
        //        this.BankName = string.Empty;
        //        this.Micr = string.Empty;
        //        this.Dor = default(DateTime);

        //        this.SaveBtnContent = "save new";
        //    }
        //    else
        //    { 
        //        Staff s = this.StaffList[this.StaffListIndex];
        //        this.TxbName = s.Name;
        //        this.TxbDesignation = s.Designation;
        //        this.TxbSubject = s.Subject;
        //        this.TxbQualification = s.Qualification;
        //        this.TxbProfQualification = s.ProfessionalQualification;
        //        this.Gender = s.Sex;
        //        //this.Doj = s.DateOfJoining;
        //        if (s.DateOfJoining.Year == 1)
        //        {
        //            DojDDIndex = DojMMIndex = DojYYIndex = 0;
        //        }
        //        else
        //        {
        //            int dIndex = Array.IndexOf(DD, s.DateOfJoining.Day.ToString("00"));
        //            DojDDIndex = (dIndex == -1) ? 0 : dIndex;
        //            int mIndex = Array.IndexOf(MM, s.DateOfJoining.Month.ToString("00"));
        //            DojMMIndex = (mIndex == -1) ? 0 : mIndex;
        //            int yIndex = Array.IndexOf(YYYY, s.DateOfJoining.Year.ToString());
        //            DojYYIndex = (yIndex == -1) ? 0 : yIndex;
        //        }
        //        // retirement date
        //        if (s.RetireDate.Year == 1)
        //        {
        //            DorDDIndex = DorMMIndex = DorYYIndex = 0;
        //        }
        //        else
        //        {
        //            int dIndex = Array.IndexOf(DD, s.RetireDate.Day.ToString("00"));
        //            DorDDIndex = (dIndex == -1) ? 0 : dIndex;
        //            int mIndex = Array.IndexOf(MM, s.RetireDate.Month.ToString("00"));
        //            DorMMIndex = (mIndex == -1) ? 0 : mIndex;
        //            int yIndex = Array.IndexOf(YYYY, s.RetireDate.Year.ToString());
        //            DorYYIndex = (yIndex == -1) ? 0 : yIndex;
        //        }

        //        this.Mobile = s.Mobile;
        //        this.AltMobile = s.LandPhone;
        //        this.Email = s.Email;
        //        this.BankAcc = s.BankAcc;
        //        this.Ifsc = s.Ifsc;
        //        this.BankBranch = s.BankBranch;
        //        this.BankName = s.BankName;
        //        this.Micr = s.Micr;

        //        this.SaveBtnContent = "update";
            
        //    }
        //}

        //private Staff GetStaffBuild()
        //{
        //    Staff s = new Staff();
        //    s.Name = this.TxbName;
        //    s.Subject = this.TxbSubject;
        //    s.Designation = this.TxbDesignation;
        //    s.Qualification = this.TxbQualification;
        //    s.ProfessionalQualification = this.TxbProfQualification;
        //    s.Sex = this.Gender;
        //    s.DateOfJoining = getDate("doj");
        //    s.RetireDate = getDate("dor");
        //    s.Mobile = this.Mobile;
        //    s.LandPhone = this.AltMobile;
        //    s.Email = this.Email;
        //    s.BankAcc = this.BankAcc;
        //    s.Ifsc = this.Ifsc;
        //    s.BankBranch = this.BankBranch;
        //    s.BankName = this.BankName;
        //    s.Micr = this.Micr;
        //    s.Id = (StaffListIndex > -1) ? StaffList[StaffListIndex].Id : string.Empty;
        //    return s;
        //}

        //private void AddStaffClicked()
        //{

        //    StaffListIndex = -1;
        //    Bclick = buttonClick.add;
        //}

        //private bool CanAddStaffClicked()
        //{
        //    if (Bclick == buttonClick.edit)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return !(Bclick == buttonClick.add);
        //    }
        //}

        //private void SaveBtnClicked()
        //{
            
            
        //    if (this.Bclick == buttonClick.add)
        //    {
                
        //        if (!isDatesValid())
        //        {
        //            System.Windows.MessageBox.Show("Please check the entered date.");
        //            return;
        //        }
        //        else
        //        {
        //            Staff newStaff = this.GetStaffBuild();
        //            int insertId = this.db.InsertStaff(newStaff);
        //            if (insertId > 0)
        //            {
        //                newStaff.Id = insertId.ToString();
        //                this.StaffList.Add(newStaff);
        //                this.StaffListIndex = this.StaffList.IndexOf(newStaff);
        //                // insert bank detail to observable list 
        //                if (!string.IsNullOrEmpty(newStaff.Ifsc) && IfscList.IndexOf(newStaff.Ifsc) == -1)
        //                {
        //                    BankBranch br = new Models.Utility.BankBranch();
        //                    br.IFSC = newStaff.Ifsc;
        //                    br.BankName = newStaff.BankName;
        //                    br.BranchName = newStaff.BankName;
        //                    br.Micr = newStaff.Micr;
        //                    BranchList.Add(br);
        //                    IfscList.Add(br.IFSC);
        //                }
        //                // insert desig
        //                if (!string.IsNullOrEmpty(TxbDesignation) && UniqueDesignations.IndexOf(TxbDesignation) == -1)
        //                {
        //                    UniqueDesignations.Add(TxbDesignation);
        //                }
        //                // insert subs
        //                if (!string.IsNullOrEmpty(TxbSubject) && UniqueSubjects.IndexOf(TxbSubject) == -1)
        //                {
        //                    UniqueSubjects.Add(TxbSubject);
        //                }
        //                // insert qualif
        //                if (!string.IsNullOrEmpty(TxbQualification) && UniqueQualifications.IndexOf(TxbQualification) == -1)
        //                {
        //                    UniqueQualifications.Add(TxbQualification);
        //                }
        //                // insert prof qualif
        //                if (!string.IsNullOrEmpty(TxbProfQualification) && UniqueProfQualifications.IndexOf(TxbProfQualification) == -1)
        //                {
        //                    UniqueProfQualifications.Add(TxbProfQualification);
        //                }

        //                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Data inserted successfully. Insert more?", "", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
        //                if (result == System.Windows.MessageBoxResult.No)
        //                {
        //                    Bclick = buttonClick.none;
        //                    StaffListIndex = -1;
        //                }
        //                else
        //                {
                           
        //                }

        //            }
        //        }
                

        //    }
        //    else
        //    {

        //        Staff s = GetStaffBuild();
        //        bool rs = this.db.UpdateStaff(s);
        //        if (rs)
        //        {
        //            Staff orgStf = StaffList[StaffListIndex];
        //            orgStf.Id = s.Id;
        //            orgStf.Name = s.Name;
        //            orgStf.Designation = s.Designation;
        //            orgStf.Subject = s.Subject;
        //            orgStf.Qualification = s.Qualification;
        //            orgStf.ProfessionalQualification = s.ProfessionalQualification;
        //            orgStf.Sex = s.Sex;
        //            orgStf.DateOfJoining = s.DateOfJoining;
        //            orgStf.RetireDate = s.RetireDate;
        //            orgStf.Mobile = s.Mobile;
        //            orgStf.LandPhone = s.LandPhone;
        //            orgStf.Email = s.Email;
        //            orgStf.BankAcc = s.BankAcc;
        //            orgStf.Ifsc = s.Ifsc;
        //            orgStf.Micr = s.Micr;
        //            orgStf.BankName = s.BankName;
        //            orgStf.BankBranch = s.BankBranch;

        //            // insert bank detail to observable list 
        //            if (!string.IsNullOrEmpty(s.Ifsc) && IfscList.IndexOf(s.Ifsc) == -1)
        //            {
        //                BankBranch br = new Models.Utility.BankBranch();
        //                br.IFSC = s.Ifsc;
        //                br.BankName = s.BankName;
        //                br.BranchName = s.BankName;
        //                br.Micr = s.Micr;
        //                BranchList.Add(br);
        //                IfscList.Add(br.IFSC);
        //            }
        //            // insert desig
        //            if (!string.IsNullOrEmpty(TxbDesignation) && UniqueDesignations.IndexOf(TxbDesignation) == -1)
        //            {
        //                UniqueDesignations.Add(TxbDesignation);
        //            }
        //            // insert subs
        //            if (!string.IsNullOrEmpty(TxbSubject) && UniqueSubjects.IndexOf(TxbSubject) == -1)
        //            {
        //                UniqueSubjects.Add(TxbSubject);
        //            }
        //            // insert qualif
        //            if (!string.IsNullOrEmpty(TxbQualification) && UniqueQualifications.IndexOf(TxbQualification) == -1)
        //            {
        //                UniqueQualifications.Add(TxbQualification);
        //            }
        //            // insert prof qualif
        //            if (!string.IsNullOrEmpty(TxbProfQualification) && UniqueProfQualifications.IndexOf(TxbProfQualification) == -1)
        //            {
        //                UniqueProfQualifications.Add(TxbProfQualification);
        //            }

        //            System.Windows.MessageBox.Show("Updated");
        //        }
        //        else
        //        {
        //            System.Windows.MessageBox.Show("Failed to update");
        //        }
        //    }

        //    Bclick = buttonClick.save;

        //}

        //private bool CanSaveBtnClicked()
        //{
        //    bool allDojdtSelected = (DojDDIndex > 0 && DojMMIndex > 0 && DojYYIndex > 0);
        //    bool allDordtSelected = (DorDDIndex > 0 && DorMMIndex > 0 && DorYYIndex > 0);

        //    bool allDojdtNotSelected = (DojDDIndex == 0 && DojMMIndex == 0 && DojYYIndex == 0);
        //    bool allDordtNotSelected = (DorDDIndex == 0 && DorMMIndex == 0 && DorYYIndex == 0);

        //    bool dtSelectedOrNot = (allDojdtSelected || allDojdtNotSelected) && (allDordtSelected || allDordtNotSelected);

        //    if (Bclick == buttonClick.none)
        //    {
        //        return false;
        //    }
        //    else if (Bclick == buttonClick.add)
        //    {
        //        return !string.IsNullOrEmpty(TxbName) && dtSelectedOrNot && !hasPartialBankDetails();
        //    }
        //    else if (Bclick == buttonClick.edit)
        //    {
        //        return dtSelectedOrNot && !hasPartialBankDetails();
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private void editBtnClicked()
        //{
        //    Bclick = buttonClick.edit;
        //}

        //private bool canEditBtnClicked()
        //{
        //    if (Bclick == buttonClick.add)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return (this.StaffListIndex > -1) && (!(string.IsNullOrEmpty(this.TxbName)));
        //    }
        //}

        //private void DeleteBtnClicked()
        //{
            
        //    bool rs = db.DeleteStaff(this.StaffList[this.StaffListIndex].Id);
        //    if (rs)
        //    {
        //        int index_temp = StaffListIndex;
        //        this.StaffListIndex = -1;
        //        StaffList.RemoveAt(index_temp);
        //        System.Windows.MessageBox.Show("Deleted successfully.");
        //    }
        //    else
        //    {
        //        System.Windows.MessageBox.Show("Failed to Delete.");
        //    }
            
            
        //}

        //private bool CanDeleteBtnClicked()
        //{
        //    return this.StaffListIndex > -1;
        //}

        //private bool isDatesValid()
        //{
        //    bool valid = false;
        //    bool allDojdtSelected = (DojDDIndex > 0 && DojMMIndex > 0 && DojYYIndex > 0);
        //    bool allDordtSelected = (DorDDIndex > 0 && DorMMIndex > 0 && DorYYIndex > 0);

        //    bool allDojdtNotSelected = (DojDDIndex == 0 && DojMMIndex == 0 && DojYYIndex == 0);
        //    bool allDordtNotSelected = (DorDDIndex == 0 && DorMMIndex == 0 && DorYYIndex == 0);

        //    valid = (allDojdtSelected || allDojdtNotSelected) && (allDordtSelected || allDordtNotSelected);

        //    if (DojDDIndex > 0 && DojMMIndex > 0 && DojYYIndex > 0)
        //    {
        //        string dt_str = YYYY[DojYYIndex].ToString() + MM[DojMMIndex].ToString() + DD[DojDDIndex];
        //        DateTime dt;
        //        valid = DateTime.TryParseExact(dt_str, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
        //    }
        //    if (DorDDIndex > 0 && DorMMIndex > 0 && DorYYIndex > 0)
        //    {
        //        string dt_str2 = YYYY[DojYYIndex].ToString() + MM[DojMMIndex].ToString() + DD[DojDDIndex];
        //        DateTime dt2;
        //        valid = DateTime.TryParseExact(dt_str2, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt2);
        //    }
        //    return valid;
        //}

        //private void updateIfscList()
        //{
        //    if (BranchList.Count > 0)
        //    {
        //        var ifsc = from n in BranchList
        //                   select n.IFSC;
        //        foreach (string item in ifsc)
        //        {
        //            IfscList.Add(item);
        //        }
        //    }
        //}

        //private void setBankDetails( string ifsc)
        //{
        //    bool flag = false;
        //    IsBankDetailReadOnly = false;
        //    if (BranchList.Count > 0)
        //    {
        //        foreach (BankBranch item in BranchList)
        //        {
        //            if (ifsc == item.IFSC)
        //            {
        //                BankName = item.BankName;
        //                BankBranch = item.BranchName;
        //                Micr = item.Micr;
        //                IsBankDetailReadOnly = true;
        //                flag = true;
        //                break;
        //            }
        //        }
        //        if (!flag)
        //        {
        //            BankName = string.Empty;
        //            BankBranch = string.Empty;
        //            Micr = string.Empty;
        //        }
        //    }
        //}

        //private bool hasPartialBankDetails()
        //{
        //    bool allBlank = string.IsNullOrEmpty(Ifsc) && string.IsNullOrEmpty(BankName) && string.IsNullOrEmpty(BankBranch) && string.IsNullOrEmpty(Micr);
        //    bool allFilled = !string.IsNullOrEmpty(Ifsc) && !string.IsNullOrEmpty(BankName) && !string.IsNullOrEmpty(BankBranch) && !string.IsNullOrEmpty(Micr);
        //    return !(allBlank || allFilled);
        //}

        //private DateTime getDate(string propertyName)
        //{
        //    if (propertyName == "doj")
        //    {
        //        if (DojDDIndex == 0 && DojMMIndex == 0 && DojYYIndex == 0)
        //        {
        //            return DateTime.MinValue;
        //        }
        //        else
        //        {
        //            string dt_str = YYYY[DojYYIndex].ToString() + MM[DojMMIndex].ToString() + DD[DojDDIndex];
        //            DateTime dt;
        //            bool valid = DateTime.TryParseExact(dt_str, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
        //            return dt;
        //        }
        //    }
        //    else if (propertyName == "dor")
        //    {
        //        if (DorDDIndex == 0 && DorMMIndex == 0 && DorYYIndex == 0)
        //        {
        //            return DateTime.MinValue;
        //        }
        //        else
        //        {
        //            string dt_str2 = YYYY[DorYYIndex].ToString() + MM[DorMMIndex].ToString() + DD[DorDDIndex];
        //            DateTime dt2;
        //            bool valid = DateTime.TryParseExact(dt_str2, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt2);
        //            return dt2;
        //        }
        //    }
        //    else
        //    {
        //        return DateTime.MinValue;
        //    }
        //}

        //private void cancelBtnClicked()
        //{
        //    Bclick = buttonClick.none;
        //}
        //private bool canCancelBtnClicked()
        //{
        //    return true;
        //}
        #endregion
    }
}
