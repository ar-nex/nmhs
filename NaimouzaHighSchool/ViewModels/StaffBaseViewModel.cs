using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;

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

        private int[] _dd28;
        public int[] DD28
        {
            get { return _dd28; }
            set { _dd28 = value; OnPropertyChanged("DD28"); }
        }

        private int[] _dd29;
        public int[] DD29
        {
            get { return _dd29; }
            set { _dd29 = value; OnPropertyChanged("DD29"); }
        }

        private int[] _dd30;
        public int[] DD30
        {
            get { return _dd30; }
            set { _dd30 = value; OnPropertyChanged("DD30"); }
        }

        private int[] _dd31;
        public int[] DD31
        {
            get { return _dd31; }
            set { _dd31 = value; OnPropertyChanged("DD31"); }
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
                UpdateDaysInMonth();
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
                UpdateDaysInMonth();
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

        private int _dorYYIndex;
        public int DorYYIndex
        {
            get { return _dorYYIndex; }
            set
            {
                _dobYYIndex = (value > -1 && value < YYYY.Length) ? value : -1;
                OnPropertyChanged("DorYYIndex");
                UpdateDaysInMonth();
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
                UpdateDaysInMonth();
            }
        }

        private int _dorDDIndex;
        public int DorDDIndex
        {
            get { return _dorDDIndex; }
            set { _dorDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DorDDIndex"); }
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
            UpdateDistinctList();
            
        }

        private void ComboCalendarInitializer()
        {
            MM = new string[] { "JAN (01)", "FEB (02)", "MAR (03)", "APR (04)", "MAY (05)", "JUN (06)", "JUL (07)", "AUG (08)", "SEP (09)", "OCT (10)", "NOV (11)", "DEC (12)" };
            DD = new int[] { };
            DD28 = new int[28];
            for (int i = 0; i < 28; i++)
            {
                DD28[i] = i + 1;
            }

            DD29 = new int[29];
            for (int i = 0; i < 29; i++)
            {
                DD29[i] = i + 1;
            }

            DD30 = new int[30];
            for (int i = 0; i < 30; i++)
            {
                DD30[i] = i + 1;
            }

            DD31 = new int[31];
            for (int i = 0; i < 31; i++)
            {
                DD31[i] = i + 1;
            }

            YYYY = new int[63];
            int dobStartYear = DateTime.Today.Year;
            for (int i = 0; i <= 62; i++)
            {
                YYYY[i] = dobStartYear - i;
            }
            DobYYIndex = DobMMIndex = DobDDIndex = -1;
        }

        private void UpdateDaysInMonth()
        {
            if (DobYYIndex == -1 || DobMMIndex == -1)
            {
                DD = new int[] { };
            }
            else
            {
                int selecYear = YYYY[DobYYIndex];
                int selecMonth = DobMMIndex + 1;
                int[] month30 = new int[] { 4, 6, 9, 11 };
                int[] month31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
                if (DateTime.IsLeapYear(selecYear))
                {
                    if (selecMonth == 2)
                    {
                        DD = DD29;
                    }
                    else
                    {
                        SetNonFebDays(selecMonth, month30, month31);
                    }
                }
                else
                {
                    if (selecMonth == 2)
                    {
                        DD = DD28;
                    }
                    else
                    {
                        SetNonFebDays(selecMonth, month30, month31);
                    }
                }
            }
        }

        private void SetNonFebDays(int selecMonth, int[] month30, int[] month31)
        {
            if (Array.IndexOf(month30, selecMonth) != -1)
            {
                DD = DD30;
            }
            else if (Array.IndexOf(month31, selecMonth) != -1)
            {
                DD = DD31;
            }
            else
            {
                DD = new int[] { };
            }
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
        }
        #endregion

    }
}
