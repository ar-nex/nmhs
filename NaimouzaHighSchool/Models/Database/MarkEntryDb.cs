using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models.Database
{
    public class MarkEntryDb : BaseDb
    {
        public MarkEntryDb()
            : base()
        {

        }

        public ObservableCollection<Teacher> GetTeacherList()
        {
            ObservableCollection<Teacher> tlist = new ObservableCollection<Teacher>();
            try
            {
                conn.Open();
                string sql = "SELECT id, name, subject, password FROM teacher WHERE 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Teacher t = new Teacher
                        {
                            Id = rdr[0].ToString(),
                            Name = rdr[1].ToString(),
                            Subject = rdr[2].ToString(),
                            PasswordHash = rdr[3].ToString()
                        };
                        tlist.Add(t);
                    }
                }
            }
            catch (Exception tl)
            {
                System.Windows.MessageBox.Show("Problem in getting teacher list. : " + tl.Message);
            }
            finally
            {
                conn.Close();
            }

            return tlist;
        }

        public ObservableCollection<ExamMarks> GetExamMarkData(ExamMarks QueryMarkObject)
        {
            ObservableCollection<ExamMarks> emarkList = new ObservableCollection<ExamMarks>();
            try
            {
                conn.Open();
                string sql = $"SELECT c.roll, c.student_basic_id, b.name FROM student_class c INNER JOIN student_basic b ON b.id = c.student_basic_id WHERE c.startYear = '{QueryMarkObject.SessionStartYear.ToString()}' AND c.endYear = '{QueryMarkObject.SessionEndYear.ToString()}' AND c.class = '{QueryMarkObject.StudentClass}' AND c.section = '{QueryMarkObject.StudentSection}'";
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                using (MySqlDataReader rdr1 = cmd.ExecuteReader())
                {
                    while (rdr1.Read())
                    {
                        ExamMarks em = new ExamMarks();
                        em.StudentName = rdr1[2].ToString();
                        em.SessionStartYear = QueryMarkObject.SessionStartYear;
                        em.SessionEndYear = QueryMarkObject.SessionEndYear;
                        em.StudentClass = QueryMarkObject.StudentClass;
                        em.StudentSection = QueryMarkObject.StudentSection;
                        em.StudentRoll = Convert.ToInt32(rdr1[0]);
                        em.StudentId = rdr1[1].ToString();

                        em.ExamPhase = QueryMarkObject.ExamPhase;
                        em.Subject = QueryMarkObject.Subject;
                        em.SubjectGroup = QueryMarkObject.SubjectGroup;

                        emarkList.Add(em);
                    }
                }

                string cls = QueryMarkObject.StudentClass;
                if (cls == "V" || cls=="VI" || cls=="VII" | cls=="VIII")
                {
                    foreach (ExamMarks item in emarkList)
                    {
                        string sql_m = $"SELECT fullMark, markObtained FROM marksheet " +
                            $" WHERE startYear = '{QueryMarkObject.SessionStartYear.ToString()}' AND endYear = '{QueryMarkObject.SessionEndYear.ToString()}'" +
                            $" AND examPhase = '{QueryMarkObject.ExamPhase}' AND subject = '{QueryMarkObject.Subject}' AND student_basic_id = '{QueryMarkObject.StudentId}'";
                        cmd.CommandText = sql_m;
                        using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                        {
                            if (rdr2.Read())
                            {
                                item.FullMark = Convert.ToInt32(rdr2[0]);
                                item.ObtainedMark = Convert.ToInt32(rdr2[1]);
                                item.AlreadyExist = true;
                            }
                            else
                            {
                                item.AlreadyExist = false;
                            }
                        }
                    }
                }
                else
                {
                    foreach (ExamMarks item in emarkList)
                    {
                        string sql_m = $"SELECT fullMark, markObtained FROM marksheet " +
                            $" WHERE startYear = '{QueryMarkObject.SessionStartYear.ToString()}' AND endYear = '{QueryMarkObject.SessionEndYear.ToString()}'" +
                            $" AND examPhase = '{QueryMarkObject.ExamPhase}' AND examType = '{QueryMarkObject.ExamType}' AND subject = '{QueryMarkObject.Subject}' AND student_basic_id = '{QueryMarkObject.StudentId}'";
                        cmd.CommandText = sql_m;
                        using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                        {
                            if (rdr2.Read())
                            {
                                item.FullMark = Convert.ToInt32(rdr2[0]);
                                item.ObtainedMark = Convert.ToInt32(rdr2[1]);
                                item.AlreadyExist = true;
                                item.ExamType = QueryMarkObject.ExamType;
                            }
                            else
                            {
                                item.AlreadyExist = false;
                                item.ExamType = QueryMarkObject.ExamType;
                            }
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Problem in getting marklist. : "+ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return emarkList;
        }


    }
}
