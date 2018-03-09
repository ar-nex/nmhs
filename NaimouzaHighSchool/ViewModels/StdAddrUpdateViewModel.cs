using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Database;



namespace NaimouzaHighSchool.ViewModels
{
    public class StdAddrUpdateViewModel : BaseViewModel
    {
        public StdAddrUpdateViewModel()
            : base()
        {
            StartUpInitializer();
        }


        private int _startYear;
        public int StartYear
        {
            get { return _startYear; }
            set { _startYear = value; OnPropertyChanged("StartYear"); }
        }

        private int _endYear;
        public int EndYear
        {
            get { return _endYear; }
            set { _endYear = value; OnPropertyChanged("EndYear"); }
        }

        private string[] _sclClass;
        public string[] SclClass
        {
            get { return _sclClass; }
            set { _sclClass = value; OnPropertyChanged("SclClass"); }
        }

        private string[] _sclSection;
        public string[] SclSection
        {
            get { return _sclSection; }
            set { _sclSection = value; OnPropertyChanged("SclSection"); }
        }


        private int _sclClassIndex;
        public int SclClassIndex
        {
            get { return _sclClassIndex; }
            set
            {
                if (value > -1 && value < SclClass.Length)
                {
                    _sclClassIndex = value;
                }
                else
                {
                    _sclClassIndex = -1;
                }
                OnPropertyChanged("SclClassIndex");
            }
        }

        private int _sclSectionIndex;
        public int SclSectionIndex
        {
            get { return _sclSectionIndex; }
            set
            {
                _sclSectionIndex = (value > -1 && value < SclSection.Length) ? value : -1;
                OnPropertyChanged("SclSectionIndex");
            }
        }

        private string _condPresentAddr;
        public string CondPresentAddr
        {
            get { return _condPresentAddr; }
            set { _condPresentAddr = value; OnPropertyChanged("CondPresentAddr"); }
        }


        private string _condPermanentAddr;
        public string CondPermanentAddr
        {
            get { return _condPermanentAddr; }
            set { _condPermanentAddr = value; OnPropertyChanged("CondPermanentAddr"); }
        }

        private string _prsntAddr1;
        public string PrsntAddr1
        {
            get { return _prsntAddr1; }
            set
            {
                _prsntAddr1 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrsntAddr1");
            }
        }

        private string _prsntAddr2;
        public string PrsntAddr2
        {
            get { return _prsntAddr2; }
            set
            {
                _prsntAddr2 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrsntAddr2");
            }
        }

        private string _prsntPO;
        public string PrsntPO
        {
            get { return _prsntPO; }
            set
            {
                _prsntPO = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrsntPO");
            }
        }

        private string _prsntPS;
        public string PrsntPS
        {
            get { return _prsntPS; }
            set
            {
                _prsntPS = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrsntPS");
            }
        }

        private string _prsntDist;
        public string PrsntDist
        {
            get { return _prsntDist; }
            set
            {
                _prsntDist = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrsntDist");
            }
        }

        private string _prsntPin;
        public string PrsntPin
        {
            get { return _prsntPin; }
            set
            {
                _prsntPin = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrsntPin");
            }
        }

        private string _prmtAddr1;
        public string PrmtAddr1
        {
            get { return _prmtAddr1; }
            set
            {
                _prmtAddr1 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrmtAddr1");
            }
        }

        private string _prmtAddr2;
        public string PrmtAddr2
        {
            get { return _prmtAddr2; }
            set
            {
                _prmtAddr2 = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrmtAddr2");
            }
        }

        private string _prmtPO;
        public string PrmtPO
        {
            get { return _prmtPO; }
            set
            {
                _prmtPO = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrmtPO");
            }
        }

        private string _prmtPS;
        public string PrmtPS
        {
            get { return _prmtPS; }
            set
            {
                _prmtPS = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrmtPS");
            }
        }

        private string _prmtDist;
        public string PrmtDist
        {
            get { return _prmtDist; }
            set
            {
                _prmtDist = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrmtDist");
            }
        }

        private string _prmtPin;
        public string PrmtPin
        {
            get { return _prmtPin; }
            set
            {
                _prmtPin = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("PrmtPin");
            }
        }

        private ObservableCollection<string> _prsntAddr1List;
        public ObservableCollection<string> PrsntAddr1List
        {
            get { return _prsntAddr1List; }
            set { _prsntAddr1List = value; OnPropertyChanged("PrsntAddr1List"); }
        }

