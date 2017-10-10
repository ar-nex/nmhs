using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class RollUpdateDb : BaseDb
    {
        public RollUpdateDb()
        : base()
        {

        }

        public List<RollUpdater> GetRollUpdaterList(string cls, string sec, int syear, int eyear)
        {
            List<RollUpdater> rList = new List<RollUpdater>();
            string syr = "'" + syear.ToString() + "'";
            string eyr = "'"+eyear.ToString()+"'";
            string clls = "'"+cls+"'";
            string section = "'"+sec+"'";
            string sql = "SELECT b.id, b.name, c.class, c.section, c.roll FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.class="+clls+" AND c.section ="+section+" AND startYear = "+syr+" AND endYear="+eyr;
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RollUpdater ru = new RollUpdater();
                    ru.Id = rdr[0].ToString();
                    ru.Name = rdr[1].ToString();
                    ru.Cls = rdr[2].ToString();
                    ru.Section = rdr[3].ToString();
                    ru.OldRoll = Convert.ToInt32(rdr[4]);

                    rList.Add(ru);
                }
            }
            catch (Exception rex)
            {
                System.Windows.MessageBox.Show("rex : "+rex.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return rList;
        }

        public List<RollUpdater> UpdateRoll(List<RollUpdater> rList, int startYear, int endYear)
        {
            List<RollUpdater> updatedItems = new List<RollUpdater>();
            string syr = "'"+startYear.ToString()+"'";
            string eyr = "'"+endYear.ToString()+"'";
            
            try
            {
                this.conn.Open();
                foreach (RollUpdater item in rList)
                {
                    int r = 0;
                    string sql = "UPDATE student_class SET roll='" + item.NewRoll + "' WHERE student_basic_id="+item.Id+" AND startYear="+syr+" AND endYear="+eyr;
                    MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                    r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        updatedItems.Add(item);
                    }
                }
            }
            catch (Exception rUpEx)
            {
                System.Windows.MessageBox.Show("rUpEx : "+ rUpEx.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return updatedItems;
        }
    }
}
