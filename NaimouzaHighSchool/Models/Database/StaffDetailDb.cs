using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class StaffDetailDb : BaseDb
    {
        public StaffDetailDb()
        : base()
        {

        }

        public List<Staff> GetStaffList()
        {
            List<Staff> staffList = new List<Staff>();
            try
            {
                this.conn.Open();
                string sql = "SELECT * FROM staff WHERE status='ACTIVE'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Staff s = new Staff();
                    s.Id = rdr[0].ToString();
                    s.Name = rdr[1].ToString();
                    s.Designation = rdr[2].ToString();
                    s.Subject = rdr[3].ToString();
                    s.Qualification = rdr[4].ToString();
                    s.ProfessionalQualification = rdr[5].ToString();
                    s.Sex = rdr[6].ToString();
                    s.DateOfJoining = (string.IsNullOrEmpty(rdr[7].ToString())) ? default(DateTime) : DateTime.Parse(rdr[7].ToString());
                    s.Mobile = rdr[8].ToString();
                    s.AltMobile = rdr[9].ToString();
                    s.Email = rdr[10].ToString();
                    s.BankAcc = rdr[11].ToString();
                    s.Ifsc = rdr[12].ToString();
                    s.BankName = rdr[13].ToString();
                    s.BankBranch = rdr[14].ToString();
                    s.Micr = rdr[15].ToString();
                    s.Status = rdr[16].ToString();
                    s.RetireDate = (string.IsNullOrEmpty(rdr[17].ToString())) ? default(DateTime) : DateTime.Parse(rdr[17].ToString());
                    staffList.Add(s);
                }
            }
            catch (Exception stfex1)
            {
                System.Windows.MessageBox.Show("stfex1 : "+stfex1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return staffList;
        }

        public int InsertStaff(Staff s)
        {
            bool rs = false;
            long inserted_id = 0;
            string nm = "'"+s.Name+"'";
            string desig = this.GetDbCompatableVal(s.Designation);
            string spc = this.GetDbCompatableVal(s.Subject);
            string qlf = this.GetDbCompatableVal(s.Qualification);
            string proQlf = this.GetDbCompatableVal(s.ProfessionalQualification);
            string gender = this.GetDbCompatableVal(s.Sex);
            int doj_temp = s.DateOfJoining.Year;
            string doj = (doj_temp == 1) ? "NULL" : s.DateOfJoining.ToString("dd-MM-yyyy");
            string mob = this.GetDbCompatableVal(s.Mobile);
            string altMob = this.GetDbCompatableVal(s.AltMobile);
            string email = this.GetDbCompatableVal(s.Email);
            string acc = this.GetDbCompatableVal(s.BankAcc);
            string ifsc = this.GetDbCompatableVal(s.Ifsc);
            string bank = this.GetDbCompatableVal(s.BankName);
            string branch = this.GetDbCompatableVal(s.BankBranch);
            string micr = this.GetDbCompatableVal(s.Micr);
            string sts = "'"+s.Status+"'";
            int dor_temp = s.RetireDate.Year;
            string dor = (dor_temp == 1) ? "NULL" : s.RetireDate.ToString("dd-MM-yyyy");

            try
            {
                this.conn.Open();
                string sql = @"INSERT INTO staff (
                        name,
                        designation,
                        speciality,
                        qualification,
                        professionalQualification,
                        gender,
                        DateOfJoining,
                        mobile,
                        altMobile,
                        email,
                        bankAcc,
                        ifsc,
                        bankName,
                        bankBranch,
                        micr,
                        status,
                        retireDate)
                    VALUES(
                            "+nm+", "
                             +desig+", "
                             +spc+", "
                             +qlf+", "
                             +proQlf+", "
                             +gender+", "
                             +doj+", "
                             +mob+", "
                             +altMob+", "
                             +email+", "
                             +acc+", "
                             +ifsc+", "
                             +bank+", "
                             +branch+", "
                             +micr+", "
                             +sts+", "
                             +dor+")";

                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                cmd.ExecuteNonQuery();
                inserted_id = cmd.LastInsertedId;

            }

            catch (Exception stfex2)
            {
                System.Windows.MessageBox.Show("stfex2 : " + stfex2.Message);

            }
            finally
            {
                this.conn.Close();
            }
            rs = inserted_id > 0;
            return Convert.ToInt32(inserted_id);
        }

        public bool UpdateStaff(Staff s)
        {
            bool rs = false;

            string nm = "'" + s.Name + "'";
            string desig = this.GetDbCompatableVal(s.Designation);
            string spc = this.GetDbCompatableVal(s.Subject);
            string qlf = this.GetDbCompatableVal(s.Qualification);
            string proQlf = this.GetDbCompatableVal(s.ProfessionalQualification);
            string gender = this.GetDbCompatableVal(s.Sex);
            int doj_temp = s.DateOfJoining.Year;
            string doj = (doj_temp == 1) ? "NULL" : s.DateOfJoining.ToString("dd-MM-yyyy");
            string mob = this.GetDbCompatableVal(s.Mobile);
            string altMob = this.GetDbCompatableVal(s.AltMobile);
            string email = this.GetDbCompatableVal(s.Email);
            string acc = this.GetDbCompatableVal(s.BankAcc);
            string ifsc = this.GetDbCompatableVal(s.Ifsc);
            string bank = this.GetDbCompatableVal(s.BankName);
            string branch = this.GetDbCompatableVal(s.BankBranch);
            string micr = this.GetDbCompatableVal(s.Micr);
            string sts = "'" + s.Status + "'";
            int dor_temp = s.RetireDate.Year;
            string dor = (dor_temp == 1) ? "NULL" : s.RetireDate.ToString("dd-MM-yyyy");

            string sql = @"UPDATE staff SET
                        name=" + nm + ", designation=" + desig + ", speciality=" + spc + ", qualification=" + qlf + ", professionalQualification=" + proQlf + ", gender=" + gender + ", DateOfJoining=" + doj + ", mobile=" + mob + ", altMobile=" + altMob + ", email=" + email + ", bankAcc=" + acc + ", ifsc=" + ifsc + ", bankName="+bank+", bankBranch="+branch+", micr="+micr+", status="+sts+", retireDate="+dor;

            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                cmd.ExecuteNonQuery();
                rs = true;
            }
            catch (Exception stfexp3)
            {
                rs = false;
                System.Windows.MessageBox.Show("stfexp3 : " + stfexp3);
            }
            finally
            {
                this.conn.Close();
            }
            return rs;
        }

        public bool DeleteStaff(string id)
        {
            bool rs = false;
            try
            {
                this.conn.Close();
                string sql = "DELETE FROM staff WHERE id = '" + id + "'";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                int r = cmd.ExecuteNonQuery();
                rs = r > 0;
            }
            catch (Exception stfexp4)
            {
                System.Windows.MessageBox.Show("stfexp4 : "+stfexp4.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return rs;
        }

        public List<string> GetDistinct(string type)
        {
            List<string> spList = new List<string>();
            string sql = string.Empty;
            switch (type)
            {
                case "SUBJECT":
                    sql = "SELECT DISTINCT speciality from staff";
                    break;
                case "DESIGNATION":
                    sql = "SELECT DISTINCT designation from staff";
                    break;
                case "QUALIFICATION":
                    sql = "SELECT DISTINCT qualification from staff";
                    break;
                case "PROFFESIONALQ":
                    sql = "SELECT DISTINCT professionalQualification from staff";
                    break;
                default:
                    break;
            }
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    spList.Add(rdr[0].ToString());
                }
            }
            catch (Exception stfexp5)
            {
                System.Windows.MessageBox.Show("stfexp5 : "+stfexp5.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return spList;
        }

        private string GetDbCompatableVal(string inp)
        { 
            return (string.IsNullOrEmpty(inp)) ? "NULL" : "'"+inp+"'";
        }
    }
}