        private ObservableCollection<string> _prsntAddr2List;
        public ObservableCollection<string> PrsntAddr2List
        {
            get { return _prsntAddr2List; }
            set { _prsntAddr2List = value; OnPropertyChanged("PrsntAddr2List"); }
        }
        private ObservableCollection<string> _prsntAddrPOList;
        public ObservableCollection<string> PrsntAddrPOList
        {
            get { return _prsntAddrPOList; }
            set { _prsntAddrPOList = value; OnPropertyChanged("PrsntAddrPOList"); }
        }
        private ObservableCollection<string> _prsntAddrPSList;
        public ObservableCollection<string> PrsntAddrPSList
        {
            get { return _prsntAddrPSList; }
            set { _prsntAddrPSList = value; OnPropertyChanged("PrsntAddrPSList"); }
        }
        private ObservableCollection<string> _prsntAddrDistList;
        public ObservableCollection<string> PrsntAddrDistList
        {
            get { return _prsntAddrDistList; }
            set { _prsntAddrDistList = value; OnPropertyChanged("PrsntAddrDistList"); }
        }
        private ObservableCollection<string> _prsntAddrPinList;
        public ObservableCollection<string> PrsntAddrPinList
        {
            get { return _prsntAddrPinList; }
            set { _prsntAddrPinList = value; OnPropertyChanged("PrsntAddrPinList"); }
        }

        // present
        private ObservableCollection<string> _prmtAddr1List;
        public ObservableCollection<string> PrmtAddr1List
        {
            get { return _prmtAddr1List; }
            set { _prmtAddr1List = value; OnPropertyChanged("PrmtAddr1List"); }
        }
        private ObservableCollection<string> _prmtAddr2List;
        public ObservableCollection<string> PrmtAddr2List
        {
            get { return _prmtAddr2List; }
            set { _prmtAddr2List = value; OnPropertyChanged("PrmtAddr2List"); }
        }
        private ObservableCollection<string> _prmtAddrPOList;
        public ObservableCollection<string> PrmtAddrPOList
        {
            get { return _prmtAddrPOList; }
            set { _prmtAddrPOList = value; OnPropertyChanged("PrmtAddrPOList"); }
        }
        private ObservableCollection<string> _prmtAddrPSList;
        public ObservableCollection<string> PrmtAddrPSList
        {
            get { return _prmtAddrPSList; }
            set { _prmtAddrPSList = value; OnPropertyChanged("PrmtAddrPSList"); }
        }
        private ObservableCollection<string> _prmtAddrDistList;
        public ObservableCollection<string> PrmtAddrDistList
        {
            get { return _prmtAddrDistList; }
            set { _prmtAddrDistList = value; OnPropertyChanged("PrmtAddrDistList"); }
        }
        private ObservableCollection<string> _prmtAddrPinList;
        public ObservableCollection<string> PrmtAddrPinList
        {
            get { return _prmtAddrPinList; }
            set { _prmtAddrPinList = value; OnPropertyChanged("PrmtAddrPinList"); }
        }



        private ObservableCollection<Student> _studentList;
        public ObservableCollection<Student> StudentList
        {
            get { return _studentList; }
            set { _studentList = value; OnPropertyChanged("StudentList"); }
        }

        private int _studentListIndex;
        public int StudentListIndex
        {
            get { return _studentListIndex; }
            set
            {
                _studentListIndex = (value > -1 && value < StudentList.Count) ? value : -1;
                OnPropertyChanged("StudentListIndex");
                RepaintAddress();
            }
        }

        private string _msg;

        public string Msg
        {
            get { return _msg; }
            set { _msg = value; OnPropertyChanged("Msg"); }
        }

        private bool _sameBothAddress;

        public bool SameBothAddress
        {
            get { return _sameBothAddress; }
            set
            {
                _sameBothAddress = value;
                OnPropertyChanged("SameBothAddress");
                if (value)
                {
                    PrmtAddr1 = PrsntAddr1;
                    PrmtAddr2 = PrsntAddr2;
                    PrmtPO = PrsntPO;
                    PrmtPS = PrsntPS;
                    PrmtDist = PrsntDist;
                    PrmtPin = PrsntPin;
                }
                else
                {
                    PrmtAddr1 = string.Empty;
                    PrmtAddr2 = string.Empty;
                    PrmtPO = string.Empty;
                }
            }
        }


        public RelayCommand GetStudentCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        private void StartUpInitializer()
        {
            StdAddressUpdateDb db = new StdAddressUpdateDb();
            StartYear = EndYear = DateTime.Now.Year;
            SclClass = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            SclSection = new string[] { "A", "B", "C", "D", "E"};
            SclClassIndex = SclSectionIndex = -1;
            StudentList = new ObservableCollection<Student>();

            PrsntAddr1List = db.GetUniqueAddrLaneX(Models.SplitAddrX.AddrLane1);
            PrsntAddr2List = db.GetUniqueAddrLaneX(Models.SplitAddrX.AddrLane2);
            PrsntAddrPOList = db.GetUniqueAddrLaneX(Models.SplitAddrX.PO);
            PrsntAddrPSList = db.GetUniqueAddrLaneX(Models.SplitAddrX.PS);
            PrsntAddrDistList = db.GetUniqueAddrLaneX(Models.SplitAddrX.Dist);
            PrsntAddrPinList = db.GetUniqueAddrLaneX(Models.SplitAddrX.PIN);

            PrmtAddr1List = db.GetUniqueAddrLaneX(Models.SplitAddrX.AddrLane1);
            PrmtAddr2List = db.GetUniqueAddrLaneX(Models.SplitAddrX.AddrLane2);
            PrmtAddrPOList = db.GetUniqueAddrLaneX(Models.SplitAddrX.PO);
            PrmtAddrPSList = db.GetUniqueAddrLaneX(Models.SplitAddrX.PS);
            PrmtAddrDistList = db.GetUniqueAddrLaneX(Models.SplitAddrX.Dist);
            PrmtAddrPinList = db.GetUniqueAddrLaneX(Models.SplitAddrX.PIN);

            StudentListIndex = -1;
            GetStudentCommand = new RelayCommand(GetStudent, CanGetStudent);
            SaveChangesCommand = new RelayCommand(SaveChanges, CanSaveCanges);
        }

