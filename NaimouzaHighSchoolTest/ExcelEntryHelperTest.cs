using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaimouzaHighSchool;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Helpers;
using System.Collections.Generic;

namespace NaimouzaHighSchoolTest
{
    [TestClass]
    public class ExcelEntryHelperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ExcelEntryHelper eh = new ExcelEntryHelper();
            List<ExcelColumnPosition> listEx = new List<ExcelColumnPosition>();
            listEx.Add(new ExcelColumnPosition("HName", "A"));
            listEx.Add(new ExcelColumnPosition("GName", "B"));
            listEx.Add(new ExcelColumnPosition("FName"));
            listEx.Add(new ExcelColumnPosition("EName"));
            listEx.Add(new ExcelColumnPosition("DName", "E"));
            listEx.Add(new ExcelColumnPosition("CName", "F"));
            bool r = eh.isExcelColPositionUnique(listEx);
            Assert.AreEqual<bool>(true, r, "Logic failed.");
        }
    }
}
