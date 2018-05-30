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

        public RelayCommand GetDataCommand { get; set; }
        public RelayCommand SaveDataCommand { get; set; }

        private void StartUpInitializer()
        {
            PromoList = new ObservableCollection<Promotion>();
            GetDataCommand = new RelayCommand(GetData, CanGetData);
            SaveDataCommand = new RelayCommand(SaveData, CanSaveData);
            EventConnector.RollUpdateEvent += EventConnector_RollUpdateEvent;
            PlistIndex = -1;
            
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
                    System.Windows.MessageBox.Show(alreadyAssignedList.Count.ToString());
                }
                else
                {
                    Promotion prm = PromoList[PlistIndex];
                    if (prm.NewRoll > 0 && !string.IsNullOrWhiteSpace(prm.NewSection))
                    {
                        db.MakePromotion(prm);
                    }
                }
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
    }
}
