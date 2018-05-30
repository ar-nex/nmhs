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

        public ObservableCollection<BankBranch> GetBankList()
        {
            ObservableCollection<BankBranch> blist = new ObservableCollection<BankBranch>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM bank_ifsc WHERE 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BankBranch bn = new BankBranch()
                    {
                        IFSC = rdr[0].ToString(),
                        BranchName = rdr[1].ToString(),
                        BankName = rdr[2].ToString(),
                        Micr = rdr[3].ToString(),
                        BranchCode = rdr[4].ToString()
                    };
                    blist.Add(bn);
                }
            }
            catch (Exception bx)
            {
                System.Windows.MessageBox.Show("Problem in getting bank list : "+bx.Message);
            }
            finally
            {
                conn.Close();
            }
            return blist;
        }

        private string GetSql4DistinctList(StaffColName colname)
        {
            string sql1 = "SELECT DISTINCT";
            string sql2 = "FROM `staff` WHERE ";
            string sql3 = "IS NOT NULL";
            string sql = string.Empty;
            switch (colname)
            {
                case StaffColName.VacancyStatus:
                    sql = $"{sql1} vacancyStatus {sql2} vacancyStatus {sql3}";
                    break;
                case StaffColName.Designation:
                    sql = $"{sql1} designation {sql2} designation {sql3}";
                    break;
                case StaffColName.Subject:
                    sql = $"{sql1} subjectName {sql2} subjectName {sql3}";
                    break;
                case StaffColName.SalarySource:
                    sql = $"{sql1} billType {sql2} billType {sql3}";
                    break;
                case StaffColName.EmployeeGroup:
                    sql = $"{sql1} empGroup {sql2} empGroup {sql3}";
                    break;
                case StaffColName.ApprvQualification:
                    sql = $"{sql1} apprvQualification {sql2} apprvQualification {sql3}";
                    break;
                case StaffColName.PayBand:
                    sql = $"{sql1} payband {sql2} payband {sql3}";
                    break;
                default:
                    break;
            }
            return sql;
        }
    }
}
