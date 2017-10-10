using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class StudentDataWriteDb : BaseDb
    {
        public StudentDataWriteDb()
        : base()
        {

        }

        public List<SubjectCombo> GetCombo()
        {
            List<SubjectCombo> cmbo = new List<SubjectCombo>();
            /*
            try
            {
                this.conn.Open();
                string sql = @"SELECT * FROM subjectcombo";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbo.Add(new SubjectCombo(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
                }
            }
            catch (Exception e1)
            {

                System.Windows.MessageBox.Show(e1.Message);
            }
            finally
            {
                this.conn.Close();
            }
             */
            return cmbo;
        }

        public bool InsertStudentData(Student s, string sessionStartYear, string sessionEndYear)
        {
            bool inserted = false;

            string aadhar = string.IsNullOrEmpty(s.Aadhar) ? "NULL" : "'" + s.Aadhar + "'";
            string name = "'" + s.Name + "'";
            string fatherName = string.IsNullOrEmpty(s.FatherName) ? "NULL" : "'" + s.FatherName + "'";
            string motherName = string.IsNullOrEmpty(s.MotherName) ? "NULL" : "'" + s.MotherName + "'";
            string guardianName = string.IsNullOrEmpty(s.GuardianName) ? "NULL" : "'" + s.GuardianName + "'";
            string guardianRelation = string.IsNullOrEmpty(s.GuardianRelation) ? "NULL" : "'" + s.GuardianRelation + "'";
            string guardianOccupation = string.IsNullOrEmpty(s.GuardianOccupation) ? "NULL" : "'" + s.GuardianOccupation + "'";
            string dob_temp = s.Dob.ToString("yyyy-MM-dd");
            string dob = (dob_temp == "0001-01-01") ? "NULL" : "'" + dob_temp + "'";
            string sex = string.IsNullOrEmpty(s.Sex) ? "NULL" : "'" + s.Sex + "'";
            // registration Not implemented yet.
            string presentAddress = string.IsNullOrEmpty(s.PresentAdrress) ? "NULL" : "'" + s.PresentAdrress + "'";
            string permanentAddress = string.IsNullOrEmpty(s.PermanentAddress) ? "NULL" : "'" + s.PermanentAddress + "'";
            string mobile = string.IsNullOrEmpty(s.Mobile) ? "NULL" : "'" + s.Mobile + "'";
            string grdMobile = string.IsNullOrEmpty(s.GuardianMobile) ? "NULL" : "'" + s.GuardianMobile + "'";
            string email = string.IsNullOrEmpty(s.Email) ? "NULL" : "'" + s.Email + "'";
            string religion = string.IsNullOrEmpty(s.Religion) ? "NULL" : "'" + s.Religion + "'";
            string socialCat = string.IsNullOrEmpty(s.SocialCategory) ? "NULL" : "'" + s.SocialCategory + "'";
            string subCast = string.IsNullOrEmpty(s.SubCast) ? "NULL" : "'" + s.SubCast + "'";
            string isPH = (s.IsPH) ? "'Y'" : "'N'";
            string phType = string.IsNullOrEmpty(s.PhType) ? "NULL" : "'" + s.PhType + "'";
            string isBpl = (s.IsBpl) ? "'Y'" : "'N'";
            string bplNo = string.IsNullOrEmpty(s.BplNo) ? "NULL" : "'" + s.BplNo + "'";
            string grdAadhar = string.IsNullOrEmpty(s.GuardianAadhar) ? "NULL" : "'" + s.GuardianAadhar + "'";
            string grdEpic = string.IsNullOrEmpty(s.GuardianEpic) ? "NULL" : "'" + s.GuardianEpic + "'";
            string bloodGroup = string.IsNullOrEmpty(s.BloodGroup) ? "NULL" : "'" + s.BloodGroup + "'";
            string bankAcc = string.IsNullOrEmpty(s.BankAcc) ? "NULL" : "'" + s.BankAcc + "'";
            string bankName = string.IsNullOrEmpty(s.BankName) ? "NULL" : "'" + s.BankName + "'";
            string branchName = string.IsNullOrEmpty(s.BankBranch) ? "NULL" : "'" + s.BankBranch + "'";
            string ifsc = string.IsNullOrEmpty(s.Ifsc) ? "NULL" : "'" + s.Ifsc + "'";
            string micr = string.IsNullOrEmpty(s.MICR) ? "NULL" : "'" + s.MICR + "'";
            string boardNo = string.IsNullOrEmpty(s.BoardNo) ? "NULL" : "'" + s.BoardNo + "'";
            string boardRoll = string.IsNullOrEmpty(s.BoardRoll) ? "NULL" : "'" + s.BoardRoll + "'";
            string councilNo = string.IsNullOrEmpty(s.CouncilNo) ? "NULL" : "'" + s.CouncilNo + "'";
            string councilRoll = string.IsNullOrEmpty(s.CouncilRoll) ? "NULL" : "'" + s.CouncilRoll + "'";

            string cls ="'" + s.StudyingClass + "'";
            string section = string.IsNullOrEmpty(s.Section) ? "NULL" : "'" + s.Section + "'";
            string roll = s.Roll.ToString();
           // string comboId = s.SubjectComboId;

            string admissionNo = string.IsNullOrEmpty(s.AdmissionNo) ? "NULL" : "'" + s.AdmissionNo + "'";
            string doa_temp = s.AdmDate.ToString("yyyy-MM-dd");
            string doa = (doa_temp == "0001-01-01") ? "NULL" : "'" + doa_temp + "'";
            string admittedClass = string.IsNullOrEmpty(s.AdmittedClass) ? "NULL" : "'" + s.AdmittedClass + "'";
            string lastSchool = string.IsNullOrEmpty(s.LastSchool) ? "NULL" : "'" + s.LastSchool + "'";
            string dol_temp = s.DateOfLeaving.ToString("yyyy-MM-dd");
            string dol = (dol_temp == "0001-01-01") ? "NULL" : "'" + dol_temp + "'";
            string tc = string.IsNullOrEmpty(s.TC) ? "NULL" : "'" + s.TC + "'";

            try
            {
                this.conn.Open();
                MySqlCommand cmd = this.conn.CreateCommand();
                MySqlTransaction myTrans = this.conn.BeginTransaction();
                cmd.Connection = this.conn;
                cmd.Transaction = myTrans;
                try
                {

                    string sql = @"INSERT INTO student_basic (
                                        aadhar, 
                                        name, 
                                        fatherName, 
                                        motherName, 
                                        guardianName, 
                                        guardianRelation, 
                                        guardianOccupation, 
                                        dob, 
                                        sex, 
                                        presentAddress, 
                                        permanentAddress, 
                                        mobile, 
                                        guardianMobile, 
                                        email, 
                                        religion, 
                                        socialCategory, 
                                        isPh, 
                                        phType, 
                                        isBPL, 
                                        BPLnumber, 
                                        guardianAadhar, 
                                        guardianEpic, 
                                        bloodGroup, 
                                        bankAccountNo, 
                                        bankName, 
                                        branchName, 
                                        IFSC,
                                        bankMICR,
                                        BoardRoll,
                                        BoardNo,
                                        CouncilRoll,
                                        CouncilNo)
                    VALUES (
                            " + aadhar+", "
                             +name+", "
                             +fatherName+", "
                             +motherName+", "
                             +guardianName+", "
                             +guardianRelation+", "
                             +guardianOccupation+", "
                             +dob+", "
                             +sex+", "
                             +presentAddress+", "
                             +permanentAddress+", "
                             +mobile+", "
                             +grdMobile+", "
                             +email+", "
                             +religion+", "
                             +socialCat+", "
                             +isPH+", "
                             +phType+", "
                             +isBpl+", "
                             +bplNo+", "
                             +grdAadhar+", "
                             +grdEpic+", "
                             +bloodGroup+", "
                             +bankAcc+", "
                             +bankName+", "
                             +branchName+", "
                             +ifsc+", "
                             +micr+", "
                             +boardRoll+", "
                             +boardNo+", "
                             +councilRoll+", "
                             +councilNo+
                            ")";

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    long insertedId = cmd.LastInsertedId;

                    string sql2 = @"INSERT INTO student_class (startYear, endYear, student_basic_id, class, section, roll)
                    VALUES ('" + sessionStartYear + "', '" + sessionEndYear + "', " + insertedId + ", " + cls + ", " + section + ", " + roll + ")";
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    string sql3 = @"INSERT INTO Admission (admissionNo, dateOfAdmission, admittedClass, lastSchool, dateOfLeaving, TC, student_basic_id)
                    VALUES(" + admissionNo + ", " + doa + ", " + admittedClass + ", " + lastSchool + ", " + dol + ", " + tc + ", " + insertedId + ")";
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

                        System.Windows.MessageBox.Show("e3 : "+e3.Message);
                    }
                    System.Windows.MessageBox.Show("e2 : "+e2.Message);
                }
            }
            catch (Exception e1)
            {

                System.Windows.MessageBox.Show("e1 : " + e1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return inserted;
        }
    }
}
