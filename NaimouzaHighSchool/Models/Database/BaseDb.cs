using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using NaimouzaHighSchool;

namespace NaimouzaHighSchool.Models.Database
{
    public class BaseDb
    {
        protected string connStr;
        protected MySqlConnection conn;

        public BaseDb()
        {
            //this.connStr = ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString;
            //this.connStr = "server=127.0.0.1;uid=delphinium_admin;" + "pwd=dark.d@tura;database=nmhs_desktop;Convert Zero Datetime=True";
           
            try
            {
                this.connStr = "server=127.0.0.1;uid=delphinium_admin;" + "pwd=dark.d@tura;database=nmhs_desktop;Convert Zero Datetime=True";

           // this.connStr = "server=192.168.0.102;uid=delphinium_admin;" + "pwd=dark.d@tura;database=nmhs_desktop;Convert Zero Datetime=True";
           
            this.conn = new MySqlConnection();
            this.conn.ConnectionString = this.connStr;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
