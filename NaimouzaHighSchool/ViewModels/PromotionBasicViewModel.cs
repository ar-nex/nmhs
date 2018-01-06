using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class PromotionBasicViewModel : BaseViewModel
    {
        public PromotionBasicViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private string[] _sclClass;
        public string[] SclClass
        {
            get => _sclClass;
            set
            {
                _sclClass = value;
                OnPropertyChanged("SclClass");
            }
        }

        private int _sclClassIndex;
        public int SclClassIndex
        {
            get => _sclClassIndex;
            set
            {
                if (value < -1 || value > SclClass.Length)
                {
                    _sclClassIndex = -1;
                }
                else
                {
                    _sclClassIndex = value;
                }
                OnPropertyChanged("SclClassIndex");
            }
        }

        private int _sclClassIndex2;
        public int SclClassIndex2
        {
            get => _sclClassIndex2;
            set
            {
                if (value < -1 || value > SclClass.Length)
                {
                    _sclClassIndex2 = -1;
                }
                else
                {
                    _sclClassIndex2 = value;
                }
                OnPropertyChanged("SclClassIndex2");
            }
        }

        private string[] _clsSection;
        public string[] ClsSection
        {
            get => _clsSection;
            set
            {
                _clsSection = value;
                OnPropertyChanged("ClsSection");
            }
        }

        private string[] _stdGender;
        public string[] StdGender
        {
            get => _stdGender;
            set
            {
                _stdGender = value;
                OnPropertyChanged("StdGender");
            }
        }

        private Gender _sx;
        private Gender _sx2;

        private int _stdGenderIndex;
        public int StdGenderIndex
        {
            get => _stdGenderIndex;
            set
            {
                if (value > -1 && value < StdGender.Length)
                {
                    _stdGenderIndex = value;
                }
                else
                {
                    _stdGenderIndex = 0;
                }
                switch (_stdGenderIndex)
                {
                    case 0:
                        _sx = Gender.NA;
                        break;
                    case 1:
                        _sx = Gender.M;
                        break;
                    case 2:
                        _sx = Gender.F;
                        break;
                    default:
                        break;
                }
                OnPropertyChanged("StdGenderIndex");
            }
        }

        private int _stdGenderIndex2;
        public int StdGenderIndex2
        {
            get => _stdGenderIndex2;
            set
            {
                if (value > -1 && value < StdGender.Length)
                {
                    _stdGenderIndex2 = value;
                }
                else
                {
                    _stdGenderIndex2 = 0;
                }
                switch (_stdGenderIndex2)
                {
                    case 0:
                        _sx2 = Gender.NA;
                        break;
                    case 1:
                        _sx2 = Gender.M;
                        break;
                    case 2:
                        _sx2 = Gender.F;
                        break;
                    default:
                        break;
                }
                OnPropertyChanged("StdGenderIndex2");
            }
        }


        private int _clsSectionIndex;
        public int ClsSectionIndex
        {
            get => _clsSectionIndex;
            set
            {
                _clsSectionIndex = (value < -1 || value > ClsSection.Length) ? -1 : value;
                OnPropertyChanged("ClsSectionIndex");
            }
        }

        private int _clsSectionIndex2;
        public int ClsSectionIndex2
        {
            get => _clsSectionIndex2;
            set
            {
                _clsSectionIndex2 = (value < -1 || value > ClsSection.Length) ? -1 : value;
                OnPropertyChanged("ClsSectionIndex2");
            }
        }

        private int _startYear;
        public int StartYear
        {
            get => _startYear;
            set
            {
                _startYear = value;
                OnPropertyChanged("StartYear");
            }
        }

        private int _endYear;
        public int EndYear
        {
            get => _endYear;
            set
            {
                _endYear = value;
                OnPropertyChanged("EndYear");
            }
        }

        private int _newStartYear;
        public int NewStartYear
        {
            get => _newStartYear;
            set
            {
                _newStartYear = value;
                OnPropertyChanged("NewStartYear");
            }
        }

        private int _newEndYear;
        public int NewEndYear
        {
            get => _newEndYear;
            set
            {
                _newEndYear = value;
                OnPropertyChanged("NewEndYear");
            }
        }

        private ObservableCollection<PromotionBasic> _promBasicList;
        public ObservableCollection<PromotionBasic> PromBasicList
        {
            get => _promBasicList;
            set
            {
                _promBasicList = value;
                OnPropertyChanged("PromBasicList");
            }
        }

        private ObservableCollection<PromotionBasic> _promBasicListOld;
        private ObservableCollection<PromotionBasic> PromBasicListOld
        {
            get => _promBasicListOld;
            set
            {
                _promBasicListOld = value;
                OnPropertyChanged("PromBasicListOld");
            }
        }

        private ObservableCollection<PromotionBasic> _promotedList;
        public ObservableCollection<PromotionBasic> PromotedList
        {
            get => _promotedList;
            set
            {
                _promotedList = value;
                OnPropertyChanged("PromotedList");
            }
        }


        public RelayCommand GetDataCommand { get; set; }
        public RelayCommand GetDataCommand2 { get; set; }
        public RelayCommand DoPromotionCommand { get; set; }

        private void StartUpInitializer()
        {
            SclClass = new string[] {"V", "VI", "VII", "VIII", "IX", "XI" };
            ClsSection = new string[] { "A", "B", "C", "D", "E" };
            StdGender = new string[] { "All", "Boys", "Girls" };
            SclClassIndex = -1;
            SclClassIndex2 = -1;

            ClsSectionIndex = -1;
            ClsSectionIndex2 = -1;

            StartYear = 2017;
            EndYear = 2017;
            NewStartYear = StartYear + 1;
            NewEndYear = EndYear + 1;
            PromBasicList = new ObservableCollection<PromotionBasic>();
            PromBasicListOld = new ObservableCollection<PromotionBasic>();
            PromotedList = new ObservableCollection<PromotionBasic>();
            GetDataCommand = new RelayCommand(GetData, CanGetData);
            GetDataCommand2 = new RelayCommand(GetData2, CanGetData2);
            DoPromotionCommand = new RelayCommand(DoPromotion, CanDoPromotion);
        }

        private void GetData()
        {
            PromotionBasicDb db = new PromotionBasicDb();
            PromBasicList = db.GetData(cls: SclClass[SclClassIndex], sec: ClsSection[ClsSectionIndex], sex: _sx, startYear: StartYear, endYear: EndYear);
            PromBasicListOld = db.GetDataAlreadyEntered(cls: SclClass[SclClassIndex], sex: _sx, startYear: StartYear, endYear: EndYear);
        }

        private void GetData2()
        {
            PromotionBasicDb db = new PromotionBasicDb();
            PromotedList = db.GetPromotedData(cls: SclClass[SclClassIndex2], sec: ClsSection[ClsSectionIndex2], sex: _sx2, startYear: 2018, endYear: 2018);
        }

        private bool CanGetData2()
        {
            return (SclClassIndex2 != -1 && ClsSectionIndex2 != -1);
        }


        private bool CanGetData()
        {
            return (SclClassIndex != -1 && ClsSectionIndex !=-1 && StartYear == 2017 && EndYear == 2017);
        }

        private void DoPromotion()
        {
            // do validation. If same roll or section already assigned or not
            ObservableCollection<PromotionBasic> prValidList = RemoveInvalids();
            PromotionBasicDb db = new PromotionBasicDb();
            ObservableCollection<PromotionBasic> notInsertedList = db.DoPromotionBasic(prList: prValidList, startYear: NewStartYear, endYear: NewEndYear);
        }
        private bool CanDoPromotion()
        {
            return true;
        }

        private ObservableCollection<PromotionBasic> RemoveInvalids()
        {
            // note new logic
            // if item has default value : continue
            // if not default check for duplicate : if no duplicate : add it. if duplicate continue
            
            ObservableCollection<PromotionBasic> prListValid = new ObservableCollection<PromotionBasic>();
            List<PromotionBasic> plist = PromBasicList.ToList();
            for (int i = 0; i < PromBasicList.Count; i++)
            {
                PromotionBasic item = PromBasicList[i];
                bool isDefault = string.IsNullOrEmpty(item.NewClass) && string.IsNullOrEmpty(item.NewSection) && (item.NewRoll <= 0);
                if (isDefault)
                {
                    continue;
                }
                else
                {
                    if (IsDuplicatePresent(plist, item, i))
                    {
                        continue;
                    }
                    else if (IsAlreadyExistInDb(item))
                    {
                        continue;
                    }
                    else
                    {
                        prListValid.Add(item);
                    }
                    
                }
            }
            foreach (var validitem in prListValid)
            {
                if (PromBasicList.IndexOf(validitem) != -1)
                {
                    PromBasicList.Remove(validitem);
                }
            }
            return prListValid;
        }

        private bool IsAlreadyExistInDb(PromotionBasic OuterItem)
        {
            bool isPresent = false;
            foreach (PromotionBasic item in PromBasicListOld)
            {
                if (item.Cls == OuterItem.NewClass && item.Section == OuterItem.NewSection && item.OldRoll == OuterItem.NewRoll)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }


        private bool IsDuplicatePresent(List<PromotionBasic> plist, PromotionBasic item, int indx)
        {
            bool isPresent = false;
            for (int i = 0; i < plist.Count; i++)
            {
                if (i == indx)
                {
                    continue;
                }
                else
                {
                    PromotionBasic innerItem = plist[i];
                    bool isInCurrentList = (item.NewClass == innerItem.NewClass) && (item.NewSection == innerItem.NewSection) && (item.NewRoll == innerItem.NewRoll);
                    if (isInCurrentList)
                    {
                        isPresent = true;
                        break;
                    }
                }
            }
            return isPresent;
        }

    }
}
