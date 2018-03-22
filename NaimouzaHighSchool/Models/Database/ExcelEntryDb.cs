using System;
using System.Windows;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    class ExcelEntryDb : BaseDb
    {
        public ExcelEntryDb()
        : base()
        {

        }

        public bool InsertFromExcel(Student s, string sessionStartYear, string sessionEndYear)
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
                    
                   
                    string bordNo = String.IsNullOrWhiteSpace(s.BoardNo) ? "NULL" : "'" + s.BoardNo + "'";
                    string bordRoll = String.IsNullOrWhiteSpace(s.BoardRoll) ? "NULL" : "'" + s.BoardRoll + "'";
                    string councilNo = String.IsNullOrWhiteSpace(s.CouncilNo) ? "NULL" : "'" + s.CouncilNo + "'";
                    string councilRoll = String.IsNullOrWhiteSpace(s.CouncilRoll) ? "NULL" : "'" + s.CouncilRoll+ "'";
                    string sbComboId = string.IsNullOrEmpty(s.SubjectComboId) ? "NULL" : "'" + s.SubjectComboId + "'";

                    string d_bankMICR = String.IsNullOrWhiteSpace(s.MICR) ? "NULL" : "'" + s.MICR + "'";

                    string d_aadhaar = GetDbCompatableValue(s.Aadhar);
                    string d_name = GetDbCompatableValue(s.Name);
                    string d_sex = GetDbCompatableValue(s.Sex);
                    string d_father = GetDbCompatableValue(s.FatherName);
                    string d_mother = GetDbCompatableValue(s.MotherName);
                    string d_guardian = GetDbCompatableValue(s.GuardianName);
                    string d_guardianRel = GetDbCompatableValue(s.GuardianRelation);
                    string d_guardianOcc = GetDbCompatableValue(s.GuardianOccupation);
                    string d_pstAddr1 = GetDbCompatableValue(s.PstAddrLane1);
                    string d_pstAddr2 = GetDbCompatableValue(s.PstAddrLane2);
                    string d_pstPO = GetDbCompatableValue(s.PstAddrPO);
                    string d_pstPS = GetDbCompatableValue(s.PstAddrPS);
                    string d_pstDist = GetDbCompatableValue(s.PstAddrDist);
                    string d_pstPIN = GetDbCompatableValue(s.PstAddrPin);
                    string d_pmtAddr1 = GetDbCompatableValue(s.PmtAddrLane1);
                    string d_pmtAddr2 = GetDbCompatableValue(s.PmtAddrLane2);
                    string d_pmtPO = GetDbCompatableValue(s.PmtAddrPO);
                    string d_pmtPS = GetDbCompatableValue(s.PmtAddrPS);
                    string d_pmtDist = GetDbCompatableValue(s.PmtAddrDist);
                    string d_pmtPIN = GetDbCompatableValue(s.PmtAddrPin);
                    string d_mobile = GetDbCompatableValue(s.Mobile);
                    string d_guardianMobile = GetDbCompatableValue(s.GuardianMobile);
                    string d_email = GetDbCompatableValue(s.Email);
                    string d_religion = GetDbCompatableValue(s.Religion);
                    string d_socialCat = GetDbCompatableValue(s.SocialCategory);
                    string d_phType = GetDbCompatableValue(s.PhType);
                    string d_BplNo = GetDbCompatableValue(s.BplNo);
                    string d_guardianAadhaar = GetDbCompatableValue(s.GuardianAadhar);
                    string d_guardianEpic = GetDbCompatableValue(s.GuardianEpic);
                    string d_bloodGroup = GetDbCompatableValue(s.BloodGroup);
                    string d_bankAcc = GetDbCompatableValue(s.BankAcc);
                    string d_bankName = GetDbCompatableValue(s.BankName);
                    string d_branchName = GetDbCompatableValue(s.BankBranch);
                    string d_ifsc = GetDbCompatableValue(s.Ifsc);

                    string isPh = s.IsPH ? "'Y'" : "'N'";
                    string isBpl = s.IsBpl ? "'Y'" : "'N'";

                    string dt = (s.Dob.Year == 1) ? "NULL" : s.Dob.ToString("yyyy-MM-dd");






                    //string sql = @"INSERT INTO student_basic (aadhar, name, fatherName, motherName, guardianName, guardianRelation, guardianOccupation, dob, sex, presentAddrLane1, presentAddrLane2, presentPO, presentPS, presentDist, presentPIN, permanentAddrLane1, permanentAddrLane2, permanentPO, permanentPS, permanentDist, permanentPIN, mobile, guardianMobile, email, religion, socialCategory, isPh, phType, isBPL, BPLnumber, guardianAadhar, guardianEpic, bloodGroup, bankAccountNo, bankName, branchName, IFSC)
                    //VALUES ('" + s.Aadhar+"', '"+s.Name+"' , '"+s.FatherName+"', '"+s.MotherName+"', '"+s.GuardianName+"', '"+s.GuardianRelation+"', '"+s.GuardianOccupation+"', '"+dt+"', '"+s.Sex+"', '"+s.PstAddrLane1+"', '"+s.PstAddrLane2+"', '"+s.PstAddrPO+"', '"+s.PstAddrPS+"', '"+s.PstAddrDist+"', '"+s.PstAddrPin+ "', '" + s.PmtAddrLane1 + "', '" + s.PmtAddrLane2 + "', '" + s.PmtAddrPO + "', '" + s.PmtAddrPS + "', '" + s.PmtAddrDist + "', '" + s.PmtAddrPin + "', '"+s.Mobile+"', '"+s.GuardianMobile+"', '"+s.Email+"', '"+s.Religion+"', '"+s.SocialCategory+"', '"+isPh+"', '"+s.PhType+"', '"+isBpl+"', '"+s.BplNo+"', '"+s.GuardianAadhar+"', '"+s.GuardianEpic+"', '"+s.BloodGroup+"', '"+s.BankAcc+"', '"+s.BankName+"', '"+s.BankBranch+"', '"+s.Ifsc+"')";

                    string sql = $"INSERT INTO student_basic (aadhar, name, fatherName, motherName, guardianName, guardianRelation, guardianOccupation, dob, sex, presentAddrLane1, presentAddrLane2, presentPO, presentPS, presentDist, presentPIN, permanentAddrLane1, permanentAddrLane2, permanentPO, permanentPS, permanentDist, permanentPIN, mobile, guardianMobile, email, religion, socialCategory, isPh, phType, isBPL, BPLnumber, guardianAadhar, guardianEpic, bloodGroup, bankAccountNo, bankName, branchName, IFSC, bankMICR)" +
                        $" VALUES ({d_aadhaar}, {d_name}, {d_father}, {d_mother}, {d_guardian}, {d_guardianRel}, {d_guardianOcc}, '{dt}', {d_sex}, {d_pstAddr1}, {d_pstAddr2}, {d_pstPO}, {d_pstPS}, {d_pstDist}, {d_pstPIN}, {d_pmtAddr1}, {d_pmtAddr2}, {d_pmtPO}, {d_pmtPS}, {d_pstDist}, {d_pmtPIN}, {d_mobile}, {d_guardianMobile}, {d_email}, {d_religion}, {d_socialCat}, {isPh}, {d_phType}, {isBpl}, {d_BplNo}, {d_guardianAadhaar}, {d_guardianEpic}, {d_bloodGroup}, {d_bankAcc}, {d_bankName}, {d_branchName}, {d_ifsc}, {d_bankMICR} )";

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    long insertedId = cmd.LastInsertedId;


                    string strm = string.IsNullOrEmpty(s.Stream) ? "NULL" : "'" + s.Stream + "'";
                    string thirdlang = string.IsNullOrEmpty(s.ThirdLang) ? "NULL" : "'" +s.ThirdLang+ "'";
                    string roll = (s.Roll == 0) ? "NULL" : s.Roll.ToString();
                    string sub1 = string.IsNullOrEmpty(s.HsSub1) ? "NULL" : "'" + s.HsSub1 + "'";
                    string sub2 = string.IsNullOrEmpty(s.HsSub2) ? "NULL" : "'" + s.HsSub2 + "'";
                    string sub3 = string.IsNullOrEmpty(s.HsSub3) ? "NULL" : "'" + s.HsSub3 + "'";
                    string adl = string.IsNullOrEmpty(s.HsAdlSub) ? "NULL" : "'" + s.HsAdlSub + "'";


                    string sql2 = @"INSERT INTO student_class (startYear, endYear, student_basic_id, class, section, roll, stream, thirdLanguage, hsElemSub1, hsElemSub2, hsElemSub3, hsAdlSub)
                    VALUES ('" +sessionStartYear+"', '"+sessionEndYear+"', '"+insertedId+"', '"+s.StudyingClass+"', '"+s.Section+"', '"+s.Roll+"', "+strm+", '"+s.ThirdLang+"', '"+s.HsSub1+"', '"+s.HsSub2+"', '"+s.HsSub3+"', '"+s.HsAdlSub+"' )";
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();

                    string admNo = String.IsNullOrWhiteSpace(s.AdmissionNo) ? "NULL" : "'" + s.AdmissionNo + "'";
                    string dtAdm = s.AdmDate.ToString("yyyy-MM-dd");
                    string dtOfAdm;
                    if (dtAdm == "0001-01-01")
                    {
                        dtOfAdm = "NULL";
                    }
                    else 
                    {
                        dtOfAdm = "'"+dtAdm+"'";
                    }
                    string admClass = String.IsNullOrWhiteSpace(s.AdmittedClass) ? "NULL" : "'" + s.AdmittedClass + "'";
                    string lastSchool = String.IsNullOrWhiteSpace(s.LastSchool) ? "NULL" : "'" + s.LastSchool + "'";
                    string dtLeave = s.DateOfLeaving.ToString("yyyy-MM-dd");
                    string dateOfLeaving;
                    if (dtLeave == "0001-01-01")
                    {
                        dateOfLeaving = "NULL";
                    }
                    else
                    {
                        dateOfLeaving = dtLeave;
                    }
                    string tc = String.IsNullOrWhiteSpace(s.TC) ? "NULL" : "'" + s.TC + "'";

                    string sql3 = @"INSERT INTO Admission (admissionNo, dateOfAdmission, admittedClass, lastSchool, dateOfLeaving, TC, student_basic_id)
                    VALUES("+admNo+", "+dtOfAdm+", "+admClass+", "+lastSchool+", "+dateOfLeaving+", "+tc+", "+insertedId+")";
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    
                    myTrans.Commit();
                    inserted = true;
                }
                catch (Exception e2)
                {

                    try
                    {
                        myTrans.Rollback();
                        inserted = false;
                    }
                    catch (Exception e3)
                    {

                        MessageBox.Show(e3.Message);
                    }
                    MessageBox.Show(e2.Message);
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
                
            }
            finally
            {
                this.conn.Close();
            }
            return inserted;
        }

        private string GetDbCompatableValue(string inp)
        {
            return string.IsNullOrEmpty(inp) ? "NULL" : "'"+inp+"'";
        }
    }
}
