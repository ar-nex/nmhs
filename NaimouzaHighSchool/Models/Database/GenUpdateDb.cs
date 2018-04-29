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
                                  $" aadhar = {dv(s.Aadhar)}, name= {dv(s.Name)}, fatherName= {dv(s.FatherName)}, motherName={dv(s.MotherName)}, guardianName={dv(s.GuardianName)}, guardianRelation={dv(s.GuardianRelation)}, guardianOccupation={dv(s.GuardianOccupation)}, dob={dob}, sex={dv(s.Sex)}, presentAddrLane1 ={dv(s.PstAddrLane1)}, presentAddrLane2 = {dv(s.PstAddrLane2)}, presentPO = {dv(s.PstAddrPO)}, presentPS = {dv(s.PstAddrPS)}, presentDist = {dv(s.PstAddrDist)}, presentPIN = {dv(s.PstAddrPin)}, permanentAddrLane1 = {dv(s.PmtAddrLane1)}, permanentAddrLane2 = {dv(s.PmtAddrLane2)}, permanentPO = {dv(s.PmtAddrPO)}, permanentPS = {dv(s.PmtAddrPS)}, permanentDist = {dv(s.PmtAddrDist)}, permanentPIN = {dv(s.PmtAddrPin)}, mobile={dv(s.Mobile)}, guardianMobile={dv(s.GuardianMobile)}, email={dv(s.Email)}, religion={dv(s.Religion)}, socialCategory={dv(s.SocialCategory)}, isPH={isPH}, phType={dv(s.PhType)}, isBPL={isBpl}, BPLnumber={dv(s.BplNo)}, guardianAadhar={dv(s.GuardianAadhar)}, guardianEpic={dv(s.GuardianEpic)}, bloodGroup={dv(s.BloodGroup)}, bankAccountNo={dv(s.BankAcc)}, bankName={dv(s.BankName)}, branchName={dv(s.BankBranch)}, IFSC={dv(s.Ifsc)}, bankMICR={dv(s.MICR)}, BoardRoll={dv(s.BoardRoll)}, BoardNo={dv(s.BoardNo)}, CouncilRoll={dv(s.CouncilRoll)}, CouncilNo={dv(s.CouncilNo)}, registrationNoMp = {dv(s.RegistrationNoMp)}, registrationNoHs = {dv(s.RegistrationNoHs)} WHERE id=" + s.Id;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery();

                    string sql2 = $"UPDATE student_class SET class={dv(s.StudyingClass)}, section={dv(s.Section)}, roll={roll} WHERE student_basic_id={dv(s.Id)} AND startYear = {sYear} AND endYear = {eYear}";
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    if (s.StudyingClass == "XI" || s.StudyingClass == "XII")
                    {
                        string sql_sub = $"UPDATE student_class SET hsElemSub1 = {dv(s.HsSub1)}, hsElemSub2 = {dv(s.HsSub2)}, hsElemSub3 = {dv(s.HsSub3)}, hsAdlSub = {dv(s.HsAdlSub)} WHERE student_basic_id = {dv(s.Id)} AND startYear = {dv(s.StartSessionYear)} AND endYear = {dv(s.EndSessionYear)}";
                        cmd.CommandText = sql_sub;
                        cmd.ExecuteNonQuery();
                    }

                    string sql3 = $"UPDATE Admission SET admissionNo={dv(s.AdmissionNo)}, admittedClass={dv(s.AdmittedClass)}, lastSchool={dv(s.LastSchool)}, TC={dv(s.TC)} WHERE student_basic_id={dv(s.Id)}";
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
    }
}
