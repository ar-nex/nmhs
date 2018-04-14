using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace NaimouzaHighSchool.Models.Database
{
    public class BaseDb
    {
        protected string connStr;
        protected MySqlConnection conn;

        

        public BaseDb()
        {
            if (ConfigurationManager.ConnectionStrings["nmhs_connection"] != null)
            {
                try
                {

                    this.connStr = ConfigurationManager.ConnectionStrings["nmhs_connection"].ConnectionString;
                    this.conn = new MySqlConnection();
                    this.conn.ConnectionString = this.connStr;


                }
                catch (Exception e_constr)
                {
                    System.Windows.MessageBox.Show("e_constr : " + e_constr.Message);
                }
            }
            else
            {
                this.connStr = "server=127.0.0.1;uid=delphinium_admin;" + "pwd=dark.d@tura;database=nmhs_desktop;Convert Zero Datetime=True";
                this.conn = new MySqlConnection();
                this.conn.ConnectionString = this.connStr;
            }
            
        }

        /// <summary>
        /// Produce sql compatable value. That is it surrounds the inputStr with '' or generate NULL.
        /// Also remove unwanted character like '
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        protected string dv(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr))
            {
                return "NULL";
            }
            else
            {
                string outputStr = inputStr.Replace(@"'", string.Empty);
                return "'" + outputStr + "'";
            }
        }

        protected string dv(DateTime dt)
        {
            return (dt.Year == 1) ? "NULL" : "'" + dt.ToString("yyyy-MM-dd") + "'";
        }

        protected string dv(bool YesNo)
        {
            return (YesNo) ? "'Y'" : "'N'";
        }

        protected string dv(int inpVal)
        {
            return "'" + inpVal.ToString() + "'";
        }
    }
}
