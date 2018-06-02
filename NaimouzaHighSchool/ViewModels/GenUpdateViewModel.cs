using System;
using System.Text.RegularExpressions;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models;

namespace NaimouzaHighSchool.ViewModels
{
    public class GenUpdateViewModel : BaseViewModel
    {
        public GenUpdateViewModel()
            : base()
        {
            StartUpInitializer();
        }

        public static Student EditableStudent { get; set; }

        private string _esName;
        public string EsName
        {
            get { return _esName; }
            set
            {
                _esName = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("EsName");
            }
        }

        private string [] _esSchoolClass;
        public string [] EsSchoolClass
        {
            get { return _esSchoolClass; }
            set { _esSchoolClass = value; OnPropertyChanged("EsSchoolClass"); }
        }

        private string _esClass;
        public string EsClass
        {
            get { return _esClass; }
            set
            {
                if (value != null)
                {
                    int clsIndex = Array.IndexOf(GlobalVar.SchoolClasses, value.ToUpper());
                    if (clsIndex > -1)
                    {
                        _esClass = value.ToUpper();
                    }
                }
                OnPropertyChanged("EsClass");
            }
        }

        private string[]  _esSection;
        public string[]  EsSection
        {
            get { return _esSection; }
            set
            {
                _esSection = value;
                OnPropertyChanged("EsSection");
            }
        }

        private int _esSectionIndex;
        public int EsSectionIndex
        {
            get { return _esSectionIndex; }
            set { _esSectionIndex = value; OnPropertyChanged("EsSectionIndex"); }
        }

        private int _esRoll;
        public int EsRoll
        {
            get { return _esRoll; }
            set { _esRoll = value; OnPropertyChanged("EsRoll"); }
        }

        private int _esSessionStartYear;
        public int EsSessionStartYear
        {
            get { return _esSessionStartYear; }
            set { _esSessionStartYear = value; OnPropertyChanged("EsSessionStartYear"); }
        }

        private int _esSessionEndYear;
        public int EsSessionEndYear
        {
            get { return _esSessionEndYear; }
            set { _esSessionEndYear = value; OnPropertyChanged("EsSessionEndYear"); }
        }

        private string[] _sex;
        public string[] Sex
        {
            get { return _sex; }
            set { _sex = value; OnPropertyChanged("Sex");  }
        }

        private int _sexIndex;
        public int SexIndex
        {
            get { return _sexIndex; }
            set
            {
                _sexIndex = (value > -1 && value < Sex.Length) ? value : -1;
                OnPropertyChanged("SexIndex");
            }
        }

        private System.Windows.Visibility _sub5Visibility;
        public System.Windows.Visibility Sub5Visibility
        {
            get { return _sub5Visibility; }
            set { _sub5Visibility = value; OnPropertyChanged("Sub5Visibility"); }
        }

        private System.Windows.Visibility _subHsVisibility;
        public System.Windows.Visibility SubHsVisibility
        {
            get { return _subHsVisibility; }
            set { _subHsVisibility = value; OnPropertyChanged("SubHsVisibility"); }
        }

        private int[] _yyyy;
        public int[] YYYY
        {
            get { return _yyyy; }
            set { _yyyy = value; OnPropertyChanged("YYYY"); }
        }

        private string[] _mm;
        public string[] MM
        {
            get { return _mm; }
            set { _mm = value; OnPropertyChanged("MM"); }
        }

        private int[] _dd;
        public int[] DD
        {
            get { return _dd; }
            set { _dd = value; OnPropertyChanged("DD"); }
        }

        private int _dobYYIndex;
        public int DobYYIndex
        {
            get { return _dobYYIndex; }
            set { _dobYYIndex = (value > -1 && value < YYYY.Length) ? value : -1; OnPropertyChanged("DobYYIndex"); }
        }

        private int _dobMMIndex;
        public int DobMMIndex
        {
            get { return _dobMMIndex; }
            set { _dobMMIndex = (value > -1 && value < MM.Length) ? value : -1; OnPropertyChanged("DobMMIndex"); }
        }

        private int _dobDDIndex;
        public int DobDDIndex
        {
            get { return _dobDDIndex; }
            set { _dobDDIndex = (value > -1 && value < DD.Length) ? value : -1; OnPropertyChanged("DobDDIndex"); }
        }

        private string[] _stream;
        public string[] Stream
        {
            get { return _stream; }
            set { _stream = value; OnPropertyChanged("Stream"); }
        }

        private int _streamIndex;
        public int StreamIndex
        {
            get { return _streamIndex; }
            set
            {
                _streamIndex = (value > -1 && value < Stream.Length) ? value : -1;
                OnPropertyChanged("StreamIndex");
                UpdateHsSubs(value);
            }
        }


        private string[] _hsArtsSubs;
        public string[] HsArtsSubs
        {
            get { return _hsArtsSubs; }
            set { _hsArtsSubs = value; OnPropertyChanged("HsArtsSubs"); }
        }

