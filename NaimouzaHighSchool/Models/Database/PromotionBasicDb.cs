using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class PromotionBasicDb : BaseDb
    {
        public PromotionBasicDb()
            : base()
        {

        }

        // temporarily it is only for 2018 session
        public ObservableCollection<PromotionBasic> GetData(string cls, string sec, Gender sex, int startYear, int endYear)
        {
            ObservableCollection<PromotionBasic> prList = new ObservableCollection<PromotionBasic>();
            string syr = "'" + startYear.ToString() + "'";
            string eyr = "'" + endYear.ToString() + "'";
            

            string curr_syr = (startYear + 1).ToString();
            string curr_eyr = (endYear + 1).ToString();

            string clls = "'" + cls + "'";
            string section = "'" + sec + "'";
            string newCls = string.Empty;
            switch (cls)
            {
                case "V":
                    newCls = "VI";
                    break;
                case "VI":
                    newCls = "VII";
                    break;
                case "VII":
                    newCls = "VIII";
                    break;
                case "VIII":
                    newCls = "IX";
                    break;
                case "IX":
                    newCls = "X";
                    break;
                case "X":
                    newCls = "XI";
                    break;
                case "XI":
                    newCls = "XII";
                    break;
                default:
                    break;
            }
            string sql_2017 = string.Empty;
            string sql_2018 = string.Empty;
            switch (sex)
            {
                case Gender.NA:
                    sql_2017 = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class=" + clls + " AND c.section =" + section + " AND c.startYear = " + syr + " AND c.endYear=" + eyr;
                    sql_2018 = $"SELECT b.id FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class IN (" + clls + ", '" + newCls + "') AND c.startYear = '" + curr_syr + "' AND c.endYear='" + curr_eyr + "'";
                    break;
                case Gender.M:
                    sql_2017 = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class=" + clls + " AND c.section =" + section + " AND b.sex = 'M' AND c.startYear = " + syr + " AND c.endYear=" + eyr;
                    sql_2018 = $"SELECT b.id FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class IN (" + clls + ", '" + newCls + "') AND b.sex = 'M' AND c.startYear = '" + curr_syr + "' AND c.endYear='" + curr_eyr + "'";
                    break;
                case Gender.F:
                    sql_2017 = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class=" + clls + " AND c.section =" + section + " AND b.sex = 'F' AND startYear = " + syr + " AND endYear=" + eyr;
                    sql_2018 = $"SELECT b.id FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class IN (" + clls + ", '" + newCls + "') AND b.sex = 'F' AND c.startYear = '" + curr_syr + "' AND c.endYear='" + curr_eyr + "'";
                    break;
                default:
                    break;
            }

           
            List<string> idsIn2018 = new List<string>();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql_2017;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (cls == "XI")
                    {
                        while (rdr.Read())
                        {
                            PromotionBasic pb = new PromotionBasic
                            {
                                Id = rdr[0].ToString(),
                                Name = rdr[1].ToString(),
                                Section = rdr[5].ToString(),
                                OldRoll = Convert.ToInt32(rdr[6]),
                                NewClass = newCls,
                                OldStat = rdr[4].ToString() + "-" + rdr[5].ToString() + "-" + rdr[6].ToString(),
                                Stream = rdr[7].ToString(),
                                HsSub1 = rdr[9].ToString(),
                                HsSub2 = rdr[10].ToString(),
                                HsSub3 = rdr[11].ToString(),
                                HsAdl = rdr[12].ToString(),
                                Sex = rdr[14].ToString()
                            };
                            
                            prList.Add(pb);
                        }
                    }
                    else
                    {
                        while (rdr.Read())
                        {
                            PromotionBasic pb = new PromotionBasic
                            {
                                Id = rdr[0].ToString(),
                                Name = rdr[1].ToString(),
                                Section = rdr[5].ToString(),
                                OldRoll = Convert.ToInt32(rdr[6]),
                                NewClass = newCls,
                                OldStat = rdr[4].ToString() + "-" + rdr[5].ToString() + "-" + rdr[6].ToString(),
                                Sex = rdr[14].ToString()
                            };

                            prList.Add(pb);
                        }
                    }
                    
                }

                cmd.CommandText = sql_2018;
                using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                {
                    while (rdr2.Read())
                    {
                        idsIn2018.Add(rdr2[0].ToString());
                    }
                }
            }
            catch (Exception pex)
            {
                System.Windows.MessageBox.Show("Problem in getting prom. student data. : "+pex.Message);
            }
            finally
            {
                conn.Close();
            }
            // remove the item which have been already entered for 2018
            if (idsIn2018.Count > 0)
            {
                foreach (string id in idsIn2018)
                {
                    foreach (PromotionBasic item in prList)
                    {
                        if (id == item.Id)
                        {
                            prList.Remove(item);
                            break;
                        }
                    }
                }
            }
            return prList;
        }

        public ObservableCollection<PromotionBasic> GetPromotedData(string cls, string sec, Gender sex, int startYear, int endYear)
        {
            ObservableCollection<PromotionBasic> plist = new ObservableCollection<PromotionBasic>();
            string clls = "'"+cls+"'";
            string section = "'" + sec + "'";
            string syr = "'" + startYear.ToString()+"'";
            string eyr = "'" + endYear.ToString()+"'";
            string sql = string.Empty;
            switch (sex)
            {
                case Gender.NA:
                    sql = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class=" + clls + " AND c.section =" + section + " AND c.startYear = " + syr + " AND c.endYear=" + eyr;
                    break;
                case Gender.M:
                    sql = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class=" + clls + " AND c.section =" + section + " AND b.sex = 'M' AND c.startYear = " + syr + " AND c.endYear=" + eyr;
                    break;
                case Gender.F:
                    sql = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class=" + clls + " AND c.section =" + section + " AND b.sex = 'F' AND c.startYear = " + syr + " AND c.endYear=" + eyr;
                    break;
                default:
                    break;
            }
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        PromotionBasic p = new PromotionBasic
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            NewClass = rdr[4].ToString(),
                            NewSection = rdr[5].ToString(),
                            NewRoll = Convert.ToInt32(rdr[6]),
                            Sex = rdr[14].ToString()
                        };

                        plist.Add(p);
                    }
                }
            }
            catch (Exception prx)
            {
                System.Windows.MessageBox.Show("Problem in getting promoted list. : "+prx.Message);
            }
            finally
            {
                conn.Close();
            }

            return plist;
        }

        public ObservableCollection<PromotionBasic> GetDataAlreadyEntered(string cls, Gender sex, int startYear, int endYear)
        {
            ObservableCollection<PromotionBasic> plist = new ObservableCollection<PromotionBasic>();
            string curr_syr = (startYear + 1).ToString();
            string curr_eyr = (endYear + 1).ToString();

            string clls = "'" + cls + "'";
            string newCls = string.Empty;
            switch (cls)
            {
                case "V":
                    newCls = "VI";
                    break;
                case "VI":
                    newCls = "VII";
                    break;
                case "VII":
                    newCls = "VIII";
                    break;
                case "VIII":
                    newCls = "IX";
                    break;
                case "IX":
                    newCls = "X";
                    break;
                case "X":
                    newCls = "XI";
                    break;
                case "XI":
                    newCls = "XII";
                    break;
                default:
                    break;
            }

            string sql_2018 = string.Empty;
            switch (sex)
            {
                case Gender.NA:
                    sql_2018 = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class='" + newCls + "' AND c.startYear = " + curr_syr + " AND c.endYear=" + curr_eyr;
                    break;
                case Gender.M:
                    sql_2018 = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class='" + newCls + "' AND b.sex = 'M' AND c.startYear = " + curr_syr + " AND c.endYear=" + curr_eyr;
                    break;
                case Gender.F:
                    sql_2018 = $"SELECT b.id, b.name, c.*, b.sex FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class='" + newCls + "' AND b.sex = 'F' AND startYear = " + curr_syr + " AND endYear=" + curr_eyr;
                    break;
                default:
                    break;
            }
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql_2018;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        PromotionBasic pb = new PromotionBasic
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            Cls = newCls,
                            Section = rdr[5].ToString(),
                            OldRoll = Convert.ToInt32(rdr[6]),
                            OldStat = rdr[4].ToString() + "-" + rdr[5].ToString() + "-" + rdr[6].ToString(),
                            Sex = rdr[14].ToString()
                        };

                        plist.Add(pb);
                    }
                            
                }
            }
            catch (Exception pex)
            {
                System.Windows.MessageBox.Show("Problem in getting prom_old. student data. : " + pex.Message);
            }
            finally
            {
                conn.Close();
            }

            return plist;
        }

        public ObservableCollection<PromotionBasic> DoPromotionBasic(ObservableCollection<PromotionBasic> prList, int startYear, int endYear)
        {
            ObservableCollection<PromotionBasic> notInsertedList = new ObservableCollection<PromotionBasic>();
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                foreach (PromotionBasic item in prList)
                {
                    if (!string.IsNullOrEmpty(item.NewSection) && item.NewRoll > 0)
                    {
                        int r = 0;
                        string sql = string.Empty;
                        if (item.Cls == "XII")
                        {
                            sql = $"INSERT IGNORE INTO student_class (startYear, endYear, class, section, roll, stream, hsElemSub1, hsElemSub2, hsElemSub3, hsAdlSub, student_basic_id) VALUES('{sYear}', '{eYear}', '{item.NewClass}', '{item.Section}', '{item.NewRoll}', '{item.Stream}', '{item.HsSub1}', '{item.HsSub2}', '{item.HsSub3}', '{item.HsAdl}', '{item.Id}')";
                        }
                        else
                        {
                            sql = $"INSERT IGNORE INTO student_class (startYear, endYear, class, section, roll, student_basic_id) VALUES('{sYear}', '{eYear}', '{item.NewClass}', '{item.Section}', '{item.NewRoll}', '{item.Id}')";
                        }
                        cmd.CommandText = sql;
                        r = cmd.ExecuteNonQuery();
                        if (r == 0)
                        {
                            notInsertedList.Add(item);
                        }
                    }
                    else
                    {
                        notInsertedList.Add(item);
                    }
                }
            }
            catch (Exception prUpdate)
            {
                System.Windows.MessageBox.Show("Problem in doing basic promotion. : "+prUpdate.Message);
            }
            finally
            {
                conn.Close();
            }
            return notInsertedList;
        }
    }
}
