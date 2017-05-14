using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace NaimouzaHighSchool.Models.Database
{
    public class Exam
    {
        public Exam()
        {

        }
        public Exam( string id, string nm, string sname, int sn)
        {
            this.Id = id;
            this.Name = nm;
            this.ShortName = sname;
            this.SerialNo = sn;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int SerialNo { get; set; }
    }
    
    public class ExamDb : BaseDb
    {
        public ExamDb()
        : base()
        {

        }

        public List<Exam> GetExamList()
        {
            List<Exam> elist = new List<Exam>();
            try
            {
                this.conn.Open();
                string sql = "SELECT * FROM exam";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    elist.Add(new Exam(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), Convert.ToInt32(rdr[3])));
                }
            }
            catch (Exception em1)
            {
                System.Windows.MessageBox.Show("em1 : " + em1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return elist;
        
        }

        public int InsertExam(Exam e)
        {
            long insertedId = 0;
            string nm = "'" + e.Name + "'";
            string sname = (string.IsNullOrEmpty(e.ShortName)) ? "NULL" : "'" + e.ShortName + "'";
            string sn = "'"+e.SerialNo.ToString()+"'";

            try
            {
                this.conn.Open();
                string sql = @"INSERT INTO exam (name, shortName, serialNo) VALUES("+nm+", "+sname+", "+sn+")";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                cmd.ExecuteNonQuery();
                insertedId = cmd.LastInsertedId;
                
            }
            catch (Exception em2)
            {
                System.Windows.MessageBox.Show("em2 : " + em2.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return Convert.ToInt32(insertedId);
        }

        public bool UpdateExam(Exam e)
        {
            int r = 0;
            string nm = "'" + e.Name + "'";
            string sname = (string.IsNullOrEmpty(e.ShortName)) ? "NULL" : "'" + e.ShortName + "'";
            string sn = "'" + e.SerialNo.ToString() + "'";

            try
            {
                this.conn.Open();
                string sql = @"UPDATE exam SET name="+nm+", shortName="+sname+", serialNo="+sn+" WHERE id="+e.Id;
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();

            }
            catch (Exception em3)
            {
                System.Windows.MessageBox.Show("em3 : " + em3.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return r > 0;
        }

        public bool DeleteExam(string id)
        {
            int r = 0;
            try
            {
                this.conn.Open();
                string sql = "DELETE FROM exam where id="+id;
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();

            }
            catch (Exception em4)
            {
                System.Windows.MessageBox.Show("em4 : " + em4.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return r > 0;
        }
    }
}
