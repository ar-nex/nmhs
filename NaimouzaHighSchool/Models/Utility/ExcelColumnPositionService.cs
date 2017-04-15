﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NaimouzaHighSchool.Models.Utility
{
    public class ExcelColumnPositionService
    {
        public ExcelColumnPositionService()
        {
            this.ListCol = new List<ExcelColumnPosition>();
            this.ListCol.Add(new ExcelColumnPosition("Student Name"));
            this.ListCol.Add(new ExcelColumnPosition("Father Name"));
            this.ListCol.Add(new ExcelColumnPosition("Mother Name"));
            this.ListCol.Add(new ExcelColumnPosition("Guardian Name"));
            this.ListCol.Add(new ExcelColumnPosition("Guardian Relation"));
            this.ListCol.Add(new ExcelColumnPosition("Guardian Occupation"));
            this.ListCol.Add(new ExcelColumnPosition("Date of birth"));
            this.ListCol.Add(new ExcelColumnPosition("Sex"));
            this.ListCol.Add(new ExcelColumnPosition("Roll"));
            this.ListCol.Add(new ExcelColumnPosition("SubjectComboId"));
            this.ListCol.Add(new ExcelColumnPosition("Present Address"));
            this.ListCol.Add(new ExcelColumnPosition("Permanent Address"));
            this.ListCol.Add(new ExcelColumnPosition("Mobile"));
            this.ListCol.Add(new ExcelColumnPosition("Guardian Mobile"));
            this.ListCol.Add(new ExcelColumnPosition("Email"));
            this.ListCol.Add(new ExcelColumnPosition("Religion"));
            this.ListCol.Add(new ExcelColumnPosition("Social Category"));
            this.ListCol.Add(new ExcelColumnPosition("Sub Cast"));
            this.ListCol.Add(new ExcelColumnPosition("Is PH"));
            this.ListCol.Add(new ExcelColumnPosition("PH type"));
            this.ListCol.Add(new ExcelColumnPosition("Is BPL"));
            this.ListCol.Add(new ExcelColumnPosition("BPL Number"));
            this.ListCol.Add(new ExcelColumnPosition("Aadhar"));
            this.ListCol.Add(new ExcelColumnPosition("Guardian Aadhar"));
            this.ListCol.Add(new ExcelColumnPosition("Guardian Epic"));
            this.ListCol.Add(new ExcelColumnPosition("Blood Group"));

            this.ListCol.Add(new ExcelColumnPosition("Board No"));
            this.ListCol.Add(new ExcelColumnPosition("Board Roll"));
            this.ListCol.Add(new ExcelColumnPosition("Council No"));
            this.ListCol.Add(new ExcelColumnPosition("Council Roll"));

            this.ListCol.Add(new ExcelColumnPosition("Admission No."));
            this.ListCol.Add(new ExcelColumnPosition("Admitted Class"));
            this.ListCol.Add(new ExcelColumnPosition("Date of Admission"));
            this.ListCol.Add(new ExcelColumnPosition("Last School"));
            this.ListCol.Add(new ExcelColumnPosition("Date of Leaving"));
            this.ListCol.Add(new ExcelColumnPosition("TC detail"));

            this.ListCol.Add(new ExcelColumnPosition("Bank Acc. No."));
            this.ListCol.Add(new ExcelColumnPosition("Bank Name"));
            this.ListCol.Add(new ExcelColumnPosition("Branch Name"));
            this.ListCol.Add(new ExcelColumnPosition("Branch IFSC"));
            this.ListCol.Add(new ExcelColumnPosition("MICR code"));
        }

        public List<ExcelColumnPosition> ListCol { get; set; }
        public List<ExcelColumnPosition> getListCol()
        {
            return this.ListCol;
        }
    }
}