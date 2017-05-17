using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.ViewModels.Helpers;
using System.Windows;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.ComponentModel;


namespace NaimouzaHighSchool.ViewModels
{
    public class ExcelEntryViewModel : BaseViewModel
    {
        public ExcelEntryViewModel()
        : base()
        {
            this.ExService = new ExcelColumnPositionService();
            this.ExcelEntryHelper = new ExcelEntryHelper();
            this.ListExCol = ExService.getListCol();
            this.IgnoredRow = 0;
            this.LblProgress = "0/0";
            this.ProgressbarValue = "0";
            this.ClassesInSchool = new string[] {"V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            this.SectionsInClass = new string[] { "-not applicable-", "A", "B", "C", "D", "E" };
            this.SessionStartYear = DateTime.Today.ToString("yyyy");
            this.SessionEndYear = DateTime.Today.ToString("yyyy");
            this.ExDb = new ExcelEntryDb();
            this._flagCanInsert = true;

            this.FileOpenCommand = new RelayCommand(getExcelFile, CanFileBrowse);
            this.IncrementIgnoredRowCommand = new RelayCommand(IncrementIgnoredRow, CanIncrementIgnoredRow);
            this.DecrementIgnoredRowCommand = new RelayCommand(DecrementIgnoredRow, CanDecrementIgnoredRow);
            this.InsertDataCommand = new RelayCommand(InsertData, CanInsertData);
            this.ResetCommand = new RelayCommand(Reset, CanReset);
            this.AbortCommand = new RelayCommand(this.Abort, this.CanAbort);
            
        }

        private List<ExcelColumnPosition> _listExCol;
        private string _txbFileName;
        private int _ignoredRow;
        private string _lblProgress;
        private string _progressbarValue;
        private string _selectedClass;
        private string _selectedSection;
        private string _sessionStartYear;
        private string _sessionEndYear;
        private bool _flagCanAbort;
        private bool _flagCanInsert;
       

        // For reading, validating etc of time consuming excel file
        private BackgroundWorker bw = new BackgroundWorker();

        public ExcelColumnPositionService ExService { get; set; }
        public ExcelEntryHelper ExcelEntryHelper { get; set; }
        public List<ExcelColumnPosition> ListExCol
        {
            get { return _listExCol; }
            set { _listExCol = value; this.OnPropertyChanged("ListExCol"); }
        }
        public string TxbFileName
        {
            get { return _txbFileName; }
            set { this._txbFileName = value; this.OnPropertyChanged("TxbFileName"); }
        }
        public int IgnoredRow
        {
            get { return this._ignoredRow; }
            set { this._ignoredRow = value; this.OnPropertyChanged("IgnoredRow"); }
        }
        public string LblProgress
        {
            get { return _lblProgress; }
            set { _lblProgress = value; this.OnPropertyChanged("LblProgress"); }
        }
        public string ProgressbarValue
        {
            get { return _progressbarValue; }
            set { _progressbarValue = value; this.OnPropertyChanged("ProgressbarValue"); }
        }
        public string[] ClassesInSchool { get; set; }
        public string[] SectionsInClass { get; set; }

        public string SelectedClass
        {
            get { return _selectedClass; }
            set { _selectedClass = value; this.OnPropertyChanged("SelectedClass"); }
        }
        public string SelectedSection
        {
            get { return _selectedSection; }
            set { _selectedSection = value; this.OnPropertyChanged("SelectedSection"); }
        }
        public string SessionStartYear
        {
            get { return _sessionStartYear; }
            set { _sessionStartYear = value; }
        }
        public string SessionEndYear
        {
            get { return _sessionEndYear; }
            set { _sessionEndYear = value; }
        }
        private ExcelEntryDb ExDb { get; set; }

        public RelayCommand FileOpenCommand { get; set; }
        public RelayCommand IncrementIgnoredRowCommand { get; set; }
        public RelayCommand DecrementIgnoredRowCommand { get; set; }
        public RelayCommand InsertDataCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand AbortCommand { get; set; }

        public void getExcelFile()
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Excel Files|*.xlsx;*.xls";
            if (ofile.ShowDialog() == true)
            {
                this.TxbFileName = ofile.FileName;
            }
        
        }

