using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;
using System;

namespace NaimouzaHighSchool.Models.Database
{
    public class StudentDataWriteDb : BaseDb
    {
        public StudentDataWriteDb()
        : base()
        {
        }

        public bool InsertStudentData(Student s)
        {
            bool inserted = false;

            try
            {
                this.conn.Open();
                MySqlCommand cmd = this.conn.CreateCommand();
                MySqlTransaction myTrans = this.conn.BeginTransaction();
                cmd.Connection = this.conn;
                cmd.Transaction = myTrans;
                try
                {
                    string sql = @"INSERT INTO student_basic (
                                        aadhar,
                                        name,
                                        fatherName,
                                        motherName,
                                        guardianName,
                                        guardianRelation,
                                        guardianOccupation,
                                        dob,
                                        sex,
                                        presentAddrLane1,
                                        presentAddrLane2,
                                        presentPO,
                                        presentPS,
                                        presentDist,
                                        presentPIN,
                                        permanentAddrLane1,
                                        permanentAddrLane2,
                                        permanentPO,
                                        permanentPS,
                                        permanentDist,
                                        permanentPIN,
                                        mobile,
                                        guardianMobile,
                                        email,
                                        religion,
                                        socialCategory,
                                        isPh,
                                        phType,
                                        isBPL,
                                        BPLnumber,
                                        guardianAadhar,
                                        guardianEpic,
                                        bloodGroup,
                                        bankAccountNo,
                                        bankName,
                                        branchName,
                                        IFSC,
                                        bankMICR,
                                        registrationNoMp,
                                        registrationNoHs,
                                        BoardRoll,
                                        BoardNo,
                                        CouncilRoll,
                                        CouncilNo)
                    VALUES (
                            " + dv(s.Aadhar) + ", "
                             + dv(s.Name) + ", "
                             + dv(s.FatherName) + ", "
                             + dv(s.MotherName) + ", "
                             + dv(s.GuardianName) + ", "
                             + dv(s.GuardianRelation) + ", "
                             + dv(s.GuardianOccupation) + ", "
                             + dv(s.Dob) + ", "
                             + dv(s.Sex) + ", "
                             + dv(s.PstAddrLane1) + ", "
                             + dv(s.PstAddrLane2) + ", "
                             + dv(s.PstAddrPO) + ", "
                             + dv(s.PstAddrPS) + ", "
                             + dv(s.PstAddrDist) + ", "
                             + dv(s.PstAddrPin) + ", "
                             + dv(s.PmtAddrLane1) + ", "
                             + dv(s.PmtAddrLane2) + ", "
                             + dv(s.PmtAddrPO) + ", "
                             + dv(s.PmtAddrPS) + ", "
                             + dv(s.PmtAddrDist) + ", "
                             + dv(s.PmtAddrPin) + ", "
                             + dv(s.Mobile) + ", "
                             + dv(s.GuardianMobile) + ", "
                             + dv(s.Email) + ", "
                             + dv(s.Religion) + ", "
                             + dv(s.SocialCategory) + ", "
                             + dv(s.IsPH) + ", "
                             + dv(s.PhType) + ", "
                             + dv(s.IsBpl) + ", "
                             + dv(s.BplNo) + ", "
                             + dv(s.GuardianAadhar) + ", "
                             + dv(s.GuardianEpic) + ", "
                             + dv(s.BloodGroup) + ", "
                             + dv(s.BankAcc) + ", "
                             + dv(s.BankName) + ", "
                             + dv(s.BankBranch) + ", "
                             + dv(s.Ifsc) + ", "
                             + dv(s.MICR) + ", "
                             + dv(s.RegistrationNoMp) + ", "
                             + dv(s.RegistrationNoHs) + ", "
                             + dv(s.BoardRoll) + ", "
                             + dv(s.BoardNo) + ", "
                             + dv(s.CouncilRoll) + ", "
                             + dv(s.CouncilNo) +
                            ")";

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    long insertedId = cmd.LastInsertedId;

                    string sql2 = @"INSERT INTO student_class (startYear, endYear, student_basic_id, class, section, roll, stream, thirdLanguage, hsElemSub1, hsElemSub2, hsElemSub3, hsAdlSub)
                    VALUES (" + dv(s.StartSessionYear) + ", " + dv(s.EndSessionYear) + ", " + insertedId + ", " + dv(s.StudyingClass) + ", " + dv(s.Section) + ", " + dv(s.Roll) + ", " + dv(s.Stream) + ", "+ dv(s.ThirdLang) +", " + dv(s.HsSub1) + ", " + dv(s.HsSub2) + ", " + dv(s.HsSub3) + ", " + dv(s.HsAdlSub) + ")";
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    string sql3 = @"INSERT INTO Admission (admissionNo, admittedClass, lastSchool, TC, student_basic_id)
                    VALUES(" + dv(s.AdmissionNo) + ", " + dv(s.AdmittedClass) + ", " + dv(s.LastSchool) + ", " + dv(s.TC) + ", " + insertedId + ")";
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();

                    myTrans.Commit();
                    inserted = true;
                }
                catch (Exception e2)
                {
                    inserted = false;
                    try
                    {
                        myTrans.Rollback();
                    }
                    catch (Exception e3)
                    {
                        System.Windows.MessageBox.Show("e3 : " + e3.Message);
                    }
                    System.Windows.MessageBox.Show("e2 : " + e2.Message);
                }
            }
            catch (Exception e1)
            {
                System.Windows.MessageBox.Show("e1 : " + e1.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return inserted;
        }
    }
}