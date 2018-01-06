using Microsoft.Win32;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

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

        private ExcelExportDb db;
        private DataTable _dtable;
        private bool _flagCanExport;

        public DataTable Dtable
        {
            get { return _dtable; }
            set { this._dtable = value; this.OnPropertyChanged("Dtable"); }
        }

        public string[] SchoolClasses { get; set; }
        public string[] Section { get; set; }

        private int _clsIndex;

        public int ClsIndex
        {
            get { return this._clsIndex; }
            set
            {
                this._clsIndex = value;
                this.Dtable = new DataTable();
                this.ProgressbarValue = "0/0";
                this.OnPropertyChanged("ClsIndex");
            }
        }

        private int _sectionIndex;

        public int SectionIndex
        {
            get { return this._sectionIndex; }
            set
            {
                this._sectionIndex = value;
                this.Dtable = new DataTable();
                this.OnPropertyChanged("SectionIndex");
            }
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

        private List<Student> _filteredList;

        public List<Student> FilteredList
        {
            get { return this._filteredList; }
            set { this._filteredList = value; this.OnPropertyChanged("FilteredList"); }
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

        private string _filterCategory;

        public string FilterCategory
        {
            get { return this._filterCategory; }
            set
            {
                this._filterCategory = value;
                this.DoFilterStdList();
                this.OnPropertyChanged("FilterCategory");
            }
        }

        private string _progressbarValue;

        public string ProgressbarValue
        {
            get { return _progressbarValue; }
            set { _progressbarValue = value; this.OnPropertyChanged("ProgressbarValue"); }
        }

        // For reading, validating etc of time consuming excel file
        private BackgroundWorker bw = new BackgroundWorker();

        public RelayCommand TestCommand { get; set; }
        public RelayCommand MoveRightCommand { get; set; }
        public RelayCommand MoveRightAllCommand { get; set; }
        public RelayCommand MoveLeftCommand { get; set; }
        public RelayCommand MoveLeftAllCommand { get; set; }
        public RelayCommand BuildGridViewCommand { get; set; }
        public RelayCommand ExportCommand { get; set; }

        #endregion property

        #region Methods

        private void StartUpInitializer()
        {
            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            this.Section = new string[] { "A", "B", "C", "D", "E" };
            this.ClsIndex = -1;
            this.SectionIndex = -1;
            this.UnSelectedColumnIndex = -1;
            this.SelectedColumnIndex = -1;
            this.SYear = DateTime.Today.Year;
            this.EYear = DateTime.Today.Year;
            this.Slist = new List<Student>();
            this.FilteredList = new List<Student>();
            this.ProgressbarValue = "0/0";

            ExcelColumnPositionService exService = new ExcelColumnPositionService();
            this.UnSelectedColumns = new ObservableCollection<string>(exService.GetColListForExport());
            this.SelectedColumns = new ObservableCollection<string>();
            this.db = new ExcelExportDb();
            this._flagCanExport = true;
            this.FilterCategory = "none";

            this.MoveRightCommand = new RelayCommand(this.MoveRight, this.CanMoveRight);
            this.MoveRightAllCommand = new RelayCommand(this.MoveRightAll, this.CanMoveRightAll);
            this.MoveLeftCommand = new RelayCommand(this.MoveLeft, this.CanMoveLeft);
            this.MoveLeftAllCommand = new RelayCommand(this.MoveLeftAll, this.CanMoveLeftAll);
            this.BuildGridViewCommand = new RelayCommand(this.BuildGridView, this.CanBuildGridView);
            this.ExportCommand = new RelayCommand(this.Export, this.CanExport);
        }

        private void MoveRight()
        {
            this.SelectedColumns.Add(this.UnSelectedColumns[this.UnSelectedColumnIndex]);
            this.UnSelectedColumns.RemoveAt(this.UnSelectedColumnIndex);
            this.UnSelectedColumnIndex = -1;
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
            this.SelectedColumnIndex = -1;
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

        private void BuildGridView()
        {
            // get the student list.

            int syear = DateTime.Today.Year;
            int eyear = DateTime.Today.Year;
            this.Slist = this.db.GetStudentListByClass(this.SchoolClasses[this.ClsIndex], this.Section[this.SectionIndex], syear, eyear);
            this.DoFilterStdList();

            DataTable dt = new DataTable();
            foreach (string item in this.SelectedColumns)
            {
                dt.Columns.Add(item);
            }

            foreach (Student s in this.FilteredList)
            {
                Object[] obj = new Object[this.SelectedColumns.Count];
                int i = 0;
                foreach (string col in this.SelectedColumns)
                {
                    obj[i] = this.GetCellVal(s, col);
                    i++;
                }
                dt.Rows.Add(obj);
            }

            this.Dtable = dt;
        }

        private bool CanBuildGridView()
        {
            return ((this.ClsIndex > -1) && (this.SectionIndex > -1) && (!string.IsNullOrEmpty(this.SYear.ToString())) && (!string.IsNullOrEmpty(this.EYear.ToString())) && (this.SelectedColumns.Count > 0));
        }

        private void Export()
        {
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private bool CanExport()
        {
            return ((this.Dtable.Columns.Count > 0) && (this._flagCanExport));
        }

        private string GetCellVal(Student s, string col)
        {
            string rstr;
            switch (col)
            {
                case "Student Name":
                    rstr = s.Name;
                    break;

                case "Father Name":
                    rstr = s.FatherName;
                    break;

                case "Mother Name":
                    rstr = s.MotherName;
                    break;

                case "Guardian Name":
                    rstr = s.GuardianName;
                    break;

                case "Guardian Relation":
                    rstr = s.GuardianRelation;
                    break;

                case "Guardian Occupation":
                    rstr = s.GuardianOccupation;
                    break;

                case "Date of birth":
                    rstr = s.Dob.ToString("dd-MM-yyyy");
                    break;

                case "Sex":
                    rstr = s.Sex;
                    break;

                case "Roll":
                    rstr = s.Roll.ToString();
                    break;

                case "SubjectComboId":
                    rstr = s.SubjectComboId;
                    break;

                case "Present Address":
                    rstr = s.PresentAdrress;
                    break;

                case "Permanent Address":
                    rstr = s.PermanentAddress;
                    break;

                case "Mobile":
                    rstr = s.Mobile;
                    break;

                case "Guardian Mobile":
                    rstr = s.GuardianMobile;
                    break;

                case "Email":
                    rstr = s.Email;
                    break;

                case "Religion":
                    rstr = s.Religion;
                    break;

                case "Social Category":
                    rstr = s.SocialCategory;
                    break;

                case "Sub Cast":
                    rstr = s.SubCast;
                    break;

                case "Is PH":
                    rstr = (s.IsPH) ? "Y" : "N";
                    break;

                case "PH type":
                    rstr = s.PhType;
                    break;

                case "Is BPL":
                    rstr = (s.IsBpl) ? "Y" : "N";
                    break;

                case "BPL Number":
                    rstr = s.BplNo;
                    break;

                case "Aadhar":
                    rstr = s.Aadhar;
                    break;

                case "Guardian Aadhar":
                    rstr = s.GuardianAadhar;
                    break;

                case "Guardian Epic":
                    rstr = s.GuardianEpic;
                    break;

                case "Blood Group":
                    rstr = s.BloodGroup;
                    break;

                case "Board No":
                    rstr = s.BoardNo;
                    break;

                case "Board Roll":
                    rstr = s.BoardRoll;
                    break;

                case "Council No.":
                    rstr = s.CouncilNo;
                    break;

                case "Council Roll":
                    rstr = s.CouncilRoll;
                    break;

                case "Admission No.":
                    rstr = s.AdmissionNo;
                    break;

                case "Admitted Class":
                    rstr = s.AdmittedClass;
                    break;

                case "Date of Admission":
                    rstr = s.AdmDate.ToString("dd-MM-yyyy");
                    break;

                case "Last School":
                    rstr = s.LastSchool;
                    break;

                case "Date of Leaving":
                    rstr = s.DateOfLeaving.ToString("dd-MM-yyyy");
                    break;

                case "TC detail":
                    rstr = s.TC;
                    break;

                case "Bank Acc. No":
                    rstr = s.BankAcc;
                    break;

                case "Bank Name":
                    rstr = s.BankName;
                    break;

                case "Branch Name":
                    rstr = s.BankBranch;
                    break;

                case "Branch IFSC":
                    rstr = s.Ifsc;
                    break;

                case "MICR code":
                    rstr = s.MICR;
                    break;

                default:
                    rstr = "";
                    break;
            }
            return rstr;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // this._flagCanInsert = false;
            this.ExportToExcel();
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // this.excelProgressbar.Value = e.ProgressPercentage;
            //this.statusText.Text = "Scaning rows. completed " + e.ProgressPercentage.ToString() + e.UserState;
            // this.ProgressbarValue = e.ProgressPercentage.ToString() + e.UserState;
            // this.ProgressbarValue = e.ProgressPercentage.ToString() + e.UserState + "%";
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._flagCanExport = true;
            // MessageBox.Show("Data inserted");
            // this.Reset();
        }

        private void ExportToExcel()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                string mydocumentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveDialog.Filter = "Excel Files|*.xlsx;*.xls";
                saveDialog.InitialDirectory = mydocumentDirectory;
                saveDialog.FileName = this.SchoolClasses[this.ClsIndex] + Section[this.SectionIndex] + ".xlsx";
                string fname = "nmhs.xlsx";
                if (saveDialog.ShowDialog() == true)
                {
                    fname = saveDialog.FileName;
                }
                this._flagCanExport = false;
                Excel.Application xlApp = new Excel.Application();
                // xlApp.Visible = true;
                var oWB = xlApp.Workbooks.Add();

                Excel._Worksheet workSheet = (Excel.Worksheet)xlApp.ActiveSheet;

                //add column title
                int cl = 0;
                foreach (string colname in this.SelectedColumns)
                {
                    cl++;
                    workSheet.Cells[1, cl] = colname;
                }
                // insert rows:

                int row = 1;
                int totalRow = this.Dtable.Rows.Count;
                this.ProgressbarValue = "0" + "/" + totalRow.ToString();
                foreach (DataRow RowItem in this.Dtable.Rows)
                {
                    row++;
                    int col = 0;
                    foreach (DataColumn ColItem in this.Dtable.Columns)
                    {
                        col++;
                        workSheet.Cells[row, col] = RowItem[ColItem];
                    }
                    // float prgPercentage = (row / totalRow) * 100;
                    this.ProgressbarValue = (row - 1).ToString() + "/" + totalRow.ToString();
                }

                workSheet.Columns[1].AutoFit();
                workSheet.Columns[2].AutoFit();

                oWB.SaveAs(fname, AccessMode: Excel.XlSaveAsAccessMode.xlShared);

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                // Marshal.ReleaseComObject(xlRange);
                // Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                oWB.Close();
                Marshal.ReleaseComObject(oWB);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception exl)
            {
                System.Windows.MessageBox.Show("exl : " + exl.Message);
            }
        }

        private void DoFilterStdList()
        {
            if (this.FilteredList.Count > 0)
            {
                this.FilteredList.Clear();
            }
            if (this.Slist.Count > 0)
            {
                switch (this.FilterCategory)
                {
                    case "none":
                        this.FilteredList = this.Slist;
                        break;

                    case "male":
                        var stdlst = from std in this.Slist
                                     where std.Sex == "M"
                                     select std;
                        foreach (Student item in stdlst)
                        {
                            this.FilteredList.Add(item);
                        }
                        break;

                    case "female":
                        var stdlst2 = from std in this.Slist
                                      where std.Sex == "F"
                                      select std;
                        foreach (Student item in stdlst2)
                        {
                            this.FilteredList.Add(item);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        #endregion Methods
    }
}