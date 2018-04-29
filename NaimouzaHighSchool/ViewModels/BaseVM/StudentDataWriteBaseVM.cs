using NaimouzaHighSchool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.ViewModels.BaseVM
{
    public class StudentDataWriteBaseVM : StudentClassBaseVM
    {
        public StudentDataWriteBaseVM()
            : base()
        {
            StartUpInitializer();
        }

        #region property
        //General
        #region generalproperty

        private string _stdName;
        public string StdName
        {
            get { return _stdName; }
            set
            {
                _stdName = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("StdName");
            }
        }

        private int _stdRoll;
        public int StdRoll
        {
            get { return _stdRoll; }
            set { _stdRoll = (value > 0 && value < 1500) ? value : 0; OnPropertyChanged("StdRoll"); }
        }

        private string[] _sex;
        public string[] Sex
        {
            get { return this._sex; }
            set { this._sex = value; this.OnPropertyChanged("Sex"); }
        }

        private int _sexIndex;
        public int SexIndex
        {
            get { return _sexIndex; }
            set { _sexIndex = (value > -1 && value < Sex.Length) ? value : -1; OnPropertyChanged("SexIndia"); }
        }

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

        public string[] Stream { get; set; }

        private int _streamIndex;
        public int StreamIndex
        {
            get { return _streamIndex; }
            set
            {
                _streamIndex = (value > -1 && value < Stream.Length) ? value : -1;
                OnPropertyChanged("StreamIndex");
                UpdateHsSubs(value);
            }
        }

        private string[] _hsArtsSubs;
        public string[] HsArtsSubs
        {
            get { return _hsArtsSubs; }
            set { _hsArtsSubs = value; OnPropertyChanged("HsArtsSubs"); }
        }

        private string[] _hsSciSubs;
        public string[] HsSciSubs
        {
            get { return _hsSciSubs; }
            set { _hsSciSubs = value; OnPropertyChanged("HsSciSubs"); }
        }

        private string[] _hsActiveSubs;
        public string[] HsActiveSubs
        {
            get { return _hsActiveSubs; }
            set { _hsActiveSubs = value; OnPropertyChanged("HsActiveSubs"); }
        }

        private string[] _hsActiveSubs1;
        public string[] HsActiveSubs1
        {
            get { return _hsActiveSubs1; }
            set { _hsActiveSubs1 = value; OnPropertyChanged("HsActiveSubs1"); }
        }

        private ObservableCollection<string> _hsActiveSubs2;
        public ObservableCollection<string> HsActiveSubs2
        {
            get { return _hsActiveSubs2; }
            set { _hsActiveSubs2 = value; OnPropertyChanged("HsActiveSubs2"); }
        }

        private ObservableCollection<string> _hsActiveSubs3;
        public ObservableCollection<string> HsActiveSubs3
        {
            get { return _hsActiveSubs3; }
            set { _hsActiveSubs3 = value; OnPropertyChanged("HsActiveSubs3"); }
        }

        private ObservableCollection<string> _hsActiveSubs4;
        public ObservableCollection<string> HsActiveSubs4
        {
            get { return _hsActiveSubs4; }
            set { _hsActiveSubs4 = value; OnPropertyChanged("HsActiveSubs4"); }
        }

        private int _hsSub1Index;
        public int HsSub1Index
        {
            get { return _hsSub1Index; }
            set { _hsSub1Index = value; OnPropertyChanged("HsSub1Index"); TrimHsSubs(2); }
        }

        private int _hsSub2Index;
        public int HsSub2Index
        {
            get { return _hsSub2Index; }
            set { _hsSub2Index = value; OnPropertyChanged("HsSub2Index"); TrimHsSubs(3); }
        }

        private int _hsSub3Index;
        public int HsSub3Index
        {
            get { return _hsSub3Index; }
            set { _hsSub3Index = value; OnPropertyChanged("HsSub3Index"); TrimHsSubs(4); }
        }

        private int _hsSub4Index;
        public int HsSub4Index
        {
            get { return _hsSub4Index; }
            set { _hsSub4Index = value; OnPropertyChanged("HsSub4Index"); }
        }

        private System.Windows.Visibility _sub5Visibility;
        public System.Windows.Visibility Sub5Visibility
        {
            get { return _sub5Visibility; }
            set { _sub5Visibility = value; OnPropertyChanged("Sub5Visibility"); }
        }

        private System.Windows.Visibility _subHsVisibility;
        public System.Windows.Visibility SubHsVisibility
        {
            get { return _subHsVisibility; }
            set { _subHsVisibility = value; OnPropertyChanged("SubHsVisibility"); }
        }

        #endregion

        #region guardian
        private string _fatherName;
        public string FatherName
        {
            get { return this._fatherName; }
            set
            {
                this._fatherName = (value != null) ? value.ToUpper() : value;
                this.OnPropertyChanged("FatherName");
            }
        }

        private string _motherName;
        public string MotherName
        {
            get { return this._motherName; }
            set { this._motherName = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("MotherName"); }
        }

        private string _guardianName;
        public string GuardianName
        {
            get { return this._guardianName; }
            set { this._guardianName = (value != null) ? value.ToUpper() : value; this.OnPropertyChanged("GuardianName"); }
        }

        private bool _isGuardianFather;
        public bool IsGuardianFather
        {
            get { return _isGuardianFather; }
            set
            {
                _isGuardianFather = value;
                OnPropertyChanged("IsGuardianFather");
                if (value)
                {
                    GuardianName = FatherName;
                    RelationWithGuardian = "Father";
                }
                else
                {
                    GuardianName = RelationWithGuardian = string.Empty;
                }
            }
        }

        private string _relationWithGuardian;
        public string RelationWithGuardian
        {
            get { return this._relationWithGuardian; }
            set
            {
                this._relationWithGuardian = (value != null) ? value.ToUpper() : value;
                if (value != null)
                {
                    if (value.ToLower() == "fa")
                    {
                        _relationWithGuardian = "FATHER";
                    }
                    else if (value.ToLower() == "mo")
                    {
                        _relationWithGuardian = "MOTHER";
                    }

                }
                this.OnPropertyChanged("RelationWithGuardian");
            }
        }

        private string _occupation;
        public string Occupation
        {
            get { return this._occupation; }
            set
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                this._occupation = myTI.ToTitleCase(value);
                this.OnPropertyChanged("Occupation");
            }
        }

        private int _annualIncome;
        public int AnnualIncome
        {
            get { return this._annualIncome; }
            set { this._annualIncome = value; this.OnPropertyChanged("AnnualIncome"); }
        }

        private string _guardianAadhar;
        public string GuardianAadhar
        {
            get { return this._guardianAadhar; }
            set { this._guardianAadhar = value; this.OnPropertyChanged("GuardianAadhar"); }
        }

        private string _voterCardNo;
        public string VoterCardNo
        {
            get { return this._voterCardNo; }
            set
            {
                this._voterCardNo = (value != null) ? value.ToUpper() : value;
                this.OnPropertyChanged("VoterCardNo");
            }
        }
        #endregion

        #endregion

        #region method

        private void StartUpInitializer()
        {
            Sex = new string[] { "Male", "Female" };
            SexIndex = -1;

            Sub5Visibility = System.Windows.Visibility.Collapsed;
            SubHsVisibility = System.Windows.Visibility.Collapsed;

            Stream = new string[] { "ARTS", "SCIENCE" };
            StreamIndex = -1;

            ComboCalendarInitializer();
            HsSubsInitializer();
        }

        /// <summary>
        /// 
        /// </summary>
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

        private void UpdateHsSubs(int value)
        {
            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;
            if (value == -1)
            {
                //  Array.Clear(HsActiveSubs, 0, HsActiveSubs.Length);
            }
            else
            {
                if (Stream[StreamIndex] == "ARTS")
                {
                    HsActiveSubs = HsArtsSubs;
                }
                else if (Stream[StreamIndex] == "SCIENCE")
                {
                    HsActiveSubs = HsSciSubs;
                }
                else
                {
                    Array.Clear(HsActiveSubs, 0, HsActiveSubs.Length);
                }
                HsActiveSubs1 = HsActiveSubs;
            }
        }

        private void TrimHsSubs(int subNo)
        {
            switch (subNo)
            {
                case 2:
                    if (HsActiveSubs2 != null && HsActiveSubs2.Count > 0)
                    {
                        HsActiveSubs2.Clear();
                    }
                    if (HsSub1Index != -1)
                    {
                        string sub1 = HsActiveSubs1[HsSub1Index];
                        if (sub1 == "ARABIC" || sub1 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs1)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs2.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs1)
                            {
                                if (item == sub1)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs2.Add(item);
                                }
                            }
                        }
                    }
                    break;

                case 3:
                    if (HsActiveSubs3 != null && HsActiveSubs3.Count > 0)
                    {
                        HsActiveSubs3.Clear();
                    }
                    if (HsSub2Index != -1)
                    {
                        string sub2 = HsActiveSubs2[HsSub2Index];
                        if (sub2 == "ARABIC" || sub2 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs2)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs3.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs2)
                            {
                                if (item == sub2)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs3.Add(item);
                                }
                            }
                        }
                    }
                    break;

                case 4:
                    if (HsActiveSubs4 != null && HsActiveSubs4.Count > 0)
                    {
                        HsActiveSubs4.Clear();
                    }
                    if (HsSub3Index != -1)
                    {
                        string sub3 = HsActiveSubs3[HsSub3Index];
                        if (sub3 == "ARABIC" || sub3 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs3)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs4.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs3)
                            {
                                if (item == sub3)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs4.Add(item);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void HsSubsInitializer()
        {
            HsArtsSubs = GlobalVar.HsArtsSubs;
            HsSciSubs = GlobalVar.HsSciSubs;
            HsActiveSubs = new string[] { };
            HsActiveSubs1 = new string[] { };
            HsActiveSubs2 = new ObservableCollection<string>();
            HsActiveSubs3 = new ObservableCollection<string>();
            HsActiveSubs4 = new ObservableCollection<string>();

            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;
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

            YYYY = new int[20];
            int dobStartYear = DateTime.Today.Year - 5;
            for (int i = 0; i <= 19; i++)
            {
                YYYY[i] = dobStartYear - i;
            }
            DobYYIndex = DobMMIndex = DobDDIndex = -1;
        }
        #endregion
    }
}
