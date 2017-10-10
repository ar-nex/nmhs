using System;
using System.Windows;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    class ExcelEntryDb : BaseDb
    {
        public ExcelEntryDb()
        : base()
        {

        }

        public bool InsertFromExcel(Student s, string sessionStartYear, string sessionEndYear)
        {
            bool inserted = false;
            try
            {
                this.conn.Open();
                MySqlCommand cmd = this.conn.CreateCommand();
                MySqlTransaction myTrans = this.conn.BeginTransaction();
                cmd.Connection = this.conn;
                cmd.Transaction = myTrans;

                try
                {
                    string dt = s.Dob.ToString("yyyy-MM-dd");
                    string isPh = s.IsPH ? "Y" : "N";
                    string isBpl = s.IsBpl ? "Y" : "N";
                   
                    string bordNo = String.IsNullOrWhiteSpace(s.BoardNo) ? "NULL" : "'" + s.BoardNo + "'";
                    string bordRoll = String.IsNullOrWhiteSpace(s.BoardRoll) ? "NULL" : "'" + s.BoardRoll + "'";
                    string councilNo = String.IsNullOrWhiteSpace(s.CouncilNo) ? "NULL" : "'" + s.CouncilNo + "'";
                    string councilRoll = String.IsNullOrWhiteSpace(s.CouncilRoll) ? "NULL" : "'" + s.CouncilRoll+ "'";
                    string sbComboId = string.IsNullOrEmpty(s.SubjectComboId) ? "NULL" : "'" + s.SubjectComboId + "'";

                    string bankMICR = String.IsNullOrWhiteSpace(s.MICR) ? "NULL" : "'" + s.MICR + "'";
                    

                    string sql = @"INSERT INTO student_basic (aadhar, name, fatherName, motherName, guardianName, guardianRelation, guardianOccupation, dob, sex, presentAddress, permanentAddress, mobile, guardianMobile, email, religion, socialCategory, isPh, phType, isBPL, BPLnumber, guardianAadhar, guardianEpic, bloodGroup, bankAccountNo, bankName, branchName, IFSC)
                    VALUES ('"+s.Aadhar+"', '"+s.Name+"' , '"+s.FatherName+"', '"+s.MotherName+"', '"+s.GuardianName+"', '"+s.GuardianRelation+"', '"+s.GuardianOccupation+"', '"+dt+"', '"+s.Sex+"', '"+s.PresentAdrress+"', '"+s.PermanentAddress+"', '"+s.Mobile+"', '"+s.GuardianMobile+"', '"+s.Email+"', '"+s.Religion+"', '"+s.SocialCategory+"', '"+isPh+"', '"+s.PhType+"', '"+isBpl+"', '"+s.BplNo+"', '"+s.GuardianAadhar+"', '"+s.GuardianEpic+"', '"+s.BloodGroup+"', '"+s.BankAcc+"', '"+s.BankName+"', '"+s.BankBranch+"', '"+s.Ifsc+"')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    long insertedId = cmd.LastInsertedId;


                    string strm = string.IsNullOrEmpty(s.Stream) ? "NULL" : "'" + s.Stream + "'";
                    string thirdlang = string.IsNullOrEmpty(s.ThirdLang) ? "NULL" : "'" +s.ThirdLang+ "'";
                    string roll = (s.Roll == 0) ? "NULL" : s.Roll.ToString();
                    string sub1 = string.IsNullOrEmpty(s.HsSub1) ? "NULL" : "'" + s.HsSub1 + "'";
                    string sub2 = string.IsNullOrEmpty(s.HsSub2) ? "NULL" : "'" + s.HsSub2 + "'";
                    string sub3 = string.IsNullOrEmpty(s.HsSub3) ? "NULL" : "'" + s.HsSub3 + "'";
                    string adl = string.IsNullOrEmpty(s.HsAdlSub) ? "NULL" : "'" + s.HsAdlSub + "'";


                    string sql2 = @"INSERT INTO student_class (startYear, endYear, student_basic_id, class, section, roll, stream, thirdLanguage, hsElemSub1, hsElemSub2, hsElemSub3, hsAdlSub)
                    VALUES ('" +sessionStartYear+"', '"+sessionEndYear+"', '"+insertedId+"', '"+s.StudyingClass+"', '"+s.Section+"', '"+s.Roll+"', "+strm+", '"+s.ThirdLang+"', '"+s.HsSub1+"', '"+s.HsSub2+"', '"+s.HsSub3+"', '"+s.HsAdlSub+"' )";
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    string admNo = String.IsNullOrWhiteSpace(s.AdmissionNo) ? "NULL" : "'" + s.AdmissionNo + "'";
                    string dtAdm = s.AdmDate.ToString("yyyy-MM-dd");
                    string dtOfAdm;
                    if (dtAdm == "0001-01-01")
                    {
                        dtOfAdm = "NULL";
                    }
                    else 
                    {
                        dtOfAdm = "'"+dtAdm+"'";
                    }
                    string admClass = String.IsNullOrWhiteSpace(s.AdmittedClass) ? "NULL" : "'" + s.AdmittedClass + "'";
                    string lastSchool = String.IsNullOrWhiteSpace(s.LastSchool) ? "NULL" : "'" + s.LastSchool + "'";
                    string dtLeave = s.DateOfLeaving.ToString("yyyy-MM-dd");
                    string dateOfLeaving;
                    if (dtLeave == "0001-01-01")
                    {
                        dateOfLeaving = "NULL";
                    }
                    else
                    {
                        dateOfLeaving = dtLeave;
                    }
                    string tc = String.IsNullOrWhiteSpace(s.TC) ? "NULL" : "'" + s.TC + "'";

                    string sql3 = @"INSERT INTO Admission (admissionNo, dateOfAdmission, admittedClass, lastSchool, dateOfLeaving, TC, student_basic_id)
                    VALUES("+admNo+", "+dtOfAdm+", "+admClass+", "+lastSchool+", "+dateOfLeaving+", "+tc+", "+insertedId+")";
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    
                    myTrans.Commit();
                    inserted = true;
                }
                catch (Exception e2)
                {

                    try
                    {
                        myTrans.Rollback();
                        inserted = false;
                    }
                    catch (Exception e3)
                    {

                        MessageBox.Show(e3.Message);
                    }
                    MessageBox.Show(e2.Message);
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
                
            }
            finally
            {
                this.conn.Close();
            }
            return inserted;
        }
    }
}
