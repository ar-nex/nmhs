using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool;

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
    }
}
