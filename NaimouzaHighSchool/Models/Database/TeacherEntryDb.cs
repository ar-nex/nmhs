using System;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class TeacherEntryDb : BaseDb
    {
        public TeacherEntryDb()
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
                System.Windows.MessageBox.Show("Problem in getting teacher list. : "+tl.Message);
            }
            finally
            {
                conn.Close();
            }

            return tlist;
        }

        public int InsertTeacher(Teacher t)
        {
            int r = 0;
            try
            {
                conn.Open();
                string sql = $"INSERT INTO teacher (name, subject, password) VALUES ('{t.Name}', '{t.Subject}', '{t.PasswordHash}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                r = (int)cmd.LastInsertedId;
            }
            catch (Exception ti)
            {
                System.Windows.MessageBox.Show("Problem in saving teacher's info. : "+ti.Message);
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public int UpdateTeacher(Teacher t)
        {
            int r = 0;
            try
            {
                conn.Open();
                string sql = $"UPDATE teacher SET name = '{t.Name}', subject = '{t.Subject}', password = '{t.Password}' WHERE id='{t.Id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception tu)
            {
                System.Windows.MessageBox.Show("Problem in updating teacher details. : "+tu.Message);
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public int DeleteTeacher(string id)
        {
            int r = 0;
            try
            {
                conn.Open();
                string sql = $"DELETE FROM teacher WHERE id = '{id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception td)
            {
                System.Windows.MessageBox.Show("Problem in deleting teacher. : "+td.Message);
            }
            finally
            {
                conn.Close();
            }
            return r;
        }

        public ObservableCollection<string> GetSubjectList()
        {
            ObservableCollection<string> sublist = new ObservableCollection<string>();
            try
            {
                conn.Open();
                string sql = $"SELECT DISTINCT subject from teacher";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        sublist.Add(rdr[0].ToString());
                    }
                }
            }
            catch (Exception sl)
            {
                System.Windows.MessageBox.Show("Problem in getting subject list. : "+sl.Message);
            }
            finally
            {
                conn.Close();
            }
            return sublist;
        }
    }
}
