using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using NaimouzaHighSchool;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class ExcelExportDb : BaseDb
    {
        public ExcelExportDb()
        : base()
        {

        }


        public List<Student> GetStudentListByClass(string cls, int sYear, int eYear)
        {
            List<Student> sList = new List<Student>();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.startYear = '" +sYear.ToString()+"' AND c.endYear = '"+eYear.ToString()+"'";

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

                    s.RegistrationNoMp = rdr[37].ToString();
                    s.RegistrationNoHs = rdr[38].ToString();

                    s.StudyingClass = rdr[41].ToString();
                    s.Section = rdr[42].ToString();
                    s.Roll = Int32.Parse(rdr[43].ToString());
                 //   s.SubjectComboId = rdr[44].ToString();

                    s.AdmissionNo = rdr[52].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[53].ToString())) ? default(DateTime) : DateTime.Parse(rdr[53].ToString());
                    s.AdmittedClass = rdr[54].ToString();
                    s.LastSchool = rdr[55].ToString();
                    s.DateOfLeaving = (string.IsNullOrEmpty(rdr[56].ToString())) ? default(DateTime) : DateTime.Parse(rdr[56].ToString());
                    s.TC = rdr[57].ToString();

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

        public List<Student> GetStudentListByClass(string cls, string sec, int sYear, int eYear)
        {
            List<Student> sList = new List<Student>();
            string sql = @"SELECT s.*, c.*, a.* FROM `student_basic` s 
                            INNER JOIN student_class c ON c.student_basic_id = s.id 
                            INNER JOIN admission a ON a.student_basic_id = s.id WHERE c.class = '" + cls + "' AND c.section='" + sec + "' AND c.startYear = '" + sYear.ToString() + "' AND c.endYear = '" + eYear.ToString() + "'";
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

                    s.RegistrationNoMp = rdr[37].ToString();
                    s.RegistrationNoHs = rdr[38].ToString();

                    s.StudyingClass = rdr[41].ToString();
                    s.Section = rdr[42].ToString();
                    s.Roll = Int32.Parse(rdr[43].ToString());
            //        s.SubjectComboId = rdr[44].ToString();

                    s.AdmissionNo = rdr[52].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[53].ToString())) ? default(DateTime) : DateTime.Parse(rdr[53].ToString());
                    s.AdmittedClass = rdr[54].ToString();
                    s.LastSchool = rdr[55].ToString();
                    s.DateOfLeaving = (string.IsNullOrEmpty(rdr[56].ToString())) ? default(DateTime) : DateTime.Parse(rdr[56].ToString());
                    s.TC = rdr[57].ToString();

                    sList.Add(s);

                }
            }
            catch (Exception e1x)
            {

                System.Windows.MessageBox.Show("e1x : " + e1x.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return sList;
        }
    }
}
