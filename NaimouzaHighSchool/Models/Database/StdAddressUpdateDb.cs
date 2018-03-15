using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class StdAddressUpdateDb : BaseDb
    {
        public StdAddressUpdateDb()
            : base()
        {

        }

        string MainTable = "student_basic";

        public ObservableCollection<Student> GetStudentAddressData(int startYear, int endYear, string cls, string section)
        {
            ObservableCollection<Student> slist = new ObservableCollection<Student>();
            try
            {
                conn.Open();
                string sql = $"SELECT b.id, b.name, b.presentAddress, b.presentAddrLane1, b.presentAddrLane2, b.presentPO, b.presentPS, b.presentDist, b.presentPIN, b.permanentAddress, b.permanentAddrLane1, b.permanentAddrLane2, b.permanentPO, b.permanentPS, b.permanentDist, b.permanentPIN, c.class, c.section, c.roll FROM {MainTable} b INNER JOIN student_class c ON b.id = c.student_basic_id WHERE c.startYear = '{startYear.ToString()}' AND c.endYear = '{endYear.ToString()}' AND c.class = '{cls}' AND c.section = '{section}' ORDER BY c.section, c.roll";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Student s = new Student()
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            PresentAdrress = rdr[2].ToString(),
                            PstAddrLane1 = rdr[3].ToString(),
                            PstAddrLane2 = rdr[4].ToString(),
                            PstAddrPO = rdr[5].ToString(),
                            PstAddrPS = rdr[6].ToString(),
                            PstAddrDist = rdr[7].ToString(),
                            PstAddrPin = rdr[8].ToString(),
                            PermanentAddress = rdr[9].ToString(),
                            PmtAddrLane1 = rdr[10].ToString(),
                            PmtAddrLane2 = rdr[11].ToString(),
                            PmtAddrPO = rdr[12].ToString(),
                            PmtAddrPS = rdr[13].ToString(),
                            PmtAddrDist = rdr[14].ToString(),
                            PmtAddrPin = rdr[15].ToString(),
                            StudyingClass = rdr[16].ToString(),
                            Section = rdr[17].ToString(),
                            Roll = Convert.ToInt32(rdr[18])
                        };
                        slist.Add(s);
                    }
                }
            }
            catch (Exception eu)
            {
                System.Windows.MessageBox.Show("Problem in getting address info. : "+eu.Message);
            }
            finally
            {
                conn.Close();
            }
            return slist;
        }

        public ObservableCollection<string> GetUniqueAddrLaneX(SplitAddrX sx)
        {
            ObservableCollection<string> xvals = new ObservableCollection<string>();
            string sql_x = string.Empty;
            switch (sx)
            {
                case SplitAddrX.AddrLane1:
                    sql_x = "presentAddrLane1";
                    break;
                case SplitAddrX.AddrLane2:
                    sql_x = "presentAddrLane2";
                    break;
                case SplitAddrX.PO:
                    sql_x = "presentPO";
                    break;
                case SplitAddrX.PS:
                    sql_x = "presentPS";
                    break;
                case SplitAddrX.Dist:
                    sql_x = "presentDist";
                    break;
                case SplitAddrX.PIN:
                    sql_x = "presentPIN";
                    break;
                default:
                    break;
            }
            string sql = $"SELECT DISTINCT {sql_x} FROM {MainTable} WHERE {sql_x} IS NOT NULL ORDER BY {sql_x}";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        xvals.Add(rdr[0].ToString());
                    }
                }
            }
            catch (Exception sau)
            {
                System.Windows.MessageBox.Show("Problem in getting "+sql_x+" list :"+sau.Message);
            }
            finally
            {
                conn.Close();
            }
            return xvals;
        }

        public bool UpdateSplitAddress(Student student)
        {
            string prAddrLane1 = (string.IsNullOrEmpty(student.PstAddrLane1)) ? "NULL" : "'"+student.PstAddrLane1+"'";
            string prAddrLane2 = (string.IsNullOrEmpty(student.PstAddrLane2)) ? "NULL" : "'" + student.PstAddrLane2 + "'";
            string prPO = (string.IsNullOrEmpty(student.PstAddrPO)) ? "NULL" : "'" + student.PstAddrPO + "'";
            string prPS = (string.IsNullOrEmpty(student.PstAddrPS)) ? "NULL" : "'" + student.PstAddrPS + "'";
            string prDist = (string.IsNullOrEmpty(student.PstAddrDist)) ? "NULL" : "'" + student.PstAddrDist + "'";
            string prPin = (string.IsNullOrEmpty(student.PstAddrPin)) ? "NULL" : "'" + student.PstAddrPin + "'";

            string pmtAddrLane1 = (string.IsNullOrEmpty(student.PmtAddrLane1)) ? "NULL" : "'" + student.PmtAddrLane1 + "'";
            string pmtAddrLane2 = (string.IsNullOrEmpty(student.PmtAddrLane2)) ? "NULL" : "'" + student.PmtAddrLane2 + "'";
            string pmtPO = (string.IsNullOrEmpty(student.PmtAddrPO)) ? "NULL" : "'" + student.PmtAddrPO + "'";
            string pmtPS = (string.IsNullOrEmpty(student.PmtAddrPS)) ? "NULL" : "'" + student.PmtAddrPS + "'";
            string pmtDist = (string.IsNullOrEmpty(student.PmtAddrDist)) ? "NULL" : "'" + student.PmtAddrDist + "'";
            string pmtPin = (string.IsNullOrEmpty(student.PmtAddrPin)) ? "NULL" : "'" + student.PmtAddrPin + "'";

            bool res = false;
            try
            {
                conn.Open();
                string sql = $"UPDATE {MainTable} SET presentAddrLane1 = {prAddrLane1}, presentAddrLane2 = {prAddrLane2}, presentPO = {prPO}, presentPS = {prPS}, presentDist = {prDist}, presentPIN = {prPin}, " +
                    $" permanentAddrLane1 = {pmtAddrLane1}, permanentAddrLane2 = {pmtAddrLane2}, permanentPO = {pmtPO}, permanentPS = {pmtPS}, permanentDist = {pmtDist}, permanentPIN = {pmtPin} " +
                    $" WHERE {MainTable}.id = '{student.Id}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int r = cmd.ExecuteNonQuery();
                res = r > 0;
            }
            catch (Exception uex)
            {
                System.Windows.MessageBox.Show("Problem in saving data. : "+uex.Message);
            }
            finally
            {
                conn.Close();
            }
            return res;
        }

    }
}
