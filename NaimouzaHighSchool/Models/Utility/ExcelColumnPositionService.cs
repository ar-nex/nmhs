using System.Collections.Generic;
namespace NaimouzaHighSchool.Models.Utility
{
    public class ExcelColumnPositionService
    {
        public ExcelColumnPositionService()
        {
            ListCol = new List<ExcelColumnPosition>();
            ListCol.Add(new ExcelColumnPosition("Student Name"));
            ListCol.Add(new ExcelColumnPosition("Father Name"));
            ListCol.Add(new ExcelColumnPosition("Mother Name"));
            ListCol.Add(new ExcelColumnPosition("Guardian Name"));
            ListCol.Add(new ExcelColumnPosition("Guardian Relation"));
            ListCol.Add(new ExcelColumnPosition("Guardian Occupation"));
            ListCol.Add(new ExcelColumnPosition("Date of birth"));
            ListCol.Add(new ExcelColumnPosition("Sex"));
            ListCol.Add(new ExcelColumnPosition("Section"));
            ListCol.Add(new ExcelColumnPosition("Roll"));


            ListCol.Add(new ExcelColumnPosition("Present AddrLane1"));
            ListCol.Add(new ExcelColumnPosition("Present Vill. or Street"));
            ListCol.Add(new ExcelColumnPosition("Present PO"));
            ListCol.Add(new ExcelColumnPosition("Present PS"));
            ListCol.Add(new ExcelColumnPosition("Present Dist"));
            ListCol.Add(new ExcelColumnPosition("Present PIN"));


            ListCol.Add(new ExcelColumnPosition("Permanent AddrLane1"));
            ListCol.Add(new ExcelColumnPosition("Permanent Vill. or Street"));
            ListCol.Add(new ExcelColumnPosition("Permanent PO"));
            ListCol.Add(new ExcelColumnPosition("Permanent PS"));
            ListCol.Add(new ExcelColumnPosition("Permanent Dist"));
            ListCol.Add(new ExcelColumnPosition("Permanent PIN"));

            ListCol.Add(new ExcelColumnPosition("Mobile"));
            ListCol.Add(new ExcelColumnPosition("Guardian Mobile"));
            ListCol.Add(new ExcelColumnPosition("Email"));
            ListCol.Add(new ExcelColumnPosition("Religion"));
            ListCol.Add(new ExcelColumnPosition("Social Category"));
            ListCol.Add(new ExcelColumnPosition("Sub Cast"));
            ListCol.Add(new ExcelColumnPosition("Is PH"));
            ListCol.Add(new ExcelColumnPosition("PH type"));
            ListCol.Add(new ExcelColumnPosition("Is BPL"));
            ListCol.Add(new ExcelColumnPosition("BPL Number"));
            ListCol.Add(new ExcelColumnPosition("Aadhar"));
            ListCol.Add(new ExcelColumnPosition("Guardian Aadhar"));
            ListCol.Add(new ExcelColumnPosition("Guardian Epic"));
            ListCol.Add(new ExcelColumnPosition("MP Registration No."));
            ListCol.Add(new ExcelColumnPosition("Blood Group"));

            ListCol.Add(new ExcelColumnPosition("Board No"));
            ListCol.Add(new ExcelColumnPosition("Board Roll"));
            ListCol.Add(new ExcelColumnPosition("Council No"));
            ListCol.Add(new ExcelColumnPosition("Council Roll"));

            ListCol.Add(new ExcelColumnPosition("Admission No."));
            ListCol.Add(new ExcelColumnPosition("Admitted Class"));
            ListCol.Add(new ExcelColumnPosition("Date of Admission"));
            ListCol.Add(new ExcelColumnPosition("Last School"));
            ListCol.Add(new ExcelColumnPosition("Date of Leaving"));
            ListCol.Add(new ExcelColumnPosition("TC detail"));

            ListCol.Add(new ExcelColumnPosition("Stream"));
            ListCol.Add(new ExcelColumnPosition("HS Sub1"));
            ListCol.Add(new ExcelColumnPosition("HS Sub2"));
            ListCol.Add(new ExcelColumnPosition("HS Sub3"));
            ListCol.Add(new ExcelColumnPosition("HS Adl Sub"));
            ListCol.Add(new ExcelColumnPosition("Third Language"));

            ListCol.Add(new ExcelColumnPosition("Bank Acc. No."));
            ListCol.Add(new ExcelColumnPosition("Bank Name"));
            ListCol.Add(new ExcelColumnPosition("Branch Name"));
            ListCol.Add(new ExcelColumnPosition("Branch IFSC"));
            ListCol.Add(new ExcelColumnPosition("MICR code"));
        }

        public List<ExcelColumnPosition> ListCol { get; set; }
        public List<ExcelColumnPosition> getListCol()
        {
            return ListCol;
        }

        public List<string> GetColListForExport()
        {
            List<string> cl = new List<string>();
            cl.Add("Student Name");
            cl.Add("Father Name");
            cl.Add("Mother Name");
            cl.Add("Guardian Name");

            cl.Add("Guardian Relation");
            cl.Add("Guardian Occupation");
            cl.Add("Date of birth");
            cl.Add("Sex");
            cl.Add("Roll");
            cl.Add("SubjectComboId");
            cl.Add("Present Address");
            // added later
            cl.Add("Present AddrLane1");
            cl.Add("Present Vill. or Street");
            cl.Add("Present PO");
            cl.Add("Present PS");
            cl.Add("Present Dist");
            cl.Add("Present PIN");
            // end added later
            cl.Add("Permanent Address");

            //added later
            // added later
            cl.Add("Permanent AddrLane1");
            cl.Add("Permanent Vill. or Street");
            cl.Add("Permanent PO");
            cl.Add("Permanent PS");
            cl.Add("Permanent Dist");
            cl.Add("Permanent PIN");
            // end added later
            // end added later

            cl.Add("Mobile");
            cl.Add("Guardian Mobile");
            cl.Add("Email");
            cl.Add("Religion");
            cl.Add("Social Category");

            cl.Add("Sub Cast");
            cl.Add("Is PH");
            cl.Add("PH type");
            cl.Add("Is BPL");
            cl.Add("BPL Number");

            cl.Add("Aadhar");
            cl.Add("Guardian Aadhar");
            cl.Add("Guardian Epic");
            cl.Add("Blood Group");
            cl.Add("Board No");

            cl.Add("Board Roll");
            cl.Add("Council No.");
            cl.Add("Council Roll");
            cl.Add("Admission No.");
            cl.Add("Admitted Class");

            cl.Add("Date of Admission");
            cl.Add("Last School");
            cl.Add("Date of Leaving");
            cl.Add("TC detail");
            cl.Add("Bank Acc. No");

            cl.Add("Bank Name");
            cl.Add("Branch Name");
            cl.Add("Branch IFSC");
            cl.Add("MICR code");


            return cl;
        }
    }
}