        private string[] _hsSciSubs;
        public string[] HsSciSubs
        {
            get { return _hsSciSubs; }
            set { _hsSciSubs = value; OnPropertyChanged("HsSciSubs"); }
        }

        private string[] _hsActiveSubs;
        public string[] HsActiveSubs
        {
            get { return _hsActiveSubs; }
            set { _hsActiveSubs = value; OnPropertyChanged("HsActiveSubs"); }
        }

        private string[] _hsActiveSubs1;
        public string[] HsActiveSubs1
        {
            get { return _hsActiveSubs1; }
            set { _hsActiveSubs1 = value; OnPropertyChanged("HsActiveSubs1"); }
        }

        private ObservableCollection<string> _hsActiveSubs2;
        public ObservableCollection<string> HsActiveSubs2
        {
            get { return _hsActiveSubs2; }
            set { _hsActiveSubs2 = value; OnPropertyChanged("HsActiveSubs2"); }
        }

        private ObservableCollection<string> _hsActiveSubs3;
        public ObservableCollection<string> HsActiveSubs3
        {
            get { return _hsActiveSubs3; }
            set { _hsActiveSubs3 = value; OnPropertyChanged("HsActiveSubs3"); }
        }

        private ObservableCollection<string> _hsActiveSubs4;
        public ObservableCollection<string> HsActiveSubs4
        {
            get { return _hsActiveSubs4; }
            set { _hsActiveSubs4 = value; OnPropertyChanged("HsActiveSubs4"); }
        }

        private int _hsSub1Index;
        public int HsSub1Index
        {
            get { return _hsSub1Index; }
            set { _hsSub1Index = value; OnPropertyChanged("HsSub1Index"); TrimHsSubs(2); }
        }

        private int _hsSub2Index;
        public int HsSub2Index
        {
            get { return _hsSub2Index; }
            set { _hsSub2Index = value; OnPropertyChanged("HsSub2Index"); TrimHsSubs(3); }
        }

        private int _hsSub3Index;
        public int HsSub3Index
        {
            get { return _hsSub3Index; }
            set { _hsSub3Index = value; OnPropertyChanged("HsSub3Index"); TrimHsSubs(4); }
        }

        private int _hsSub4Index;
        public int HsSub4Index
        {
            get { return _hsSub4Index; }
            set { _hsSub4Index = value; OnPropertyChanged("HsSub4Index"); }
        }

        private string _esAadhaar;
        public string EsAadhaar
        {
            get { return _esAadhaar; }
            set { _esAadhaar = value; OnPropertyChanged("EsAadhaar"); }
        }

        private string[] _esReligion;
        public string[] EsReligion
        {
            get { return _esReligion; }
            set { _esReligion = value; OnPropertyChanged("EsReligion"); }
        }

        private int _esReligionIndex;
        public int EsReligionIndex
        {
            get { return _esReligionIndex; }
            set { _esReligionIndex = (value > -1 && value < EsReligion.Length) ? value : -1; OnPropertyChanged("EsReligionIndex"); }
        }


        public string[] SocialCatList { get; set; }
        public string[] BloodGroups { get; set; }

       
        private int _socialCatIndex;
        public int SocialCatIndex
        {
            get { return _socialCatIndex; }
            set { _socialCatIndex = (value > -1 && value < SocialCatList.Length) ? value : -1; OnPropertyChanged("SocialCatIndex"); }
        }

        private int _bloodGroupIndex;
        public int BloodGroupIndex
        {
            get { return _bloodGroupIndex; }
            set { _bloodGroupIndex = (value > -1 && value < BloodGroups.Length) ? value : -1; OnPropertyChanged("BloodGroupIndex"); }
        }

        private bool _isEsBpl;
        public bool IsEsBpl
        {
            get { return _isEsBpl; }
            set { _isEsBpl = value; OnPropertyChanged("IsEsBpl"); }
        }

        private string _esBplNo;
        public string EsBplNo
        {
            get { return _esBplNo; }
            set { _esBplNo = value; OnPropertyChanged("EsBplNo"); }
        }

        private bool _isEsPH;
        public bool IsEsPH
        {
            get { return _isEsPH; }
            set { _isEsPH = value; OnPropertyChanged("IsEsPH"); }
        }

        private string _esPhType;
        public string EsPhType
        {
            get { return _esPhType; }
            set { _esPhType = value; OnPropertyChanged("EsPhType"); }
        }

        private string _esFather;
        public string EsFather
        {
            get { return _esFather; }
            set
            {
                if (value != null)
                {
                    _esFather = value.ToUpper();
                }
                OnPropertyChanged("EsFather");
            }
        }

        private bool _isSameFatherGuardian;
        public bool IsSameFatherGuardian
        {
            get { return _isSameFatherGuardian; }
            set
            {
                _isSameFatherGuardian = value;
                if (value)
                {
                    EsGuardian = EsFather;
                    EsGuardianRel = "FATHER";
                }
                else
                {
                    EsGuardian = EsGuardianRel = string.Empty;
                }
                OnPropertyChanged("IsSameFatherGuardian");
            }
        }


