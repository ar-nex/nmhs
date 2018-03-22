using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.ViewModels
{
    public class StudentClassBaseViewModel : BaseViewModel
    {
        public StudentClassBaseViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private int _startYear;
        public int StartYear
        {
            get { return _startYear; }
            set
            {
                _startYear = (value < 2017 || value > DateTime.Now.Year +2) ? DateTime.Now.Year : value;
                OnPropertyChanged("StartYear");
            }
        }

        private int _endYear;
        public int EndYear
        {
            get { return _endYear; }
            set
            {
                _endYear = (value < 2017 || value > DateTime.Now.Year + 2) ? DateTime.Now.Year : value;
                OnPropertyChanged("EndYear");
            }
        }

        private string[] _schoolClass;
        public string[] SchoolClass
        {
            get { return _schoolClass; }
            set { _schoolClass = value; OnPropertyChanged("SchoolClass"); }
        }

        private int _schoolClassIndex;
        public int SchoolClassIndex
        {
            get { return _schoolClassIndex; }
            set
            {
                _schoolClassIndex = (value > -1 && value < SchoolClass.Length) ? value : -1;
                OnPropertyChanged("SchoolClassIndex");
            }
        }

        private string[] _schoolSection;
        public string[] SchoolSection
        {
            get { return _schoolSection; }
            set { _schoolSection = value; OnPropertyChanged("SchoolSection"); }
        }

        private int _schoolSectionIndex;
        public int SchoolSectionIndex
        {
            get { return _schoolSectionIndex; }
            set
            {
                _schoolSectionIndex = (value > -1 && value < SchoolSection.Length) ? value : -1;
                OnPropertyChanged("SchoolSectionIndex");
            }
        }

        private void StartUpInitializer()
        {
            SchoolClass = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            SchoolSection = new string[] { "A", "B", "C", "D", "E"};
            SchoolClassIndex = SchoolSectionIndex = -1;
            StartYear = EndYear = DateTime.Now.Year;
        }
    }
}
