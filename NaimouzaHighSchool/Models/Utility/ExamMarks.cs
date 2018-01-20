﻿namespace NaimouzaHighSchool.Models.Utility
{
    public class ExamMarks : BaseModel
    {
        public ExamMarks()
            : base()
        {

        }

        private string _studentId;
        public string StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
                OnPropertyChanged("StudentId");
            }
        }

        private string _studentName;
        public string StudentName
        {
            get => _studentName;
            set
            {
                _studentName = value;
                OnPropertyChanged("StudentName");
            }
        }

        private string _studentClass;
        public string StudentClass
        {
            get => _studentClass;
            set
            {
                _studentClass = value;
                OnPropertyChanged("StudentClass");
            }
        }

        private string _studentSection;
        public string StudentSection
        {
            get => _studentSection;
            set
            {
                _studentSection = value;
                OnPropertyChanged("StudentSection");
            }
        }

        private int _studentRoll;
        public int StudentRoll
        {
            get => _studentRoll;
            set
            {
                _studentRoll = value;
                OnPropertyChanged("StudentRoll");
            }
        }

        private int _sessionStartYear;
        public int SessionStartYear
        {
            get => _sessionStartYear;
            set
            {
                _sessionStartYear = value;
                OnPropertyChanged("SessionStartYear");
            }
        }

        private int _sessionEndYear;
        public int SessionEndYear
        {
            get => _sessionEndYear;
            set
            {
                _sessionEndYear = value;
                OnPropertyChanged("SessionEndYear");
            }
        }

        private string _examPhase;
        public string ExamPhase
        {
            get => _examPhase;
            set
            {
                _examPhase = value;
                OnPropertyChanged("ExamPhase");
            }
        }

        private string _examType;
        public string ExamType
        {
            get => _examType;
            set
            {
                _examType = value;
                OnPropertyChanged("ExamType");
            }
        }

        private int _fullMark;
        public int FullMark
        {
            get => _fullMark;
            set
            {
                _fullMark = value;
                OnPropertyChanged("FullMark");
            }
        }

        private float _obtainedMark;
        public float ObtainedMark
        {
            get => _obtainedMark;
            set
            {
                _obtainedMark = value;
                OnPropertyChanged("ObtainedMark");
            }
        }

        private string _subject;
        public string Subject
        {
            get => _subject;
            set
            {
                _subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private string _subjectGroup;
        public string SubjectGroup
        {
            get => _subjectGroup;
            set
            {
                _subjectGroup = value;
                OnPropertyChanged("SubjectGroup");
            }
        }

        private bool _isAbsent;
        public bool IsAbsent
        {
            get => _isAbsent;
            set
            {
                _isAbsent = value;
                OnPropertyChanged("IsAbsent");
            }
        }

        private bool _alreadyExist;
        public bool AlreadyExist
        {
            get => _alreadyExist;
            set
            {
                _alreadyExist = value;
                OnPropertyChanged("AlreadyExist");
            }
        }
    }
}