        private string _esMother;
        public string EsMother
        {
            get { return _esMother; }
            set
            {
                if (value != null)
                {
                    _esMother = value.ToUpper();
                }
                OnPropertyChanged("EsMother");
            }
        }

        private string _esGuardian;
        public string EsGuardian
        {
            get { return _esGuardian; }
            set
            {
                if (value != null)
                {
                    _esGuardian = value.ToUpper();
                }
                OnPropertyChanged("EsGuardian");
            }
        }

        private string _esGuardianRel;
        public string EsGuardianRel
        {
            get { return _esGuardianRel; }
            set
            {
                if (value != null)
                {
                    _esGuardianRel = value.ToUpper();
                }
                OnPropertyChanged("EsGuardianRel");
            }
        }

        private string _esGuardianOccu;
        public string EsGuardianOccu
        {
            get { return _esGuardianOccu; }
            set
            {
                if (value != null)
                {
                    _esGuardianOccu = value.ToUpper();
                }
                OnPropertyChanged("EsGuardianOccu");
            }
        }

        private string _esGuardianAadhaar;
        public string EsGuardianAadhaar
        {
            get { return _esGuardianAadhaar; }
            set
            {
                if (value != null)
                {
                    _esGuardianAadhaar = value.ToUpper();
                }
                OnPropertyChanged("EsGuardianAadhaar");
            }
        }

        private string _esGuardianEpic;
        public string EsGuardianEpic
        {
            get { return _esGuardianEpic; }
            set
            {
                if (value != null)
                {
                    _esGuardianEpic = value.ToUpper();
                }
                OnPropertyChanged("EsGuardianEpic");
            }
        }


        private string _esAddr1;
        public string EsAddr1
        {
            get { return _esAddr1; }
            set
            {
                if (value != null)
                {
                    _esAddr1 = value.ToUpper();
                }
                OnPropertyChanged("EsAddr1");
            }
        }

        private string _esAddr2;
        public string EsAddr2
        {
            get { return _esAddr2; }
            set
            {
                if (value != null)
                {
                    _esAddr2 = value.ToUpper();
                }
                OnPropertyChanged("EsAddr2");
            }
        }

        private string _esAddrPO;
        public string EsAddrPO
        {
            get { return _esAddrPO; }
            set
            {
                if (value != null)
                {
                    _esAddrPO = value.ToUpper();
                }
                OnPropertyChanged("EsAddrPO");
            }
        }

        private string _esAddrPS;
        public string EsAddrPS
        {
            get { return _esAddrPS; }
            set
            {
                if (value != null)
                {
                    _esAddrPS = value.ToUpper();
                }
                OnPropertyChanged("EsAddrPS");
            }
        }

        private string _esAddrDist;
        public string EsAddrDist
        {
            get { return _esAddrDist; }
            set
            {
                if (value != null)
                {
                    _esAddrDist = value.ToUpper();
                }
                OnPropertyChanged("EsAddrDist");
            }
        }

        private string _esAddrPIN;
        public string EsAddrPIN
        {
            get { return _esAddrPIN; }
            set
            {
                if (value != null)
                {
                    _esAddrPIN = value.ToUpper();
                }
                OnPropertyChanged("EsAddrPIN");
            }
        }

        private string _esPaddr1;
        public string EsPaddr1
        {
            get { return _esPaddr1; }
            set
            {
                if (value != null)
                {
                    _esPaddr1 = value.ToUpper();
                }
                OnPropertyChanged("EsPaddr1");
            }
        }

        private string _esPaddr2;
        public string EsPaddr2
        {
            get { return _esPaddr2; }
            set
            {
                if (value != null)
                {
                    _esPaddr2 = value.ToUpper();
                }
                OnPropertyChanged("EsPaddr2");
            }
        }

        private string _esPaddrPO;
        public string EsPaddrPO
        {
            get { return _esPaddrPO; }
            set
            {
                if (value != null)
                {
                    _esPaddrPO = value.ToUpper();
                }
                OnPropertyChanged("EsPaddrPO");
            }
        }

        private string _esPaddrPS;
        public string EsPaddrPS
        {
            get { return _esPaddrPS; }
            set
            {
                if (value != null)
                {
                    _esPaddrPS = value.ToUpper();
                }
                OnPropertyChanged("EsPaddrPS");
            }
        }

        private string _esPaddrDist;
        public string EsPaddrDist
        {
            get { return _esPaddrDist; }
            set
            {
                if (value != null)
                {
                    _esPaddrDist = value.ToUpper();
                }
                OnPropertyChanged("EsPaddrDist");
            }
        }

        private string _esPaddrPIN;
        public string EsPaddrPIN
        {
            get { return _esPaddrPIN; }
            set
            {
                if (value != null)
                {
                    _esPaddrPIN = value.ToUpper();
                }
                OnPropertyChanged("EsPaddrPIN");
            }
        }

