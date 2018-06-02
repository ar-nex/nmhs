using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;
using System.ComponentModel;

namespace NaimouzaHighSchool.ViewModels
{
    public class PromotionViewModel : StudentClassBaseViewModel
    {
        public PromotionViewModel()
            : base()
        {
            StartUpInitializer();
        }


        private int _newSessionStratYear;
        public int NewSessionStartYear
        {
            get { return _newSessionStratYear; }
            set
            {
                _newSessionStratYear = value;
                OnPropertyChanged("NewSessionStartYear");
                NewSessionHeader = "New Session : " + NewSessionStartYear.ToString() + "-" + NewSessionEndYear.ToString();
            }
        }

        private int _newSessionEndYear;
        public int NewSessionEndYear
        {
            get { return _newSessionEndYear; }
            set
            {
                _newSessionEndYear = value;
                OnPropertyChanged("NewSessionEndYear");
                NewSessionHeader = "New Session : " + NewSessionStartYear.ToString() + "-" + NewSessionEndYear.ToString();
            }
        }

        private string _dupMsg;
        public string DupMsg
        {
            get { return _dupMsg; }
            set { _dupMsg = value; OnPropertyChanged("DupMsg"); }
        }

        private bool _doChangeNewClass;
        public bool DoChangeNewClass
        {
            get { return _doChangeNewClass; }
            set
            {
                _doChangeNewClass = value;
                OnPropertyChanged("DoChangeNewClass");
                NewClassChanged();
            }
        }

        private bool _isNewClassReadOnly;
        public bool IsNewClassReadOnly
        {
            get { return _isNewClassReadOnly; }
            set { _isNewClassReadOnly = value; OnPropertyChanged("IsNewClassReadOnly"); }
        }



        private int _plistIndex;
        public int PlistIndex
        {
            get { return _plistIndex; }
            set { _plistIndex = (value > -1 && value < PromoList.Count) ? value : -1; OnPropertyChanged("PlistIndex"); }
        }

        private string _prevSessionHeader;
        public string PrevSessionHeader
        {
            get { return _prevSessionHeader; }
            set { _prevSessionHeader = value; OnPropertyChanged("PrevSessionHeader"); }
        }

        private string _newSessionHeader;
        public string NewSessionHeader
        {
            get { return _newSessionHeader; }
            set { _newSessionHeader = value; OnPropertyChanged("NewSessionHeader"); }
        }

        private ObservableCollection<Promotion> _promoList;
        public ObservableCollection<Promotion> PromoList
        {
            get { return _promoList; }
            set { _promoList = value; OnPropertyChanged("PromoList"); }
        }
        List<Promotion> SavablePromoList = new List<Promotion>();
        private BackgroundWorker bw = new BackgroundWorker();

        private string _prevSecA;
        public string PrevSecA
        {
            get { return _prevSecA; }
            set { _prevSecA = value; OnPropertyChanged("PrevSecA"); }
        }

        private string _prevSecB;
        public string PrevSecB
        {
            get { return _prevSecB; }
            set { _prevSecB = value; OnPropertyChanged("PrevSecB"); }
        }

        private string _prevSecC;
        public string PrevSecC
        {
            get { return _prevSecC; }
            set { _prevSecC = value; OnPropertyChanged("PrevSecC"); }
        }

        private string _prevSecD;
        public string PrevSecD
        {
            get { return _prevSecD; }
            set { _prevSecD = value; OnPropertyChanged("PrevSecD"); }
        }

        private string _prevSecE;
        public string PrevSecE
        {
            get { return _prevSecE; }
            set { _prevSecE = value; OnPropertyChanged("PrevSecE"); }
        }


        private string _newSecA;
        public string NewSecA
        {
            get { return _newSecA; }
            set { _newSecA = value; OnPropertyChanged("NewSecA"); }
        }

        private string _newSecB;
        public string NewSecB
        {
            get { return _newSecB; }
            set { _newSecB = value; OnPropertyChanged("NewSecB"); }
        }

        private string _newSecC;
        public string NewSecC
        {
            get { return _newSecC; }
            set { _newSecC = value; OnPropertyChanged("NewSecC"); }
        }

        private string _newSecD;
        public string NewSecD
        {
            get { return _newSecD; }
            set { _newSecD = value; OnPropertyChanged("NewSecD"); }
        }

        private string _newSecE;
        public string NewSecE
        {
            get { return _newSecE; }
            set { _newSecE = value; OnPropertyChanged("NewSecE"); }
        }

        private ObservableCollection<PromotionMapping> _oldToNewMapA;
        public ObservableCollection<PromotionMapping> OldToNewMapA
        {
            get { return _oldToNewMapA; }
            set { _oldToNewMapA = value; OnPropertyChanged("OldToNewMapA"); }
        }

        private ObservableCollection<PromotionMapping> _oldToNewMapB;
        public ObservableCollection<PromotionMapping> OldToNewMapB
        {
            get { return _oldToNewMapB; }
            set { _oldToNewMapB = value; OnPropertyChanged("OldToNewMapB"); }
        }

