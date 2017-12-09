using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class SubjectUtility
    {
        public SubjectUtility()
        {
            InitSubsHSCommon();

        }

        private Dictionary<string, string> SubsHSCommon = new Dictionary<string, string>();
        private Dictionary<string, string> SubsHSArtsOnly = new Dictionary<string, string>();
        private Dictionary<string, string> SubsHSScienceOnly = new Dictionary<string, string>();
        private Dictionary<string, string> SubsSE = new Dictionary<string, string>();
        private Dictionary<string, string> SubsHP = new Dictionary<string, string>();

        private void InitSubsHSCommon()
        {
            SubsHSCommon.Add("BNGP", "BENGALI (Gr. -A)");
            SubsHSCommon.Add("BNGB", "BENGALI (Gr. -B)");
            SubsHSCommon.Add("ENGA", "ENGLISH (Gr. -A)");
            SubsHSCommon.Add("BNGB", "ENGLISH (Gr. -A)");
            SubsHSCommon.Add("GERG", "GEOGRAPHY");
        }

        private void InitSubsHSArts()
        {
            SubsHSArtsOnly.Add("POLS", "POLITICAL SCIENCE");
            SubsHSArtsOnly.Add("HIST", "HISTORY");
            SubsHSArtsOnly.Add("POLS", "POLITICAL SCIENCE");

        }
    }
}
