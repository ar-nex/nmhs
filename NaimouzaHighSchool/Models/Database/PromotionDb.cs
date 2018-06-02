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

        public int GetPreviousToNewCount(int prevStartYear, int prevEndYear, int newStartYear, int newEndYear, string oldClass, string oldSection)
        {
            int count = 0;

            string[] sclClass = { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            int clsIndex = Array.IndexOf(sclClass, oldClass);
            string newClass = sclClass[clsIndex + 1];

            try
            {
                conn.Open();
                string sql = $"SELECT COUNT(*) FROM `student_class` WHERE startYear = {dv(newStartYear)} and endYear = {dv(newEndYear)} and class = {dv(newClass)} and student_basic_id IN (SELECT student_basic_id FROM student_class WHERE startYear = {dv(prevStartYear)} and endYear = {dv(prevEndYear)} AND class = {dv(oldClass)} and section = {dv(oldSection)})";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            catch (Exception cx)
            {
                System.Windows.MessageBox.Show("Problem in getting mapping count. : "+cx.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public int GetPreviousCount(int prevStartYear, int prevEndYear, string oldClass, string oldSection)
        {
            int count = 0;
            try
            {
                conn.Open();
                string sql = $"SELECT COUNT(*) FROM student_class WHERE startYear = {dv(prevStartYear)} AND endYear = {dv(prevEndYear)} AND class = {dv(oldClass)} AND section = {dv(oldSection)}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            catch (Exception nx)
            {
                System.Windows.MessageBox.Show("Probem in getting new section count : " + nx.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public int GetNewCount(int newStartYear, int newEndYear, string oldClass, string newSection)
        {
            int count = 0;

            string[] sclClass = { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            int clsIndex = Array.IndexOf(sclClass, oldClass);
            string newClass = sclClass[clsIndex + 1];

            try
            {
                conn.Open();
                string sql = $"SELECT COUNT(*) FROM student_class WHERE startYear = {dv(newStartYear)} AND endYear = {dv(newEndYear)} AND class = {dv(newClass)} AND section = {dv(newSection)}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            catch (Exception nx)
            {
                System.Windows.MessageBox.Show("Probem in getting new section count : "+nx.Message);
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public ObservableCollection<PromotionMapping> GetPreviousToNewMap(int prevStartYear, int prevEndYear, int newStartYear, int newEndYear, string oldClass, string oldSection)
        {
            ObservableCollection<PromotionMapping> resultList = new ObservableCollection<PromotionMapping>();
            try
            {
                conn.Open();
                Queue<string> tempQueue = new Queue<string>();
                string sql1 = $"SELECT student_basic_id, roll FROM student_class WHERE startYear = {dv(prevStartYear)} AND endYear = {dv(prevEndYear)} AND class = {dv(oldClass)} AND section = {dv(oldSection)}";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql1;
                using (MySqlDataReader rdr1 = cmd.ExecuteReader())
                {
                    while (rdr1.Read())
                    {
                        string str = oldClass + "-" + oldSection + "-" + rdr1[1].ToString() + "-" + rdr1[0].ToString();
                        tempQueue.Enqueue(str);
                    }
                }
                while (tempQueue.Count > 0)
                {
                    string oldCombination = tempQueue.Dequeue();
                    int lastPosOfDash = oldCombination.LastIndexOf("-");
                    string student_id = oldCombination.Substring(lastPosOfDash+1);
                    string modifiedCombo = oldCombination.Substring(0, lastPosOfDash);

                    string sql2 = $"SELECT class, section, roll FROM student_class WHERE startYear = {dv(newStartYear)} AND endYear = {dv(newEndYear)} AND student_basic_id = {dv(student_id)}";
                    cmd.CommandText = sql2;
                    using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                    {
                        if (rdr2.Read())
                        {
                            string finalCombo = modifiedCombo + " --> " + rdr2[0].ToString() + "-" + rdr2[1].ToString() + "-" + rdr2[2].ToString();
                            resultList.Add(new PromotionMapping(finalCombo));
                        }
                    }
                }
                
            }
            catch (Exception mx)
            {
                System.Windows.MessageBox.Show("Problem in getting forward mapper : "+mx.Message);
            }
            finally
            {
                conn.Close();
            }
            return resultList;
        }

        public ObservableCollection<PromotionMapping> GetNewFromPreviousMap(int prevStartYear, int prevEndYear, int newStartYear, int newEndYear, string oldClass, string NewSection)
        {
            string[] sclClass = { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            int clsIndex = Array.IndexOf(sclClass, oldClass);
            string newClass = sclClass[clsIndex + 1];

            ObservableCollection<PromotionMapping> resultList = new ObservableCollection<PromotionMapping>();
            try
            {
                conn.Open();
                Queue<string> tempQueue = new Queue<string>();
                string sql1 = $"SELECT student_basic_id, roll FROM student_class WHERE startYear = {dv(newStartYear)} AND endYear = {dv(newEndYear)} AND class = {dv(newClass)} AND section = {dv(NewSection)}";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql1;
                using (MySqlDataReader rdr1 = cmd.ExecuteReader())
                {
                    while (rdr1.Read())
                    {
                        string str = newClass + "-" + NewSection + "-" + rdr1[1].ToString() + "-" + rdr1[0].ToString();
                        tempQueue.Enqueue(str);
                    }
                }
                while (tempQueue.Count > 0)
                {
                    string newCombination = tempQueue.Dequeue();
                    int lastPosOfDash = newCombination.LastIndexOf("-");
                    string student_id = newCombination.Substring(lastPosOfDash+1);
                    string modifiedCombo = newCombination.Substring(0, lastPosOfDash);

                    string sql2 = $"SELECT class, section, roll FROM student_class WHERE startYear = {dv(prevStartYear)} AND endYear = {dv(prevEndYear)} AND student_basic_id = {dv(student_id)}";
                    cmd.CommandText = sql2;
                    using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                    {
                        if (rdr2.Read())
                        {
                            string finalCombo = modifiedCombo + " <-- " + rdr2[0].ToString() + "-" + rdr2[1].ToString() + "-" + rdr2[2].ToString();
                            resultList.Add(new PromotionMapping(finalCombo));
                        }
                    }
                }
            }
            catch (Exception nx)
            {
                System.Windows.MessageBox.Show("Problem in getting new to old mapping. : "+nx.Message);
            }
            finally
            {
                conn.Close();
            }
            return resultList;
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
