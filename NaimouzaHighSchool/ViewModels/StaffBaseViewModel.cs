using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Helpers;

namespace NaimouzaHighSchool.ViewModels
{
    public class StaffBaseViewModel : BaseViewModel
    {
        public StaffBaseViewModel()
            : base()
        {
            StartUpInit();
        }

        #region common
        private int[] _yyyy;
        public int[] YYYY
        {
            get { return _yyyy; }
            set { _yyyy = value; OnPropertyChanged("YYYY"); }
        }

        private string[] _mm;
        public string[] MM
        {
            get { return _mm; }
            set { _mm = value; OnPropertyChanged("MM"); }
        }

        private int[] _dd;
        public int[] DD
        {
            get { return _dd; }
            set { _dd = value; OnPropertyChanged("DD"); }
        }



        #endregion

        #region primary
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("Name");
            }
        }

        private int _dobYYIndex;
        public int DobYYIndex
        {
            get { return _dobYYIndex; }
            set
            {
                _dobYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DobYYIndex");
                DD = FillDateInMonth(DobYYIndex, DobMMIndex);
            }
        }

        private int _dobMMIndex;
        public int DobMMIndex
        {
            get { return _dobMMIndex; }
            set
            {
                _dobMMIndex = (value > -1 && value < MM.Length) ? value : -1;
                OnPropertyChanged("DobMMIndex");
                DD = FillDateInMonth(DobYYIndex, DobMMIndex);
            }
        }

        private int _dobDDIndex;
        public int DobDDIndex
        {
            get { return _dobDDIndex; }
            set { _dobDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DobDDIndex"); }
        }

        public string[] Sex { get; set; }

        private int _sexIndex;
        public int SexIndex
        {
            get { return _sexIndex; }
            set
            {
                _sexIndex = (value > -1 && value < Sex.Length) ? value : -1;
                OnPropertyChanged("SexIndex");
            }
        }

        public string[] SocialCategory { get; set; }

        private int _socialCategoryIndex;
        public int SocialCategoryIndex
        {
            get { return _socialCategoryIndex; }
            set
            {
                _socialCategoryIndex = (value > -1 && value < SocialCategory.Length) ? value : -1;
                OnPropertyChanged("SocialCategoryIndex");
            }
        }

        private string _voterId;
        public string VoterId
        {
            get { return _voterId; }
            set { _voterId = (value != null) ? value.ToUpper() : value; OnPropertyChanged("VoterId"); }
        }

        private string _vacancyStatus;
        public string VacancyStatus
        {
            get { return _vacancyStatus; }
            set { _vacancyStatus = (value != null) ? value.ToUpper() : value; OnPropertyChanged("VacancyStatus"); }
        }

        public ObservableCollection<string> Vacancy { get; set; }

        private string _designation;
        public string Designation
        {
            get { return _designation; }
            set { _designation = (value != null) ? value.ToUpper() : value; OnPropertyChanged("Designation"); }
        }

        public ObservableCollection<string> DesignationList { get; set; }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = (value != null) ? value.ToUpper() : value; OnPropertyChanged("Subject"); }
        }

        public ObservableCollection<string> SubjectList { get; set; }

        private int[] _ddRt;
        public int[] DDRt
        {
            get { return _ddRt; }
            set { _ddRt = value; OnPropertyChanged("DDRt"); }
        }

        private int _dorYYIndex;
        public int DorYYIndex
        {
            get { return _dorYYIndex; }
            set
            {
                _dorYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DorYYIndex");
                DDRt = FillDateInMonth(DorYYIndex, DorMMIndex);
            }
        }

        private int _dorMMIndex;
        public int DorMMIndex
        {
            get { return _dorMMIndex; }
            set
            {
                _dorMMIndex = (value > -1 && value < MM.Length) ? value : -1;
                OnPropertyChanged("DorMMIndex");
                DDRt = FillDateInMonth(DorYYIndex, DorMMIndex);
            }
        }

        private int _dorDDIndex;
        public int DorDDIndex
        {
            get { return _dorDDIndex; }
            set { _dorDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DorDDIndex"); }
        }

        
        /// <summary>
        /// bill type or salary source
        /// </summary>
        private string _salarySource;
        public string SalarySource
        {
            get { return _salarySource; }
            set { _salarySource = (value != null) ? value.ToUpper() : value; OnPropertyChanged("SalarySource"); }
        }

        public ObservableCollection<string> SalarySourceList { get; set; }

        private int[] _ddJn;
        public int[] DDJn
        {
            get { return _ddJn; }
            set { _ddJn = value; OnPropertyChanged("DDJn"); }
        }

        private int _dojYYIndex;
        public int DojYYIndex
        {
            get { return _dojYYIndex; }
            set
            {
                _dojYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DojYYIndex");
                DDJn = FillDateInMonth(DojYYIndex, DojMMIndex);
            }
        }

        private int _dojMMIndex;
        public int DojMMIndex
        {
            get { return _dojMMIndex; }
            set
            {
                _dojMMIndex = (value > -1 && value < MM.Length) ? value : -1;
                OnPropertyChanged("DojMMIndex");
                DDJn = FillDateInMonth(DojYYIndex, DojMMIndex);
            }
        }

        private int _dojDDIndex;
        public int DojDDIndex
        {
            get { return _dojDDIndex; }
            set { _dojDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DojDDIndex"); }
        }

        private string _empGroup;
        public string EmpGroup
        {
            get { return _empGroup; }
            set { _empGroup = value; OnPropertyChanged("EmpGroup"); }
        }

        public ObservableCollection<string> EmpGroupList { get; set; }

        private string _apprvQualification;
        public string ApprvQualification
        {
            get { return _apprvQualification; }
            set { _apprvQualification = value; OnPropertyChanged("ApprvQualification"); }
        }

        public ObservableCollection<string> ApprvQualificationList { get; set; }

        private string _adlQualification;
        public string AdlQualification
        {
            get { return _adlQualification; }
            set { _adlQualification = value; OnPropertyChanged("AdlQualification"); }
        }

        private int _gradePay;
        public int GradePay
        {
            get { return _gradePay; }
            set { _gradePay = value; OnPropertyChanged("GradePay"); }
        }

        private int _basicPay;
        public int BasicPay
        {
            get { return _basicPay; }
            set { _basicPay = value; OnPropertyChanged("BasicPay"); }
        }

        private string _academicSection;
        public string AcademicSection
        {
            get { return _academicSection; }
            set { _academicSection = value; OnPropertyChanged("AcademicSection"); }
        }

        private string _payScale;
        public string PayScale
        {
            get { return _payScale; }
            set { _payScale = value; OnPropertyChanged("PayScale"); }
        }


        private string _apprvApntNo;
        public string ApprvApntNo
        {
            get { return _apprvApntNo; }
            set { _apprvApntNo = value; OnPropertyChanged("ApprvApntNo"); }
        }

        private int[] _ddIncr;
        public int[] DDIncr
        {
            get { return _ddIncr; }
            set { _ddIncr = value; OnPropertyChanged("DDIncr"); }
        }

        private int _doIncrYYIndex;
        public int DoIncrYYIndex
        {
            get { return _doIncrYYIndex; }
            set
            {
                _doIncrYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DoIncrYYIndex");
                DDIncr = FillDateInMonth(DoIncrYYIndex, DoIncrMMIndex);
            }
        }

        private int _doIncrMMIndex;
        public int DoIncrMMIndex
        {
            get { return _doIncrMMIndex; }
            set
            {
                _doIncrMMIndex = (value > -1 && value < MM.Length) ? value : -1;
                OnPropertyChanged("DoIncrMMIndex");
                DDIncr = FillDateInMonth(DoIncrYYIndex, DoIncrMMIndex);
            }
        }

        private int _doIncrDDIndex;
        public int DoIncrDDIndex
        {
            get { return _doIncrDDIndex; }
            set { _doIncrDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DoIncrDDIndex"); }
        }



        private int[] _ddAad;
        public int[] DDAad
        {
            get { return _ddAad; }
            set { _ddAad = value; OnPropertyChanged("DDAad"); }
        }

        private int _doAadYYIndex;
        public int DoAadYYIndex
        {
            get { return _doAadYYIndex; }
            set
            {
                _doAadYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DoAadYYIndex");
                DDAad = FillDateInMonth(DoAadYYIndex, DoAadMMIndex);
            }
        }

        private int _doAadMMIndex;
        public int DoAadMMIndex
        {
            get { return _doAadMMIndex; }
            set
            {
                _doAadMMIndex = (value > -1 && value < MM.Length) ? value : -1;
                OnPropertyChanged("DoAadMMIndex");
                DDAad = FillDateInMonth(DoAadYYIndex, DoAadMMIndex);
            }
        }

        private int _doAadDDIndex;
        public int DoAadDDIndex
        {
            get { return _doAadDDIndex; }
            set { _doAadDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DoAadDDIndex"); }
        }

        private int _incrementAmount;
        public int IncrementAmount
        {
            get { return _incrementAmount; }
            set { _incrementAmount = value; OnPropertyChanged("IncrementAmount"); }
        }

        private int _payInPayBand;
        public int PayInPayBand
        {
            get { return _payInPayBand; }
            set { _payInPayBand = value; OnPropertyChanged("PayInPayBand"); }
        }

        private string _payBand;
        public string PayBand
        {
            get { return _payBand; }
            set { _payBand =(value != null) ? value.ToUpper() : value; OnPropertyChanged("PayBand"); }
        }

        public ObservableCollection<string> PayBandList { get; set; }

        #endregion

        #region bank
        private ObservableCollection<BankBranch> _branchList;
        public ObservableCollection<BankBranch> BranchList
        {
            get { return _branchList; }
            set { _branchList = value; OnPropertyChanged("BranchList"); }
        }

        private string _accountNo;
        public string AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; OnPropertyChanged("AccountNo"); }
        }

        private string _ifsc;
        public string IFSC
        {
            get { return _ifsc; }
            set { _ifsc = value; OnPropertyChanged("IFSC"); }
        }

        private string _bankName;
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = (value != null) ? value.ToUpper() : value; OnPropertyChanged("BankName"); }
        }

        private string _bankBranch;
        public string BankBranch
        {
            get { return _bankBranch; }
            set { _bankBranch = value; OnPropertyChanged("BankBranch"); }
        }

        private string _micr;
        public string MICR
        {
            get { return _micr; }
            set { _micr = value; OnPropertyChanged("MICR"); }
        }

        private string _branchCode;
        public string BranchCode
        {
            get { return _branchCode; }
            set { _branchCode = value; OnPropertyChanged("BranchCode"); }
        }


        #endregion


        #region method

        private void StartUpInit()
        {
            ComboCalendarInitializer();
            DobYYIndex = DobMMIndex = DobDDIndex = -1;
            Sex = new string[] { "Male", "Female"};
            SexIndex = -1;
            SocialCategory = new string[] { "GEN", "SC", "ST", "OBC", "OBC-A", "OBC-B"};
            SocialCategoryIndex = -1;
            Vacancy = new ObservableCollection<string>();
            DesignationList = new ObservableCollection<string>();
            SubjectList = new ObservableCollection<string>();
            SalarySourceList = new ObservableCollection<string>();
            EmpGroupList = new ObservableCollection<string>();
            ApprvQualificationList = new ObservableCollection<string>();
            PayBandList = new ObservableCollection<string>();
            UpdateDistinctList();


            BranchList = new ObservableCollection<BankBranch>();
        }

        private void ComboCalendarInitializer()
        {
            MM = new string[] { "JAN (01)", "FEB (02)", "MAR (03)", "APR (04)", "MAY (05)", "JUN (06)", "JUL (07)", "AUG (08)", "SEP (09)", "OCT (10)", "NOV (11)", "DEC (12)" };
            DD = new int[] { };
            DDRt = new int[] { };
            DDIncr = new int[] { };
            DDAad = new int[] { };

            YYYY = new int[63];
            int dobStartYear = DateTime.Today.Year;
            for (int i = 0; i <= 62; i++)
            {
                YYYY[i] = dobStartYear - i;
            }
            DobYYIndex = DobMMIndex = DobDDIndex = -1;
            DorYYIndex = DorMMIndex = DorDDIndex = -1;
            DojYYIndex = DojMMIndex = DojDDIndex = -1;
            DoIncrYYIndex = DoIncrMMIndex = DoIncrDDIndex = -1;
            DoAadYYIndex = DoAadMMIndex = DoAadDDIndex = -1;
        }

        private int[] FillDateInMonth(int yearIndex, int monthIndex)
        {
            int[] dd = new int[] { };
            if (yearIndex == -1 || monthIndex == -1)
            {
                return dd;
            }
            else
            {
                dd = DateHelper.FillMonthDates(YYYY[yearIndex], month: monthIndex +1);
            }
            return dd;
        }

        private void UpdateDistinctList()
        {
            StaffAddDb db = new StaffAddDb();
            ObservableCollection<string> xList = new ObservableCollection<string>();

            xList = db.GetDistinctList(Models.StaffColName.VacancyStatus);
            if (xList.Count > 0)
            {
                Vacancy = xList;
            }
            else
            {
                Vacancy.Add("PERMANENT");
            }

            xList = db.GetDistinctList(Models.StaffColName.Designation);
            if (xList.Count > 0)
            {
                DesignationList = xList;
            }
            else
            {
                DesignationList.Add("AT");
            }

            xList = db.GetDistinctList(Models.StaffColName.Subject);
            SubjectList = xList;

            xList = db.GetDistinctList(Models.StaffColName.SalarySource);
            if (xList.Count > 0)
            {
                SalarySourceList = xList;
            }
            else
            {
                SalarySourceList.Add("SSA SCHOOL");
            }

            // xList = db.GetDistinctList(Models.StaffColName.EmployeeGroup);
            xList = new ObservableCollection<string>();
            if (xList.Count > 0)
            {
                EmpGroupList = xList;
            }
            else
            {
                EmpGroupList.Add("Gr-A");
            }

            //  xList = db.GetDistinctList(Models.StaffColName.ApprvQualification);
            xList = new ObservableCollection<string>();
            if (xList.Count > 0)
            {
                ApprvQualificationList = xList;
            }
            else
            {
                ApprvQualificationList.Add("GRADUATE");
                ApprvQualificationList.Add("POST GRADUATE");
            }

            xList = db.GetDistinctList(Models.StaffColName.PayBand);
            if (xList.Count > 0)
            {
                PayBandList = xList;
            }
            else
            {
                PayBandList.Add("PB4");
            }
        }
        #endregion

    }
}
