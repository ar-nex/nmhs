using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class BoardExamViewModel : BaseViewModel
    {
        public BoardExamViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        #region properties

        #region visibility
        private System.Windows.Visibility _clsVisibility;
        public System.Windows.Visibility ClsVisibility
        {
            get { return this._clsVisibility; }
            set { this._clsVisibility = value; this.OnPropertyChanged("ClsVisibility"); }
        }

        private System.Windows.Visibility _sectionVisibility;
        public System.Windows.Visibility SectionVisibility
        {
            get { return this._sectionVisibility; }
            set { this._sectionVisibility = value; this.OnPropertyChanged("SectionVisibility"); }
        }

        private System.Windows.Visibility _rollVisibility;
        public System.Windows.Visibility RollVisibility
        {
            get { return this._rollVisibility; }
            set { this._rollVisibility = value; this.OnPropertyChanged("RollVisibility"); }
        }

        private System.Windows.Visibility _boardRollVisibility;
        public System.Windows.Visibility BoardRollVisibility
        {
            get { return this._boardRollVisibility; }
            set { this._boardRollVisibility = value; this.OnPropertyChanged("BoardRollVisibility"); }
        }

        private System.Windows.Visibility _boardNoVisibility;
        public System.Windows.Visibility BoardNoVisibility
        {
            get { return this._boardNoVisibility; }
            set { this._boardNoVisibility = value; this.OnPropertyChanged("BoardNoVisibility"); }
        }

        private bool _isClsVisibile;
        public bool IsClsVisible
        {
            get { return this._isClsVisibile; }
            set
            {
                this._isClsVisibile = value;
                this.OnPropertyChanged("IsClsVisible");
                if (value)
                {
                    this.ClsVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    this.ClsVisibility = System.Windows.Visibility.Collapsed;
                }
            }
        }

        private bool _isSectionVisible;
        public bool IsSectionVisible
        {
            get { return this._isSectionVisible; }
            set
            {
                this._isSectionVisible = value;
                this.OnPropertyChanged("IsSectionVisible");
                this.SectionVisibility = (value) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        private bool _isRollVisible;
        public bool IsRollVisible
        {
            get { return this._isRollVisible; }
            set 
            {
                this._isRollVisible = value;
                this.OnPropertyChanged("IsRollVisible");
                this.RollVisibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        private bool _isBoardRollVisible;
        public bool IsBoardRollVisible
        {
            get { return this._isBoardRollVisible; }
            set
            {
                this._isBoardRollVisible = value;
                this.OnPropertyChanged("IsBoardRollVisible");
                this.BoardRollVisibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        private bool _isBoardNoVisible;
        public bool IsBoardNoVisible
        {
            get { return this._isBoardNoVisible; }
            set 
            {
                this._isBoardNoVisible = value;
                this.OnPropertyChanged("IsBoardNoVisible");
                this.BoardNoVisibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        #endregion
        private int _txbFullMarks;
        public int TxbFullMarks
        {
            get { return this._txbFullMarks; }
            set 
            { 
                this._txbFullMarks = value;
                this.SetFullMarks();
                this.OnPropertyChanged("TxbFullMarks"); 
            }
        }

        public string[] ExamList { get; set; }
        private int _examListIndex;
        public int ExamListIndex
        {
            get { return this._examListIndex; }
            set 
            {
                if (value > -1 && value < this.ExamList.Length)
                {
                    this._examListIndex = value;
                }
                else
                {
                    this._examListIndex = -1;
                }
                this.OnPropertyChanged("ExamListIndex");
            }
        }

        private int _sessionStartYear;
        public int SessionStartYear
        {
            get { return this._sessionStartYear; }
            set
            {
                int cYear = DateTime.Today.Year;
                if (value > cYear || value < cYear - 15)
                {
                    this._sessionStartYear = 1;
                }
                else
                {
                    this._sessionStartYear = value;
                }
                this.OnPropertyChanged("SessionStartYear");
            }
        }

        private int _sessionEndYear;
        public int SessionEndYear
        {
            get { return this._sessionEndYear; }
            set
            {
                int cYear = DateTime.Today.Year;
                if (value > cYear || value < cYear - 15)
                {
                    this._sessionEndYear = 1;
                }
                else
                {
                    this._sessionEndYear = value;
                }
                this.OnPropertyChanged("SessionEndYear");
            }
        }

       

        private ObservableCollection<BoardStudent> _lbs;
        public ObservableCollection<BoardStudent> Lbs 
        {
            get { return this._lbs; }
            set { this._lbs = value; this.OnPropertyChanged("Lbs"); }
        }

        public string[] CandidateCategory { get; set; }

        private BoardExamDb db { get; set; }

        public RelayCommand SaveUpdatesCommand { get; set; }
        public RelayCommand GetCommand { get; set; }
        #endregion

        #region method
        private void StartUpInitializer()
        {
            this.ExamList = new string[] { "Secondary", "Higher Secondary"};
            this.CandidateCategory = new string[] { "R", "C", "S"};
            this.db = new BoardExamDb();

            this.Lbs = new ObservableCollection<BoardStudent>();
            this.SessionStartYear = DateTime.Today.Year;
            this.SessionEndYear = DateTime.Today.Year;
            this.ExamListIndex = -1;

            this.IsClsVisible = false;
            this.IsSectionVisible = false;
            this.IsRollVisible = false;
            this.IsBoardRollVisible = true;
            this.IsBoardNoVisible = true;
            this.SaveUpdatesCommand = new RelayCommand(this.SaveUpdates, this.CanSaveUpdates);
            this.GetCommand = new RelayCommand(this.Get, this.CanGet);
            
        }

        private void SaveUpdates()
        {
            foreach (BoardStudent item in this.Lbs)
            {
                if (item.Status == "PASS")
                {
                    item.Status = "P";
                }

                if (item.Status == "FAIL" )
                {
                    item.Status = "F";
                }

                if (!item.AppearedInExam)
                {
                    item.ObtainedMarks = 0;
                    item.Status = "A";
                }
            }

            string cls = string.Empty;
            if (this.ExamListIndex == 0)
            {
                cls = "MP";
            }
            else if (this.ExamListIndex == 1)
            {
                cls = "HS";
            }
            else
            {
                System.Windows.MessageBox.Show("Please class.");
                return;
            }
            var ListForDb = from n in this.Lbs
                            where n.ObtainedMarks > 0
                            select n;
            List<BoardStudent> finalListForDb = new List<BoardStudent>();
            foreach (BoardStudent item in ListForDb)
            {
                finalListForDb.Add(item);
            }

            if (finalListForDb.Count > 0)
            {
                int insertedRecords = this.db.InsertData(finalListForDb, cls, this.SessionEndYear);
                if (insertedRecords > 0)
                {
                    System.Windows.MessageBox.Show(insertedRecords.ToString() + " record(s) inserted.");
                    foreach (BoardStudent item in finalListForDb)
                    {
                        this.Lbs.Remove(item);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("No record inserted.");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please enter obtained marks.");
                return;
            }

            
        }
        private bool CanSaveUpdates()
        {
            int len = (from n in this.Lbs
                       where n.ObtainedMarks > 0
                       select n).Count();
            return (len > 0 && this.ExamListIndex > -1);
        }

        private void SetFullMarks()
        {
            foreach (BoardStudent bs in this.Lbs)
            {
                bs.TotalMarks = this.TxbFullMarks;
            }
        }

        private void Get()
        {
            
            string cls;
            if (this.ExamListIndex == 0)
            {
                cls = "X";
            }
            else
            {
                cls = "XII";
            }
            if (this.TxbFullMarks > 0)
            {
                List<BoardStudent> tempList = db.GetData(cls, this.SessionStartYear.ToString(), this.SessionEndYear.ToString());
                if (tempList.Count > 0)
                {
                    foreach (BoardStudent item in tempList)
                    {
                        item.TotalMarks = this.TxbFullMarks;
                    }
                    this.Lbs = new ObservableCollection<BoardStudent>(tempList);
                }
            }
            else
            {
                this.Lbs = new ObservableCollection<BoardStudent>(db.GetData(cls, this.SessionStartYear.ToString(), this.SessionEndYear.ToString()));
            }
            
           
        }
        private bool CanGet()
        {
            return (this.ExamListIndex != -1 && this.SessionStartYear != 1 && this.SessionEndYear != 1);
        }
        #endregion
    }
}
