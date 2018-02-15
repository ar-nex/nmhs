using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class RollUpdateViewModel : BaseViewModel
    {
        public RollUpdateViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        #region property
        private ObservableCollection<RollUpdater> _rollUpdaterList;
        public ObservableCollection<RollUpdater> RollUpdaterList
        {
            get { return this._rollUpdaterList; }
            set { this._rollUpdaterList = value; this.OnPropertyChanged("RollUpdater"); }
        }

        private int _rollUpdaterListIndex;
        public int RollUpdaterListIndex
        {
            get { return this._rollUpdaterListIndex; }
            set { this._rollUpdaterListIndex = value; this.OnPropertyChanged("RollUpdaterListIndex"); }
        }

        public string[] SchoolClasses { get; set; }
        public string[] SchoolSection { get; set; }

        private int _schoolClassesIndex;
        public int SchoolClassesIndex
        {
            get { return this._schoolClassesIndex; }
            set { this._schoolClassesIndex = value; this.OnPropertyChanged("SchoolClassesIndex"); }
        }

        private int _schoolSectionIndex;
        public int SchoolSectionIndex
        {
            get { return this._schoolSectionIndex; }
            set { this._schoolSectionIndex = value; this.OnPropertyChanged("SchoolSectionIndex"); }
        }

        private int _txbStartYear;
        public int TxbStartYear
        {
            get { return this._txbStartYear; }
            set { this._txbStartYear = value; this.OnPropertyChanged("TxbStartYear"); }
        }

        private int _txbEndYear;
        public int TxbEndYear
        {
            get { return this._txbEndYear; }
            set { this._txbEndYear = value; this.OnPropertyChanged("TxbEndYear"); }
        }

        private RollUpdateDb db { get; set; }
        public RelayCommand GetRollUpdatersCommand { get; set; }
        public RelayCommand UpdateRollesCommand { get; set; }
        #endregion

        #region method
        private void StartUpInitializer()
        {
            this.db = new RollUpdateDb();
            this.RollUpdaterList = new ObservableCollection<RollUpdater>();
            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            this.SchoolSection = new string[] { "A", "B", "C", "D", "E" };
            this.SchoolClassesIndex = -1;
            this.SchoolSectionIndex = -1;
            this.TxbStartYear = this.TxbEndYear = DateTime.Today.Year;
            this.GetRollUpdatersCommand = new RelayCommand(this.GetRollUpdaters, this.CanGetRollUpdaters);
            this.UpdateRollesCommand = new RelayCommand(this.UpdateRolles, this.CanUpdateRolles);
        }

        private void GetRollUpdaters()
        {
            if (this.RollUpdaterList.Count > 0)
            {
                this.RollUpdaterList.Clear();
            }
            List<RollUpdater> rlist = new List<RollUpdater>();
            rlist = this.db.GetRollUpdaterList(this.SchoolClasses[this.SchoolClassesIndex], this.SchoolSection[this.SchoolSectionIndex], this.TxbStartYear, this.TxbEndYear);
            if (rlist.Count > 0)
            {
                
                foreach (RollUpdater item in rlist)
                {
                    item.NewRollSectionSetEvent += this.RollSectionUpdateHandler;
                    this.RollUpdaterList.Add(item);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("There is no student in that class and section");
            }
            
        }

        

        private bool CanGetRollUpdaters()
        { 
            bool classSectionSelected = ((this.SchoolClassesIndex > -1 && this.SchoolClassesIndex < this.SchoolClasses.Length)&&(this.SchoolSectionIndex > -1 && this.SchoolSectionIndex < this.SchoolSection.Length));
            int cYear = DateTime.Today.Year;
            bool validSession = ((this.TxbStartYear > cYear - 15) && (this.TxbStartYear < cYear + 1)) && ((this.TxbEndYear > cYear - 15) && (this.TxbEndYear < cYear + 1));
            return classSectionSelected && validSession;
        }

        private void UpdateRolles()
        {
            List<RollUpdater> rList = new List<RollUpdater>();
            var rUpdaterList = from r in this.RollUpdaterList
                               where r.NewRoll > 0
                               select r;
            foreach (RollUpdater item in rUpdaterList)
            {
                rList.Add(item);
            }
            List<RollUpdater> updatedItems = db.UpdateRoll(rList, this.TxbStartYear, this.TxbEndYear);
            
            foreach (RollUpdater up in updatedItems)
            {
                this.RollUpdaterList.Remove(up);
            }
            System.Windows.MessageBox.Show(updatedItems.Count.ToString() + " student's roll updated.");
        }

        private bool CanUpdateRolles()
        {
            int newRollCount = (from n in this.RollUpdaterList
                                where n.NewRoll > 0
                                select n).Count();
            return newRollCount > 0;
        }


        public void RollSectionUpdateHandler(Object sender, EventArgs e)
        {
            /*
            int enteredNewRoll = this.RollUpdaterList[this.RollUpdaterListIndex].NewRoll;
            int rollCounter = 0;
            foreach (RollUpdater item in this.RollUpdaterList)
            {
                if (item.NewRoll == 0)
                {
                    continue;
                }
                if (enteredNewRoll == item.NewRoll)
                {
                    rollCounter++;
                }
                if (rollCounter > 1)
                {
                    System.Windows.MessageBox.Show(enteredNewRoll.ToString() +" already assigned to another student");
                    this.RollUpdaterList[this.RollUpdaterListIndex].NewRoll = 0;
                    break;
                }
            }
            */
            // new code
            // section or roll changed
            // if duplicate found
            // alert the user
            // Reset the section and roll

            int enteredNewRoll = RollUpdaterList[RollUpdaterListIndex].NewRoll;
            string enteredNewSec = RollUpdaterList[RollUpdaterListIndex].NewSection;
            Predicate<RollUpdater> RollUpdatedPredicate = r => r.NewRoll == enteredNewRoll && r.Section == enteredNewSec;
            int counter = 0;
            foreach (var item in RollUpdaterList)
            {
                if (item.NewRoll == 0)
                {
                    continue;
                }
                if (RollUpdatedPredicate(item))
                {
                    counter++;
                }
                if (counter > 1)
                {
                    string msg = string.Format("Entered Roll {0} and Section {1} already assigned to another student. ", item.NewRoll.ToString(), item.NewSection);
                    System.Windows.MessageBox.Show(msg);
                    RollUpdaterList[this.RollUpdaterListIndex].NewRoll = 0;
                    RollUpdaterList[this.RollUpdaterListIndex].NewSection = string.Empty;
                    break;
                }
            }
            
        }
        #endregion
    }
}
