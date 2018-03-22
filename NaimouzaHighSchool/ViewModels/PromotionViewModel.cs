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
            set { _newSessionStratYear = value; OnPropertyChanged("NewSessionStartYear"); }
        }

        private int _newSessionEndYear;
        public int NewSessionEndYear
        {
            get { return _newSessionEndYear; }
            set { _newSessionEndYear = value; OnPropertyChanged("NewSessionEndYear"); }
        }

        private string _dupMsg;
        public string DupMsg
        {
            get { return _dupMsg; }
            set { _dupMsg = value; OnPropertyChanged("DupMsg"); }
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

            
        }

        private void GetData()
        {
            PromoList.Clear();
            PromotionDb db = new PromotionDb();
            PromoList = db.GetList(startYear: StartYear, endYear: EndYear, cls: SchoolClass[SchoolClassIndex], section: SchoolSection[SchoolSectionIndex]);
            foreach (var item in PromoList)
            {
                item.RollUpdateEvent += RollUpdateHandler;
            }

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
    }
}
