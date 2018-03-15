using System;
using System.Collections.Generic;
namespace NaimouzaHighSchool.Models.Utility
{
    public class ExcelColumnStudentBuilder
    {
        public ExcelColumnStudentBuilder(List<ExcelColumnPosition> posList)
        {
            listOfPosition = new List<ExcelColumnPosition>();
            colIndex = new Dictionary<int, string>();
            listOfPosition = posList;
            setDictionary();
           
        }

        private List<ExcelColumnPosition> listOfPosition { get; set; }
        private Dictionary<int, string> colIndex { get; set; }
      
        public Student BuildStudent(string[] rowValues, string cls, string section)
        {
            Student s = new Student();
            s.StudyingClass = cls;
            if (section == "A" || section == "B" || section == "C" || section == "D" || section == "E")
            {
                s.Section = section;
            }
            for (int i = 0; i <= rowValues.Length; i++)
            {
                int j = i+1;
               
                if (colIndex.ContainsKey(j))
                {
                    string colHeader = colIndex[j];
                    switch (colHeader)
                    {
                        case "Student Name":
                            s.Name = rowValues[i];
                            
                            break;
                        case "Father Name":
                            s.FatherName = rowValues[i];
                            break;
                        case "Mother Name":
                            s.MotherName = rowValues[i];
                            break;
                        case "Guardian Name":
                            s.GuardianName = rowValues[i];
                            break;
                        case "Guardian Relation":
                            s.GuardianRelation = rowValues[i];
                            break;
                        case "Guardian Occupation":
                            s.GuardianOccupation = rowValues[i];
                            break;
                        case "Date of birth":
                            string dt = rowValues[i];
                            if (dt.IndexOf('/') > -1)
                            {
                                
                                try
                                {
                                    //s.Dob = DateTime.ParseExact(rowValues[i], "dd/MM/yyyy", null);
                                    s.Dob = DateTime.ParseExact(rowValues[i], "yyyy/MM/dd", null);

                                }
                                catch (Exception)
                                {

                                    s.Dob = DateTime.Parse(rowValues[i]);
                                }
                                
                               
                            }
                            else if (dt.IndexOf('-') > -1)
                            {
                                try
                                {
                                    //s.Dob = DateTime.ParseExact(rowValues[i], "dd-MM-yyyy", null);
                                    s.Dob = DateTime.ParseExact(rowValues[i], "yyyy-MM-dd", null);
                                }
                                catch (Exception)
                                {

                                    s.Dob = DateTime.Parse(rowValues[i]);
                                }
                                
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(dt))
                                {
                                    s.Dob = default(DateTime);
                                }
                                else
                                {
                                    double d = double.Parse(rowValues[i]);
                                    s.Dob = DateTime.FromOADate(d);
                                }

                            }
                            
                            break;
                        case "Sex":
                            s.Sex = rowValues[i];
                            break;
                        case "Section":
                            s.Section = rowValues[i];
                            break;
                        case "Roll":
                            s.Roll = Int32.Parse(rowValues[i]);
                            break;
                        case "SubjectComboId":
                            s.SubjectComboId = rowValues[i].ToString();
                            break;
                        case "Blood Group":
                            s.BloodGroup = rowValues[i];
                            break;
                        case "Present Address":
                            s.PresentAdrress = rowValues[i];
                            break;
                        case "Present AddrLane1":
                            s.PstAddrLane1 = rowValues[i];
                            break;
                        case "Present Vill. or Street":
                            s.PstAddrLane2 = rowValues[i];
                            break;
                        case "Present PO":
                            s.PstAddrPO = rowValues[i];
                            break;
                        case "Present PS":
                            s.PstAddrPS = rowValues[i];
                            break;
                        case "Present Dist":
                            s.PstAddrDist = rowValues[i];
                            break;
                        case "Present PIN":
                            s.PstAddrPin = rowValues[i];
                            break;

                        case "Permanent Address":
                            s.PermanentAddress = rowValues[i];
                            break;

                        case "Permanent Vill. or Street":
                            s.PmtAddrLane2 = rowValues[i];
                            break;
                        case "Permanent PO":
                            s.PmtAddrPO = rowValues[i];
                            break;
                        case "Permanent PS":
                            s.PmtAddrPS = rowValues[i];
                            break;
                        case "Permanent Dist":
                            s.PmtAddrDist = rowValues[i];
                            break;
                        case "Permanent PIN":
                            s.PmtAddrPin = rowValues[i];
                            break;

                        case "Mobile":
                            s.Mobile = rowValues[i];
                            break;
                        case "Guardian Mobile":
                            s.GuardianMobile = rowValues[i];
                            break;
                        case "Email":
                            s.Email = rowValues[i];
                            break;
                        case "Religion":
                            s.Religion = rowValues[i];
                            break;
                        case "Social Category":
                            s.SocialCategory = rowValues[i];
                            break;
                        case "Sub Cast":
                            s.SubCast = rowValues[i];
                            break;
                        case "Is PH":
                            string val = rowValues[i].ToUpper();
                            if (val == "Y" || val == "YES" || val == "1")
                            {
                                s.IsPH = true;
                            }
                            else
                            {
                                s.IsPH = false;
                            }
                            break;
                        case "PH type":
                            s.PhType = rowValues[i];
                            break;
                        case "Is BPL":
                            string valBPL = rowValues[i].ToUpper();
                            if (valBPL == "Y" || valBPL == "YES" || valBPL == "1" || valBPL == "BPL")
                            {
                                s.IsBpl = true;
                            }
                            else
                            {
                                s.IsBpl = false;
                            }
                            break;
                        case "BPL Number":
                            s.BplNo = rowValues[i];
                            break;
                        case "Aadhar":
                            s.Aadhar = rowValues[i];
                            break;
                        case "Guardian Aadhar":
                            s.GuardianAadhar = rowValues[i];
                            break;
                        case "Guardian Epic":
                            s.GuardianEpic = rowValues[i];
                            break;
                        case "Board No":
                            s.BoardNo = rowValues[i];
                            break;
                        case "Board Roll":
                            s.BoardRoll = rowValues[i];
                            break;
                        case "Council No":
                            s.CouncilNo = rowValues[i];
                            break;
                        case "Council Roll":
                            s.CouncilRoll = rowValues[i];
                            break;
                        case "Admission No.":
                            s.AdmissionNo = rowValues[i];
                            break;
                        case "Admitted Class":
                            s.AdmittedClass = rowValues[i];
                            break;
                        case "Date of Admission":
                            string dt_adm = rowValues[i];
                            if (dt_adm.IndexOf('/') > -1)
                            {
                                
                                try
                                {
                                    s.AdmDate = DateTime.ParseExact(rowValues[i], "dd/MM/yyyy", null);
                                }
                                catch (Exception)
                                {

                                    s.AdmDate = DateTime.Parse(rowValues[i]);
                                }
                                
                               
                            }
                            else if (dt_adm.IndexOf('-') > -1)
                            {
                                try
                                {
                                    s.AdmDate = DateTime.ParseExact(rowValues[i], "dd-MM-yyyy", null);
                                }
                                catch (Exception)
                                {

                                    s.AdmDate = DateTime.Parse(rowValues[i]);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(dt_adm))
                                {
                                    s.AdmDate = default(DateTime);
                                }
                                else
                                {
                                    double d1 = double.Parse(rowValues[i]);
                                    s.AdmDate = DateTime.FromOADate(d1);
                                }
                                
                               
                            }
                           
                            break;
                        case "Last School":
                            s.LastSchool = rowValues[i];
                            break;
                        case "Date of Leaving":
                            string dt_leave = rowValues[i];
                            if (dt_leave.IndexOf('/') > -1)
                            {
                                try
                                {
                                    s.DateOfLeaving = DateTime.ParseExact(rowValues[i], "dd/MM/yyyy", null);
                                }
                                catch (Exception)
                                {

                                    s.DateOfLeaving = DateTime.Parse(rowValues[i]);
                                }
                               
                               
                            }
                            else if(dt_leave.IndexOf('-') > -1)
                            {
                                try
                                {
                                    s.DateOfLeaving = DateTime.ParseExact(rowValues[i], "dd-MM-yyyy", null);
                                }
                                catch (Exception)
                                {

                                    s.DateOfLeaving = DateTime.Parse(rowValues[i]);
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(dt_leave))
                                {
                                    s.DateOfLeaving = default(DateTime);
                                }
                                else
                                {
                                    double d2 = double.Parse(rowValues[i]);
                                    s.DateOfLeaving = DateTime.FromOADate(d2);
                                }
                                
                               
                            }
                            break;
                        case "TC detail":
                            s.TC = rowValues[i];
                            break;

                        case "Stream":
                            s.Stream = rowValues[i];
                            break;

                        case "HS Sub1":
                            s.HsSub1 = rowValues[i];
                            break;

                        case "HS Sub2":
                            s.HsSub2 = rowValues[i];
                            break;

                        case "HS Sub3":
                            s.HsSub3 = rowValues[i];
                            break;

                        case "HS Adl Sub":
                            s.HsAdlSub = rowValues[i];
                            break;

                        case "Third Language":
                            s.ThirdLang = rowValues[i];
                            break;

                        case "Bank Acc. No.":
                            s.BankAcc = rowValues[i];
                            break;
                        case "Bank Name":
                            s.BankName = rowValues[i];
                            break;
                        case "Branch Name":
                            s.BankBranch = rowValues[i];
                            break;
                        case "Branch IFSC":
                            s.Ifsc = rowValues[i];
                            break;
                        case "MICR code":
                            s.MICR = rowValues[i];
                            break;
                        default:
                            break;
                    }
                }
            }
            return s;
        }

       /// <summary>
       /// Converts col lable from A, B, C... to 1,2,3... and adds them in dictionary
       /// </summary>
        private void setDictionary()
        {
            string[] validColPos = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
            foreach (ExcelColumnPosition item in listOfPosition)
            {
                if (!String.IsNullOrWhiteSpace(item.ColPosition))
                {
                    colIndex.Add((Array.IndexOf(validColPos, item.ColPosition)+1), value: item.ColName);
                }
            }
        }

    }
}
