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
                        string sql_m = $"SELECT fullMark, markObtained, id FROM marksheet " +
                            $" WHERE startYear = '{QueryMarkObject.SessionStartYear.ToString()}' AND endYear = '{QueryMarkObject.SessionEndYear.ToString()}'" +
                            $" AND examPhase = '{QueryMarkObject.ExamPhase}' AND subject = '{item.Subject}' AND student_basic_id = '{item.StudentId}'";
                        cmd.CommandText = sql_m;
                        using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                        {
                            if (rdr2.Read())
                            {
                                item.FullMark = Convert.ToInt32(rdr2[0]);
                                item.ObtainedMark = Convert.ToInt32(rdr2[1]);
                                item.RecordIdInTable = rdr2[2].ToString();
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
                        string sql_m = $"SELECT fullMark, markObtained, id FROM marksheet " +
                            $" WHERE startYear = '{QueryMarkObject.SessionStartYear.ToString()}' AND endYear = '{QueryMarkObject.SessionEndYear.ToString()}'" +
                            $" AND examPhase = '{QueryMarkObject.ExamPhase}' AND examType = '{QueryMarkObject.ExamType}' AND subject = '{QueryMarkObject.Subject}' AND student_basic_id = '{QueryMarkObject.StudentId}'";
                        cmd.CommandText = sql_m;
                        using (MySqlDataReader rdr2 = cmd.ExecuteReader())
                        {
                            if (rdr2.Read())
                            {
                                item.FullMark = Convert.ToInt32(rdr2[0]);
                                item.ObtainedMark = Convert.ToInt32(rdr2[1]);
                                item.RecordIdInTable = rdr2[2].ToString();
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

        public List<string> InsertMarkData(List<ExamMarks> emList)
        {
            List<string> NotInsertedRollList = new List<string>();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                foreach (var item in emList)
                {
                    string sql = string.Empty;
                    if (item.AlreadyExist)
                    {
                        if (item.IsAbsent)
                        {
                            sql = $"UPDATE marksheet SET markObtained = 0, present = 'N', teacher_id = '{item.TeacherId}' WHERE id = '{item.RecordIdInTable}'";
                        }
                        else
                        {
                            sql = $"UPDATE marksheet SET markObtained = '{item.ObtainedMark.ToString()}', fullMark = '{item.FullMark.ToString()}' WHERE id = '{item.RecordIdInTable}'";
                        }
                    }
                    else if (item.IsAbsent)
                    {
                        if (item.StudentClass == "V" || item.StudentClass == "VI" || item.StudentClass == "VII" | item.StudentClass == "VIII")
                        {
                            sql = $"INSERT INTO marksheet (startYear, endYear, examPhase, fullMark, markObtained, subject, subGroup, present, student_basic_id, teacher_id) " +
                               $" VALUES ('{item.SessionStartYear}', '{item.SessionEndYear}', '{item.ExamPhase}', '{item.FullMark}', '{item.ObtainedMark}', '{item.Subject}', '{item.SubjectGroup}', 'N', '{item.StudentId}', '{item.TeacherId}')";
                        }
                        else
                        {
                            sql = $"INSERT INTO marksheet (startYear, endYear, examPhase, examType, fullMark, markObtained, subject, subGroup, present, student_basic_id, teacher_id) VALUES " +
                               $" '{item.SessionStartYear}', '{item.SessionEndYear}', '{item.ExamPhase}', '{item.ExamType}', '{item.FullMark}', '{item.ObtainedMark}', '{item.Subject}', '{item.SubjectGroup}', 'N', '{item.StudentId}', '{item.TeacherId}'";
                        }
                    }
                    else
                    {
                        if (item.StudentClass == "V" || item.StudentClass == "VI" || item.StudentClass == "VII" | item.StudentClass == "VIII")
                        {
                            sql = $"INSERT INTO marksheet (startYear, endYear, examPhase, fullMark, markObtained, subject, subGroup, present, student_basic_id, teacher_id) " +
                               $" VALUES ('{item.SessionStartYear}', '{item.SessionEndYear}', '{item.ExamPhase}', '{item.FullMark}', '{item.ObtainedMark}', '{item.Subject}', '{item.SubjectGroup}', 'Y', '{item.StudentId}', '{item.TeacherId}')";
                        }
                        else
                        {
                            sql = $"INSERT INTO marksheet (startYear, endYear, examPhase, examType, fullMark, markObtained, subject, subGroup, present, student_basic_id, teacher_id) VALUES " +
                                $" '{item.SessionStartYear}', '{item.SessionEndYear}', '{item.ExamPhase}', '{item.ExamType}', '{item.FullMark}', '{item.ObtainedMark}', '{item.Subject}', '{item.SubjectGroup}', 'Y', '{item.StudentId}', '{item.TeacherId}'";
                        }
                    }

                    if (!string.IsNullOrEmpty(sql))
                    {
                        cmd.CommandText = sql;
                        int count = cmd.ExecuteNonQuery();
                        if (count == 0)
                        {
                            NotInsertedRollList.Add(item.StudentRoll.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Sorry! There is problems in saving marksheet data. : "+ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return NotInsertedRollList;
        }


    }
}
