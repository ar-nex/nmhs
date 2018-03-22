using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class StudentBuilderFromCompleteMySqlDataReader : BaseDb
    {
        public StudentBuilderFromCompleteMySqlDataReader()
            : base()
        {

        }

        protected Student BuildObject(MySqlDataReader rdr)
        {
            Student s = new Student();
            s.Id = rdr[0].ToString();
            s.Aadhar = rdr[1].ToString();
            s.Name = rdr[2].ToString();
            s.FatherName = rdr[3].ToString();
            s.MotherName = rdr[4].ToString();
            s.GuardianName = rdr[5].ToString();
            s.GuardianRelation = rdr[6].ToString();

            s.GuardianOccupation = rdr[7].ToString();
            s.Dob = (string.IsNullOrEmpty(rdr[8].ToString())) ? default(DateTime) : DateTime.Parse(rdr[8].ToString());
            s.Sex = rdr[9].ToString();
            s.PresentAdrress = rdr[11].ToString();
            s.PermanentAddress = rdr[18].ToString();

            s.Mobile = rdr[25].ToString();
            s.GuardianMobile = rdr[26].ToString();
            s.Email = rdr[27].ToString();
            s.Religion = rdr[28].ToString();
            s.SocialCategory = rdr[29].ToString();

            s.SubCast = rdr[30].ToString();
            s.IsPH = (rdr[31].ToString() == "Y") ? true : false;
            s.PhType = rdr[32].ToString();
            s.IsBpl = (rdr[33].ToString() == "Y") ? true : false;
            s.BplNo = rdr[34].ToString();

            s.GuardianAadhar = rdr[35].ToString();
            s.GuardianEpic = rdr[36].ToString();
            s.BloodGroup = rdr[37].ToString();
            s.BankAcc = rdr[38].ToString();
            s.BankName = rdr[39].ToString();

            s.BankBranch = rdr[40].ToString();
            s.Ifsc = rdr[41].ToString();
            s.MICR = rdr[42].ToString();
            s.BoardRoll = rdr[45].ToString();
            s.BoardNo = rdr[46].ToString();

            s.CouncilRoll = rdr[47].ToString();
            s.CouncilNo = rdr[48].ToString();

            s.RegistrationNoMp = rdr[49].ToString();
            s.RegistrationNoHs = rdr[50].ToString();

            s.StartSessionYear = Convert.ToInt32(rdr[51]);
            s.EndSessionYear = Convert.ToInt32(rdr[52]);

            s.StudyingClass = rdr[53].ToString();
            s.Section = rdr[54].ToString();
            s.Roll = Int32.Parse(rdr[55].ToString());
            s.HsSub1 = rdr[58].ToString();
            s.HsSub2 = rdr[59].ToString();
            s.HsSub3 = rdr[60].ToString();
            s.HsAdlSub = rdr[61].ToString();


            s.AdmissionNo = rdr[64].ToString();
            s.AdmDate = (string.IsNullOrEmpty(rdr[65].ToString())) ? default(DateTime) : DateTime.Parse(rdr[65].ToString());
            s.AdmittedClass = rdr[66].ToString();
            s.LastSchool = rdr[67].ToString();
            s.DateOfLeaving = (string.IsNullOrEmpty(rdr[68].ToString())) ? default(DateTime) : DateTime.Parse(rdr[68].ToString());
            s.TC = rdr[69].ToString();
            return s;
        }
    }
}
