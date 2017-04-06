using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class CombSubPair
    {
        public CombSubPair()
        :base()
        {

        }
        public CombSubPair(string sb, string cmb)
        {
            this.SubName = sb;
            this.CombCode = cmb;
        }
        public string SubName { get; set; }
        public string CombCode { get; set; }
    }
}
