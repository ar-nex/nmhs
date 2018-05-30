using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class PromotionDb : BaseDb
    {
        public PromotionDb()
            : base()
        {

        }

        public ObservableCollection<Promotion> GetList(int startYear, int endYear, string cls, string section, int newStartYear, int newEndYear)
        {
            ObservableCollection<Promotion> plist = new ObservableCollection<Promotion>();
            string[] sclClass = { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            int clsIndex = Array.IndexOf(sclClass, cls);
            if (clsIndex < 0 || clsIndex >= sclClass.Length)
            {
                System.Windows.MessageBox.Show("Invalid class");
                return plist;
            }
            else
            {
                string newCls = sclClass[clsIndex+1];
                try
                {
                    conn.Open();
                    string sql1 = $"SELECT b.id, b.name, c.roll FROM student_basic b INNER JOIN student_class c ON b.id = c.student_basic_id WHERE startYear = '{startYear}' AND endYear = '{endYear}' AND class = '{cls}' AND section = '{section}'";
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql1;
                    using (MySqlDataReader rdr1 = cmd.ExecuteReader())
                    {
                        while (rdr1.Read())
                        {
                            Promotion p = new Promotion()
                            {
                                StudentId = rdr1[0].ToString(),
                                StudentName = rdr1[1].ToString(),
                                OldStudyClass = cls,
                                OldSection = section,
                                OldRoll = Convert.ToInt32(rdr1[2]),
                                OldCombined = cls+"-"+section+"-"+Convert.ToInt32(rdr1[2]),
                                OldStartYear = startYear,
                                OldEndYear = endYear,
                                NewStudyClass = newCls,
                                NewStartYear = startYear + 1,
                                NewEndYear = endYear + 1
                            };
                            plist.Add(p);
                        }
                    }

                   
                    foreach (var item in plist)
                    {
                        string sql2 = $"SELECT class, section, roll FROM student_class WHERE student_basic_id = '{item.StudentId}' AND startYear = '{newStartYear}' AND endYear = '{newEndYear}'";
                        cmd.CommandText = sql2;
                        try
                        {
                            using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                            {

                                if (rdr2.Read())
                                {
                                    item.NewStudyClass = rdr2[0].ToString();
                                    item.NewSection = rdr2[1].ToString();
                                    item.NewRoll = Convert.ToInt32(rdr2[2]);
                                    item.IsAlreadyExist = true;
                                }
                            }
                        }
                        catch (Exception x)
                        {
                            System.Windows.MessageBox.Show(x.ToString());
                        }
                    }
                }
                catch (Exception gx)
                {
                    System.Windows.MessageBox.Show("Problem in getting promotion data. : " + gx.Message);
                   
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return plist;
        }

        public void MakePromotion(List<Promotion> plist)
        {
            try
            {
                conn.Open();
                string sql = string.Empty;
                MySqlCommand cmd = conn.CreateCommand();
                foreach (var item in plist)
                {
                    if (item.IsAlreadyExist)
                    {
                        sql = $"UPDATE student_class SET class = '{item.NewStudyClass}', section = '{item.NewSection}', roll = '{item.NewRoll}' WHERE startYear = '{item.NewStartYear}' AND endYear = '{item.NewEndYear}' AND student_basic_id = '{item.StudentId}'";
                    }
                    else
                    {
                        sql = $"INSERT INTO student_class (startYear, endYear, class, section, roll, student_basic_id) VALUES ('{item.NewStartYear}', '{item.NewEndYear}', '{item.NewStudyClass}', '{item.NewSection}', '{item.NewRoll}', '{item.StudentId}')";
                    }
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception mx)
            {
                System.Windows.MessageBox.Show("Promblem for making promotion. : "+mx.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void MakePromotion(Promotion prm)
        {
            try
            {
                conn.Open();
                string sql = string.Empty;
                MySqlCommand cmd = conn.CreateCommand();
                
                    if (prm.IsAlreadyExist)
                    {
                        sql = $"UPDATE student_class SET class = '{prm.NewStudyClass}', section = '{prm.NewSection}', roll = '{prm.NewRoll}' WHERE startYear = '{prm.NewStartYear}' AND endYear = '{prm.NewEndYear}' AND student_basic_id = '{prm.StudentId}'";
                    }
                    else
                    {
                        sql = $"INSERT INTO student_class (startYear, endYear, class, section, roll, student_basic_id) VALUES ('{prm.NewStartYear}', '{prm.NewEndYear}', '{prm.NewStudyClass}', '{prm.NewSection}', '{prm.NewRoll}', '{prm.StudentId}')";
                    }
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                
            }
            catch (Exception mx)
            {
                System.Windows.MessageBox.Show("Promblem for making promotion. : " + mx.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public List<string> HasAlreadyAssignedOrNot(int startYear, int endYear, string cls, string section, int roll)
        {
            List<string> stdNameList = new List<string>();
            try
            {
                conn.Open();
                string sql = $"SELECT b.name FROM student_basic b INNER JOIN student_class c ON b.id = c.student_basic_id WHERE c.startYear = {dv(startYear)} AND c.endYear = {dv(endYear)} AND c.class = {dv(cls)} AND c.section = {dv(section)} AND c.roll = {dv(roll)}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    stdNameList.Add(rdr[0].ToString());
                }
            }
            catch (Exception dpex)
            {
                System.Windows.MessageBox.Show("Problem in getting info of assigned or not. : "+dpex.Message);
            }
            finally
            {
                conn.Close();
            }
            return stdNameList;
        }

        public bool IsAlreadyExist(int startYear, int endYear, string studentId)
        {
            bool exist = false;
            try
            {
                conn.Open();
                string sql = $"SELECT COUNT(*) FROM student_class WHERE startYear = {dv(startYear)} AND endYear = {dv(endYear)} AND student_basic_id = {dv(studentId)}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    if (Convert.ToInt32(result) > 0)
                    {
                        exist = true;
                    }
                    else
                    {
                        exist = false;
                    }
                }
                else
                {
                    exist = false;
                }
            }
            catch (Exception alx)
            {
                System.Windows.MessageBox.Show("Problem in getting already exist or not. : "+alx.Message);
            }
            finally
            {
                conn.Close();
            }
            return exist;
        }

        /*
        public bool IsDuplicateInDb(int startYear, int endYear, string cls, string section, int roll)
        {
            bool hasDuplicate = false;
            try
            {
                conn.Open();
                string sql = $"SELECT COUNT(*) FROM student_class WHERE startYear = '{startYear}' AND endYear = '{endYear}' AND class = '{cls}' AND section = '{section}' AND roll = '{roll}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                Object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    if (Convert.ToInt32(result) > 0)
                    {
                        hasDuplicate = true;
                    }
                }
                else
                {
                    hasDuplicate = false;
                }
            }
            catch (Exception dx)
            {
                System.Windows.MessageBox.Show("Problem in getting dublicate. : "+dx.Message);
            }
            finally
            {
                conn.Close();
            }
            return hasDuplicate;
        }
        */
    }
}
