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
                string sql = @"SELECT b.name, b.fatherName, b.sex, b.dob, b.presentAddress, c.class, c.section, c.roll from student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class = '" + searchData[0] + "' AND c.section = '" + searchData[1] + "' AND c.roll = " + searchData[2] + " AND c.startYear = '" + searchData[3] + "' AND c.endYear = '" + searchData[4] + "'";
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
                    
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("characterCertificate : "+e.Message);
            }
            
            return s;
        }
    }
}
