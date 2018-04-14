using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class StudentDataReadDb : StudentBuilderFromCompleteMySqlDataReader
    {
        public StudentDataReadDb()
        : base()
        {

        }

        private string basic_table = "student_basic";

        public List<Student> GetStudentList(string type, string param, int startYear, int endYear)
        {
            List<Student> sList = new List<Student>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            string sql;
            switch (type)
            {
                case "name":

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                        $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                        $" WHERE s.name LIKE '%{param}%' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                case "aadhar":
                   
                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                        $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                        $" WHERE s.aadhar = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;

                case "admissionNo":

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                    $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                    $" WHERE a.admissionNo = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                case "madhyamicNo":
                   
                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                    $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                    $" WHERE s.BoardNo = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                case "madhyamicRoll":

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                    $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                    $" WHERE s.BoardRoll = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                default:
                    return sList;
                   
            }

            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = BuildObject(rdr);
                    sList.Add(s);
                }
            }
            catch (Exception e1)
            {

                System.Windows.MessageBox.Show("e1 : "+e1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return sList;
        }

        public List<Student> GetStudentListByClass(string cls, int startYear, int endYear)
        {
            List<Student> sList = new List<Student>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            //string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
            //                INNER JOIN student_class c ON c.student_basic_id = s.id 
            //                INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

            string sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s" +
                $" INNER JOIN student_class c ON c.student_basic_id = s.id INNER JOIN admission a ON a.student_basic_id = s.id " +
                $" WHERE c.class = '{cls}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = BuildObject(rdr);
                    sList.Add(s);
                }
            }
            catch (Exception e1cl)
            {

                System.Windows.MessageBox.Show("e1cl : " + e1cl.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return sList;
        }

        public List<Student> GetStudentListByClass(string cls, string sec, int startYear, int endYear)
        {
            List<Student> sList = new List<Student>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            //string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
            //                INNER JOIN student_class c ON c.student_basic_id = s.id 
            //                INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.section='" + sec + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

            string sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s" +
                $" INNER JOIN student_class c ON c.student_basic_id = s.id INNER JOIN admission a ON a.student_basic_id = s.id " +
                $" WHERE c.class = '{cls}' AND c.section = '{sec}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = BuildObject(rdr);
                    sList.Add(s);
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
            return sList;
        }

        public List<Student> GetStudentListByClass(string cls, string sec, int roll, int startYear, int endYear)
        {
            List<Student> sList = new List<Student>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            //string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
            //                INNER JOIN student_class c ON c.student_basic_id = s.id 
            //                INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.section='" + sec + "' AND c.roll = '" + roll + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

            string sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s" +
           $" INNER JOIN student_class c ON c.student_basic_id = s.id INNER JOIN admission a ON a.student_basic_id = s.id " +
           $" WHERE c.class = '{cls}' AND c.section = '{sec}' AND c.roll = '{roll}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = BuildObject(rdr);
                    sList.Add(s);
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
            return sList;
        
        }

        public List<Student> GetStudentListByClass(string cls, int roll, int startYear, int endYear)
        {
            List<Student> sList = new List<Student>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            //string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
            //                INNER JOIN student_class c ON c.student_basic_id = s.id 
            //                INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.roll = '" + roll + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

            string sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s" +
          $" INNER JOIN student_class c ON c.student_basic_id = s.id INNER JOIN admission a ON a.student_basic_id = s.id " +
          $" WHERE c.class = '{cls}' AND c.roll = '{roll}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = BuildObject(rdr);
                    sList.Add(s);
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
            return sList;

        }

        public List<Student> GetStudentListByClass(int roll, int startYear, int endYear)
        {
            List<Student> sList = new List<Student>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.roll = '" + roll + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student s = BuildObject(rdr);
                    sList.Add(s);
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
            return sList;

        }

        public Student GetStudent(string studentId)
        {
            Student s = new Student();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.id = '" + studentId + "'" ;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    s = BuildObject(rdr);
                }
            }
            catch (Exception es)
            {
                System.Windows.MessageBox.Show("Sorry! problem in getting updated student info. : "+es.Message);
            }
            finally
            {
                conn.Close();
            }
            return s;
        }

       

        public bool DeleteStudent(string StdId)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"DELETE FROM Marksheet WHERE student_basic_id = "+StdId;
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();      

                string sql1 = @"DELETE FROM Admission WHERE student_basic_id = " + StdId;
                MySqlCommand cmd1 = new MySqlCommand(sql1, this.conn);
                r = cmd1.ExecuteNonQuery();

                string sql2 = @"DELETE FROM student_class WHERE student_basic_id = " + StdId;
                MySqlCommand cmd2 = new MySqlCommand(sql2, this.conn);
                r = cmd2.ExecuteNonQuery();

                string sql2a = @"DELETE FROM BoardExam WHERE student_basic_id = " + StdId;
                MySqlCommand cmd2a = new MySqlCommand(sql2a, this.conn);
                r = cmd2a.ExecuteNonQuery();

                string sql3 = @"DELETE FROM student_basic WHERE id = " + StdId;
                MySqlCommand cmd3 = new MySqlCommand(sql3, this.conn);
                r = cmd3.ExecuteNonQuery();

            }

            catch (Exception e)
            {

                System.Windows.MessageBox.Show(e.Message);
            }
            finally
            {
                this.conn.Close();
            }

            rs = (r > 0) ? true : false;
            return rs;
        }

        public bool UpdateStudentInfo(Student s)
        {
            bool rs = false;
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

            string cls = "'" + s.StudyingClass + "'";
            string section = string.IsNullOrEmpty(s.Section) ? "NULL" : "'" + s.Section + "'";
            string roll = s.Roll.ToString();

            string admissionNo = string.IsNullOrEmpty(s.AdmissionNo) ? "NULL" : "'" + s.AdmissionNo + "'";
            string doa_temp = s.AdmDate.ToString("yyyy-MM-dd");
            string doa = (doa_temp == "0001-01-01") ? "NULL" : "'" + doa_temp + "'";
            string admittedClass = string.IsNullOrEmpty(s.AdmittedClass) ? "NULL" : "'" + s.AdmittedClass + "'";
            string lastSchool = string.IsNullOrEmpty(s.LastSchool) ? "NULL" : "'" + s.LastSchool + "'";
            string dol_temp = s.DateOfLeaving.ToString("yyyy-MM-dd");
            string dol = (dol_temp == "0001-01-01") ? "NULL" : "'" + dol_temp + "'";
            string tc = string.IsNullOrEmpty(s.TC) ? "NULL" : "'" + s.TC + "'";

            string sYear = "'"+s.StartSessionYear.ToString()+"'";
            string eYear = "'" + s.EndSessionYear.ToString() + "'";

            try
            {
                this.conn.Open();
                MySqlCommand cmd = this.conn.CreateCommand();
                MySqlTransaction myTrans = this.conn.BeginTransaction();
                cmd.Connection = this.conn;
                cmd.Transaction = myTrans;
                try
                {
                    string sql1 = $"UPDATE {basic_table} SET " +
                                   $" aadhar = " + aadhar + ", name=" + name + ", fatherName=" + fatherName + ", motherName=" + motherName + ", guardianName=" + guardianName + ", guardianRelation=" + guardianRelation + ", guardianOccupation=" + guardianOccupation + ", dob=" + dob + ", sex=" + sex + ", presentAddress=" + presentAddress + ", permanentAddress=" + permanentAddress + ", mobile=" + mobile + ", guardianMobile=" + grdMobile + ", email=" + email + ", religion=" + religion + ", socialCategory=" + socialCat + ", subCast=" + subCast + ", isPH=" + isPH + ", phType=" + phType + ", isBPL=" + isBpl + ", BPLnumber=" + bplNo + ", guardianAadhar=" + grdAadhar + ", guardianEpic=" + grdEpic + ", bloodGroup=" + bloodGroup + ", bankAccountNo=" + bankAcc + ", bankName=" + bankName + ", branchName=" + branchName + ", IFSC=" + ifsc + ", bankMICR=" + micr + ", BoardRoll=" + boardRoll + ", BoardNo=" + boardNo + ", CouncilRoll=" + councilRoll + ", CouncilNo=" + councilNo + " WHERE id=" + s.Id;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery();

                    string sql2 = $"UPDATE student_class SET class=" + cls + ", section=" + section + ", roll=" + roll + " WHERE student_basic_id=" + s.Id + " AND startYear = "+sYear+" AND endYear = "+eYear;
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    string sql3 = $"UPDATE Admission SET admissionNo=" + admissionNo + ", dateOfAdmission=" + doa + ", admittedClass=" + admittedClass + ", lastSchool=" + lastSchool + ", dateOfLeaving=" + dol + ", TC=" + tc + " WHERE student_basic_id=" + s.Id;
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();

                    myTrans.Commit();  
                    rs = true;
                }
                catch(Exception ex5)
                {
                    try
                    {
                        myTrans.Rollback();
                        rs = false;
                    }
                    catch (Exception e3)
                    {

                        System.Windows.MessageBox.Show("e3 : " + e3.Message);
                    }
                    System.Windows.MessageBox.Show("ex5 : " + ex5.Message);
                }
            }
            catch (Exception ex4)
            {
                System.Windows.MessageBox.Show("ex4 : "+ex4.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return rs;
        }

        public string[] IsRollExists(int syear, int eyear, string cls, string section, int roll, string stdId)
        {
            string[] rdata = new string[2];
            try
            {
                string sql = "SELECT b.id, b.name FROM "+basic_table+" b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.startYear = '"+syear.ToString()+"' AND c.endYear = '"+eyear.ToString()+"' AND c.class = '"+cls+"' AND c.section = '"+section+"' AND c.roll='"+roll.ToString()+"'";
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                string dupName = string.Empty;
                int i = 0;
                while (rdr.Read())
                {
                    if (rdr[0].ToString() != stdId)
                    {
                        i++;
                        dupName = rdr[1].ToString();
                    }
                }
                rdata[0] = i.ToString();
                rdata[1] = dupName;
            }
            catch (Exception exr)
            {

                System.Windows.MessageBox.Show("exr : "+exr.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return rdata;
        
        }

       
    }
}
