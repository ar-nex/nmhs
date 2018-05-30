using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace NaimouzaHighSchool.Models.Database
{
    public class MicroStdInfo : NaimouzaHighSchool.ViewModels.BaseViewModel
    {

        public MicroStdInfo(string id, string nm, string fnm, int roll)
        {
            this.Id = id;
            this.Name = nm;
            this.FatherName = fnm;
            this.Roll = roll;
            this.IsSelected = false;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int Roll { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return this._isSelected; }
            set { this._isSelected = value; this.OnPropertyChanged("IsSelected");}
        }
    }
    
    public class DeleteDb : BaseDb
    {
        public DeleteDb()
        : base()
        {
           
        }


        public List<MicroStdInfo> GetStudentsSpecific(string cls, string section, int roll, int syear, int eyear)
        {
            List<MicroStdInfo> lm = new List<MicroStdInfo>();
            string syr = syear.ToString();
            string eyr = eyear.ToString();
            try
            {
                this.conn.Open();
                string sql = "SELECT b.id, b.name, b.fatherName, c.roll FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class = '"+cls+"' AND c.section = '"+section+"' AND roll = '"+roll+"' AND startYear='"+syr+"' AND endYear='"+eyr+"'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lm.Add(new MicroStdInfo(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), Convert.ToInt32(rdr[3])));
                }
            }
            catch (Exception dexp)
            {
                System.Windows.MessageBox.Show("dexp : "+dexp.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return lm;
        }

        public List<MicroStdInfo> GetStudentsSpecific(string cls, string section, int syear, int eyear)
        {
            List<MicroStdInfo> lm = new List<MicroStdInfo>();
            string syr = syear.ToString();
            string eyr = eyear.ToString();
            try
            {
                this.conn.Open();
                string sql = "SELECT b.id, b.name, b.fatherName, c.roll FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class = '" + cls + "' AND c.section = '" + section + "' AND startYear='" + syr + "' AND endYear='" + eyr + "'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lm.Add(new MicroStdInfo(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), Convert.ToInt32(rdr[3])));
                }
            }
            catch (Exception dexp)
            {
                System.Windows.MessageBox.Show("dexp : " + dexp.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return lm;
        }



        public int GetTotalStudents(string cls, string section, int syear, int eyear)
        {
            int n = 0;
            string syr = syear.ToString();
            string eyr = eyear.ToString();
            try
            {
                this.conn.Open();
                string sql = "SELECT COUNT(*) FROM student_class WHERE startYear = '"+syr+"' AND endYear = '"+eyr+"' AND class='"+cls+"' AND section = '"+section+"'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                Object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    n = Convert.ToInt32(result);
                }
            }
            catch (Exception dex1)
            {
                System.Windows.MessageBox.Show("dex1 : " + dex1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return n;
        }

        public bool DeleteSpecific(List<string> idList)
        {
           
            bool rs = false;
            if (idList.Count == 0)
            {
                return false;
            }
            else if (idList.Count == 1)
            {
                string sql1 = @"DELETE FROM Marksheet WHERE student_basic_id = " + idList[0];
                string sql2 = @"DELETE FROM Admission WHERE student_basic_id = " + idList[0];
                string sql3 = @"DELETE FROM student_class WHERE student_basic_id = " + idList[0];
                string sql4 = @"DELETE FROM BoardExam WHERE student_basic_id = " + idList[0];
                string sql5 = @"DELETE FROM student_basic WHERE id = " + idList[0];

                try
                {
                    this.conn.Open();
                    MySqlCommand cmd = this.conn.CreateCommand();
                    MySqlTransaction myTrans = this.conn.BeginTransaction();
                    cmd.Connection = this.conn;
                    cmd.Transaction = myTrans;
                    try
                    {
                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql3;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql4;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql5;
                        cmd.ExecuteNonQuery();

                        myTrans.Commit();
                        rs = true;
                    }
                    catch (Exception e2)
                    {
                        try
                        {
                            myTrans.Rollback();
                            rs = false;
                        }
                        catch (Exception e3)
                        {

                            System.Windows.MessageBox.Show(e3.Message);
                        }
                        System.Windows.MessageBox.Show(e2.Message);
                    }
                }
                catch (Exception dex2)
                {
                    System.Windows.MessageBox.Show("dex2 : "+dex2.Message);
                }
                finally
                {
                    this.conn.Close();
                }
            }
                // if there is more than one ids
            else
            {
                string idIn = string.Empty;
                foreach (string id in idList)
                {
                    idIn = idIn + id + ", "; 
                }
               
                idIn = idIn.Remove(idIn.Length-2);
                string sql1 = @"DELETE FROM Marksheet WHERE student_basic_id IN (" + idIn + ")";
                string sql2 = @"DELETE FROM Admission WHERE student_basic_id IN (" + idIn + ")";
                string sql3 = @"DELETE FROM student_class WHERE student_basic_id IN (" + idIn + ")";
                string sql4 = @"DELETE FROM BoardExam WHERE student_basic_id IN (" + idIn + ")";
                string sql5 = @"DELETE FROM student_basic WHERE id IN (" + idIn + ")";
               
                try
                {
                    this.conn.Open();
                    MySqlCommand cmd = this.conn.CreateCommand();
                    MySqlTransaction myTrans = this.conn.BeginTransaction();
                    cmd.Connection = this.conn;
                    cmd.Transaction = myTrans;
                    try
                    {
                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql3;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql4;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = sql5;
                        cmd.ExecuteNonQuery();

                        myTrans.Commit();
                        rs = true;
                    }
                    catch (Exception e2)
                    {
                        try
                        {
                            myTrans.Rollback();
                            rs = false;
                        }
                        catch (Exception e3)
                        {

                            System.Windows.MessageBox.Show(e3.Message);
                        }
                        System.Windows.MessageBox.Show(e2.Message);
                    }
                }
                catch (Exception dex3)
                {
                    System.Windows.MessageBox.Show("dex3 : " + dex3.Message);
                }
                finally
                {
                    this.conn.Close();
                }
            }
            return rs;
        }

        public bool DeleteStudents(string cls, string section, int syear, int eyear)
        {
            bool rs = false;
            string syr = syear.ToString();
            string eyr = eyear.ToString();

            string sql1 = @"DELETE FROM Marksheet WHERE student_basic_id IN (SELECT id FROM student_basic b INNER JOIN student_class c on c.student_basic_id = b.id WHERE c.class = '"+cls+"' AND c.section = '"+section+"' AND startYear='"+syr+"' AND endYear='"+eyr+"')";
            string sql2 = @"DELETE FROM Admission WHERE student_basic_id IN (SELECT id FROM student_basic b INNER JOIN student_class c on c.student_basic_id = b.id WHERE c.class = '" + cls + "' AND c.section = '" + section + "' AND startYear='" + syr + "' AND endYear='" + eyr + "')";
            string sql3 = @"DELETE FROM BoardExam WHERE student_basic_id IN (SELECT id FROM student_basic b INNER JOIN student_class c on c.student_basic_id = b.id WHERE c.class = '" + cls + "' AND c.section = '" + section + "' AND startYear='" + syr + "' AND endYear='" + eyr + "')";
            string sql4 = @"DELETE b.*, c.* FROM student_basic AS b INNER JOIN student_class AS c ON c.student_basic_id = b.id WHERE c.class = '" + cls + "' AND c.section = '" + section + "' AND startYear='" + syr + "' AND endYear='" + eyr + "'";

            try
            {
                this.conn.Open();
                MySqlCommand cmd = this.conn.CreateCommand();
                MySqlTransaction myTrans = this.conn.BeginTransaction();
                cmd.Connection = this.conn;
                cmd.Transaction = myTrans;
                try
                {
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = sql4;
                    cmd.ExecuteNonQuery();

                    myTrans.Commit();
                    rs = true;
                }
                catch (Exception e2)
                {
                    try
                    {
                        myTrans.Rollback();
                        rs = false;
                    }
                    catch (Exception e3)
                    {

                        System.Windows.MessageBox.Show(e3.Message);
                    }
                    System.Windows.MessageBox.Show(e2.Message);
                }
            }
            catch (Exception eCom)
            {
                System.Windows.MessageBox.Show("eCom : "+eCom.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return rs;
        }

        public List<string> DeleteSessionData(int startYear, int endYear, string cls, string section)
        {
            string sql = $"SELECT student_basic_id FROM student_class WHERE startYear = {dv(startYear)} AND endYear = {dv(endYear)} AND class = {dv(cls)} AND section = {dv(section)}";
            return DeleteSessionInfo(sql, startYear: startYear, endYear: endYear);
        }

        public List<string> DeleteSessionData(int startYear, int endYear, string cls)
        {
            string sql = $"SELECT student_basic_id FROM student_class WHERE startYear = {dv(startYear)} AND endYear = {dv(endYear)} AND class = {dv(cls)}";
            return DeleteSessionInfo(sql, startYear: startYear, endYear: endYear);
        }

        private List<string> DeleteSessionInfo(string sql, int startYear, int endYear)
        {
            List<string> notDeletedIdList = new List<string>();
            try
            {
                conn.Open();
                List<string> idList = new List<string>();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
               
                using (MySqlDataReader rdr1 = cmd.ExecuteReader())
                {
                    while (rdr1.Read())
                    {
                        idList.Add(rdr1[0].ToString());
                    }
                }
                string sql2 = string.Empty;
                foreach (var id in idList)
                {
                    sql2 = $"SELECT COUNT(student_basic_id) FROM student_class WHERE student_basic_id = {dv(id)}";
                    cmd.CommandText = sql2;
                    object result = cmd.ExecuteScalar();
                    if (result != null && Convert.ToInt32(result) > 1)
                    {
                        string sql3 = $"DELETE FROM student_class WHERE student_basic_id = {dv(id)} AND startYear = {dv(startYear)} AND endYear = {dv(endYear)}";
                        cmd.CommandText = sql3;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        notDeletedIdList.Add(id);
                    }
                }
            }
            catch (Exception sx)
            {
                System.Windows.MessageBox.Show("Problem in deleting session Data. : "+sx.Message);
            }
            finally
            {
                conn.Close();
            }
            return notDeletedIdList;
        }
    }
}