        private string _esMobile;
        public string EsMobile
        {
            get { return _esMobile; }
            set { _esMobile = value; OnPropertyChanged("EsMobile"); }
        }

        private string _esGuardianMobile;
        public string EsGuardianMobile
        {
            get { return _esGuardianMobile; }
            set { _esGuardianMobile = value; OnPropertyChanged("EsGuardianMobile"); }
        }

        private string _esEmail;
        public string EsEmail
        {
            get { return _esEmail; }
            set { _esEmail = value; OnPropertyChanged("EsEmail"); }
        }

        private string _esBankAccNo;
        public string EsBankAccNo
        {
            get { return _esBankAccNo; }
            set { _esBankAccNo = value; OnPropertyChanged("EsBankAccNo"); }
        }

        private string _esBankName;
        public string EsBankName
        {
            get { return _esBankName; }
            set { _esBankName = value; OnPropertyChanged("EsBankName"); }
        }

        private string _esBankBranch;
        public string EsBankBranch
        {
            get { return _esBankBranch; }
            set { _esBankBranch = value; OnPropertyChanged("EsBankBranch"); }
        }

        private string _esBankIfsc;
        public string EsBankIfsc
        {
            get { return _esBankIfsc; }
            set { _esBankIfsc = value; OnPropertyChanged("EsBankIfsc"); }
        }

        private string _esBankMicr;
        public string EsBankMicr
        {
            get { return _esBankMicr; }
            set { _esBankMicr = value; OnPropertyChanged("EsBankMicr"); }
        }

        private string _esLastSchool;
        public string EsLastSchool
        {
            get { return _esLastSchool; }
            set { _esLastSchool = value; OnPropertyChanged("EsLastSchool"); }
        }

        private string _esBoard;
        public string EsBoard
        {
            get { return _esBoard; }
            set { _esBoard = value; OnPropertyChanged("EsBoard"); }
        }

        private string _esTC;
        public string EsTC
        {
            get { return _esTC; }
            set { _esTC = value; OnPropertyChanged("EsTC"); }
        }

        private string _esQualifiedExam;
        public string EsQualifiedExam
        {
            get { return _esQualifiedExam; }
            set { _esQualifiedExam = value; OnPropertyChanged("EsQualifiedExam"); }
        }

        private string _esQualifiedExamFullMarks;
        public string EsQualifiedExamFullMarks
        {
            get { return _esQualifiedExamFullMarks; }
            set { _esQualifiedExamFullMarks = value; OnPropertyChanged("EsQualifiedExamFullMarks"); }
        }

        private string _esQualifiedExamObtainedMarks;
        public string EsQualifiedExamObtainedMarks
        {
            get { return _esQualifiedExamObtainedMarks; }
            set { _esQualifiedExamObtainedMarks = value; OnPropertyChanged("EsQualifiedExamObtainedMarks"); }
        }

        private string _esAdmissionNo;
        public string EsAdmissionNo
        {
            get { return _esAdmissionNo; }
            set { _esAdmissionNo = value; OnPropertyChanged("EsAdmissionNo"); }
        }

        private int _esAdmittedClassIndex;
        public int EsAdmittedClassIndex
        {
            get { return _esAdmittedClassIndex; }
            set { _esAdmittedClassIndex = value; OnPropertyChanged("EsAdmittedClassIndex"); }
        }

        private bool _sameAddress;
        public bool SameAddress
        {
            get { return _sameAddress; }
            set
            {
                _sameAddress = value;
                OnPropertyChanged("SameAddress");
                if (value)
                {
                    EsPaddr1 = EsAddr1;
                    EsPaddr2 = EsAddr2;
                    EsPaddrPO = EsAddrPO;
                    EsPaddrPS = EsAddrPS;
                    EsPaddrDist = EsAddrDist;
                    EsPaddrPIN = EsAddrPIN;
                }
                else
                {
                    EsPaddr1 = string.Empty;
                    EsPaddr2 = string.Empty;
                    EsPaddrPO = string.Empty;
                    EsPaddrPS = string.Empty;
                    EsPaddrDist = string.Empty;
                    EsPaddrPIN = string.Empty;
                }
            }
        }


        private string _mpRegisNo;
        public string MpRegisNo
        {
            get { return _mpRegisNo; }
            set { _mpRegisNo = (value != null) ? value.ToUpper() : value; OnPropertyChanged("MpRegisNo"); }
        }

        private string _mpRoll;
        public string MpRoll
        {
            get { return _mpRoll; }
            set { _mpRoll = (value != null) ? value.ToUpper() : value; OnPropertyChanged("MpRoll"); }
        }

        private string _mpNo;
        public string MpNo
        {
            get { return _mpNo; }
            set { _mpNo = (value != null) ? value.ToUpper() : value; OnPropertyChanged("MpNo"); }
        }

        private string _hsRegisNo;
        public string HsRegisNo
        {
            get { return _hsRegisNo; }
            set { _hsRegisNo = (value != null) ? value.ToUpper() : value; OnPropertyChanged("HsRegisNo"); }
        }

