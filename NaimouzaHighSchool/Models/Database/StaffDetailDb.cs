using System;
using System.Collections.Generic;
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
                string sql = "SELECT s.id, s.name, s.designation, s.subjectName, s.eduQualification, s.profQualification, s.sex, s.joiningDate, s.retirementDate, s.mobileNo, s.altMobile, s.email, s.bankAcc, s.bank_ifsc_code, b.bankBranch, b.bankName, b.micr FROM staff s LEFT JOIN bank_ifsc b ON s.bank_ifsc_code = b.ifsc_code WHERE 1";
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
                    s.RetireDate = (string.IsNullOrEmpty(rdr[8].ToString())) ? default(DateTime) : DateTime.Parse(rdr[8].ToString());
                    s.Mobile = rdr[9].ToString();
                    s.AltMobile = rdr[10].ToString();
                    s.Email = rdr[11].ToString();
                    s.BankAcc = rdr[12].ToString();
                    s.Ifsc = rdr[13].ToString();
                    s.BankBranch = rdr[14].ToString();
                    s.BankName = rdr[15].ToString();
                    s.Micr = rdr[16].ToString();
                   
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
            string doj = (doj_temp == 1) ? "NULL" : "'"+s.DateOfJoining.ToString("yyyy-MM-dd")+"'";
            string mob = this.GetDbCompatableVal(s.Mobile);
            string altMob = this.GetDbCompatableVal(s.AltMobile);
            string email = this.GetDbCompatableVal(s.Email);
            string acc = this.GetDbCompatableVal(s.BankAcc);
            string ifsc = this.GetDbCompatableVal(s.Ifsc);
            string bank = this.GetDbCompatableVal(s.BankName);
            string branch = this.GetDbCompatableVal(s.BankBranch);
            string micr = this.GetDbCompatableVal(s.Micr);
            int dor_temp = s.RetireDate.Year;
            string dor = (dor_temp == 1) ? "NULL" : "'"+s.RetireDate.ToString("yyyy-MM-dd")+"'";

            if (!string.IsNullOrEmpty(s.Ifsc))
            {
                string sql1 = @"INSERT IGNORE INTO bank_ifsc ( ifsc_code, bankBranch, bankName, micr) VALUES( "+ifsc+", "+branch+", "+bank+", "+micr+")";
                string sql2 = @"INSERT INTO staff (
                    name,
                    designation,
                    subjectName,
                    eduQualification,
                    profQualification,
                    sex,
                    joiningDate,
                    retirementDate,
                    bankAcc,
                    bank_ifsc_code,
                    mobileNo,
                    altMobile,
                    email)
                    VALUES(
                            " + nm + ", "
                                 + desig + ", "
                                 + spc + ", "
                                 + qlf + ", "
                                 + proQlf + ", "
                                 + gender + ", "
                                 + doj + ", "
                                 + dor + ", "
                                 + acc + ", "
                                 + ifsc + ", "
                                 + mob + ", "
                                 + altMob + ", "
                                 + email + ")";

                try
                {
                    this.conn.Open();
                    MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                    cmd1.ExecuteNonQuery();
                    MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                    cmd2.ExecuteNonQuery();
                    inserted_id = cmd2.LastInsertedId;

                }
                catch (Exception ein)
                {
                    System.Windows.MessageBox.Show("Problem in inserting staff detail. Message : "+ein.Message);
                }
                finally
                {
                    this.conn.Close();
                }


            }
            else
            {
                try
                {
                    this.conn.Open();
                    string sql = @"INSERT INTO staff (
                    name,
                    designation,
                    subjectName,
                    eduQualification,
                    profQualification,
                    sex,
                    joiningDate,
                    retirementDate,
                    mobileNo,
                    altMobile,
                    email)
                    VALUES(
                            " + nm + ", "
                                 + desig + ", "
                                 + spc + ", "
                                 + qlf + ", "
                                 + proQlf + ", "
                                 + gender + ", "
                                 + doj + ", "
                                 + dor + ", "
                                 + mob + ", "
                                 + altMob + ", "
                                 + email + ")";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    inserted_id = cmd.LastInsertedId;

                }

                catch (Exception stfex2)
                {
                    System.Windows.MessageBox.Show("stfex2 : " + stfex2.Message);

                }
                finally
                {
                    conn.Close();
                }
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
            string doj = (doj_temp == 1) ? "NULL" : "'"+s.DateOfJoining.ToString("yyyy-MM-dd")+"'";
            int dor_temp = s.RetireDate.Year;
            string dor = (dor_temp == 1) ? "NULL" : "'"+s.RetireDate.ToString("yyyy-MM-dd")+"'";
            string mob = this.GetDbCompatableVal(s.Mobile);
            string altMob = this.GetDbCompatableVal(s.AltMobile);
            string email = this.GetDbCompatableVal(s.Email);

            string acc = this.GetDbCompatableVal(s.BankAcc);
            string ifsc = this.GetDbCompatableVal(s.Ifsc);
            string bank = this.GetDbCompatableVal(s.BankName);
            string branch = this.GetDbCompatableVal(s.BankBranch);
            string micr = this.GetDbCompatableVal(s.Micr);

            if (!string.IsNullOrEmpty(s.Ifsc))
            {
                string sql1 = @"INSERT IGNORE INTO bank_ifsc ( ifsc_code, bankBranch, bankName, micr) VALUES( " + ifsc + ", " + branch + ", " + bank + ", " + micr + ")";
                string sql2 = @"UPDATE staff SET
                        name=" + nm + ", designation=" + desig + ", subjectName=" + spc + ", eduQualification=" + qlf + ", profQualification=" + proQlf + ", sex=" + gender + ", joiningDate=" + doj + ", mobileNo=" + mob + ", altMobile=" + altMob + ", email=" + email + ", bankAcc=" + acc + ", bank_ifsc_code=" + ifsc + ", retirementDate=" + dor + " WHERE id = "+s.Id;
                try
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.Transaction = myTrans;
                    try
                    {
                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();

                        myTrans.Commit();
                        rs = true;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            myTrans.Rollback();
                            rs = false;

                        }
                        catch (Exception ter)
                        {
                            System.Windows.MessageBox.Show("update transaction problem: ter : "+ter.Message);
                            rs = false;
                        }
                    }
                    
                }
                catch (Exception eup)
                {
                    System.Windows.MessageBox.Show("Problem at Staff Update. Message : "+eup.Message);
                }
                finally
                {
                    this.conn.Close();
                }
            }
            else
            {
                string sql = @"UPDATE staff SET
                        name=" + nm + ", designation=" + desig + ", subjectName=" + spc + ", eduQualification=" + qlf + ", profQualification=" + proQlf + ", sex=" + gender + ", joiningDate=" + doj + ", mobileNo=" + mob + ", altMobile=" + altMob + ", email=" + email + ", retirementDate=" + dor + " WHERE id = " + s.Id;

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
            }
            
            return rs;
        }

        public bool DeleteStaff(string id)
        {
            bool rs = false;
            try
            {
                this.conn.Open();
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
                    sql = "SELECT DISTINCT subjectName from staff";
                    break;
                case "DESIGNATION":
                    sql = "SELECT DISTINCT designation from staff";
                    break;
                case "QUALIFICATION":
                    sql = "SELECT DISTINCT eduQualification from staff";
                    break;
                case "PROFFESIONALQ":
                    sql = "SELECT DISTINCT profQualification from staff";
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

        public List<BankBranch> getBankBranchList()
        {
            List<BankBranch> branchList = new List<BankBranch>();
            string sql = "SELECT * FROM bank_ifsc";
            try
            {
                this.conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BankBranch b = new BankBranch();
                    b.IFSC = rdr[0].ToString();
                    b.BranchName = rdr[1].ToString();
                    b.BankName = rdr[2].ToString();
                    b.Micr = rdr[3].ToString();

                    branchList.Add(b);
                }

            }
            catch (Exception e1)
            {
                System.Windows.MessageBox.Show("Er. in StaffDetailDb->getBankBranchList :"+e1.Message);
            }
            finally
            {
                this.conn.Close();
            }

            return branchList;
        }

        private string GetDbCompatableVal(string inp)
        { 
            return (string.IsNullOrEmpty(inp)) ? "NULL" : "'"+inp+"'";
        }
    }
}
