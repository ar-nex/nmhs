using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using NaimouzaHighSchool;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class StudentDataReadDb : BaseDb
    {
        public StudentDataReadDb()
        : base()
        {

        }

        public List<Student> GetStudentList(string type, string param)
        {
            List<Student> sList = new List<Student>();
            string sql;
            switch (type)
            {
                case "name":
                    sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.name LIKE '%"+param+"%'";
                    break;
                case "aadhar":
                    sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.aadhar = '" + param + "'";
                    break;

                case "admissionNo":
                    sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE a.admissionNo = '" + param + "'";
                    break;
                case "madhyamicNo":
                    sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.BoardNo = '" + param + "'";
                    break;
                case "madhyamicRoll":
                    sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE s.BoardRoll = '" + param + "'";
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
                    s.IsPH = (rdr[19].ToString() == "Y") ? true: false;
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
                    s.StudyingClass = rdr[39].ToString();
                    s.Section = rdr[40].ToString();
                    s.Roll = Int32.Parse(rdr[41].ToString());

                    s.AdmissionNo = rdr[46].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[47].ToString())) ? default(DateTime) : DateTime.Parse(rdr[47].ToString());
                    s.AdmittedClass = rdr[48].ToString();
                    s.LastSchool = rdr[49].ToString();
                    s.DateOfLeaving = (string.IsNullOrEmpty(rdr[50].ToString())) ? default(DateTime) : DateTime.Parse(rdr[50].ToString());
                    s.TC = rdr[51].ToString();

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

        public List<Student> GetStudentListByClass(string cls)
        {
            List<Student> sList = new List<Student>();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
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
                    s.StudyingClass = rdr[39].ToString();
                    s.Section = rdr[40].ToString();
                    s.Roll = Int32.Parse(rdr[41].ToString());

                    s.AdmissionNo = rdr[46].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[47].ToString())) ? default(DateTime) : DateTime.Parse(rdr[47].ToString());
                    s.AdmittedClass = rdr[48].ToString();
                    s.LastSchool = rdr[49].ToString();
                    s.DateOfLeaving = (string.IsNullOrEmpty(rdr[50].ToString())) ? default(DateTime) : DateTime.Parse(rdr[50].ToString());
                    s.TC = rdr[51].ToString();

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

        public List<Student> GetStudentListByClass(string cls, string sec)
        {
            List<Student> sList = new List<Student>();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.section='" + sec + "'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
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
                    s.StudyingClass = rdr[39].ToString();
                    s.Section = rdr[40].ToString();
                    s.Roll = Int32.Parse(rdr[41].ToString());

                    s.AdmissionNo = rdr[46].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[47].ToString())) ? default(DateTime) : DateTime.Parse(rdr[47].ToString());
                    s.AdmittedClass = rdr[48].ToString();
                    s.LastSchool = rdr[49].ToString();
                    s.DateOfLeaving = (string.IsNullOrEmpty(rdr[50].ToString())) ? default(DateTime) : DateTime.Parse(rdr[50].ToString());
                    s.TC = rdr[51].ToString();

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

        public List<Student> GetStudentListByClass(string cls, string sec, int roll)
        {
            List<Student> sList = new List<Student>();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.section='" + sec + "' AND c.roll = '" + roll + "'";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
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
                    s.StudyingClass = rdr[39].ToString();
                    s.Section = rdr[40].ToString();
                    s.Roll = Int32.Parse(rdr[41].ToString());

                    s.AdmissionNo = rdr[46].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[47].ToString())) ? default(DateTime) : DateTime.Parse(rdr[47].ToString());
                    s.AdmittedClass = rdr[48].ToString();
                    s.LastSchool = rdr[49].ToString();
                    s.DateOfLeaving = (string.IsNullOrEmpty(rdr[50].ToString())) ? default(DateTime) : DateTime.Parse(rdr[50].ToString());
                    s.TC = rdr[51].ToString();

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
    }
}