        private string _hsRoll;
        public string HsRoll
        {
            get { return _hsRoll; }
            set { _hsRoll = (value != null) ? value.ToUpper() : value; OnPropertyChanged("HsRoll"); }
        }

        // hs admit roll no
        private string _hsNo;
        public string HsNo
        {
            get { return _hsNo; }
            set { _hsNo = (value != null) ? value.ToUpper() : value; OnPropertyChanged("HsNo"); }
        }

        private string [] _qualifiedClass;
        public string [] QualifiedClass
        {
            get { return _qualifiedClass; }
            set { _qualifiedClass = value; OnPropertyChanged("QualifiedClass"); }
        }

        private int _qualifiedClassIndex;
        public int QualifiedClassIndex
        {
            get { return _qualifiedClassIndex; }
            set { _qualifiedClassIndex = (value > -1 && value < QualifiedClass.Length) ? value: -1;  OnPropertyChanged("QualifiedClassIndex"); }
        }

        private string _msg;
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; OnPropertyChanged("Msg"); }
        }


        public RelayCommand SaveCommand { get; set; }

        private void StartUpInitializer()
        {
            EsSchoolClass = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI" };
            QualifiedClass = new string[] {"IV", "V", "VI", "VII", "VIII", "IX", "X" };
            Sex = new string[] { "Boy", "Girl" };
            Stream = new string[] { "ARTS", "SCIENCE"};
            QualifiedClassIndex = -1;
            StreamIndex = -1;
            SexIndex = -1;
            EsSection = new string[] { "A", "B", "C", "D", "E" };
            EsReligion = new string[] { "ISLAM", "HINDUISM", "OTHER"};
            MM = new string[] { "JAN (01)", "FEB (02)", "MAR (03)", "APR (04)", "MAY (05)", "JUN (06)", "JUL (07)", "AUG (08)", "SEP (09)", "OCT (10)", "NOV (11)", "DEC (12)" };
            DD = new int[31];
            HsArtsSubs = new string[] { "ARABIC", "ECONOMICS", "EDUCATION", "GEOGRAPHY", "PHILOSOPHY", "HISTORY",  "POL. SC",  "SOCIOLOGY" };
            HsSciSubs = new string[] { "PHYSICS", "CHEMISTRY", "MATHEMATICS", "BIOLOGY" };

            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;


            for (int i = 0; i < 31; i++)
            {
                DD[i] = i + 1;
            }
            int yyArrayLenght = DateTime.Today.Year - 1995;
            YYYY = new int[yyArrayLenght];
            for (int i = 0; i < yyArrayLenght; i++)
            {
                YYYY[i] = 1995 + i;
            }


            SocialCatList = new string[] { "GEN", "SC", "ST", "OBC-A", "OBC-B" };
            BloodGroups = new string[] { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };

            HsSubsInitializer();

            if (EditableStudent != null)
            {
                BuildDetailsFromEditableStudent();
            }

            Msg = string.Empty;

            SaveCommand = new RelayCommand(SaveUpdatedStudent, CanSaveUpdatedStudent);
        }

        private void BuildDetailsFromEditableStudent()
        {
            EsName = EditableStudent.Name;
            EsClass = EditableStudent.StudyingClass;
            EsSessionStartYear = EditableStudent.StartSessionYear;
            EsSessionEndYear = EditableStudent.EndSessionYear;
            if (EditableStudent.Sex == "M")
            {
                SexIndex = 0;
            }
            else if (EditableStudent.Sex == "F")
            {
                SexIndex = 1;
            }
            else
            {
                SexIndex = -1;
            }
            EsSectionIndex = Array.IndexOf(EsSection, EditableStudent.Section);
            EsRoll = EditableStudent.Roll;
            if (EditableStudent.StudyingClass == "V")
            {
                SubHsVisibility = System.Windows.Visibility.Collapsed;
                Sub5Visibility = System.Windows.Visibility.Visible;
            }
            else if (EditableStudent.StudyingClass == "XI" || EditableStudent.StudyingClass == "XII")
            {
                Sub5Visibility = System.Windows.Visibility.Collapsed;
                SubHsVisibility = System.Windows.Visibility.Visible;
               
                StreamIndex = Array.IndexOf(Stream, EditableStudent.Stream);
                if (StreamIndex > -1)
                {
                    if (Stream[StreamIndex] == "ARTS")
                    {
                        HsActiveSubs = HsArtsSubs;
                    }
                    else if (Stream[StreamIndex] == "SCIENCE")
                    {
                        HsActiveSubs = HsSciSubs;
                    }
                    HsSub1Index = Array.IndexOf(HsActiveSubs1, EditableStudent.HsSub1);

                    HsSub2Index = HsActiveSubs2.IndexOf(EditableStudent.HsSub2);
                    HsSub3Index = HsActiveSubs3.IndexOf(EditableStudent.HsSub3);
                    HsSub4Index = HsActiveSubs4.IndexOf(EditableStudent.HsAdlSub);
                   
                }

            }
            else
            {
                SubHsVisibility = System.Windows.Visibility.Collapsed;
                Sub5Visibility = System.Windows.Visibility.Collapsed;
            }

            DobYYIndex = Array.IndexOf(YYYY, EditableStudent.Dob.Year);
            DobMMIndex = EditableStudent.Dob.Month - 1;
            DobDDIndex = Array.IndexOf(DD, EditableStudent.Dob.Day);

            EsAadhaar = EditableStudent.Aadhar;
            EsReligionIndex = Array.IndexOf(EsReligion, EditableStudent.Religion);
            SocialCatIndex = Array.IndexOf(SocialCatList, EditableStudent.SocialCategory);
            BloodGroupIndex = Array.IndexOf(BloodGroups, EditableStudent.BloodGroup);

            IsEsBpl = EditableStudent.IsBpl;
            EsBplNo = (IsEsBpl) ? EditableStudent.BplNo : string.Empty;
            IsEsPH = EditableStudent.IsPH;
            EsPhType = (IsEsPH) ? EditableStudent.PhType : string.Empty;

            EsFather = EditableStudent.FatherName;
            EsMother = EditableStudent.MotherName;
            EsGuardian = EditableStudent.GuardianName;
            EsGuardianRel = EditableStudent.GuardianRelation;
            EsGuardianOccu = EditableStudent.GuardianOccupation;
            EsGuardianAadhaar = EditableStudent.GuardianAadhar;
            EsGuardianEpic = EditableStudent.GuardianEpic;

            EsAddr1 = EditableStudent.PstAddrLane1;
            EsAddr2 = EditableStudent.PstAddrLane2;
            EsAddrPO = EditableStudent.PstAddrPO;
            EsAddrPS = EditableStudent.PstAddrPS;
            EsAddrDist = EditableStudent.PstAddrDist;
            EsAddrPIN = EditableStudent.PstAddrPin;

            EsPaddr1 = EditableStudent.PmtAddrLane1;
            EsPaddr2 = EditableStudent.PmtAddrLane2;
            EsPaddrPO = EditableStudent.PmtAddrPO;
            EsPaddrPS = EditableStudent.PmtAddrPS;
            EsPaddrDist = EditableStudent.PmtAddrDist;
            EsPaddrPIN = EditableStudent.PmtAddrPin;

            EsMobile = EditableStudent.Mobile;
            EsGuardianMobile = EditableStudent.GuardianMobile;
            EsEmail = EditableStudent.Email;

            EsBankAccNo = EditableStudent.BankAcc;
            EsBankName = EditableStudent.BankName;
            EsBankBranch = EditableStudent.BankBranch;
            EsBankIfsc = EditableStudent.Ifsc;
            EsBankMicr = EditableStudent.MICR;

            EsLastSchool = EditableStudent.LastSchool;
            //EsBoard = "";
            EsTC = EditableStudent.TC;
            /*
             * Remaining properties
             *  
             */
            EsAdmittedClassIndex = Array.IndexOf(EsSchoolClass, EditableStudent.AdmittedClass);
            EsAdmissionNo = EditableStudent.AdmissionNo;

            MpRegisNo = EditableStudent.RegistrationNoMp;
            MpRoll = EditableStudent.BoardRoll;
            MpNo = EditableStudent.BoardNo;

            HsRegisNo = EditableStudent.RegistrationNoHs;
            HsRoll = EditableStudent.CouncilRoll;
            HsNo = EditableStudent.CouncilNo;
        }

        private bool HasError()
        {
            // class
            if (Array.IndexOf(GlobalVar.SchoolClasses, EsClass) == -1)
            {
                System.Windows.MessageBox.Show("Sorry! Class has some invalid entries.");
                return true;
            }
            // section
            bool valSection = EsSectionIndex != -1;
            if (!valSection)
            {
                System.Windows.MessageBox.Show("Sorry! Section is not correct.");
                return true;
            }
            // roll
            bool valRoll = EsRoll > 0;
            if (!valRoll)
            {
                System.Windows.MessageBox.Show("Sorry! Roll is not correct.");
                return true;
            }
            // date of birth
            try
            {
                DateTime valDob = new DateTime(YYYY[DobYYIndex], DobMMIndex+1, DD[DobDDIndex]);
            }
            catch (Exception exdob)
            {
                System.Windows.MessageBox.Show("Sorry! Date of Birth is not correct.");
                return true;
            }

            // aadhaar
            if (!string.IsNullOrEmpty(EsAadhaar))
            {
                string pattern = @"^\d{12}$";
                Match match = Regex.Match(EsAadhaar.Trim(), pattern);
                if (!match.Success)
                {
                    System.Windows.MessageBox.Show("Please enter correct Aadhaar no.");
                    return true;
                }
            }

            // mobile
            if (!string.IsNullOrEmpty(EsMobile))
            {
                string pattern = @"^\d{10}$";
                Match match = Regex.Match(EsMobile.Trim(), pattern);
                if (!match.Success)
                {
                    System.Windows.MessageBox.Show("Please enter correct mobile no.");
                    return true;
                }
            }

            if (!string.IsNullOrEmpty(EsGuardianMobile))
            {
                string pattern = @"^\d{10}$";
                Match match = Regex.Match(EsGuardianMobile.Trim(), pattern);
                if (!match.Success)
                {
                    System.Windows.MessageBox.Show("Please enter guardian's correct mobile no.");
                    return true;
                }
            }
            // email

            return false;
        }

        private Student GetUpdatedStudent()
        {
            Student s = new Student();

            s.Id = EditableStudent.Id;
            s.Name = EsName;
            if (SexIndex == 0)
            {
                s.Sex = "M";
            }
            else if (SexIndex == 1)
            {
                s.Sex = "F";
            }
            s.StudyingClass = EsClass;

            s.StartSessionYear = EsSessionStartYear;
            s.EndSessionYear = EsSessionEndYear;

            s.Section = EsSection[EsSectionIndex];
            s.Roll = EditableStudent.Roll;
            s.Dob = new DateTime(YYYY[DobYYIndex], DobMMIndex + 1, DD[DobDDIndex]);
            if (s.StudyingClass == "V")
            {

            }

            if (s.StudyingClass == "XI" || s.StudyingClass == "XII")
            {
                // StreamIndex = Array.IndexOf(Stream, EditableStudent.Stream);
                // s.Stream = EditableStudent.Stream;
                if (StreamIndex > -1)
                {
                    s.Stream = Stream[StreamIndex];
                }
                /*
                if (s.Stream == "ARTS")
                {
                    s.HsSub1 = HsActiveSubs1[HsSub1Index];
                    s.HsSub2 = HsActiveSubs2[HsSub2Index];
                    s.HsSub3 = HsActiveSubs3[HsSub3Index];
                    s.HsAdlSub = HsActiveSubs4[HsSub4Index];
                    
                }
                else if (s.Stream == "SCIENCE")
                {
                    s.HsSub1 = HsActiveSubs1[HsSub1Index];
                    s.HsSub2 = HsActiveSubs2[HsSub2Index];
                    s.HsSub3 = HsActiveSubs3[HsSub3Index];
                    s.HsAdlSub = HsActiveSubs4[HsSub4Index];
                }
                */
                if (HsSub1Index > -1)
                {
                    s.HsSub1 = HsActiveSubs1[HsSub1Index];
                }
                if (HsSub2Index > -1)
                {
                    s.HsSub2 = HsActiveSubs2[HsSub2Index];
                }
                if (HsSub3Index > -1)
                {
                    s.HsSub3 = HsActiveSubs3[HsSub3Index];
                }
                if (HsSub4Index > -1)
                {
                    s.HsAdlSub = HsActiveSubs4[HsSub4Index];
                }

            }
            
            if (!string.IsNullOrEmpty(EsAadhaar))
            {
                s.Aadhar = EsAadhaar.Trim();
            }

            if (EsReligionIndex != -1)
            {
                s.Religion = EsReligion[EsReligionIndex];
            }

            if (SocialCatIndex != -1)
            {
                s.SocialCategory = SocialCatList[SocialCatIndex];
            }

            if (BloodGroupIndex != -1)
            {
                s.BloodGroup = BloodGroups[BloodGroupIndex];
            }

            if (IsEsBpl)
            {
                s.IsBpl = true;
                s.BplNo = EsBplNo;
            }
            else
            {
                s.IsBpl = false;
                s.BplNo = string.Empty;
            }

            if (IsEsPH)
            {
                s.IsPH = true;
                s.PhType = EsPhType;
            }
            else
            {
                s.IsPH = false;
                s.PhType = string.Empty;
            }

            s.FatherName = EsFather;
            s.MotherName = EsMother;
            s.GuardianName = EsGuardian;
            s.GuardianRelation = EsGuardianRel;
            s.GuardianOccupation = EsGuardianOccu;
            // aadhaar
            //
            s.GuardianEpic = EsGuardianEpic;

            s.PstAddrLane1 = EsAddr1;
            s.PstAddrLane2 = EsAddr2;
            s.PstAddrPO = EsAddrPO;
            s.PstAddrPS = EsAddrPS;
            s.PstAddrDist = EsAddrDist;
            s.PstAddrPin = EsAddrPIN;

            s.PmtAddrLane1 = EsPaddr1;
            s.PmtAddrLane2 = EsPaddr2;
            s.PmtAddrPO = EsPaddrPO;
            s.PmtAddrPS = EsPaddrPS;
            s.PmtAddrDist = EsPaddrDist;
            s.PmtAddrPin = EsPaddrPIN;


            // mobile use regex
            if (!string.IsNullOrEmpty(EsMobile))
            {
                s.Mobile = EsMobile.Trim();
            }
            if (!string.IsNullOrEmpty(EsGuardianMobile))
            {
                s.GuardianMobile = EsGuardianMobile.Trim();
            }
            s.Email = EsEmail;

            s.BankAcc = EsBankAccNo;
            s.BankName = EsBankName;
            s.BankBranch = EsBankBranch;
            s.Ifsc = EsBankIfsc;
            s.MICR = EsBankMicr;

            s.LastSchool = EsLastSchool;
            // last board
            s.TC = EsTC;
            // qualified exam
            if (QualifiedClassIndex != -1)
            {
                
            }

            // full marks qualified
            // mark obt in qualified

            s.AdmissionNo = EsAdmissionNo;
            if (EsAdmittedClassIndex != -1)
            {
                s.AdmittedClass = EsSchoolClass[EsAdmittedClassIndex];
            }

            s.RegistrationNoMp = MpRegisNo;
            s.BoardRoll = MpRoll;
            s.BoardNo = MpNo;

            s.RegistrationNoHs = HsRegisNo;
            s.CouncilRoll = HsRoll;
            s.CouncilNo = HsNo;

         //   s.StartSessionYear = EditableStudent.StartSessionYear;
          //  s.EndSessionYear = EditableStudent.EndSessionYear;

            return s;
        }

        private void SaveUpdatedStudent()
        {
            if (!HasError())
            {
                Student UpdatedStudent = GetUpdatedStudent();
                GenUpdateDb db = new GenUpdateDb();
                if (db.UpdateStudent(UpdatedStudent, EditableStudent.StartSessionYear, EditableStudent.EndSessionYear))
                {
                    Msg = UpdatedStudent.Name+"'s details updated successfully.";
                }
                else
                {
                    Msg = "Sorry! Failed to update";
                }

            }
            else
            {
                Msg = "Data could not be saved.";
            }
        }

        private bool CanSaveUpdatedStudent()
        {
            return true;
        }

        private void HsSubsInitializer()
        {
            HsArtsSubs = GlobalVar.HsArtsSubs;
            HsSciSubs = GlobalVar.HsSciSubs;
            HsActiveSubs = new string[] { };
            HsActiveSubs1 = new string[] { };
            HsActiveSubs2 = new ObservableCollection<string>();
            HsActiveSubs3 = new ObservableCollection<string>();
            HsActiveSubs4 = new ObservableCollection<string>();

            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;
        }

        private void UpdateHsSubs(int value)
        {
            HsSub1Index = HsSub2Index = HsSub3Index = HsSub4Index = -1;
            if (value == -1)
            {
                //  Array.Clear(HsActiveSubs, 0, HsActiveSubs.Length);
            }
            else
            {
                if (Stream[StreamIndex] == "ARTS")
                {
                    HsActiveSubs = HsArtsSubs;
                }
                else if (Stream[StreamIndex] == "SCIENCE")
                {
                    HsActiveSubs = HsSciSubs;
                }
                else
                {
                    Array.Clear(HsActiveSubs, 0, HsActiveSubs.Length);
                }
                HsActiveSubs1 = HsActiveSubs;
            }
        }

        private void TrimHsSubs(int subNo)
        {
            switch (subNo)
            {
                case 2:
                    if (HsActiveSubs2 != null && HsActiveSubs2.Count > 0)
                    {
                        HsActiveSubs2.Clear();
                    }
                    if (HsSub1Index != -1)
                    {
                        string sub1 = HsActiveSubs1[HsSub1Index];
                        if (sub1 == "ARABIC" || sub1 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs1)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs2.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs1)
                            {
                                if (item == sub1)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs2.Add(item);
                                }
                            }
                        }
                    }
                    break;

                case 3:
                    if (HsActiveSubs3 != null && HsActiveSubs3.Count > 0)
                    {
                        HsActiveSubs3.Clear();
                    }
                    if (HsSub2Index != -1)
                    {
                        string sub2 = HsActiveSubs2[HsSub2Index];
                        if (sub2 == "ARABIC" || sub2 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs2)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs3.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs2)
                            {
                                if (item == sub2)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs3.Add(item);
                                }
                            }
                        }
                    }
                    break;

                case 4:
                    if (HsActiveSubs4 != null && HsActiveSubs4.Count > 0)
                    {
                        HsActiveSubs4.Clear();
                    }
                    if (HsSub3Index != -1)
                    {
                        int r = HsSub3Index;
                        ObservableCollection<string> tr = HsActiveSubs3;
                        string sub3 = HsActiveSubs3[HsSub3Index];
                      //  string sub3 = HsActiveSubs[HsSub3Index];

                        if (sub3 == "ARABIC" || sub3 == "ECONOMICS")
                        {
                            foreach (var item in HsActiveSubs3)
                            {
                                if (item == "ARABIC" || item == "ECONOMICS")
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs4.Add(item);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in HsActiveSubs3)
                            {
                                if (item == sub3)
                                {
                                    continue;
                                }
                                else
                                {
                                    HsActiveSubs4.Add(item);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
