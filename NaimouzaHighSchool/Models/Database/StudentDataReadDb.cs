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
                    //sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                    //        INNER JOIN student_class c ON c.student_basic_id = s.id 
                    //        INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.name LIKE '%"+param+"%' AND c.startYear = "+sYear+" AND c.endYear = "+eYear;

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                        $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                        $" WHERE s.name LIKE '%{param}%' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                case "aadhar":
                    //sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                    //        INNER JOIN student_class c ON c.student_basic_id = s.id 
                    //        INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.aadhar = '" + param + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                        $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                        $" WHERE s.aadhar = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;

                case "admissionNo":
                    //sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                    //        INNER JOIN student_class c ON c.student_basic_id = s.id 
                    //        INNER JOIN admission a ON a.student_basic_id = s.id WHERE a.admissionNo = '" + param + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                    $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                    $" WHERE a.admissionNo = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                case "madhyamicNo":
                    //sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                    //        INNER JOIN student_class c ON c.student_basic_id = s.id 
                    //        INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.BoardNo = '" + param + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

                    sql = $"SELECT s.*, c.*, a.* FROM {basic_table} s INNER JOIN student_class c ON c.student_basic_id = s.id" +
                    $" INNER JOIN admission a ON a.student_basic_id = s.id" +
                    $" WHERE s.BoardNo = '{param}' AND c.startYear = '{sYear}' AND c.endYear = '{eYear}'";
                    break;
                case "madhyamicRoll":
                    //sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                    //        INNER JOIN student_class c ON c.student_basic_id = s.id 
                    //        INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.BoardRoll = '" + param + "' AND c.startYear = " + sYear + " AND c.endYear = " + eYear;

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

        private Student BuildObject_old(MySqlDataReader rdr)
        {
            Student s = new Student();
            s.Id = rdr[0].ToString();
            s.Aadhar = rdr[1].ToString();
            s.Name = rdr[2].ToString();
            s.FatherName = rdr[3].ToString();
            s.MotherName = rdr[4].ToString();
            s.GuardianName = rdr[5].ToString();
            s.GuardianRelation = rdr[6].ToString();

            s.GuardianOccupation = rdr[7].ToString();
            s.Dob = (string.IsNullOrEmpty(rdr[8].ToString())) ? default(DateTime) : DateTime.Parse(rdr[8].ToString());
            s.Sex = rdr[9].ToString();
            s.PresentAdrress = rdr[11].ToString();
            s.PermanentAddress = rdr[12].ToString();

            s.Mobile = rdr[13].ToString();
            s.GuardianMobile = rdr[14].ToString();
            s.Email = rdr[15].ToString();
            s.Religion = rdr[16].ToString();
            s.SocialCategory = rdr[17].ToString();

            s.SubCast = rdr[18].ToString();
            s.IsPH = (rdr[19].ToString() == "Y") ? true : false;
            s.PhType = rdr[20].ToString();
            s.IsBpl = (rdr[21].ToString() == "Y") ? true : false;
            s.BplNo = rdr[22].ToString();

            s.GuardianAadhar = rdr[23].ToString();
            s.GuardianEpic = rdr[24].ToString();
            s.BloodGroup = rdr[25].ToString();
            s.BankAcc = rdr[26].ToString();
            s.BankName = rdr[27].ToString();

            s.BankBranch = rdr[28].ToString();
            s.Ifsc = rdr[29].ToString();
            s.MICR = rdr[30].ToString();
            s.BoardRoll = rdr[33].ToString();
            s.BoardNo = rdr[34].ToString();

            s.CouncilRoll = rdr[35].ToString();
            s.CouncilNo = rdr[36].ToString();

            s.RegistrationNoMp = rdr[37].ToString();
            s.RegistrationNoHs = rdr[38].ToString();

            s.StudyingClass = rdr[41].ToString();
            s.Section = rdr[42].ToString();
            s.Roll = Int32.Parse(rdr[43].ToString());
            // s.SubjectComboId = rdr[44].ToString(); 
            s.HsSub1 = rdr[46].ToString();
            s.HsSub2 = rdr[47].ToString();
            s.HsSub3 = rdr[48].ToString();
            s.HsAdlSub = rdr[49].ToString();


            s.AdmissionNo = rdr[52].ToString();
            s.AdmDate = (string.IsNullOrEmpty(rdr[53].ToString())) ? default(DateTime) : DateTime.Parse(rdr[53].ToString());
            s.AdmittedClass = rdr[54].ToString();
            s.LastSchool = rdr[55].ToString();
            s.DateOfLeaving = (string.IsNullOrEmpty(rdr[56].ToString())) ? default(DateTime) : DateTime.Parse(rdr[56].ToString());
            s.TC = rdr[57].ToString();
            return s;
        }
       

        public ArrayList GetComboSubjects(string comboId)
        {
            ArrayList sList = new ArrayList();
            try
            {
                this.conn.Open();
                string sql = "SELECT s.Name FROM Subject s WHERE id IN (SELECT Subject_id FROM SubjectCombo_has_Subject WHERE SubjectCombo_id="+comboId+")";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    sList.Add(rdr[0].ToString());
                }
            }
            catch (Exception ex3)
            {
                System.Windows.MessageBox.Show("ex3" + ex3.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return sList;
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

        public List<SubjectCombo> GetComobCodeList()
        {
            List<SubjectCombo> comboList = new List<SubjectCombo>();
            /*
            string sql = "SELECT * FROM `subjectcombo`";
            try
            {
                this.conn.Open();
                 MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    comboList.Add(new SubjectCombo(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
                }

            }
            catch (Exception ex6r)
            {
                System.Windows.MessageBox.Show("ex6r : "+ex6r.Message);
            }
            finally
            {
                this.conn.Close();
            }
             */
            return comboList;
        }
    }
}
