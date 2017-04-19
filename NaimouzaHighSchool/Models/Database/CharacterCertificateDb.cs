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
    public class CharacterCertificateDb : BaseDb
    {
        public CharacterCertificateDb()
        :base()
        {

        }

        public Student GetData(string[] searchData)
        {
            Student s = new Student();
            try
            {
                this.conn.Open();
                string sql = @"SELECT b.name, b.fatherName, b.sex, b.dob, b.presentAddress, c.class, c.section, c.roll, a.admissionNo, a.dateOfAdmission from student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id INNER JOIN Admission a ON a.student_basic_id = b.id WHERE c.class = '" + searchData[0] + "' AND c.section = '" + searchData[1] + "' AND c.roll = " + searchData[2] + " AND c.startYear = '" + searchData[3] + "' AND c.endYear = '" + searchData[4] + "'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    s.Name = rdr[0].ToString();
                    s.FatherName = rdr[1].ToString();
                    s.Sex = rdr[2].ToString();
                    s.Dob = DateTime.Parse(rdr[3].ToString());
                    s.PresentAdrress = rdr[4].ToString();
                    s.StudyingClass = rdr[5].ToString();
                    s.Section = rdr[6].ToString();
                    s.Roll = Int32.Parse(rdr[7].ToString());
                    s.AdmissionNo = rdr[8].ToString();
                    s.AdmDate = (string.IsNullOrEmpty(rdr[9].ToString())) ? default(DateTime) : DateTime.Parse(rdr[9].ToString());               
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("characterCertificate : "+e.Message);
            }
            
            return s;
        }

        public List<string[]> GetDataList(string[] searchData)
        {
            List<string[]> slist = new List<string[]>();
            try
            {
                this.conn.Open();
                string sql = @"SELECT b.name, b.fatherName, b.sex, b.dob, b.presentAddress, c.class, c.section, c.roll, a.admissionNo, a.dateOfAdmission from student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id INNER JOIN Admission a ON a.student_basic_id = b.id WHERE c.class = '" + searchData[0] + "' AND c.section = '" + searchData[1] + "' AND c.startYear = '" + searchData[2] + "' AND c.endYear = '" + searchData[3] + "'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string[] s = new string[] { rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString(), rdr[6].ToString(), rdr[7].ToString(), rdr[8].ToString(), rdr[9].ToString() };
                    slist.Add(s);

                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("characterCertificate3 : " + e.Message);
            }
            return slist;
        }
    }
}
