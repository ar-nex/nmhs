using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class MarkEntryDb : BaseDb
    {
        public MarkEntryDb()
            : base()
        {

        }

        public ObservableCollection<Teacher> GetTeacherList()
        {
            ObservableCollection<Teacher> tlist = new ObservableCollection<Teacher>();
            try
            {
                conn.Open();
                string sql = "SELECT id, name, subject, password FROM teacher WHERE 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Teacher t = new Teacher
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            Subject = rdr[2].ToString(),
                            Password = rdr[3].ToString()
                        };
                        tlist.Add(t);
                    }
                }
            }
            catch (Exception tl)
            {
                System.Windows.MessageBox.Show("Problem in getting teacher list. : " + tl.Message);
            }
            finally
            {
                conn.Close();
            }

            return tlist;
        }
    }
}
