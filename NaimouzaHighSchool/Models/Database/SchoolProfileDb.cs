using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace NaimouzaHighSchool.Models.Database
{
    public class SchoolProfileDb : BaseDb
    {
        public SchoolProfileDb()
            : base()
        {

        }

        private int CountM;
        private int CountF;
        private int CountGenNull;

        private int CountGen;
        private int CountSc;
        private int CountSt;
        private int CountObc;
        private int CountObcA;
        private int CountObcB;
        private int CountSocNull;

        private int CountApl;
        private int CountBpl;


        public (int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int) GetProfile(int StartYear, int EndYear)
        {
            int CountTot = 0;
            int Count5 = 0;
            int Count6 = 0;
            int Count7 = 0;
            int Count8 = 0;
            int Count9 = 0;
            int Count10 = 0;
            int Count11 = 0;
            int Count12 = 0;

            string fixedSql = $"SELECT COUNT(b.id) FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id ";
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql_tot = $"{fixedSql} WHERE c.startYear = {dv(StartYear)} AND c.endYear = {dv(EndYear)}";
                cmd.CommandText = sql_tot;
                Object r = cmd.ExecuteScalar();
                CountTot = (r != null) ? Convert.ToInt32(r) : 0;

                Count5 = GetCount(cmd, sql_tot, "V", 0);
                Count6 = GetCount(cmd, sql_tot, "VI", 0);
                Count7 = GetCount(cmd, sql_tot, "VII", 0);
                Count8 = GetCount(cmd, sql_tot, "VIII", 0);
                Count9 = GetCount(cmd, sql_tot, "IX", 0);
                Count10 = GetCount(cmd, sql_tot, "X", 0);
                Count11 = GetCount(cmd, sql_tot, "XI",  0);
                Count12 = GetCount(cmd, sql_tot, "XII", 0);

                CountM = GetCount(cmd, sql_tot, "M", 1);
                CountF = GetCount(cmd, sql_tot, "F", 1);
                CountGenNull = GetCount(cmd, sql_tot, string.Empty, 1);

                CountGen = GetCount(cmd, sql_tot, "GEN", 2);
                CountSc = GetCount(cmd, sql_tot, "SC", 2);
                CountSt = GetCount(cmd, sql_tot, "ST", 2);
                CountObc = GetCount(cmd, sql_tot, "OBC", 2);
                CountObcA = GetCount(cmd, sql_tot, "OBC-A", 2);
                CountObcB = GetCount(cmd, sql_tot, "OBC-B", 2);
                CountSocNull = GetCount(cmd, sql_tot, string.Empty, 2);

                CountApl = GetCount(cmd, sql_tot, "N", 3);
                CountBpl = GetCount(cmd, sql_tot, "Y", 3);
            }
            catch (Exception sp)
            {
                System.Windows.MessageBox.Show("Problem in getting school profile info.: "+sp.Message);
            }
            finally
            {
                conn.Close();
            }
            var tpl = (CountTot, Count5, Count6, Count7, Count8, Count9, Count10, Count11, Count12, CountM, CountF, CountGenNull, CountGen, CountSc, CountSt, CountObc, CountObcA, CountObcB, CountSocNull, CountApl, CountBpl);
            return tpl;
        }

        public (int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int) GetProfile(int StartYear, int EndYear, string cls)
        {
            int CountTot = 0;
            int CountA = 0;
            int CountB = 0;
            int CountC = 0;
            int CountD = 0;
            int CountE = 0;
            int CountSecNull = 0;
            string fixedSql = $"SELECT COUNT(b.id) FROM student_basic b INNER JOIN student_class c ON c.student_basic_id = b.id WHERE c.startYear = {dv(StartYear)} AND c.endYear = {dv(EndYear)} AND c.class = {dv(cls)}";

            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string sql_tot = $"{fixedSql} AND c.class = {dv(cls)}";
                cmd.CommandText = sql_tot;
                Object r = cmd.ExecuteScalar();
                CountTot = (r != null) ? Convert.ToInt32(r) : 0;

                CountA = GetCountInCl(cmd, sql_tot, "A", 0);
                CountB = GetCountInCl(cmd, sql_tot, "B", 0);
                CountC = GetCountInCl(cmd, sql_tot, "C", 0);
                CountD = GetCountInCl(cmd, sql_tot, "D", 0);
                CountE = GetCountInCl(cmd, sql_tot, "E", 0);
                CountSecNull = GetCountInCl(cmd, sql_tot, string.Empty, 0);

                CountM = GetCountInCl(cmd, sql_tot, "M", 1);
                CountF = GetCountInCl(cmd, sql_tot, "F", 1);
                CountGenNull = GetCountInCl(cmd, sql_tot, string.Empty, 1);

                CountGen = GetCountInCl(cmd, sql_tot, "GEN", 2);
                CountSc = GetCountInCl(cmd, sql_tot, "SC", 2);
                CountSt = GetCountInCl(cmd, sql_tot, "ST", 2);
                CountObc = GetCountInCl(cmd, sql_tot, "OBC", 2);
                CountObcA = GetCountInCl(cmd, sql_tot, "OBC-A", 2);
                CountObcB = GetCountInCl(cmd, sql_tot, "OBC-B", 2);

                CountApl = GetCountInCl(cmd, sql_tot, "N", 3);
                CountBpl = GetCountInCl(cmd, sql_tot, "Y", 3);
            }
            catch (Exception sp)
            {
                System.Windows.MessageBox.Show("Problem in getting class profile info.: " + sp.Message);
            }
            finally
            {
                conn.Close();
            }

            var tpl = (CountTot, CountA, CountB, CountC, CountD, CountE, CountSecNull, CountM, CountF, CountGenNull, CountGen, CountSc, CountSt, CountObc, CountObcA, CountObcB, CountSocNull, CountApl, CountBpl);
            return tpl;
        }

        public (int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int) GetProfileOfStream(int StartYear, int EndYear, string cls)
        {
            int CountTot = 0;
            int CountArt = 0;
            int CountStreamNull = 0;
            int CountSci = 0;
            int CountArb = 0;
            int CountEco = 0;
            int CountEdu = 0;
            int CountGeo = 0;
            int CountHis = 0;
            int CountPhi = 0;
            int CountPol = 0;
            int CountSoc = 0;

            int CountPhy = 0;
            int CountChe = 0;
            int CountMth = 0;
            int CountBio = 0;

            string fixedSql = $"SELECT COUNT(*) FROM student_class WHERE startYear = {dv(StartYear)} AND endYear = {dv(EndYear)} AND class = {dv(cls)}";
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = fixedSql;
                Object r = cmd.ExecuteScalar();
                CountTot = (r != null) ? Convert.ToInt32(r) : 0;

                CountArt = GetCountStream(cmd, fixedSql, "ARTS", 0);
                CountSci = GetCountStream(cmd, fixedSql, "SCIENCE", 0);
                CountStreamNull = GetCountStream(cmd, fixedSql, string.Empty, 0);

                CountArb = GetCountStream(cmd, fixedSql, "ARABIC", 1);
                CountEco = GetCountStream(cmd, fixedSql, "ECONOMICS", 1);
                CountEdu = GetCountStream(cmd, fixedSql, "EDUCATION", 1);
                CountGeo = GetCountStream(cmd, fixedSql, "GEOGRAPHY", 1);
                CountHis = GetCountStream(cmd, fixedSql, "HISTORY", 1);
                CountPhi = GetCountStream(cmd, fixedSql, "PHILOSOPHY", 1);
                CountPol = GetCountStream(cmd, fixedSql, "POL. SC", 1);
                CountSoc = GetCountStream(cmd, fixedSql, "SOCIOLOGY", 1);
                CountPhy = GetCountStream(cmd, fixedSql, "PHYSICS", 1);
                CountChe = GetCountStream(cmd, fixedSql, "CHEMISTRY", 1);
                CountMth = GetCountStream(cmd, fixedSql, "MATHEMATICS", 1);
                CountBio = GetCountStream(cmd, fixedSql, "BIOLOGY", 1);
            }
            catch (Exception sp)
            {
                System.Windows.MessageBox.Show("Problem in getting stream info.: " + sp.Message);
            }
            finally
            {
                conn.Close();
            }

            var tpl = (CountTot, CountArt, CountSci, CountStreamNull, CountArb, CountEco, CountEdu, CountGeo, CountHis, CountPhi, CountPol, CountSoc, CountPhy, CountChe, CountMth, CountBio);
            return tpl;
        }

        private int GetCountInCl(MySqlCommand cmd, string sql, string mainParam, int type)
        {
            // type 0 for section
            // 1 for gender
            // 2 for social
            // 3 for bpl
            string sql_a = string.Empty;
            if (type == 0)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql_a = $"{sql} AND ( c.section IS {dv(mainParam)} OR c.section = '')";
                }
                else
                {
                    sql_a = $"{sql} AND c.section = {dv(mainParam)}";
                }
            }
            else if (type == 1)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql_a = $"{sql} AND ( b.sex IS {dv(mainParam)} OR b.sex = '')";
                }
                else
                {
                    sql_a = $"{sql} AND b.sex = {dv(mainParam)}";
                }
            }
            else if (type == 2)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql_a = $"{sql} AND ( b.socialCategory IS {dv(mainParam)} OR b.socialCategory = '')";
                }
                else
                {
                    sql_a = $"{sql} AND b.socialCategory = {dv(mainParam)}";
                }
            }
            else if (type == 3)
            {
                sql_a = $"{sql} AND b.isBPL = {dv(mainParam)}";
            }
            cmd.CommandText = sql_a;
            Object r = cmd.ExecuteScalar();
            return (r != null) ? Convert.ToInt32(r) : 0;
        }

        private int GetCount(MySqlCommand cmd, string fxSql, string mainParam, int type)
        {
            // type 0 for class
            // 1 for gender
            // 2 for social
            // 3 for bpl
            string sql = string.Empty;
            if (type == 0)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql = $"{fxSql} AND ( c.class IS {dv(mainParam)} OR c.class = '' )";
                }
                else
                {
                    sql = $"{fxSql} AND c.class = {dv(mainParam)}";
                }
            }
            else if (type == 1)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql = $"{fxSql} AND ( b.sex IS {dv(mainParam)} OR b.sex = '' )";
                }
                else
                {
                    sql = $"{fxSql} AND b.sex = {dv(mainParam)}";
                }
            }
            else if (type == 2)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql = $"{fxSql} AND ( b.socialCategory IS {dv(mainParam)} OR b.socialCategory = '' )";
                }
                else
                {
                    sql = $"{fxSql} AND b.socialCategory = {dv(mainParam)}";
                }
            }
            else if (type == 3)
            {
                sql = $"{fxSql} AND b.isBPL = {dv(mainParam)}";
            }
            cmd.CommandText = sql;
            Object r = cmd.ExecuteScalar();
            return (r != null) ? Convert.ToInt32(r) : 0;
        }

        private int GetCountStream(MySqlCommand cmd, string fxSql, string mainParam, int type)
        {
            // type = 0 stream
            // type = 1 subject
            string sql = string.Empty;
            if (type == 0)
            {
                if (string.IsNullOrEmpty(mainParam))
                {
                    sql = $"{fxSql} AND (stream IS {dv(mainParam)} OR stream = '')";
                }
                else
                {
                    sql = $"{fxSql} AND stream = {dv(mainParam)}";
                }
            }
            else if (type == 1)
            {
                sql = $"{fxSql} AND (hsElemSub1 = {dv(mainParam)} OR hsElemSub2 = {dv(mainParam)} OR hsElemSub3 = {dv(mainParam)} OR hsAdlSub = {dv(mainParam)})";
            }
            cmd.CommandText = sql;
            object r = cmd.ExecuteScalar();
            return (r != null) ? Convert.ToInt32(r) : 0;
        }
    }
}
