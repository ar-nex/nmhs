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
    public class SubjectGroupDb:BaseDb
    {
        public SubjectGroupDb()
        :base()
        {

        }

        /*

        public List<string> GetGroups()
        {
            List<string> GrpList = new List<string>();
            try
            {
                this.conn.Open();
                string sql = @"SELECT DISTINCT Name FROM subjectgroup";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GrpList.Add(rdr[0].ToString());
                   
                }

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);

            }
            finally
            {
                this.conn.Close();
            }
            return GrpList;
        }

        public bool InsertGroup(string group)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"INSERT INTO subjectgroup (name) VALUES ('"+group+"')";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();
                
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

        public bool InsertSubject(Subject sb)
        {
            bool rs = false;
            int r = -1;

            try
            {
                this.conn.Open();
                string sql = @"INSERT INTO subject (Name, ShortName, SubjectGroup_id) SELECT '" + sb.SubName + "', '" + sb.ShortName + "', id from subjectgroup WHERE Name='" + sb.BelongingGroup + "'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception eb1)
            {

                System.Windows.MessageBox.Show(eb1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            rs = (r > 0) ? true : false;
            return rs;
        }

        public bool UpdateGroup(string oldval, string newval)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"UPDATE subjectgroup SET Name='"+newval+"' WHERE Name='"+oldval+"'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception e2)
            {
                System.Windows.MessageBox.Show(e2.Message);
            }
            finally
            {
                this.conn.Close();
            }
            rs = (r > 0) ? true : false;
            return rs;
        
        }

        public bool UpdateSub(Subject newval)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"UPDATE subject SET Name='" + newval.SubName + "', ShortName='" + newval.ShortName + "', SubjectGroup_id = (SELECT subjectgroup.id FROM subjectgroup WHERE subjectgroup.Name = '"+newval.BelongingGroup+"') WHERE id='"+newval.ID+"'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception e2)
            {
                System.Windows.MessageBox.Show(e2.Message);
            }
            finally
            {
                this.conn.Close();
            }
            rs = (r > 0) ? true : false;
            return rs;

        }


        public bool DeleteGroup(string grpName)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"DELETE FROM subjectgroup WHERE Name = '"+grpName+"'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception e3)
            {

                System.Windows.MessageBox.Show(e3.Message);
            }
            finally
            {
                this.conn.Close();
            }
            rs = (r > 0) ? true : false;
            return rs;
        }

        public bool DeleteSubject(string subId)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"DELETE FROM subject where id = "+subId+";";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception sb)
            {

                System.Windows.MessageBox.Show("sb : "+sb.Message);
            }
            finally
            {
                this.conn.Close();
            }
            rs = (r > 0) ? true : false;
            return rs;
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> sblist = new List<Subject>();
            try
            {
                this.conn.Open();
                string sql = @"SELECT s.id, s.Name, s.ShortName, g.Name FROM subject s INNER JOIN subjectgroup g ON g.id = s.SubjectGroup_id";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    sblist.Add(new Subject(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString()));
                }
            }
            catch (Exception e4)
            {

                System.Windows.MessageBox.Show(e4.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return sblist;       
        }

        */
    }
}
