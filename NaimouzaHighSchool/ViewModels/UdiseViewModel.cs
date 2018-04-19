using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.ViewModels
{
    public class UdiseViewModel : StudentClassBaseViewModel
    {
        public UdiseViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private string _outputFile;
        public string OutputFile
        {
            get { return _outputFile; }
            set { _outputFile = value; OnPropertyChanged("OutputFile"); }
        }

        public UDiseProperty [] UdProperty { get; set; }

        private List<Student> slist = new List<Student>();

        private string _progressbarValue;
        public string ProgressbarValue
        {
            get { return _progressbarValue; }
            set { _progressbarValue = value; OnPropertyChanged("ProgressbarValue"); }
        }

        private BackgroundWorker bw = new BackgroundWorker();



        public RelayCommand SaveGeneratedExcelFileCommand { get; set; }

        private void StartUpInitializer()
        {
            SaveGeneratedExcelFileCommand = new RelayCommand(SaveGeneratedExcelFile, CanSaveGeneratedExcelFile);
            UdProperty = new UDiseProperty[44];
            FillUdProperty();
            ProgressbarValue = "0/0";
        }


        private void SaveGeneratedExcelFile()
        {
            // System.Windows.MessageBox.Show(OutputFile);
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressbarValue = "100 % completed";
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelExportDb db = new ExcelExportDb();
            slist = db.GetStudentListByClass(SchoolClass[this.SchoolClassIndex], SchoolSection[SchoolSectionIndex], StartYear, EndYear);
            if (slist.Count > 0)
            {
                int sListStdIndex = 0;
                try
                {
                    Excel.Application xlApp = new Excel.Application();
                    var oWB = xlApp.Workbooks.Add();
                    Excel._Worksheet workSheet = (Excel.Worksheet)xlApp.ActiveSheet;
                    workSheet.Rows.WrapText = true;
                    
                    //add column titile
                    workSheet.Cells[2, 1] = "U-DISE Code : "+GlobalVar.Udise;
                    workSheet.Cells[2, 3] = "School Name : " + GlobalVar.SchoolName;
                    workSheet.Cells[2, 5] = "Class : "+SchoolClass[SchoolClassIndex];
                    workSheet.Cells[2, 6] = "Section : " + SchoolSection[SchoolSectionIndex];
                    workSheet.Cells[2, 7] = "Academic Year : 2017-2018";

                    workSheet.Cells[3, 1] = "SL";
                    workSheet.Cells[3, 2] = "Variable";
                    workSheet.Cells[3, 4] = "Student 1";
                    workSheet.Cells[3, 5] = "Student 2";
                    workSheet.Cells[3, 6] = "Student 3";
                    workSheet.Cells[3, 7] = "Student 4";

                    workSheet.Range[workSheet.Cells[2, 1], workSheet.Cells[2, 2]].Merge();
                    workSheet.Range[workSheet.Cells[2, 3], workSheet.Cells[2, 4]].Merge();

                    int totalStudent = slist.Count;
                    this.ProgressbarValue = "0" + "%";

                    var OtrLoops = Math.Ceiling(Convert.ToDecimal(totalStudent / 4));
                    int OuterLoopNos = (int)OtrLoops;
                    int StdInLastOuter = totalStudent - (OuterLoopNos * 4);

                    // made spliting array
                    List<Student>[] StdListArray = new List<Student>[OuterLoopNos];

                    if (StdInLastOuter == 0)
                    {
                        for (int i = 0; i < OuterLoopNos; i++)
                        {
                            int startIndex = i * 4;
                            int endIndex = startIndex + 4;
                            List<Student> tempList = new List<Student>();
                            for (int k = startIndex; k < endIndex; k++)
                            {
                                tempList.Add(slist[k]);
                            }
                            StdListArray[i] = tempList;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < OuterLoopNos - 1; i++)
                        {
                            int startIndex = i * 4;
                            int endIndex = startIndex + 4;
                            List<Student> tempList = new List<Student>();
                            for (int k = startIndex; k < endIndex; k++)
                            {
                                tempList.Add(slist[k]);
                            }
                            StdListArray[i] = tempList;
                        }

                        // last array add
                        List<Student> tempList2 = new List<Student>();

                        int sIndex = (OuterLoopNos)*4;
                        for (int j = sIndex; j < slist.Count; j++)
                        {
                            tempList2.Add(slist[j]);
                        }
                        StdListArray[OuterLoopNos - 1] = tempList2;
                    }

                    int startRow = 4;
                    for (int oi = 0; oi < OuterLoopNos; oi++)
                    {
                        startRow = WriteInCell(startRow, StdListArray[oi], workSheet);
                        double percen = (oi * 4 * 100) / totalStudent;
                        ProgressbarValue = percen.ToString() + "%";
                    }

                    workSheet.Rows.AutoFit();

                    oWB.SaveAs(OutputFile, AccessMode: Excel.XlSaveAsAccessMode.xlShared);

                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    oWB.Close();
                    Marshal.ReleaseComObject(oWB);

                    //quit and release
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    OutputFile = string.Empty;
                }
                catch (Exception exl)
                {
                    System.Windows.MessageBox.Show("Problem in generating excel file. : "+sListStdIndex.ToString()+" "+exl.Message);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Sorry! there is no record.");
            }
        }

        private string GetPropVal(StudentProperty propEnum, Student s)
        {
            string pval = string.Empty;
            switch (propEnum)
            {
                case StudentProperty.Aadhaar:
                    pval = s.Aadhar;
                    break;
                case StudentProperty.Name:
                    pval = s.Name;
                    break;
                case StudentProperty.FatherName:
                    pval = s.FatherName;
                    break;
                case StudentProperty.MotherName:
                    pval = s.MotherName;
                    break;
                case StudentProperty.Dob:
                    pval = s.Dob.ToString("dd/MM/yyyy");
                    break;
                case StudentProperty.Gender:
                    if (s.Sex == "M")
                    {
                        pval = "1";
                    }
                    else if (s.Sex == "F")
                    {
                        pval = "2";
                    }
                    break;
                case StudentProperty.SocialCat:
                    if (s.SocialCategory == "GEN")
                    {
                        pval = "1";
                    }
                    else if (s.SocialCategory == "SC")
                    {
                        pval = "2";
                    }
                    else if(s.SocialCategory == "ST")
                    {
                        pval = "3";
                    }
                    else if (s.SocialCategory.Contains("OBC"))
                    {
                        pval = "4";
                    }
                    break;
                case StudentProperty.Religion:
                    pval = s.Religion;
                    break;
                case StudentProperty.MotherTongue:
                    pval = "Bengali";
                    break;
                case StudentProperty.Locality:
                    pval = s.PstAddrLane2 + ", "+s.PstAddrDist+", "+s.PstAddrPin;
                    break;
                case StudentProperty.DoA:
                    pval = string.Empty;
                    break;
                case StudentProperty.AdmNo:
                    pval = string.Empty;
                    break;
                case StudentProperty.IsBpl:
                    pval = (s.IsBpl) ? "1" : "2";
                    break;
                case StudentProperty.IsDisadvantaged:
                    pval = string.Empty;
                    break;
                case StudentProperty.GettingFreeEdu:
                    pval = string.Empty;
                    break;
                case StudentProperty.CurrYearClass:
                    pval = ClassToNumber(s.StudyingClass);
                    break;
                case StudentProperty.PrevYearClass:
                    int currClass = Convert.ToInt32(ClassToNumber(s.StudyingClass));
                    pval = (currClass - 1).ToString();
                    break;
                case StudentProperty.IfClassOne:
                    pval = string.Empty;
                    break;
                case StudentProperty.DaysAttended:
                    pval = string.Empty;
                    break;
                case StudentProperty.InstrMedium:
                    pval = "Bengali";
                    break;
                case StudentProperty.DisabilityType:
                    pval = s.PhType;
                    break;
                case StudentProperty.CWSNFacility:
                    pval = string.Empty;
                    break;
                case StudentProperty.FacilityUniform:
                    pval = "0";
                    break;
                case StudentProperty.FacilityBooks:
                    pval = string.Empty;
                    break;
                case StudentProperty.FacilityTransport:
                    pval = string.Empty;
                    break;
                case StudentProperty.FacilityEscort:
                    pval = string.Empty;
                    break;
                case StudentProperty.FacilityBicycle:
                    pval = string.Empty;
                    break;
                case StudentProperty.FacilityHostel:
                    pval = "0";
                    break;
                case StudentProperty.FacilityTraining:
                    pval = "0";
                    break;
                case StudentProperty.IsHomeLess:
                    pval = string.Empty;
                    break;
                case StudentProperty.LastExamResult:
                    pval = string.Empty;
                    break;
                case StudentProperty.LastExamPercentage:
                    pval = string.Empty;
                    break;
                case StudentProperty.CurrSchoolingStatus:
                    break;
                case StudentProperty.HsStream:
                    if (s.StudyingClass == "XI" || s.StudyingClass == "XII")
                    {
                        pval = s.Stream;
                    }
                    else
                    {
                        pval = string.Empty;
                    }
                    break;
                case StudentProperty.VocSector:
                    pval = string.Empty;
                    break;
                case StudentProperty.VocJobRoll:
                    pval = string.Empty;
                    break;
                case StudentProperty.VocCompNSQF:
                    pval = string.Empty;
                    break;
                case StudentProperty.VocOptedFor:
                    pval = string.Empty;
                    break;
                case StudentProperty.VocPlament:
                    pval = string.Empty;
                    break;
                case StudentProperty.VocSalaryOffered:
                    pval = string.Empty;
                    break;
                case StudentProperty.BankAcc:
                    pval = s.BankAcc;
                    break;
                case StudentProperty.IFSC:
                    pval = s.Ifsc;
                    break;
                case StudentProperty.Mobile:
                    pval = s.Mobile;
                    break;
                case StudentProperty.Email:
                    pval = s.Email;
                    break;
                default:
                    break;

            }
            return pval;
        }

        private bool CanSaveGeneratedExcelFile()
        {
             return !string.IsNullOrEmpty(OutputFile) && SchoolClassIndex != -1 && SchoolSectionIndex != -1;
        }

        private void FillUdProperty()
        {
            UdProperty[0] = new UDiseProperty("Student's AADHAAR Number", StudentProperty.Aadhaar);
            UdProperty[1] = new UDiseProperty("Name of the student", StudentProperty.Name);
            UdProperty[2] = new UDiseProperty("Father’s Name", StudentProperty.FatherName);
            UdProperty[3] = new UDiseProperty("Mother’s Name", StudentProperty.MotherName);
            UdProperty[4] = new UDiseProperty("Date of Birth", StudentProperty.Dob);
            UdProperty[5] = new UDiseProperty("Gender", StudentProperty.Gender);
            UdProperty[6] = new UDiseProperty("Social Category", StudentProperty.SocialCat);
            UdProperty[7] = new UDiseProperty("Religion", StudentProperty.Religion);
            UdProperty[8] = new UDiseProperty("Mother Tongue", StudentProperty.MotherTongue);
            UdProperty[9] = new UDiseProperty("Name of Habitation or Locality", StudentProperty.Locality);

            UdProperty[10] = new UDiseProperty("Date of Admission", StudentProperty.DoA);
            UdProperty[11] = new UDiseProperty("Admission Number", StudentProperty.AdmNo);
            UdProperty[12] = new UDiseProperty("Whether belong to BPL", StudentProperty.IsBpl);
            UdProperty[13] = new UDiseProperty("Belong to Disadvantaged Group", StudentProperty.IsDisadvantaged);
            UdProperty[14] = new UDiseProperty("Getting free education as per RTE Act", StudentProperty.GettingFreeEdu);
            UdProperty[15] = new UDiseProperty("Studying in Class in the year 2017-18", StudentProperty.CurrYearClass);
            UdProperty[16] = new UDiseProperty("Class studied in the Previous Year in 2016-17*", StudentProperty.PrevYearClass);
            UdProperty[17] = new UDiseProperty("If studying in class 1, Status of the previous year", StudentProperty.IfClassOne);
            UdProperty[18] = new UDiseProperty("No. of days child attended school(in the prev. year)", StudentProperty.DaysAttended);
            UdProperty[19] = new UDiseProperty("Medium of Instruction", StudentProperty.InstrMedium);

            UdProperty[20] = new UDiseProperty("Type of Disability (if any)", StudentProperty.DisabilityType);
            UdProperty[21] = new UDiseProperty("Facilities received by CWSN", StudentProperty.CWSNFacility);
            UdProperty[22] = new UDiseProperty("No. of uniform sets", StudentProperty.FacilityUniform);
            UdProperty[23] = new UDiseProperty("Set of free Text Books", StudentProperty.FacilityBooks);
            UdProperty[24] = new UDiseProperty("Free Transport", StudentProperty.FacilityTransport);
            UdProperty[25] = new UDiseProperty("Free Escort facility", StudentProperty.FacilityEscort);
            UdProperty[26] = new UDiseProperty("Free Bicycle", StudentProperty.FacilityBicycle);
            UdProperty[27] = new UDiseProperty("Free Hostel facility", StudentProperty.FacilityHostel);
            UdProperty[28] = new UDiseProperty("Special Training", StudentProperty.FacilityTraining);
            UdProperty[29] = new UDiseProperty("Whether the child is homeless", StudentProperty.IsHomeLess);

            UdProperty[30] = new UDiseProperty("Result", StudentProperty.LastExamResult);
            UdProperty[31] = new UDiseProperty("% of Marks obtained", StudentProperty.LastExamPercentage);
            UdProperty[32] = new UDiseProperty("Schooling status in 2017-18", StudentProperty.CurrSchoolingStatus);
            UdProperty[33] = new UDiseProperty("Stream", StudentProperty.HsStream);
            UdProperty[34] = new UDiseProperty("Trade / Sector", StudentProperty.VocSector);
            UdProperty[35] = new UDiseProperty("Job role", StudentProperty.VocJobRoll);
            UdProperty[36] = new UDiseProperty("Completed NSQF Level", StudentProperty.VocCompNSQF);
            UdProperty[37] = new UDiseProperty("Student Opted for", StudentProperty.VocOptedFor);
            UdProperty[38] = new UDiseProperty("Employment/Placement Status", StudentProperty.VocPlament);
            UdProperty[39] = new UDiseProperty("Salary offered", StudentProperty.VocSalaryOffered);

            UdProperty[40] = new UDiseProperty("Student’s Bank Account Number", StudentProperty.BankAcc);
            UdProperty[41] = new UDiseProperty("IFSC code of the bank branch", StudentProperty.IFSC);
            UdProperty[42] = new UDiseProperty("Mobile Number", StudentProperty.Mobile);
            UdProperty[43] = new UDiseProperty("Email", StudentProperty.Email);
        }

        private string ClassToNumber(string cls)
        {
            string clsNum = string.Empty;
            switch (cls)
            {
                case "V":
                    clsNum = "5";
                    break;
                case "VI":
                    clsNum = "6";
                    break;
                case "VII":
                    clsNum = "7";
                    break;
                case "VIII":
                    clsNum = "8";
                    break;
                case "IX":
                    clsNum = "9";
                    break;
                case "X":
                    clsNum = "10";
                    break;
                case "XI":
                    clsNum = "11";
                    break;
                case "XII":
                    clsNum = "12";
                    break;
                default:
                    break;
            }
            return clsNum;
        }

        private int WriteInCell(int startRow, List<Student> sOneRowList, Excel._Worksheet workSheet)
        {
            for (int i = 0; i < UdProperty.Length; i++)
            {
                // static
                // serial number
                workSheet.Cells[startRow + i + 1, 1] = i + 1;

                int facilityRow = 0;
                int resultRow = 0;
                int vocRow = 0;

                if (i >= 22 && i <= 28)
                {
                    workSheet.Cells[startRow + i + 1, 3] = UdProperty[i].PropertyName;
                    if (i == 22)
                    {
                        facilityRow = startRow + i + 1;
                        workSheet.Cells[facilityRow, 2] = "Facilities Provided to the student";
                        workSheet.Range[workSheet.Cells[facilityRow, 2], workSheet.Cells[facilityRow + 6, 2]].Merge();
                    }
                }
                else if (i >= 30 && i <= 31)
                {
                    workSheet.Cells[startRow + i + 1, 3] = UdProperty[i].PropertyName;
                    if (i == 30)
                    {
                        resultRow = startRow +i + 1;
                        workSheet.Cells[resultRow, 2] = "In the last examination";
                        workSheet.Range[workSheet.Cells[resultRow, 2], workSheet.Cells[resultRow + 1, 2]].Merge();
                    }
                }
                else if (i >= 34 && i <= 39)
                {
                    workSheet.Cells[startRow + i + 1, 3] = UdProperty[i].PropertyName;
                    if (i == 34)
                    {
                        vocRow = startRow + i + 1;
                        workSheet.Cells[vocRow, 2] = "For the student of grades 9 to 12 who have opted for Vocational course";
                        workSheet.Range[workSheet.Cells[vocRow, 2], workSheet.Cells[vocRow + 5, 2]].Merge();
                    }
                }
                else
                {
                    workSheet.Cells[startRow + i + 1, 2] = UdProperty[i].PropertyName;
                    workSheet.Range[workSheet.Cells[startRow + i + 1, 2], workSheet.Cells[startRow + i + 1, 3]].Merge();
                }

                // dynamic
                int sindex = 0;
                foreach (var item in sOneRowList)
                {
                    workSheet.Cells[startRow + i + 1, 4 + sindex] = GetPropVal(UdProperty[i].PropEnum, item);
                    sindex++;
                }
            }

            return startRow + UdProperty.Length + 2 ;
        }
    }
}
