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
    public class SubjectComboDb : BaseDb
    {
        public SubjectComboDb()
        :base()
        {

        }

        /*
        public List<SubjectCombo> GetCombo()
        {
            List<SubjectCombo> cmbo = new List<SubjectCombo>();
            try
            {
                this.conn.Open();
                string sql = @"SELECT * FROM subjectcombo";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbo.Add(new SubjectCombo(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
                }
            }
            catch (Exception e1)
            {

                System.Windows.MessageBox.Show(e1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return cmbo;
        }

        public List<CombSubPair> GetCombSubPair()
        {
            List<CombSubPair> cmboSb = new List<CombSubPair>();
            try
            {
                this.conn.Open();
                string sql = @"SELECT c.code, s.Name From subjectcombo c
                               INNER JOIN subjectcombo_has_subject p
                               ON c.id = p.SubjectCombo_id
                               INNER JOIN subject s
                               ON s.id=p.Subject_id";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmboSb.Add(new CombSubPair(rdr[1].ToString(), rdr[0].ToString()));
                }
            }
            catch (Exception e1)
            {

                System.Windows.MessageBox.Show(e1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return cmboSb;
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
                while (rdr.Read())
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

        public bool InsertComboSub(string comb, string subid)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"INSERT INTO subjectcombo_has_subject (Subject_id, SubjectCombo_id) SELECT '" + subid + "', id FROM subjectcombo WHERE code='" + comb + "'";
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

        public long InsertCombo(string comb, string cls)
        {
            long insertedId = 0;
            try
            {
                this.conn.Open();
                string sql = @"INSERT INTO subjectcombo (code, class) VALUES ('"+comb+"', '"+cls+"')";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                cmd.ExecuteNonQuery();
                insertedId = cmd.LastInsertedId;

            }

            catch (Exception e)
            {

                System.Windows.MessageBox.Show(e.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return insertedId;

        }

        public bool RemoveComboSub(string comb, string subid)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"DELETE FROM subjectcombo_has_subject WHERE Subject_id='" + subid + "' AND SubjectCombo_id=(SELECT id FROM subjectcombo WHERE code='" + comb + "')";
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

        public bool RemoveCombo(string comboId)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"DELETE FROM subjectcombo WHERE id='" + comboId + "'";
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

        public bool UpdateComboCode(SubjectCombo c)
        {
            bool rs = false;
            int r = -1;
            try
            {
                this.conn.Open();
                string sql = @"UPDATE subjectcombo SET code='" + c.Code + "' WHERE id='" + c.Id + "'";
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
        */

    }
}
