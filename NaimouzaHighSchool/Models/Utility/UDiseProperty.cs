using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class UDiseProperty
    {
        public UDiseProperty(string nm, StudentProperty sp)
        {
            PropertyName = nm;
            PropEnum = sp;
        }
        public string PropertyName { get; set; }
        public StudentProperty PropEnum { get; set; }
    }
}
