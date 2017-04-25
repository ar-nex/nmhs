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
    public class ExcelExportViewModel : BaseViewModel
    {
        public ExcelExportViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        #region property
        //private ExcelExportDb db;
        //private DataTable _dt;
        //public DataTable Dt
        //{
        //    get { return _dt; }
        //    set { this._dt = value; this.OnPropertyChanged("Dt"); }
        //}
        public string[] SchoolClasses { get; set; }
        public string[] Section { get; set; }

        private int _clsIndex;
        public int ClsIndex
        {
            get { return this._clsIndex; }
            set { this._clsIndex = value; this.OnPropertyChanged("ClsIndex"); }
        }

        private int _sectionIndex;
        public int SectionIndex
        {
            get { return this._sectionIndex; }
            set { this._sectionIndex = value; this.OnPropertyChanged("SectionIndex"); }
        }

        private int _sYear;
        public int SYear
        {
            get { return this._sYear; }
            set { this._sYear = value; this.OnPropertyChanged("SYear"); }
        }
        private int _eYear;
        public int EYear
        {
            get { return this._eYear; }
            set { this._eYear = value; this.OnPropertyChanged("EYear"); }
        }
        private List<Student> _slist;
        public List<Student> Slist
        {
            get { return this._slist; }
            set { this._slist = value; this.OnPropertyChanged("Slist"); }
        }

        private ObservableCollection<string> _unSelectedColumns;
        public ObservableCollection<string> UnSelectedColumns
        {
            get { return this._unSelectedColumns; }
            set { this._unSelectedColumns = value; this.OnPropertyChanged("UnSelectedColumns"); }
        }

        private int _unSelectedColumnIndex;
        public int UnSelectedColumnIndex
        {
            get { return this._unSelectedColumnIndex; }
            set { this._unSelectedColumnIndex = value; this.OnPropertyChanged("UnSelectedColumnIndex"); }
        }

        private ObservableCollection<string> _selectedColumns;
        public ObservableCollection<string> SelectedColumns
        {
            get { return this._selectedColumns; }
            set { this._selectedColumns = value; this.OnPropertyChanged("SelectedColumns"); }
        }

        private int _selectedColumnIndex;
        public int SelectedColumnIndex
        {
            get { return this._selectedColumnIndex; }
            set { this._selectedColumnIndex = value; this.OnPropertyChanged("SelectedColumnIndex"); }
        }

      

        public RelayCommand TestCommand { get; set; }
        public RelayCommand MoveRightCommand { get; set; }
        public RelayCommand MoveRightAllCommand { get; set; }
        public RelayCommand MoveLeftCommand { get; set; }
        public RelayCommand MoveLeftAllCommand { get; set; }
        #endregion

        #region Methods
        private void StartUpInitializer()
        {
            //this.Dt = new DataTable();
            //Dt.Columns.Add("Name");
            //Dt.Columns.Add("Age");

            //Dt.Rows.Add(new Object[] {"Amrin", "9"});
            //this.TestCommand = new RelayCommand(this.Test, this.CanTest);
            //this.db = new ExcelExportDb();
            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            this.Section = new string[] { "A", "B", "C", "D", "E" };
            this.ClsIndex = -1;
            this.SectionIndex = -1;
            this.UnSelectedColumnIndex = -1;
            this.SelectedColumnIndex = -1;
            this.SYear = DateTime.Today.Year;
            this.EYear = DateTime.Today.Year;
            this.Slist = new List<Student>();
            ExcelColumnPositionService exService = new ExcelColumnPositionService();
            this.UnSelectedColumns = new ObservableCollection<string>(exService.GetColListForExport());
            this.SelectedColumns = new ObservableCollection<string>();
           

            this.MoveRightCommand = new RelayCommand(this.MoveRight, this.CanMoveRight);
            this.MoveRightAllCommand = new RelayCommand(this.MoveRightAll, this.CanMoveRightAll);
            this.MoveLeftCommand = new RelayCommand(this.MoveLeft, this.CanMoveLeft);
            this.MoveLeftAllCommand = new RelayCommand(this.MoveLeftAll, this.CanMoveLeftAll);
        }

        private void Test()
        {
            //DataTable d1 = new DataTable();
            //d1.Columns.Add("New One");
            //d1.Columns.Add("New Two");
            //d1.Columns.Add("New Third");
            //d1.Rows.Add(new object[]{"Tn", "12", "a"});
            //d1.Rows.Add(new object[] { "To", "13", "b" });
            //d1.Rows.Add(new object[] { "Tp", "14", "" });
            //d1.Rows.Add(new object[] { "Tq", "15", "d" });

            //this.Dt = d1;
        }

        private bool CanTest()
        {
            return true;
        }

        private void MoveRight()
        {
            //this.SelectedColumns.Add(this.UnSelectedColumns[this.UnSelectedColumnIndex]);
            //this.UnSelectedColumns.RemoveAt(this.UnSelectedColumnIndex);

            //if (this.UnSelectedColumns.Count > this.UnSelectedColumnIndex + 1)
            //{
            //    this.UnSelectedColumnIndex++;
            //}
            //else
            //{
            //    this.UnSelectedColumnIndex = -1;
            //}
            
        }

        private bool CanMoveRight()
        { 
            return (this.UnSelectedColumnIndex > -1 && this.UnSelectedColumnIndex < this.UnSelectedColumns.Count);
        }

        private void MoveRightAll()
        {
            foreach (string item in this.UnSelectedColumns)
            {
                this.SelectedColumns.Add(item);
            }
            this.UnSelectedColumns.Clear();
        }

        private bool CanMoveRightAll()
        {
            return (this.UnSelectedColumns.Count > 0) ? true : false;
            
        }

        private void MoveLeft()
        {
            this.UnSelectedColumns.Add(this.SelectedColumns[this.SelectedColumnIndex]);
            this.SelectedColumns.RemoveAt(this.SelectedColumnIndex);
        }

        private bool CanMoveLeft()
        { 
            return (this.SelectedColumnIndex > -1 && this.SelectedColumnIndex < this.SelectedColumns.Count);
        }

        private void MoveLeftAll()
        {
            foreach (string item in this.SelectedColumns)
            {
                this.UnSelectedColumns.Add(item);
            }
            this.SelectedColumns.Clear();
        }

        private bool CanMoveLeftAll()
        {
            return this.SelectedColumns.Count > 0;
        }
        #endregion
    }
}
