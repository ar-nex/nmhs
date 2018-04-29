using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public static class OutputFormatter
    {
        public static string GetText(string inp, IdNumberType idtype)
        {
            if (string.IsNullOrEmpty(inp))
            {
                return string.Empty;
            }
            else
            {
                string opStr = string.Empty;
                StringBuilder sbuilder = new StringBuilder(inp);
                switch (idtype)
                {
                    case IdNumberType.Aadhaar:
                        if (inp.Length == 12)
                        {
                            sbuilder.Insert(4, "-");
                            sbuilder.Insert(9, "-");
                            opStr = sbuilder.ToString();
                        }
                        else
                        {
                            opStr = inp;
                        }
                        break;
                    case IdNumberType.Mobile:
                        if (inp.Length == 10)
                        {
                            sbuilder.Insert(3, "-");
                            sbuilder.Insert(7, "-");
                            opStr = sbuilder.ToString();
                        }
                        else if (inp.Length == 11)
                        {
                            if (inp[0] == '0')
                            {
                                sbuilder.Remove(0, 1);
                                sbuilder.Insert(3, "-");
                                sbuilder.Insert(7, "-");
                                opStr = sbuilder.ToString();
                            }
                            else
                            {
                                opStr = inp;
                            }
                        }
                        else if (inp.Length == 12)
                        {
                            if (inp[0] == '9' && inp[1] == '1')
                            {
                                sbuilder.Remove(0, 2);
                                sbuilder.Insert(3, "-");
                                sbuilder.Insert(7, "-");
                                opStr = sbuilder.ToString();
                            }
                            else
                            {
                                opStr = inp;
                            }
                        }
                        else if (inp.Length == 13)
                        {
                            if (inp[0] == '+' && inp[1] == '9' && inp[2] == '1')
                            {
                                sbuilder.Remove(0, 3);
                                sbuilder.Insert(3, "-");
                                sbuilder.Insert(7, "-");
                                opStr = sbuilder.ToString();
                            }
                            else
                            {
                                opStr = inp;
                            }
                        }
                        else
                        {
                            opStr = inp;
                        }
                        break;
                    case IdNumberType.StudentId:
                        if (inp.Length == 10)
                        {
                            sbuilder.Insert(4, "-");
                            sbuilder.Insert(7, "-");
                            opStr = sbuilder.ToString();
                        }
                        else
                        {
                            opStr = inp;
                        }
                        break;
                    default:
                        break;
                }
                return opStr;
            }
        }
    }
}
