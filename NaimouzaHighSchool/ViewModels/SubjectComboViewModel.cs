using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class SubjectComboViewModel : BaseViewModel
    {
        public SubjectComboViewModel()
        :base()
        {
            this.StartUpInitialize();
        }

        #region field & property
       
        private ObservableCollection<SubjectCombo> _parentScombo;
        /// <summary>
        /// Contains all the combinations Names (code) containing their codename, id and belonging class This is not shown in the interface.
        /// Deos not contains Subject.
        /// </summary>
        public ObservableCollection<SubjectCombo> ParentScombo
        {
            get { return _parentScombo; }
            set
            {
                _parentScombo = value;

                this.OnPropertyChanged("ParentScombo");
            }
        }
 
        private ObservableCollection<SubjectCombo> _scomboByClass;
        /// <summary>
        /// Filtered combination name according to the class selected by the user and displayed after selection of class. Generated from ParentScombo.
        /// Does not contain Subject.
        /// </summary>
        public ObservableCollection<SubjectCombo> ScomboByClass
        {
            get { return _scomboByClass; }
            set
            {
                _scomboByClass = value;
                this.OnPropertyChanged("ScomboByClass");
            }
        }

        private int _selectedComboIndex;
        /// <summary>
        /// Contains index of the Selected combo of the list of CombobyClass.
        /// </summary>
        public int SelectedComboIndex
        {
            get { return _selectedComboIndex; }
            set
            {
                _selectedComboIndex = value;
                if (value > -1)
                {
                    this.UpdateSubjectSelection();
                    this.TxbComboText = this.ScomboByClass[value].Code;
                }
                else
                {
                    this.TxbComboText = string.Empty;
                }
                this.OnPropertyChanged("SelectedComboIndex");
            }
        }

        private bool _isTxbComboReadOnly;
        /// <summary>
        /// For adding and Editing Textbox is not readonly otherwise readonly
        /// </summary>
        public bool IsTxbComboReadOnly
        {
            get { return _isTxbComboReadOnly; }
            set { _isTxbComboReadOnly = value; this.OnPropertyChanged("IsTxbComboReadOnly"); }
        }

        private string _txbComboText;
        /// <summary>
        /// Contains the text of Combo Name of seleted and get the new combo name
        /// </summary>
        public string TxbComboText
        {
            get { return _txbComboText; }
            set { _txbComboText = value; this.OnPropertyChanged("TxbComboText"); }
        }

        private List<CombSubPair> _csPair;
        /// <summary>
        /// Holds All the Subject and Combination Name (code) pair.
        /// </summary>
        public List<CombSubPair> CsPair
        {
            get { return _csPair; }
            set { _csPair = value; }
        }
       
        private string _classOfCombo;
        /// <summary>
        /// Selected Class (of school) in the interface
        /// </summary>
        public string ClassOfCombo
        {
            get { return _classOfCombo; }
            set
            {
                _classOfCombo = value;
                this.UpdateComboByClass(value);
                this.SublistNotSelected.Clear();
                this.SublistSelected.Clear();
                this.OnPropertyChanged("ClassOfCombo");
            }
        }
       
        private ObservableCollection<Subject> _subList;
        /// <summary>
        /// Contains all the Subjects stored in the database. Parents of _subListNotSelected & _subListSelected.
        /// </summary>
        public ObservableCollection<Subject> SubList
        {
            get { return _subList; }
            set { _subList = value; this.OnPropertyChanged("SubList"); }
        }
   
        private ObservableCollection<string> _subListNotSelected;
        /// <summary>
        /// Subjects' names which are not included in the current combination.
        /// </summary>
        public ObservableCollection<string> SublistNotSelected
        {
            get { return _subListNotSelected; }
            set { _subListNotSelected = value; this.OnPropertyChanged("SubListNotSelected"); }
        }
      
        private ObservableCollection<string> _subListSelected;
        /// <summary>
        /// Subjects' names which are included in the current combination.
        /// </summary>
        public ObservableCollection<string> SublistSelected
        {
            get { return _subListSelected; }
            set { _subListSelected = value; this.OnPropertyChanged("SubListSelected"); }
        }
                
        private int _indexNotSelected;
        /// <summary>
        /// Contains the index no. of list of not included subjects. Default val. is -1.
        /// </summary>
        public int IndexNotSelected
        {
            get { return _indexNotSelected; }
            set { _indexNotSelected = value; this.OnPropertyChanged("IndexNotSelected"); }
        }
        
        private int _indexSelected;
        /// <summary>
        /// Contains the index no. of list of included subjects. Default val. is -1.
        /// </summary>
        public int IndexSelected
        {
            get { return _indexSelected; }
            set { _indexSelected = value; this.OnPropertyChanged("IndexSelected"); }
        }

        private enum _saveIndicator { None, Add, Edit };
        private _saveIndicator _sindi;

        #endregion

        #region property
        
        public string[] ClassNames { get; set; }
        private SubjectComboDb db { get; set; }

        #region commands
        public RelayCommand CommandAddInSelection { get; set; }
        public RelayCommand CommandRemoveFromSelection { get; set; }
        public RelayCommand CommandAddCombo { get; set; }
        public RelayCommand CommandEditCombo { get; set; }
        public RelayCommand CommandSaveCombo { get; set; }
        public RelayCommand CommandDeleteCombo { get; set; }
        #endregion

        #endregion

        #region method
        private void StartUpInitialize()
        {
            this.SublistNotSelected = new ObservableCollection<string>();
            this.SublistSelected = new ObservableCollection<string>();
            this.IndexNotSelected = -1;
            this.IndexSelected = -1;

            this.ClassNames = new string[] { "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};

            db = new SubjectComboDb();
            List<SubjectCombo> cmblist = db.GetCombo();
            this.ParentScombo = new ObservableCollection<SubjectCombo>(cmblist);

            this.CsPair = new List<CombSubPair>();
            CsPair = db.GetCombSubPair();
                      
            this.ScomboByClass = new ObservableCollection<SubjectCombo>();
            this.SubList = new ObservableCollection<Subject>(db.GetSubjects());
            
            this.SelectedComboIndex = -1;
            this.IsTxbComboReadOnly = true;
            this._sindi = _saveIndicator.None;

            this.CommandAddInSelection = new RelayCommand(this.AddInSelected, this.CanAddInSelection);
            this.CommandRemoveFromSelection = new RelayCommand(this.RemoveFromSelected, this.CanRemoveFromSelected);

            this.CommandAddCombo = new RelayCommand(this.AddCombo, this.CanAddCombo);
            this.CommandEditCombo = new RelayCommand(this.EditCombo, this.CanEditCombo);
            this.CommandSaveCombo = new RelayCommand(this.SaveCombo, this.CanSaveCombo);
            this.CommandDeleteCombo = new RelayCommand(this.DeleteCombo, this.CanDeleteCombo);
        }
        
        /// <summary>
        /// Update the observableCollection object holding the name of the subject combo whenever accordingly to the selection of class.
        /// </summary>
        /// <param name="cls">Currently selected class</param>
        private void UpdateComboByClass(string cls)
        {
           
            if (this.ScomboByClass.Count > 0)
            {
                this.ScomboByClass.Clear();
            }
            var scomb = from s in this.ParentScombo
                         where s.BelongingClass == cls
                         select s;
            foreach (SubjectCombo item in scomb)
            {
                this.ScomboByClass.Add(item);
            }
        }



        private void UpdateSubjectSelection()
        {
            
            if (this.SublistSelected.Count > 0)
            {
                this.SublistSelected.Clear();
            }
            if (this.SublistNotSelected.Count > 0)
            {
                this.SublistNotSelected.Clear();
            }

            // Fill list of notselected subs with all available subs and then remove which are being or ware selected before.
            foreach (Subject item in SubList)
            {               
                this.SublistNotSelected.Add(item.SubName);
            }

            SubjectCombo SelectedCombo = this.ScomboByClass[this.SelectedComboIndex];
            var scombo = from s in CsPair
                         where s.CombCode == SelectedCombo.Code
                         select s.SubName;

            foreach (string item in scombo)
            {
                this.SublistSelected.Add(item);
                foreach (string sitem in SublistNotSelected)
                {
                    if (item == sitem)
                    {
                        SublistNotSelected.Remove(sitem);
                        break;
                    }
                }
            }
        }

        private void AddInSelected()
        {
            // add that to the db
            // get sb id
            string slSub = this.SublistNotSelected[this.IndexNotSelected];
            string sbId = "";
            foreach (Subject item in SubList)
            {
                if (slSub == item.SubName)
                {
                    sbId = item.ID;
                    break;
                }
            }
            SubjectCombo SelectedCombo = this.ScomboByClass[this.SelectedComboIndex];
            bool insertedCombo = db.InsertComboSub(SelectedCombo.Code, sbId);
            if (insertedCombo)
            {
                this.SublistNotSelected.Remove(slSub);
                this.SublistSelected.Add(slSub);
                this.IndexNotSelected = -1;
            }
            // remove that from notselected
            // add that to selected.

        }
        private bool CanAddInSelection()
        {
            return (IndexNotSelected > -1) ? true : false;
        }

        private void RemoveFromSelected()
        {
            string slSub = this.SublistSelected[this.IndexSelected];
            string sbId = "";
            foreach (Subject item in SubList)
            {
                if (slSub == item.SubName)
                {
                    sbId = item.ID;
                    break;
                }
            }
            SubjectCombo SelectedCombo = this.ScomboByClass[this.SelectedComboIndex];
            bool deleted = db.RemoveComboSub(SelectedCombo.Code, sbId);
            if (deleted)
            {
                this.SublistSelected.Remove(slSub);
                this.SublistNotSelected.Add(slSub);
                this.IndexSelected = -1;
            }
        }
        private bool CanRemoveFromSelected()
        {
            return (IndexSelected > -1) ? true : false;
        }


        private void AddCombo()
        {
            this.IsTxbComboReadOnly = false;
            this.TxbComboText = string.Empty;
            this._sindi = _saveIndicator.Add;
        }
        private bool CanAddCombo()
        {
            return true;
        }

        private void EditCombo()
        {
            this.IsTxbComboReadOnly = false;
            this._sindi = _saveIndicator.Edit;
        }
        private bool CanEditCombo()
        {
           // return (this.SelectedComboIndex > -1) ? true : false;
            return true;
        }

        private void SaveCombo()
        {
            switch (this._sindi)
            {
                case _saveIndicator.None:
                    break;
                case _saveIndicator.Add:
                    long comboId = db.InsertCombo(this.TxbComboText, this.ClassOfCombo);
                    if (comboId > 0)
                    {
                        this.ParentScombo.Add(new SubjectCombo(comboId.ToString(), this.TxbComboText, this.ClassOfCombo));
                        this.UpdateComboByClass(this.ClassOfCombo);
                        this._sindi = _saveIndicator.None;
                        this.TxbComboText = string.Empty;
                        this.IsTxbComboReadOnly = true;
                    }
                    break;
                case _saveIndicator.Edit:
                    //if (db.UpdateComboCode(new SubjectCombo(this.ScomboByClass[this.SelectedComboIndex].Id, this.TxbComboText, this.ClassOfCombo)))
                    //{
                    //    this.ScomboByClass[this.SelectedComboIndex].Code = this.TxbComboText;
                    //    System.Windows.MessageBox.Show("Updated.");
                    //    this._sindi = _saveIndicator.None;
                    //    this.IsTxbComboReadOnly = true;
                    //}
                    break;
                default:
                    break;
            }
        }
        private bool CanSaveCombo()
        {
            bool rs = false;
            switch (this._sindi)
            {
                case _saveIndicator.None:
                    rs = false;
                    break;
                case _saveIndicator.Add:
                    if (string.IsNullOrWhiteSpace(this.TxbComboText))
                    {
                        rs = false;
                    }
                    else if(this.isComboCodeExist(this.TxbComboText) || string.IsNullOrWhiteSpace(this.ClassOfCombo))
                    {
                        rs = false;
                    }
                    else
                    {
                        rs = true;
                    }
                    break;
                case _saveIndicator.Edit:
                    if (this.isComboCodeExist(this.TxbComboText))
                    {
                        rs = false;
                    }
                    else
                    {
                        rs = true;
                    }
                    break;
                default:
                    break;
            }
            //return rs;
            return true;
        }

        private void DeleteCombo()
        {
            string selectedComboId = this.ScomboByClass[this.SelectedComboIndex].Id;
            if (db.RemoveCombo(selectedComboId))
            {
                int tempIndex = this.SelectedComboIndex;
                this.SelectedComboIndex = -1;
                this.ScomboByClass.RemoveAt(tempIndex);
                this._sindi = _saveIndicator.None;
                this.TxbComboText = string.Empty;
            }
        }
        private bool CanDeleteCombo()
        {
             if (this.SelectedComboIndex < 0)
            {
                return false;
            }
             else if (this.SublistSelected.Count > 0)
             {
                 return false;
             }
             else
             {
                 return true;
             }
        }

        private bool isComboCodeExist(string cd)
        {
            bool rs = false;
            foreach (SubjectCombo item in this.ParentScombo)
            {
                if (item.Code == cd)
                {
                    rs = true;
                    break;
                }
            }
            return rs;
        }
        #endregion
    }
}
