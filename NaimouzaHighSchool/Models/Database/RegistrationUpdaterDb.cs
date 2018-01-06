using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class RegistrationUpdaterDb : BaseDb
    {
        public RegistrationUpdaterDb()
            : base()
        {

        }

        public ObservableCollection<RegistrationUpdater> GetRegistrationData(string cls, string section, int startYear, int endYear)
        {
            string sYear = startYear.ToString();
            string eYear = endYear.ToString();
            ObservableCollection<RegistrationUpdater> rlist = new ObservableCollection<RegistrationUpdater>();
            try
            {
                string sql = string.Empty;
                if (cls == "IX" || cls == "X")
                {
                    sql = $"SELECT b.id, b.name, b.registrationNoMp, c.class, c.section, c.roll FROM student_basic b INNER JOIN student_class c ON b.id = c.student_basic_id WHERe c.startYear = '{sYear}' AND c.endYear = '{endYear}' AND c.class = '{cls}' AND c.section = '{section}'";
                }
               // else if (cls == "XI" || cls == "XII")
                else
                {
                    sql = $"SELECT b.id, b.name, b.registrationNoHs, c.class, c.section, c.roll FROM student_basic b INNER JOIN student_class c ON b.id = c.student_basic_id WHERe c.startYear = '{sYear}' AND c.endYear = '{endYear}' AND c.class = '{cls}' AND c.section = '{section}'";
                }
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        RegistrationUpdater r = new RegistrationUpdater
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            RegistrationNo = rdr[2].ToString(),
                            Cls = rdr[3].ToString(),
                            Section = rdr[4].ToString(),
                            Roll = Convert.ToInt32(rdr[5])
                        };

                        rlist.Add(r);
                    }
                }
            }
            catch (Exception rx)
            {
                System.Windows.MessageBox.Show("Problem in getting registration data. : "+rx.Message);
            }
            finally
            {
                conn.Close();
            }
            return rlist;
        }

        public ObservableCollection<RegistrationUpdater> UpdateRegistration(ObservableCollection<RegistrationUpdater> rlist)
        {
            ObservableCollection<RegistrationUpdater> RetList = new ObservableCollection<RegistrationUpdater>();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                foreach (var item in rlist)
                {
                    string sql = string.Empty;
                    string regis = string.IsNullOrEmpty(item.RegistrationNo) ? "NULL" : item.RegistrationNo;
                    if (item.Cls == "IX" || item.Cls == "X")
                    {
                        sql = $"UPDATE student_basic SET registrationNoMp = '{regis}' WHERE id = '{item.Id}'";
                    }
                    else
                    {
                        sql = $"UPDATE student_basic SET registrationNoHs = '{regis}' WHERE id = '{item.Id}'";
                    }
                    cmd.CommandText = sql;
                    int n = cmd.ExecuteNonQuery();
                    if (n == 0)
                    {
                        RetList.Add(item);
                    }
                }
            }
            catch (Exception ux)
            {
                System.Windows.MessageBox.Show("Problem in update registration. : "+ux.Message);
            }
            finally
            {
                conn.Close();
            }
            return RetList;
        }
    }
}
