using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class MarkEntryViewModel : BaseViewModel
    {
        public MarkEntryViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private int _startYear;
        public int StartYear
        {
            get => _startYear;
            set
            {
                int cYear = DateTime.Today.Year;
                if (value < cYear - 2 || value > cYear)
                {
                    _startYear = 0;
                }
                else
                {
                    _startYear = value;
                }
                OnPropertyChanged("StartYear");
            }
        }

        private int _endYear;
        public int EndYear
        {
            get => _endYear;
            set
            {
                int cYear = DateTime.Today.Year;
                if (value < cYear - 2 || value > cYear + 2)
                {
                    _endYear = 0;
                }
                else
                {
                    _endYear = value;
                }
                OnPropertyChanged("EndYear");
            }
        }

        private string [] _cls;
        public string [] Cls
        {
            get => _cls;
            set
            {
                _cls = value;
                OnPropertyChanged("Cls");
            }
        }

        private int _clsIndex;
        public int ClsIndex
        {
            get => _clsIndex;
            set
            {
                if (value < -1 || value > Cls.Length)
                {
                    _clsIndex = -1;
                }
                else
                {
                    _clsIndex = value;
                }
                OnPropertyChanged("ClsIndex");
                OnClassChanged();
                SubsGroup = GetSubsGroup();
            }
        }

        private string [] _section;
        public string [] Section
        {
            get => _section;
            set
            {
                _section = value;
                OnPropertyChanged("Section");
            }
        }

        private int _sectionIndex;
        public int SectionIndex
        {
            get => _sectionIndex;
            set
            {
                if (value < -1 || value > Section.Length)
                {
                    _sectionIndex = -1;
                }
                else
                {
                    _sectionIndex = value;
                }
                OnPropertyChanged("SectionIndex");
            }
        }

        private string[] _examUnit;
        public string[] ExamUnit
        {
            get => _examUnit;
            set
            {
                _examUnit = value;
                OnPropertyChanged("ExamUnit");
            }
        }

        private int _examUnitIndex;
        public int ExamUnitIndex
        {
            get => _examUnitIndex;
            set
            {
                if (value < -1 || value > ExamUnit.Length)
                {
                    _examUnitIndex = -1;
                }
                else
                {
                    _examUnitIndex = value;
                }
                OnPropertyChanged("ExamUnitIndex");
            }
        }

        private Visibility _typeVisibility;
        public Visibility TypeVisibility
        {
            get => _typeVisibility;
            set
            {
                _typeVisibility = value;
                OnPropertyChanged("TypeVisibility");
            }
        }

        private string[] _exmType;
        public string[] ExmType
        {
            get => _exmType;
            set
            {
                _exmType = value;
                OnPropertyChanged("ExmType");
            }
        }

        private int _exmTypeIndex;
        public int ExmTypeIndex
        {
            get => _exmTypeIndex;
            set
            {
                if (value < -1 || value > ExmType.Length)
                {
                    _exmTypeIndex = -1;
                }
                else
                {
                    _exmTypeIndex = value;
                }
                OnPropertyChanged("ExmTypeIndex");
            }
        }

        private string _subsGroup;
        public string SubsGroup
        {
            get => _subsGroup;
            set
            {
                _subsGroup = value;
                OnPropertyChanged("SubsGroup");
            }
        }

        private ObservableCollection<string> _subject;
        public ObservableCollection<string> Subject
        {
            get => _subject;
            set
            {
                _subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private int _subjectIndex;
        public int SubjectIndex
        {
            get => _subjectIndex;
            set
            {
                if (value < -1 || value > Subject.Count)
                {
                    _subjectIndex = -1;
                }
                else
                {
                    _subjectIndex = value;
                }
                OnPropertyChanged("SubjectIndex");
                SubsGroup = GetSubsGroup();
            }
        }

        private ObservableCollection<string> _upperPrimarySubs = new ObservableCollection<string>();
        private ObservableCollection<string> _secondarySubs = new ObservableCollection<string>();

        private ObservableCollection<Teacher> _teacherList;
        public ObservableCollection<Teacher> TeacherList
        {
            get => _teacherList;
            set
            {
                _teacherList = value;
                OnPropertyChanged("TeacherList");
            }
        }

        private int _teacherListIndex;
        public int TeacherListIndex
        {
            get => _teacherListIndex;
            set
            {
                if (value < -1 || value > TeacherList.Count)
                {
                    _teacherListIndex = -1;
                }
                else
                {
                    _teacherListIndex = value;
                }
                OnPropertyChanged("TeacherListIndex");
            }
        }

        public RelayCommand SaveCommand { get; set; }

        private void StartUpInitializer()
        {
            MarkEntryDb db = new MarkEntryDb();

            StartYear = DateTime.Today.Year;
            EndYear = DateTime.Today.Year;
            Cls = new string[] {"V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            Section = new string[] { "A", "B", "C", "D", "E" };
            ExamUnit = new string[] { "1st", "2nd", "3rd" };
            ExmType = new string[] { "Project", "Written"};
            Subject = new ObservableCollection<string>();
            TeacherList = new ObservableCollection<Teacher>();
            TeacherList = db.GetTeacherList();
            SubsInitialize();
            ExamUnitIndex = -1;
            ClsIndex = -1;
            SectionIndex = -1;
            ExmTypeIndex = -1;
            SubjectIndex = -1;
            TeacherListIndex = -1;
            TypeVisibility = Visibility.Collapsed;
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void Save()
        {
            
        }

        private bool CanSave()
        {
            return true;
        }

        private void OnClassChanged()
        {
            Subject.Clear();
            if (ClsIndex == -1)
            {

            }
            else
            {
                string clls = Cls[ClsIndex];
                if (clls == "V" || clls == "VI" || clls == "VII" || clls == "VIII")
                {
                    TypeVisibility = Visibility.Collapsed;
                    Subject = _upperPrimarySubs;
                }
                else if (clls == "IX" || clls == "X")
                {
                    TypeVisibility = Visibility.Visible;
                    Subject = _secondarySubs;
                }
            }
        }

        private void SubsInitialize()
        {
            _upperPrimarySubs.Add("1st Language");
            _upperPrimarySubs.Add("2nd Language");
            _upperPrimarySubs.Add("Phy. & Art Education");
            _upperPrimarySubs.Add("Mathematics");
            _upperPrimarySubs.Add("Envr. Science");

            _upperPrimarySubs.Add("Question & Experimentation");
            _upperPrimarySubs.Add("Participation");
            _upperPrimarySubs.Add("Empathy & Co-Operation");
            _upperPrimarySubs.Add("Creative Expansion");
            _upperPrimarySubs.Add("Interpretation & Application");


            _secondarySubs.Add("Bengali");
            _secondarySubs.Add("English");
            _secondarySubs.Add("Mathematics");
            _secondarySubs.Add("Physical Science");
            _secondarySubs.Add("Life Science");
            _secondarySubs.Add("History");
            _secondarySubs.Add("Geography");
            _secondarySubs.Add("Work & Physical Education");

        }

        private string GetSubsGroup()
        {
            if (ClsIndex == -1 || SubjectIndex == -1)
            {
                return string.Empty;
            }
            else
            {
                string cls = Cls[ClsIndex];
                string sb = Subject[SubjectIndex];
                if (cls == "V" || cls=="VI" || cls=="VII" || cls=="VIII")
                {
                    string[] sums = new string[] { "1st Language", "2nd Language", "Phy. & Art Education", "Mathematics", "Envr. Science" };
                    if (Array.IndexOf(sums, sb) != -1)
                    {
                        return "Summative";
                    }
                    else
                    {
                        return "Formative";
                    }
                }
                else if (cls == "IX" || cls == "X")
                {
                    if (sb == "Bengali" || sb == "English")
                    {
                        return "Language";
                    }
                    else if (sb == "Mathematics" || sb == "Physical Science" || sb == "Life Science")
                    {
                        return "Science";
                    }
                    else if (sb == "History" || sb == "Geography")
                    {
                        return "India and People";
                    }
                    else
                    {
                        return "Optional";
                    }
                   
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
