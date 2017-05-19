using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    class SchoolLeavingAndCharacterDb : BaseDb
    {
        public SchoolLeavingAndCharacterDb()
        : base()
        {

        }

        public SchoolLeavingStudent GetDataForLeaving(string bRoll, string bNo, string exm)
        {
            SchoolLeavingStudent s = new SchoolLeavingStudent();
            string sql = string.Empty;
            if (exm.ToUpper() == "SECONDARY")
            {
                sql = @"SELECT b.name, b.fatherName, b.sex, b.permanentAddress, b.BoardRoll, b.BoardNo, e.year, e.marksObtained, e.grade, e.category FROM student_basic b INNER JOIN BoardExam e ON e.student_basic_id = b.id WHERE b.BoardRoll = '" + bRoll + "' AND b.BoardNo = '" + bNo + "' AND e.marksObtained IS NOT NULL";
            }
            else if (exm.ToUpper() == "HIGHER SECONDARY")
            {
                sql = @"SELECT b.name, b.fatherName, b.sex, b.permanentAddress, b.CouncilRoll, c.CouncilNo, e.year, e.marksObtained, e.grade, e.category FROM student_basic b INNER JOIN BoardExam e ON e.student_basic_id = b.id WHERE b.CouncilRoll = '" + bRoll + "' AND b.CouncilNo = '" + bNo + "' AND e.marksObtained IS NOT NULL";
            }
            else
            {
                return s;
            }
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    s.Name = rdr[0].ToString();
                    s.FatherName = rdr[1].ToString();
                    s.Sex = rdr[2].ToString();
                    s.PermanentAddress = rdr[3].ToString();
                    s.PassingYear = Convert.ToInt32(rdr[6]);
                    s.MarksObtained = Convert.ToInt32(rdr[7]);
                    s.Grade = rdr[8].ToString();
                    s.CandidateCategory = rdr[9].ToString();
                    if (exm.ToUpper() == "SECONDARY")
                    {
                        s.BoardRoll = rdr[4].ToString();
                        s.BoardNo = rdr[5].ToString(); 
                    }
                    else if (exm.ToUpper() == "HIGHER SECONDARY")
                    {
                        s.CouncilRoll = rdr[4].ToString();
                        s.CouncilNo = rdr[5].ToString();
                    }
                }
                
            }
            catch (Exception lex)
            {
                System.Windows.MessageBox.Show("lex : "+lex.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return s;
        }

        public List<SchoolLeavingStudent> GetDataForLeaving(int year, string exm)
        {
            List<SchoolLeavingStudent> sl = new List<SchoolLeavingStudent>();
            string sql = string.Empty;
            if (exm.ToUpper() == "SECONDARY")
            {
                sql = @"SELECT b.name, b.fatherName, b.sex, b.permanentAddress, b.BoardRoll, b.BoardNo, e.year, e.marksObtained, e.grade, e.category FROM student_basic b INNER JOIN BoardExam e ON e.student_basic_id = b.id WHERE e.year = '"+year.ToString()+"' AND e.marksObtained IS NOT NULL";
            }
            else if (exm.ToUpper() == "HIGHER SECONDARY")
            {
                sql = @"SELECT b.name, b.fatherName, b.sex, b.permanentAddress, b.CouncilRoll, c.CouncilNo, e.year, e.marksObtained, e.grade, e.category FROM student_basic b INNER JOIN BoardExam e ON e.student_basic_id = b.id WHERE e.year = '" + year.ToString() + "' AND e.marksObtained IS NOT NULL";
            }
            else
            {
                return sl;
            }
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SchoolLeavingStudent s = new SchoolLeavingStudent();
                    s.Name = rdr[0].ToString();
                    s.FatherName = rdr[1].ToString();
                    s.Sex = rdr[2].ToString();
                    s.PermanentAddress = rdr[3].ToString();
                    s.PassingYear = Convert.ToInt32(rdr[6]);
                    s.MarksObtained = Convert.ToInt32(rdr[7]);
                    s.Grade = rdr[8].ToString();
                    s.CandidateCategory = rdr[9].ToString();
                    if (exm.ToUpper() == "SECONDARY")
                    {
                        s.BoardRoll = rdr[4].ToString();
                        s.BoardNo = rdr[5].ToString();
                    }
                    else if (exm.ToUpper() == "HIGHER SECONDARY")
                    {
                        s.CouncilRoll = rdr[4].ToString();
                        s.CouncilNo = rdr[5].ToString();
                    }
                    sl.Add(s);
                }

            }
            catch (Exception lex)
            {
                System.Windows.MessageBox.Show("lex : " + lex.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return sl;
        }
    }
}
