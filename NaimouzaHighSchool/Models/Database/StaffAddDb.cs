using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;
using System.Collections.ObjectModel;

namespace NaimouzaHighSchool.Models.Database
{
    public class StaffAddDb : BaseDb
    {
        public StaffAddDb()
            : base()
        {

        }

      
        public ObservableCollection<string> GetDistinctList(StaffColName colname)
        {
            ObservableCollection<string> xList = new ObservableCollection<string>();
            try
            {
                conn.Open();
                string sql = GetSql4DistinctList(colname);
                if (!string.IsNullOrEmpty(sql))
                {
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        xList.Add(rdr[0].ToString());
                    }
                }
            }
            catch (Exception vx)
            {
                System.Windows.MessageBox.Show("Problem in getting distinct List list. : " + vx.Message);
            }
            finally
            {
                conn.Close();
            }
            return xList;
        }

        private string GetSql4DistinctList(StaffColName colname)
        {
            string sql1 = "SELECT DISTINCT";
            string sql2 = "FROM `staff` WHERE 1";
            string sql = string.Empty;
            switch (colname)
            {
                case StaffColName.VacancyStatus:
                    sql = $"{sql1} designation {sql2}";
                    break;
                case StaffColName.Designation:
                    sql = $"{sql1} designation {sql2}";
                    break;
                case StaffColName.Subject:
                    sql = $"{sql1} designation {sql2}";
                    break;
                default:
                    break;
            }
            return sql;
        }
    }
}