        private ObservableCollection<PromotionMapping> _oldToNewMapC;
        public ObservableCollection<PromotionMapping> OldToNewMapC
        {
            get { return _oldToNewMapC; }
            set { _oldToNewMapC = value; OnPropertyChanged("OldToNewMapC"); }
        }

        private ObservableCollection<PromotionMapping> _oldToNewMapD;
        public ObservableCollection<PromotionMapping> OldToNewMapD
        {
            get { return _oldToNewMapD; }
            set { _oldToNewMapD = value; OnPropertyChanged("OldToNewMapD"); }
        }

        private ObservableCollection<PromotionMapping> _oldToNewMapE;
        public ObservableCollection<PromotionMapping> OldToNewMapE
        {
            get { return _oldToNewMapE; }
            set { _oldToNewMapE = value; OnPropertyChanged("OldToNewMapE"); }
        }

        private ObservableCollection<PromotionMapping> _newFromOldMapA;
        public ObservableCollection<PromotionMapping> NewFromOldMapA
        {
            get { return _newFromOldMapA; }
            set { _newFromOldMapA = value; OnPropertyChanged("NewFromOldMapA"); }
        }

        private ObservableCollection<PromotionMapping> _newFromOldMapB;
        public ObservableCollection<PromotionMapping> NewFromOldMapB
        {
            get { return _newFromOldMapB; }
            set { _newFromOldMapB = value; OnPropertyChanged("NewFromOldMapB"); }
        }

        private ObservableCollection<PromotionMapping> _newFromOldMapC;
        public ObservableCollection<PromotionMapping> NewFromOldMapC
        {
            get { return _newFromOldMapC; }
            set { _newFromOldMapC = value; OnPropertyChanged("NewFromOldMapC"); }
        }

        private ObservableCollection<PromotionMapping> _newFromOldMapD;
        public ObservableCollection<PromotionMapping> NewFromOldMapD
        {
            get { return _newFromOldMapD; }
            set { _newFromOldMapD = value; OnPropertyChanged("NewFromOldMapD"); }
        }

        private ObservableCollection<PromotionMapping> _newFromOldMapE;
        public ObservableCollection<PromotionMapping> NewFromOldMapE
        {
            get { return _newFromOldMapE; }
            set { _newFromOldMapE = value; OnPropertyChanged("NewFromOldMapE"); }
        }

        public RelayCommand GetDataCommand { get; set; }
        public RelayCommand SaveDataCommand { get; set; }


        private void StartUpInitializer()
        {
            PromoList = new ObservableCollection<Promotion>();

            OldToNewMapA = new ObservableCollection<PromotionMapping>();
            OldToNewMapB = new ObservableCollection<PromotionMapping>();
            OldToNewMapC = new ObservableCollection<PromotionMapping>();
            OldToNewMapD = new ObservableCollection<PromotionMapping>();
            OldToNewMapE = new ObservableCollection<PromotionMapping>();

            NewFromOldMapA = new ObservableCollection<PromotionMapping>();
            NewFromOldMapB = new ObservableCollection<PromotionMapping>();
            NewFromOldMapC = new ObservableCollection<PromotionMapping>();
            NewFromOldMapD = new ObservableCollection<PromotionMapping>();
            NewFromOldMapE = new ObservableCollection<PromotionMapping>();

            GetDataCommand = new RelayCommand(GetData, CanGetData);
            SaveDataCommand = new RelayCommand(SaveData, CanSaveData);
            EventConnector.RollUpdateEvent += EventConnector_RollUpdateEvent;
            PlistIndex = -1;
           
        }

