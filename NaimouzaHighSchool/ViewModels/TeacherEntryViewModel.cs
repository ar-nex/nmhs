using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;


namespace NaimouzaHighSchool.ViewModels
{
    public class TeacherEntryViewModel : BaseViewModel
    {
        public TeacherEntryViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private Visibility _addBtnVisibility;
        public Visibility AddBtnVisibility
        {
            get => _addBtnVisibility;
            set
            {
                _addBtnVisibility = value;
                OnPropertyChanged("AddBtnVisibility");
            }
        }

        private string _teacherName;
        public string TeacherName
        {
            get => _teacherName;
            set
            {
                if (value != null)
                {
                    _teacherName = value.ToUpper();
                }
                OnPropertyChanged("TeacherName");
            }
        }

        private string _teacherSubject;
        public string TeacherSubject
        {
            get => _teacherSubject;
            set
            {
                if (value != null)
                {
                    _teacherSubject = value.ToUpper();
                }
                OnPropertyChanged("TeacherSubject");
            }
        }

        private ObservableCollection<string> _subjects;
        public ObservableCollection<string> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged("Subjects");
            }
        }

        private int _subjectsIndex;
        public int SubjectsIndex
        {
            get => _subjectsIndex;
            set
            {
                _subjectsIndex = value;
                OnPropertyChanged("SubjectsIndex");
            }
        }

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

        private string _teacherPassword;
        public string TeacherPassword
        {
            get => _teacherPassword;
            set
            {
                _teacherPassword = value;
                OnPropertyChanged("TeacherPassword");
            }
        }

        private bool _forAdd;

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommandWithParam DeleteCommand { get; set; }

        private void StartUpInitializer()
        {
            TeacherEntryDb db = new TeacherEntryDb();
            AddBtnVisibility = Visibility.Hidden;
            _forAdd = true;
            Subjects = new ObservableCollection<string>();
            TeacherList = new ObservableCollection<Teacher>();
            SubjectsIndex = -1;
            Subjects = db.GetSubjectList();
            TeacherList = db.GetTeacherList();
            SaveCommand = new RelayCommand(Save, CanSave);
            AddCommand = new RelayCommand(Add, CanAdd);
            DeleteCommand = new RelayCommandWithParam(DeleteTeacher, CanDeleteTeacher);
        }

        private void Save()
        {
            if (_forAdd)
            {
                Teacher t = new Teacher();
                t.Name = TeacherName;
                t.Subject = TeacherSubject;
                t.Password = TeacherPassword;
                t.PasswordHash = GetPasswordHash(TeacherPassword);
                TeacherEntryDb db = new TeacherEntryDb();
                int r = db.InsertTeacher(t);
                if (r > 0)
                {
                    TeacherName = string.Empty;
                    TeacherPassword = string.Empty;
                    SubjectsIndex = -1;
                    TeacherSubject = string.Empty;

                    UpdateList();
                }
                else
                {
                    MessageBox.Show("Sorry! Some problem occured.");
                }
            }
            else
            {

            }
        }

        private string GetPasswordHash(string teacherPassword)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                // convert the input string into byte array and compute the hash
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(teacherPassword));
          
                // loop through each byte of the hashed data and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            return sBuilder.ToString();
        }

        private bool CanSave()
        {
            if (_forAdd)
            {
                return !string.IsNullOrEmpty(TeacherName) && !string.IsNullOrEmpty(TeacherSubject) && !string.IsNullOrEmpty(TeacherPassword) && (TeacherPassword.Length > 4);
            }
            else
            {
                return false;
            }
        }

        private void Add()
        {
            _forAdd = true;
        }

        private bool CanAdd()
        {
            return true;
        }

        private void DeleteTeacher(object parameter)
        {
            TeacherEntryDb db = new TeacherEntryDb();
            Teacher t = (Teacher)parameter;
            int r = db.DeleteTeacher(t.Id);
            if (r == 0)
            {
                MessageBox.Show("Problem in deleting Teacher.");
            }
            else
            {
                UpdateList();
            }
        }
        private bool CanDeleteTeacher()
        {
            return true;
        }

        private void UpdateList()
        {
            TeacherEntryDb db = new TeacherEntryDb();
            Subjects = db.GetSubjectList();
            TeacherList = db.GetTeacherList();
        }
    }
}
