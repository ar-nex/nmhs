using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class DeleteViewModel : BaseViewModel
    {
        public DeleteViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        #region property

        private string[] _schoolClasses;
        public string[] SchoolClasses
        {
            get { return this._schoolClasses; }
            set { this._schoolClasses = value; this.OnPropertyChanged("SchoolClasses"); }
        }

        private int _schoolClassesIndex;
        public int SchoolClassesIndex
        {
            get { return this._schoolClassesIndex; }
            set 
            {
                this._schoolClassesIndex = value;
                this.UpdateMessage1();
                this.OnPropertyChanged("SchoolClassesIndex");
            }
        }

        private string[] _schoolSections;
        public string[] SchoolSections
        {
            get { return this._schoolSections; }
            set { this._schoolSections = value; this.OnPropertyChanged("SchoolSections"); }
        }

        private int _schoolSectionsIndex;
        public int SchoolSectionsIndex
        {
            get { return this._schoolSectionsIndex; }
            set 
            {
                this._schoolSectionsIndex = value;
                this.UpdateMessage1();
                this.OnPropertyChanged("SchoolSectionsIndex");
            }
        }

        private int _totalStudents;
        public int TotalStudents
        {
            get { return this._totalStudents; }
            set { this._totalStudents = value; this.OnPropertyChanged("TotalStudents"); }
        }

        private string _message;
        public string Message
        {
            get { return this._message; }
            set { this._message = value; this.OnPropertyChanged("Message"); }
        }

        private int _schoolClassesSpecificIndex;
        public int SchoolClassesSpecificIndex
        {
            get { return this._schoolClassesSpecificIndex; }
            set 
            { 
                this._schoolClassesSpecificIndex = value; 
                this.OnPropertyChanged("SchoolClassesSpecificIndex");
               
            }
        }

        private int _schoolSectionsSpecificIndex;
        public int SchoolSectionsSpecificIndex
        {
            get { return this._schoolSectionsSpecificIndex; }
            set 
            { 
                this._schoolSectionsSpecificIndex = value; 
                this.OnPropertyChanged("SchoolSectionsSpecificIndex");
               
            }
        }

        private int _totalSpecificStudents;
        public int TotalSpecificStudents
        {
            get { return this._totalSpecificStudents; }
            set { this._totalSpecificStudents = value; this.OnPropertyChanged("TotalSpecificStudents"); }
        }

        private string _messageSpecific;
        public string MessageSpecific
        {
            get { return this._messageSpecific; }
            set { this._messageSpecific = value; this.OnPropertyChanged("MessageSpecific"); }
        }

        private int _roll;
        public int Roll
        {
            get { return this._roll; }
            set { this._roll = value; this.OnPropertyChanged("Roll"); }
        }

        private ObservableCollection<MicroStdInfo> _mlist;
        public ObservableCollection<MicroStdInfo> Mlist
        {
            get { return this._mlist; }
            set { this._mlist = value; this.OnPropertyChanged("Mlist"); }
        }

        private DeleteDb db { get; set; }
        public RelayCommand DeleteClassWiseCommand { get; set; }
        public RelayCommand DeleteSpecificCommand { get; set; }
        public RelayCommand UpdateMlistCommand { get; set; }
        
        #endregion

        #region method
        private void StartUpInitializer()
        {
            this.SchoolClasses = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" };
            this.SchoolSections = new string[] { "A", "B", "C", "D", "E" };

            this.SchoolClassesIndex = -1;
            this.SchoolSectionsIndex = -1;
            this.SchoolClassesSpecificIndex = -1;
            this.SchoolSectionsSpecificIndex = -1;

            this.MessageSpecific = "No student is selected.";
            this.Message = "No class is selected.";

            this.Mlist = new ObservableCollection<MicroStdInfo>();
            this.db = new DeleteDb();

            
            this.DeleteClassWiseCommand = new RelayCommand(this.DeleteClassWise, this.CanDeleteClassWise);
            this.DeleteSpecificCommand = new RelayCommand(this.DeleteSpecific, this.CanDeleteSpecific);
            this.UpdateMlistCommand = new RelayCommand(this.UpdateMlist, this.CanUpdateMlist);

        }

        private void DeleteClassWise()
        {
            int syear = DateTime.Today.Year;
            int eyear = DateTime.Today.Year;
            bool deleted = this.db.DeleteStudents(this.SchoolClasses[this.SchoolClassesIndex], this.SchoolSections[this.SchoolSectionsIndex], syear, eyear);
            if (deleted)
            {
                System.Windows.MessageBox.Show("deleted");
            }
            else
            {
                System.Windows.MessageBox.Show("Failed");
            }
        }

        private bool CanDeleteClassWise()
        {
            return this.TotalStudents > 0;
        }

        private void DeleteSpecific()
        {
            var mitem = from m in this.Mlist
                        where m.IsSelected == true
                        select m;
            List<string> ids = new List<string>();
            foreach (MicroStdInfo item in mitem)
            {
                ids.Add(item.Id);
            }
            if (ids.Count == 0)
            {
                System.Windows.MessageBox.Show("There is no item to be deleted.");
                return;
            }
            else
            {
                if (db.DeleteSpecific(ids))
                {
                    System.Windows.MessageBox.Show("deleted");
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed.");
                }
            }
        }

        private bool CanDeleteSpecific()
        {
            //return this.TotalSpecificStudents > 0;
            
            
            return true;
        }

        private void GetSpecific()
        { 
        
        }

        private bool CanGetSpecific()
        { 
            return (this.SchoolSectionsSpecificIndex > -1 && this.SchoolClassesSpecificIndex > -1);
        }

        private void UpdateMessage1()
        {
            if (this.SchoolClassesIndex == -1 || this.SchoolSectionsIndex == -1)
            {
                return;
            }
            else
            {
                int syear = DateTime.Today.Year;
                int eyear = DateTime.Today.Year;
                int n = db.GetTotalStudents(this.SchoolClasses[this.SchoolClassesIndex], this.SchoolSections[this.SchoolSectionsIndex], syear, eyear);
                string msg = "Class " + this.SchoolClasses[this.SchoolClassesIndex] + "-" + this.SchoolSections[this.SchoolSectionsIndex] + " has "+n.ToString()+" students.";
                this.Message = msg;
                this.TotalStudents = n;
            }
        }

        private void UpdateMlist()
        {
            int syear = DateTime.Today.Year;
            int eyear = DateTime.Today.Year;

            if (this.SchoolSectionsSpecificIndex > -1 && this.SchoolClassesSpecificIndex > -1 && this.Roll > 0)
            {
                
                ObservableCollection<MicroStdInfo> ml = new ObservableCollection<MicroStdInfo>(db.GetStudentsSpecific(this.SchoolClasses[this.SchoolClassesSpecificIndex], this.SchoolSections[this.SchoolSectionsSpecificIndex], this.Roll, syear, eyear));
                this.Mlist = ml;
            }
            else if (this.SchoolSectionsSpecificIndex > -1 && this.SchoolClassesSpecificIndex > -1 && this.Roll == 0)
            {
                ObservableCollection<MicroStdInfo> ml = new ObservableCollection<MicroStdInfo>(db.GetStudentsSpecific(this.SchoolClasses[this.SchoolClassesSpecificIndex], this.SchoolSections[this.SchoolSectionsSpecificIndex], syear, eyear));
                this.Mlist = ml;
            }
            else
            {
                return;
            }

            
        }

        private bool CanUpdateMlist()
        {
            return !(this.SchoolClassesSpecificIndex == -1 || this.SchoolSectionsSpecificIndex == -1);
        }

       
        #endregion
    }
}