        #region method
        public bool CanFileBrowse()
        {
            return true;
        }

        public void IncrementIgnoredRow()
        {
            this.IgnoredRow++;
        }
        public bool CanIncrementIgnoredRow()
        { 
            return (this.IgnoredRow > 10) ? false : true;
        }

        public void DecrementIgnoredRow()
        {
            this.IgnoredRow--;
        }
        public bool CanDecrementIgnoredRow()
        {
            return (this.IgnoredRow < 1) ? false : true;
        }

        private void Abort()
        {
            bw.CancelAsync();
            this._flagCanAbort = false;
            this._flagCanInsert = true;
            this.Reset();
        }

        private bool CanAbort()
        {
            return this._flagCanAbort;
        }

        public void InsertData()
        {

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            this._flagCanAbort = true;

        }


        public bool CanInsertData()
        {
            return (String.IsNullOrEmpty(this.TxbFileName) || this.IgnoredRow < 1 || !ExcelEntryHelper.isExcelColPositionUnique(this.ListExCol) || String.IsNullOrEmpty(this.SelectedClass) || !this._flagCanInsert) ? false : true;
        }

        public void Reset()
        {
            this.IgnoredRow = -1;
            ExcelColumnPositionService ExServiceNew = new ExcelColumnPositionService();
            this.ListExCol = ExServiceNew.getListCol();
            this.ProgressbarValue = "0";
            this.LblProgress = "0/0";
            this.TxbFileName = string.Empty;
        }

        public bool CanReset()
        {
            return true;
        }


        private void processExcel(DoWorkEventArgs e_dw)
        {
            Excel.Application xlApp = new Excel.Application();
            if (string.IsNullOrEmpty(this.TxbFileName))
            {
                return;
            }
            else
            {
                try
                {

                    var xlWorkbooks = xlApp.Workbooks;
                    Excel.Workbook xlWorkbook = xlWorkbooks.Open(this.TxbFileName);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    int scannableFirstRow = this.IgnoredRow + 1;
                    string[] rowValues = new string[colCount];

                    ExcelColumnStudentBuilder stdBuild = new ExcelColumnStudentBuilder(this.ListExCol);

                    for (int i = scannableFirstRow; i <= rowCount; i++)
                    {
                        bool breakFlag = false;
                        for (int j = 1; j <= colCount; j++)
                        {
                            if (bw != null && bw.CancellationPending)
                            {
                                e_dw.Cancel = true;
                                breakFlag = true;
                                break;
                            }
                            if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                            {
                                rowValues[j - 1] = xlRange.Cells[i, j].Value2.ToString();
                            }
                            else
                            {
                                rowValues[j - 1] = "";
                            }

                        }
                        if (breakFlag)
                        {
                            break;
                        }

                        //build student object for each row
                        Student s = stdBuild.BuildStudent(rowValues, this.SelectedClass, this.SelectedSection);
                        // insert into database
                        bool hasInserted = ExDb.InsertFromExcel(s, this.SessionStartYear, this.SessionEndYear);

                        this.LblProgress = i.ToString() + "/" + rowCount.ToString();
                        float progressPercent = (i * 100) / rowCount;
                        this.ProgressbarValue = progressPercent.ToString();
                    }


                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);

                    //close and release
                    xlWorkbook.Close();
                    Marshal.ReleaseComObject(xlWorkbook);

                    this.TxbFileName = null;

                    Marshal.ReleaseComObject(xlWorkbooks);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message);
                }

            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            this._flagCanInsert = false;
            this.processExcel(e);
        }


        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // this.excelProgressbar.Value = e.ProgressPercentage;
            //this.statusText.Text = "Scaning rows. completed " + e.ProgressPercentage.ToString() + e.UserState;
            this.ProgressbarValue = e.ProgressPercentage.ToString() + e.UserState;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TxbFileName = string.Empty;
            this._flagCanInsert = true;
            this.LblProgress = "Inserted Successfully.";
            this.Reset();
        }

        #endregion method

    }
}
