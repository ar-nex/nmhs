using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.ViewModels.Helpers;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace NaimouzaHighSchool.ViewModels
{
    public class ExcelEntryStaffViewModel : BaseViewModel
    {
        public ExcelEntryStaffViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private bool _flagCanAbort;
        private bool _flagCanInsert;

        public string _lblProgress;
        public string LblProgress
        {
            get => _lblProgress;
            set
            {
                _lblProgress = value;
                OnPropertyChanged("LblProgress");
            }
        }

        private string _progressbarValue;
        public string ProgressbarValue
        {
            get { return _progressbarValue; }
            set { _progressbarValue = value; OnPropertyChanged("ProgressbarValue"); }
        }

        private string _txbFileName;
        public string TxbFileName
        {
            get => _txbFileName;
            set
            {
                _txbFileName = value;
                OnPropertyChanged("TxbFileName");
            }
        }

        private int _ignoredRow;
        public int IgnoredRow
        {
            get { return _ignoredRow; }
            set { _ignoredRow = value; OnPropertyChanged("IgnoredRow"); }
        }

        private List<ExcelColumnPositionStaff> _listExCol;
        public List<ExcelColumnPositionStaff> ListExCol
        {
            get => _listExCol;
            set
            {
                _listExCol = value;
                OnPropertyChanged("ListExCol");
            }
        }

        public ExcelColumnPositionServiceStaff ExService { get; set; }
        public ExcelEntryHelper ExcelEntryHelper { get; set; }

        private BackgroundWorker bw = new BackgroundWorker();

        public RelayCommand InsertDataCommand { get; set; }
        public RelayCommand AbortCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand FileOpenCommand { get; set; }
        public RelayCommand IncrementIgnoredRowCommand { get; set; }
        public RelayCommand DecrementIgnoredRowCommand { get; set; }

        private void StartUpInitializer()
        {
            ExService = new ExcelColumnPositionServiceStaff();
            ExcelEntryHelper = new ExcelEntryHelper();
            ListExCol = ExService.GetListCol();
            IgnoredRow = 0;
            ProgressbarValue = "0";

            InsertDataCommand = new RelayCommand(InsertData, CanInsertData);
            AbortCommand = new RelayCommand(AbortInsert, CanAbortInsert);
            ResetCommand = new RelayCommand(Reset, CanReset);
            FileOpenCommand = new RelayCommand(FileOpen, CanFileOpen);
            IncrementIgnoredRowCommand = new RelayCommand(IncrementIgnoredRow, CanIncrementIgnoredRow);
            DecrementIgnoredRowCommand = new RelayCommand(DecrementIgnoredRow, CanDecrementIgnoredRow);
        }

        private void InsertData()
        {
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            _flagCanAbort = true;
        }
        private bool CanInsertData()
        {
            return false;
        }

        private void processExcel(DoWorkEventArgs e_dw)
        {
            Excel.Application xlApp = new Excel.Application();
            if (string.IsNullOrEmpty(TxbFileName))
            {
                return;
            }
            else
            {
                try
                {

                    var xlWorkbooks = xlApp.Workbooks;
                    Excel.Workbook xlWorkbook = xlWorkbooks.Open(TxbFileName);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    int scannableFirstRow = IgnoredRow + 1;
                    string[] rowValues = new string[colCount];

                //    ExcelColumnStudentBuilder stdBuild = new ExcelColumnStudentBuilder(ListExCol);

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
                       // Student s = stdBuild.BuildStudent(rowValues, SelectedClass, SelectedSection);
                        // insert into database
                     //   bool hasInserted = ExDb.InsertFromExcel(s, SessionStartYear, SessionEndYear);

                        LblProgress = i.ToString() + "/" + rowCount.ToString();
                        float progressPercent = (i * 100) / rowCount;
                        ProgressbarValue = progressPercent.ToString();
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

                    TxbFileName = null;

                    Marshal.ReleaseComObject(xlWorkbooks);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);

                }
                catch (Exception e)
                {

                    System.Windows.MessageBox.Show(e.Message);
                }

            }
        }

        private void AbortInsert()
        {

        }

        private bool CanAbortInsert()
        {
            return true;
        }

        private void Reset()
        {
            IgnoredRow = -1;
            ExcelColumnPositionServiceStaff ExServiceNew = new ExcelColumnPositionServiceStaff();
            ListExCol = ExServiceNew.GetListCol();
            ProgressbarValue = "0";
            LblProgress = "0/0";
            TxbFileName = string.Empty;
        }

        private bool CanReset()
        {
            return true;
        }

        private void FileOpen()
        {
            OpenFileDialog ofile = new OpenFileDialog();
            ofile.Filter = "Excel Files|*.xlsx;*.xls";
            if (ofile.ShowDialog() == true)
            {
                TxbFileName = ofile.FileName;
            }
        }

        private bool CanFileOpen()
        {
            return true;
        }

        private void IncrementIgnoredRow()
        {
            IgnoredRow++;
        }

        private bool CanIncrementIgnoredRow()
        {
            return (IgnoredRow > 10) ? false : true;
        }

        private void DecrementIgnoredRow()
        {
            IgnoredRow--;
        }

        private bool CanDecrementIgnoredRow()
        {
            return (IgnoredRow < 1) ? false : true;
        }



        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _flagCanInsert = false;
            processExcel(e);
        }


        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // excelProgressbar.Value = e.ProgressPercentage;
            //statusText.Text = "Scaning rows. completed " + e.ProgressPercentage.ToString() + e.UserState;
            ProgressbarValue = e.ProgressPercentage.ToString() + e.UserState;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxbFileName = string.Empty;
            _flagCanInsert = true;
            LblProgress = "Inserted Successfully.";
            Reset();
        }

    }
}