        private void MapperData()
        {
            PromotionDb db = new PromotionDb();
            int oldFromACount = db.GetPreviousToNewCount(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "A");
            int oldFromBCount = db.GetPreviousToNewCount(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "B");
            int oldFromCCount = db.GetPreviousToNewCount(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "C");
            int oldFromDCount = db.GetPreviousToNewCount(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "D");
            int oldFromECount = db.GetPreviousToNewCount(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "E");

            int newACount = db.GetNewCount(newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], newSection: "A");
            int newBCount = db.GetNewCount(newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], newSection: "B");
            int newCCount = db.GetNewCount(newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], newSection: "C");
            int newDCount = db.GetNewCount(newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], newSection: "D");
            int newECount = db.GetNewCount(newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], newSection: "E");

            int oldACount = db.GetPreviousCount(prevStartYear: StartYear, prevEndYear: EndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "A");
            int oldBCount = db.GetPreviousCount(prevStartYear: StartYear, prevEndYear: EndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "B");
            int oldCCount = db.GetPreviousCount(prevStartYear: StartYear, prevEndYear: EndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "C");
            int oldDCount = db.GetPreviousCount(prevStartYear: StartYear, prevEndYear: EndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "D");
            int oldECount = db.GetPreviousCount(prevStartYear: StartYear, prevEndYear: EndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "E");

            PrevSecA = $"Section A : {oldFromACount} of {oldACount}";
            PrevSecB = $"Section B : {oldFromBCount} of {oldBCount}";
            PrevSecC = $"Section C : {oldFromCCount} of {oldCCount}";
            PrevSecD = $"Section D : {oldFromDCount} of {oldDCount}";
            PrevSecE = $"Section E : {oldFromECount} of {oldECount}";

            NewSecA = $"Section A : {newACount}";
            NewSecB = $"Section B : {newBCount}";
            NewSecC = $"Section C : {newCCount}";
            NewSecD = $"Section D : {newDCount}";
            NewSecE = $"Section E : {newECount}";

            OldToNewMapA = db.GetPreviousToNewMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "A");
            OldToNewMapB = db.GetPreviousToNewMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "B");
            OldToNewMapC = db.GetPreviousToNewMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "C");
            OldToNewMapD = db.GetPreviousToNewMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "D");
            OldToNewMapE = db.GetPreviousToNewMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], oldSection: "E");

            NewFromOldMapA = db.GetNewFromPreviousMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], NewSection: "A");
            NewFromOldMapB = db.GetNewFromPreviousMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], NewSection: "B");
            NewFromOldMapC = db.GetNewFromPreviousMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], NewSection: "C");
            NewFromOldMapD = db.GetNewFromPreviousMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], NewSection: "D");
            NewFromOldMapE = db.GetNewFromPreviousMap(prevStartYear: StartYear, prevEndYear: EndYear, newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear, oldClass: SchoolClass[SchoolClassIndex], NewSection: "E");
        }

        private void EventConnector_RollUpdateEvent(object sender, EventArgs e)
        {
            PromotionDb db = new PromotionDb();
            if (PlistIndex > -1)
            {
                List<string> alreadyAssignedList = db.HasAlreadyAssignedOrNot(startYear: NewSessionStartYear, endYear: NewSessionEndYear, cls: PromoList[PlistIndex].NewStudyClass, section: PromoList[PlistIndex].NewSection, roll: PromoList[PlistIndex].NewRoll);
                if (alreadyAssignedList.Count > 0)
                {
                    PromoList[PlistIndex].NewRoll = 0;
                    System.Windows.MessageBox.Show("This section & roll already assigned to "+alreadyAssignedList.Count.ToString()+ " student(s)");
                }
                else
                {
                    Promotion prm = PromoList[PlistIndex];
                    if (prm.NewRoll > 0 && !string.IsNullOrWhiteSpace(prm.NewSection))
                    {
                        db.MakePromotion(prm);
                    }
                }
                MapperData();
            }
        }

        private void GetData()
        {
            PromoList.Clear();
            PromotionDb db = new PromotionDb();
            PromoList = db.GetList(startYear: StartYear, endYear: EndYear, cls: SchoolClass[SchoolClassIndex], section: SchoolSection[SchoolSectionIndex], newStartYear: NewSessionStartYear, newEndYear: NewSessionEndYear);
            PlistIndex = -1;
            NewSessionStartYear = StartYear + 1;
            NewSessionEndYear = EndYear + 1;
            RollUpdateHandler();
            MapperData();
        }


        private bool CanGetData()
        {
            bool validSYear = StartYear > 2016 && StartYear < DateTime.Today.Year + 1 && EndYear > 2016 && EndYear < DateTime.Today.Year + 2;
            bool validClsInfo = SchoolClassIndex != -1 && SchoolSectionIndex != -1;
            return validSYear && validClsInfo;
        }

        private void SaveData()
        {
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (var item in SavablePromoList)
            {
                PromoList.Remove(item);
            }
            SavablePromoList.Clear();
            DupMsg = string.Empty;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DupMsg = "Please wait. Saving Data..";
            foreach (var item in PromoList)
            {
                if (item.DuplicateCode == 0)
                {
                    SavablePromoList.Add(item);
                }
            }

            PromotionDb db = new PromotionDb();
            db.MakePromotion(SavablePromoList);
           
            // reset
        }

        private bool CanSaveData()
        {
            return PromoList.Count > 0;
        }

        private void RollUpdateHandler(Object sender, EventArgs e)
        {
            RollUpdateHandler();
        }

        private void RollUpdateHandler()
        {
            PromotionDb db = new PromotionDb();
            // Refresh the row background color
            foreach (var item in PromoList)
            {
                item.DuplicateCode = 0;
            }
            // check for duplicate in grid
            var promosGrp = from p in PromoList
                            group p by new { p.NewSection, p.NewRoll };
            foreach (var itemGrp in promosGrp)
            {
                if (itemGrp.Count() > 1)
                {
                    foreach (var item in itemGrp)
                    {
                        item.DuplicateCode = 1;
                    }
                }
            }
        }

        protected override void OnStartYearChanged()
        {
            NewSessionStartYear = StartYear + 1;
            PrevSessionHeader = "Previous Session : " + StartYear.ToString() + "-" + EndYear.ToString() ;
        }

        protected override void OnEndYearChanged()
        {
            NewSessionEndYear = EndYear + 1;
            PrevSessionHeader = "Previous Session : " + StartYear.ToString() + "-" + EndYear.ToString();
        }

        private void NewClassChanged()
        {
            if (DoChangeNewClass)
            {
                IsNewClassReadOnly = false;
            }
            else
            {
                IsNewClassReadOnly = true;
            }
        }
    }
}
