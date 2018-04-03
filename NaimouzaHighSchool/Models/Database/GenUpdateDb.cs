using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class GenUpdateDb : BaseDb
    {
        public GenUpdateDb()
            : base()
        {
                
        }

        private string basic_table = "student_basic";

        

        public bool UpdateStudent(Student s)
        {
            bool rs = false;
            string dob_temp = s.Dob.ToString("yyyy-MM-dd");
            string dob = (dob_temp == "0001-01-01") ? "NULL" : "'" + dob_temp + "'";
            string isPH = (s.IsPH) ? "'Y'" : "'N'";
            string isBpl = (s.IsBpl) ? "'Y'" : "'N'";
            string roll = "'" + s.Roll.ToString() + "'";
            string sYear = "'" + s.StartSessionYear.ToString() + "'";
            string eYear = "'" + s.EndSessionYear.ToString() + "'";

            try
            {
                conn.Open();
                MySqlCommand cmd = this.conn.CreateCommand();
                MySqlTransaction myTrans = this.conn.BeginTransaction();
                cmd.Connection = this.conn;
                cmd.Transaction = myTrans;
                try
                {
                    string sql1 = $"UPDATE {basic_table} SET " +
                                  $" aadhar = {DbVal(s.Aadhar)}, name= {DbVal(s.Name)}, fatherName= {DbVal(s.FatherName)}, motherName={DbVal(s.MotherName)}, guardianName={DbVal(s.GuardianName)}, guardianRelation={DbVal(s.GuardianRelation)}, guardianOccupation={DbVal(s.GuardianOccupation)}, dob={dob}, sex={DbVal(s.Sex)}, presentAddrLane1 ={DbVal(s.PstAddrLane1)}, presentAddrLane2 = {DbVal(s.PstAddrLane2)}, presentPO = {DbVal(s.PstAddrPO)}, presentPS = {DbVal(s.PstAddrPS)}, presentDist = {DbVal(s.PstAddrDist)}, presentPIN = {DbVal(s.PstAddrPin)}, permanentAddrLane1 = {DbVal(s.PmtAddrLane1)}, permanentAddrLane2 = {DbVal(s.PmtAddrLane2)}, permanentPO = {DbVal(s.PmtAddrPO)}, permanentPS = {DbVal(s.PmtAddrPS)}, permanentDist = {DbVal(s.PmtAddrDist)}, permanentPIN = {DbVal(s.PmtAddrPin)}, mobile={DbVal(s.Mobile)}, guardianMobile={DbVal(s.GuardianMobile)}, email={DbVal(s.Email)}, religion={DbVal(s.Religion)}, socialCategory={DbVal(s.SocialCategory)}, isPH={isPH}, phType={DbVal(s.PhType)}, isBPL={isBpl}, BPLnumber={DbVal(s.BplNo)}, guardianAadhar={DbVal(s.GuardianAadhar)}, guardianEpic={DbVal(s.GuardianEpic)}, bloodGroup={DbVal(s.BloodGroup)}, bankAccountNo={DbVal(s.BankAcc)}, bankName={DbVal(s.BankName)}, branchName={DbVal(s.BankBranch)}, IFSC={DbVal(s.Ifsc)}, bankMICR={DbVal(s.MICR)}, BoardRoll={DbVal(s.BoardRoll)}, BoardNo={DbVal(s.BoardNo)}, CouncilRoll={DbVal(s.CouncilRoll)}, CouncilNo={DbVal(s.CouncilNo)}, registrationNoMp = {DbVal(s.RegistrationNoMp)}, registrationNoHs = {DbVal(s.RegistrationNoHs)} WHERE id=" + s.Id;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery();


                    string sql2 = $"UPDATE student_class SET class={DbVal(s.StudyingClass)}, section={DbVal(s.Section)}, roll={roll} WHERE student_basic_id={DbVal(s.Id)} AND startYear = {sYear} AND endYear = {eYear}";
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    string sql3 = $"UPDATE Admission SET admissionNo={DbVal(s.AdmissionNo)}, admittedClass={DbVal(s.AdmittedClass)}, lastSchool={DbVal(s.LastSchool)}, TC={DbVal(s.TC)} WHERE student_basic_id={DbVal(s.Id)}";
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();

                    myTrans.Commit();
                    rs = true;
                }
                catch (Exception ex5)
                {
                    try
                    {
                        myTrans.Rollback();
                        rs = false;
                    }
                    catch (Exception e3)
                    {

                        System.Windows.MessageBox.Show("e3 : " + e3.Message);
                    }
                    System.Windows.MessageBox.Show("ex5 : " + ex5.Message);
                }
            }
            catch (Exception ex4)
            {
                System.Windows.MessageBox.Show("ex4 : " + ex4.Message);
            }
            finally
            {
                conn.Close();
            }
            if (rs)
            {
                EventConnector.OnStudentUpdated();
            }
            return rs;
        }


        private string DbVal(string inp)
        {
            return (string.IsNullOrEmpty(inp)) ? "NULL" : "'"+inp+"'";
        }
       
    }
}