        private void GetStudent()
        {
            StdAddressUpdateDb db = new StdAddressUpdateDb();
            StudentList = db.GetStudentAddressData(startYear: StartYear, endYear: EndYear, cls: SclClass[SclClassIndex], section: SclSection[SclSectionIndex]);
            
        }
        private bool CanGetStudent()
        {
            bool valYear = StartYear > 2016 && StartYear <= DateTime.Now.Year + 2 && EndYear > 2016 && EndYear <= DateTime.Now.Year + 2;
            bool valAcademi = SclClassIndex > -1 && SclClassIndex < SclClass.Length && SclSectionIndex > -1 && SclSectionIndex < SclSection.Length;
            return valYear && valAcademi;
        }


        private void Reset()
        {
            PrsntAddr1 = PrsntAddr2 = PrsntPO = PrsntPS = PrsntDist = PrsntPin = string.Empty;
            PrmtAddr1 = PrmtAddr2 = PrmtPO = PrmtPS = PrmtDist = PrmtPin = string.Empty;
         //   Msg = string.Empty;
        }
        private void DoEmptyList()
        {

        }

        private void RepaintAddress()
        {
            if (StudentListIndex == -1)
            {
                return;
            }
            else
            {
                Reset();
                Student s = StudentList[StudentListIndex];
                CondPresentAddr = s.PresentAdrress;
                CondPermanentAddr = s.PermanentAddress;

                // present split address
                if (!string.IsNullOrEmpty(s.PstAddrLane1))
                {
                    PrsntAddr1 = s.PstAddrLane1;
                }
                if (!string.IsNullOrEmpty(s.PstAddrLane2))
                {
                    PrsntAddr2 = s.PstAddrLane2;
                }
                if (!string.IsNullOrEmpty(s.PstAddrPO))
                {
                    PrsntPO = s.PstAddrPO;
                }
                if (!string.IsNullOrEmpty(s.PstAddrPS))
                {
                    PrsntPS = s.PstAddrPS;
                }
                if (!string.IsNullOrEmpty(s.PstAddrDist))
                {
                    PrsntDist = s.PstAddrDist;
                }
                if (!string.IsNullOrEmpty(s.PstAddrPin))
                {
                    PrsntPin = s.PstAddrPin;
                }

                // permanent split address
                if (!string.IsNullOrEmpty(s.PmtAddrLane1))
                {
                    PrmtAddr1 = s.PmtAddrLane1;
                }
                if (!string.IsNullOrEmpty(s.PmtAddrLane2))
                {
                    PrmtAddr2 = s.PmtAddrLane2;
                }
                if (!string.IsNullOrEmpty(s.PmtAddrPO))
                {
                    PrmtPO = s.PmtAddrPO;
                }
                if (!string.IsNullOrEmpty(s.PmtAddrPS))
                {
                    PrmtPS = s.PmtAddrPS;
                }
                if (!string.IsNullOrEmpty(s.PmtAddrDist))
                {
                    PrmtDist = s.PmtAddrDist;
                }
                if (!string.IsNullOrEmpty(s.PmtAddrPin))
                {
                    PrmtPin = s.PmtAddrPin;
                }
            }
        }

        private void SaveChanges()
        {
            StdAddressUpdateDb db = new StdAddressUpdateDb();
            Student s = StudentList[StudentListIndex];
            s.PstAddrLane1 = PrsntAddr1;
            s.PstAddrLane2 = PrsntAddr2;
            s.PstAddrPO = PrsntPO;
            s.PstAddrDist = PrsntDist;
            s.PstAddrPin = PrsntPin;

            s.PmtAddrLane1 = PrmtAddr1;
            s.PmtAddrLane2 = PrmtAddr2;
            s.PmtAddrPO = PrmtPO;
            s.PmtAddrPS = PrmtPS;
            s.PmtAddrDist = PrmtDist;
            s.PmtAddrPin = PrmtPin;

            if (db.UpdateSplitAddress(s))
            {
                Msg = s.Name +"'s address updated successfully.";
                if (StudentListIndex+1 < StudentList.Count)
                {
                    StudentListIndex++;
                    SameBothAddress = false;
                }
            }
            else
            {
                Msg = "Sorry! failed to update";
            }
        }

        private bool CanSaveCanges()
        {
            return StudentListIndex != -1;
        }

    }
}
