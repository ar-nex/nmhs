using System;
using System.Data;
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
    public class BoardExamDb : BaseDb
    {
        public BoardExamDb()
        : base()
        {
            this.ds = new DataSet();
            this.conn = new MySqlConnection(this.connStr);
           // this.GetData();
        }

        public DataSet ds;
        private MySqlDataAdapter da;

        public List<BoardStudent> GetData(string cls, string syear, string eyear)
        {
            List<BoardStudent> lbs = new List<BoardStudent>();
            try
            {
            
                this.conn.Open();
                string sql = "SELECT b.id, b.name, c.class, c.section, c.roll FROM student_basic b LEFT JOIN BoardExam e ON e.student_basic_id = b.id INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class = '" + cls + "' AND c.startYear = '" + syear + "' AND c.endYear = '" + eyear + "' AND e.marksObtained IS NULL";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BoardStudent bs = new BoardStudent();
                    bs.Id = rdr[0].ToString();
                    bs.Name = rdr[1].ToString();
                    bs.Cls = rdr[2].ToString();
                    bs.Section = rdr[3].ToString();
                    bs.Roll = Int32.Parse(rdr[4].ToString());

                    lbs.Add(bs);
                    
                }
            }
            catch (Exception bxm)
            {
                System.Windows.MessageBox.Show("bxm : "+bxm.Message);
            }
            return lbs;
            
        }

        public void UpdateData()
        {

            try
            {
                da.Update(this.ds, "BoardExam");
            }
            catch (Exception upd)
            {
                System.Windows.MessageBox.Show("upd : "+upd.Message);
            }
        }
       // SELECT b.id, e.year, e.marksObtained, e.totalMarks, e.grade, e.status FROM student_basic b LEFT JOIN BoardExam e ON e.student_basic_id = b.id INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class = "+cls+" AND c.section = "+section+" AND c.startYear = "+syear+" AND c.endYear = "+eyear;
    }
}
