using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.ViewModels.Commands;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;

namespace NaimouzaHighSchool.ViewModels
{
    public class RegistrationUpdaterViewModel : BaseViewModel
    {
        public RegistrationUpdaterViewModel()
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
            get=> _sclClassIndex;
            set
            {
                _sclClassIndex = (value > -1 && value < SclClass.Length) ? value : -1;
                OnPropertyChanged("SclClassIndex");
            }
        }


        private string[] _sclSection;
        public string[] SclSection
        {
            get => _sclSection;
            set
            {
                _sclSection = value;
                OnPropertyChanged("SclSection");
            }
        }

        private int _sclSectionIndex;
        public int SclSectionIndex
        {
            get => _sclSectionIndex;
            set
            {
                _sclSectionIndex = (value > -1 && value < SclSection.Length) ? value : -1;
                OnPropertyChanged("SclSectionIndex");
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

        private ObservableCollection<RegistrationUpdater> _rList;
        public ObservableCollection<RegistrationUpdater> RList
        {
            get => _rList;
            set
            {
                _rList = value;
                OnPropertyChanged("RList");
            }
        }

        public RelayCommand GetDataCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private void StartUpInitializer()
        {
            SclClass = new string[] { "IX", "X", "XI", "XII"};
            SclSection = new string[] { "A", "B", "C", "D" };
            SclClassIndex = -1;
            SclSectionIndex = -1;
            StartYear = DateTime.Today.Year;
            EndYear = DateTime.Today.Year;
            RList = new ObservableCollection<RegistrationUpdater>();
            GetDataCommand = new RelayCommand(GetData, CanGetData);
            UpdateCommand = new RelayCommand(Update, CanUpdate);
        }

        private void Update()
        {
            RegistrationUpdaterDb db = new RegistrationUpdaterDb();

            ObservableCollection<RegistrationUpdater> notinsertedList = db.UpdateRegistration(RList);
            RList = notinsertedList;
            
        }

        private bool CanUpdate()
        {
            return RList.Count > 0;
        }

        private void GetData()
        {
            RegistrationUpdaterDb db = new RegistrationUpdaterDb();
            RList = db.GetRegistrationData(cls: SclClass[SclClassIndex], section: SclSection[SclSectionIndex], startYear: StartYear, endYear: EndYear);
        }

        private bool CanGetData()
        {
            return SclClassIndex != -1 && SclSectionIndex != -1;
        }
    }
}
