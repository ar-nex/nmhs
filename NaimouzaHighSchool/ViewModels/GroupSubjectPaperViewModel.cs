using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class GroupSubjectPaperViewModel:BaseViewModel
    {
        public GroupSubjectPaperViewModel()
        :base()
        {
            this.StartUpInitilize();
        }

        #region fields
        private ObservableCollection<string> _groups;
        private ObservableCollection<Subject> _subList;
        private ObservableCollection<SubjectGroup> _sbGroups;

        private string _txbGroup;
        private bool _txbGroupReadOnly;
        private int _selectedGroupIndex;
        private bool _addEditFlag;
        private string _cmbSelectedSubGroup1;
        private string _comboBelongingGroup;
        private string _txbSelectedSub1;
        private string _txbShortName1;
        private bool _isEntryEnable;
        private string _txbSubName;
        private string _txbShortName;
        private ObservableCollection<string> _subNames;
        public enum _saveIndicator { None, Add, Edit };
        public _saveIndicator _sindi;
        public enum subSaveIndicator { None, Add, Edit};
        public subSaveIndicator _subSindi;
        

        //hold the old grpname for the purpose of updating it.
        private string _oldGrpName;
        //hold the old sub name



        private bool _istxbSubReadOnly;
        private bool _isComboHitVisible;
     
        
        #endregion

        #region property
       
        public ObservableCollection<string> Groups
        {
            get { return _groups; }
            set { _groups = value; this.OnPropertyChanged("Groups"); }
        }
        public string TxbGroup
        {
            get { return _txbGroup; }
            set { _txbGroup = value; this.OnPropertyChanged(String.Empty); }
        }
        public bool TxbGroupReadOnly
        {
            get { return _txbGroupReadOnly; }
            set { _txbGroupReadOnly = value; this.OnPropertyChanged("TxbGroupReadOnly"); }
        }  
        public int SelectedGroupIndex
        {
            get { return _selectedGroupIndex; }
            set { _selectedGroupIndex = value; this.OnPropertyChanged("SelectedGroupIndex"); }
        }
        public bool AddEditFlag
        {
            get { return _addEditFlag; }
            set { _addEditFlag = value; this.OnPropertyChanged("AddEditFlag"); }
        }
        public _saveIndicator Sindi
        {
            get { return _sindi; }
            set { _sindi = value; this.OnPropertyChanged("Sindi"); }
        }
        public subSaveIndicator SubSindi
        {
            get { return _subSindi; }
            set { _subSindi = value; this.OnPropertyChanged("SubSindi"); }
        }

        public ObservableCollection<Subject> SubList
        {
            get { return _subList; }
            set { _subList = value; this.OnPropertyChanged("SubList"); }
        }
        public ObservableCollection<SubjectGroup> SbGroups
        {
            get { return _sbGroups; }
            set { _sbGroups = value; this.OnPropertyChanged("SbGroups"); }
        }

        public string CmbSelectedSubGroup1
        {
            get { return _cmbSelectedSubGroup1; }
            set
            {
                this._cmbSelectedSubGroup1 = value;
                this.TxbShortName1 = "";
                this.SubNames.Clear();
                if (!string.IsNullOrEmpty(value))
                {
                    var sb = from s in this.SubList
                         where s.BelongingGroup == value
                         select s.SubName;
                    foreach (string item in sb)
                    {
                        this.SubNames.Add(item);
                    }
                }
                this.OnPropertyChanged("CmbSelectedSubGroup1");
            }
        }
        public ObservableCollection<string> SubNames
        {
            get { return _subNames; }
            set 
            { 
                _subNames = value;
                this.OnPropertyChanged("SubNames"); 
            }
        }
        public string TxbSelectedSub1
        {
            get { return _txbSelectedSub1; }
            set 
            {
                this._txbSelectedSub1 = value;
                var sb = from s in this.SubList
                         where s.SubName == value
                         select s.ShortName;
                foreach (string item in sb)
                {
                    this.TxbShortName1 = item;
                }
            }
        }
        public string TxbShortName1
        {
            get { return _txbShortName1; }
            set { _txbShortName1 = value; this.OnPropertyChanged("TxbShortName1"); }
        }
        public bool IsEntryEnable
        {
            get { return _isEntryEnable; }
            set { _isEntryEnable = value; this.OnPropertyChanged("IsEntryEnable"); }
        }



        public string TxbSubName
        {
            get { return _txbSubName; }
            set { _txbSubName = value; this.OnPropertyChanged("TxbSubName"); }
        }
        public string TxbShortName
        {
            get { return _txbShortName; }
            set { _txbShortName = value; this.OnPropertyChanged("TxbShortName"); }
        }
        public string ComboBelongingGroup
        {
            get { return _comboBelongingGroup; }
            set { _comboBelongingGroup = value; this.OnPropertyChanged("CombobelongingGroup"); }
        }
        public bool IsTxbSubReadOnly
        {
            get { return _istxbSubReadOnly; }
            set { _istxbSubReadOnly = value; this.OnPropertyChanged("IsTxbSubReadOnly"); }
        }
        public bool IsComboHitVisible
        {
            get { return _isComboHitVisible; }
            set { _isComboHitVisible = value; this.OnPropertyChanged("IsComboHitVisible"); }
        }

        private int _selectedGroupIndex2;
        public int SelectedGroupIndex2
        {
            get { return this._selectedGroupIndex2; }
            set 
            { 
                this._selectedGroupIndex2 = value;
                this.CmbSelectedSubGroup1 = (value > -1) ? this.Groups[value] : string.Empty;
                this.OnPropertyChanged("SelectedGroupIndex2");
            }
        }

        private int _comboBelongingGroupIndex;
        public int ComboBelongingGroupIndex
        {
            get { return this._comboBelongingGroupIndex; }
            set 
            {
                this._comboBelongingGroupIndex = value;
                this.ComboBelongingGroup = (value > -1) ? this.Groups[value] : string.Empty;
                this.OnPropertyChanged("ComboBelongingGroupIndex");
            }
        }

        public RelayCommand CommandAddGroup { get; set; }
        public RelayCommand CommandEditGroup { get; set; }
        public RelayCommand CommandSaveGroup { get; set; }
        public RelayCommand CommandDeleteGroup { get; set; }

        public RelayCommand CommandAddSub { get; set; }
        public RelayCommand CommandEditSub { get; set; }
        public RelayCommand CommandSaveSub { get; set; }
        public RelayCommand CommandDeleteSub { get; set; }
        public RelayCommand CommandTestSub { get; set; }
   
        private SubjectGroupDb db { get; set; }
        #endregion

        #region Methods
        private void StartUpInitilize()
        {
           
            db = new SubjectGroupDb();
            List<string> grList = new List<string>();
            grList = db.GetGroups();
            Groups = new ObservableCollection<string>(grList);
            
            SbGroups = new ObservableCollection<SubjectGroup>();
            List<Subject> sbListFromDb = new List<Subject>();
            
            sbListFromDb = db.GetSubjects();
            SubList = new ObservableCollection<Subject>(sbListFromDb);
            SbGroups = this.CreateSubjectGroup(Groups, SubList);
          
            this.TxbGroupReadOnly = true;
           
            this.Sindi = _saveIndicator.None;
            this.SubSindi = subSaveIndicator.None;

            this.SubNames = new ObservableCollection<string>();
            this.SelectedGroupIndex2 = -1;
            this.ComboBelongingGroupIndex = -1;

            #region commands
            CommandAddGroup = new RelayCommand(this.AddGroup, this.CanAddGroup);
            CommandEditGroup = new RelayCommand(this.EditGroup, this.CanEditGroup);
            CommandSaveGroup = new RelayCommand(this.SaveGroup, this.CanSaveGroup);
            CommandDeleteGroup = new RelayCommand(this.DeleteGroup, this.CanDeleteGroup);

            CommandAddSub = new RelayCommand(this.AddSub, this.CanAddSub);
            CommandEditSub = new RelayCommand(this.EditSub, this.CanEditSub);
            CommandSaveSub = new RelayCommand(this.SaveSub, this.CanSaveSub);
            CommandDeleteSub = new RelayCommand(this.DeleteSub, this.CanDeleteSub);
            CommandTestSub = new RelayCommand(this.TestSub, this.CanTestSub);
            #endregion
        }


        private ObservableCollection<SubjectGroup> CreateSubjectGroup(ObservableCollection<string> grps, ObservableCollection<Subject> sbs )
        {
            ObservableCollection<SubjectGroup> sGrp = new ObservableCollection<SubjectGroup>();
            if (grps.Count > 0)
            {
                foreach (string item in grps)
                {
                    SubjectGroup sg = new SubjectGroup();
                    sg.GroupTitle = item;
                    
                    ObservableCollection<Subject> sobser = new ObservableCollection<Subject>();
                    var sbTemp = from s in sbs
                                     where s.BelongingGroup == item
                                     select s;
                    foreach (Subject itemSb in sbTemp)
                    {
                        sobser.Add(itemSb);
                    }
                    sg.SubsList = sobser;
                    sGrp.Add(sg);
                }
                
            }
            return sGrp;
        }

        private bool CanAddGroup()
        {
            return true;
        }
        private void AddGroup()
        {
            this.TxbGroup = "";
            this.TxbGroupReadOnly = false;
            this.SelectedGroupIndex = -1;
            Sindi = _saveIndicator.Add;
            
        }
        private bool CanEditGroup()
        {
            return (this.SelectedGroupIndex > -1) ? true : false;
        }
        private void EditGroup()
        {
            Sindi = _saveIndicator.Edit;
            TxbGroupReadOnly = false;
            //hold the old value;
            this._oldGrpName = this.TxbGroup;
        }
        private bool CanSaveGroup()
        {
            bool rt = false;
            switch (Sindi)
            {
                case _saveIndicator.None:
                    rt = false;
                    break;
                case _saveIndicator.Add:
                    
                    bool rt1 = (String.IsNullOrWhiteSpace(this.TxbGroup)) ? false : true;
                    if (!rt1)
                    {
                        rt = rt1;                     
                    }
                    else
                    { 
                        rt = !this.Groups.Contains(this.TxbGroup);
                    }
                    break;
                case _saveIndicator.Edit:
                    rt = !this.Groups.Contains(this.TxbGroup);
                    break;
                default:
                    break;
            }
           
            return rt;
        }
        private void SaveGroup()
        {
            if (Sindi == _saveIndicator.Add)
            {
                bool grpIntered = String.IsNullOrWhiteSpace(this.TxbGroup) ? false : true;
                bool grpExist = this.Groups.Contains(this.TxbGroup);
                if (grpIntered && !grpExist)
                {
                    bool inserted = db.InsertGroup(this.TxbGroup);
                    if (inserted)
                    {
                        this.Groups.Add(this.TxbGroup);
                        //update the subject container group
                        SubjectGroup sgNew = new SubjectGroup();
                        sgNew.GroupTitle = this.TxbGroup;
                        SbGroups.Add(sgNew);
                    }
                }
            }
            else if(Sindi == _saveIndicator.Edit)
            {
                string newGrpName = TxbGroup;
                if (_oldGrpName != newGrpName)
                {
                    bool updated = db.UpdateGroup(_oldGrpName, newGrpName);
                    if (updated)
                    {
                        System.Windows.MessageBox.Show("Updated");
                        int oldIndex = Groups.IndexOf(_oldGrpName);
                        Groups.Remove(_oldGrpName);
                        Groups.Insert(oldIndex, TxbGroup);                      
                        //update the subject-group container
                        foreach (SubjectGroup item in SbGroups)
                        {
                           
                            if (item.GroupTitle == _oldGrpName)
                            {
                                item.GroupTitle = newGrpName;
                                return;
                            }
                        }
                        _oldGrpName = null;

                    }
                }
            }
            this.Sindi = _saveIndicator.None;
        }
       
        // Group can only be deleted it is selected and it contains no subject
        private bool CanDeleteGroup()
        {
            bool isSelected = (this.SelectedGroupIndex > -1) ? true : false;
            if (isSelected)
            {
                string selGrp = TxbGroup;
                foreach (SubjectGroup item in SbGroups)
                {
                    if (item.GroupTitle == selGrp)
                    {
                        int noOfSubs = item.SubsList.Count;
                        return (noOfSubs == 0) ? true : false;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }


        }
        private void DeleteGroup()
        {
            if (!String.IsNullOrWhiteSpace(TxbGroup))
            {
                bool deleted = db.DeleteGroup(TxbGroup);
                if (deleted)
                {
                    Groups.Remove(TxbGroup);
                }
            }
            Sindi = _saveIndicator.None;
        }

        private bool CanAddSub()
        {
            return (Groups.Count > 0) ? true : false;
        }
        private void AddSub()
        {
            //this.CloneSelectedSubject = new Subject();
            //this.IsTxbSubReadOnly = false;
            //this.IsComboHitVisible = true;
            this.IsEntryEnable = true;
            SubSindi = subSaveIndicator.Add;
        }

        private bool CanEditSub()
        {

 
            if (string.IsNullOrWhiteSpace(this.CmbSelectedSubGroup1) || string.IsNullOrWhiteSpace(this.TxbSelectedSub1) || string.IsNullOrWhiteSpace(this.TxbShortName1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void EditSub()
        {
            this.IsEntryEnable = true;
            this.SubSindi = subSaveIndicator.Edit;
            this.ResetNewSubVal();
        }

        private bool CanSaveSub()
        {
            bool rs = false;
            switch (SubSindi)
            {
                case subSaveIndicator.None:
                    rs = false;
                    break;
                case subSaveIndicator.Add:
                    rs = this.CanEnableSaveBtn();
                    break;
                case subSaveIndicator.Edit:                   
                    rs = this.CanEnableEditSaveBtn();
                    break;
                default:
                    break;
            }
            return rs;
        }

        private bool CanTestSub()
        {
            return true;
        }
        private void TestSub()
        {
            
        }
        
        // there is sub in the save after edit regarding selected subject.
        private void SaveSub()
        {
            Subject CloneSubject = new Subject();
            if (SubSindi == subSaveIndicator.Add)
            {
                CloneSubject.SubName = this.TxbSubName;
                CloneSubject.ShortName = this.TxbShortName;
                CloneSubject.BelongingGroup = this.ComboBelongingGroup;

                bool inserted = db.InsertSubject(CloneSubject);
                if (inserted)
                {
                    //update the subject in view
                    var sbGrTemp = from s in this.SbGroups
                                   where s.GroupTitle == CloneSubject.BelongingGroup
                                   select s;
                    foreach (SubjectGroup item in sbGrTemp)
                    {
                        item.SubsList.Add(CloneSubject);
                    }
                    CloneSubject = null;
                    TxbSubName = String.Empty;
                    TxbShortName = String.Empty;
                    //ComboBelongingGroup = String.Empty;
                    this.IsEntryEnable = false;
                }
            }
            else if (SubSindi == subSaveIndicator.Edit)
            {
                CloneSubject.SubName = TxbSelectedSub1;
                CloneSubject.ShortName = TxbShortName1;
                CloneSubject.BelongingGroup = CmbSelectedSubGroup1;
                foreach (SubjectGroup itemGr in SbGroups)
                {
                    bool findFlag = false;
                    foreach (Subject itemSb in itemGr.SubsList)
                    {
                        if (itemSb.SubName == CloneSubject.SubName && itemSb.ShortName == CloneSubject.ShortName && itemSb.BelongingGroup == CloneSubject.BelongingGroup)
                        {
                            CloneSubject.ID = itemSb.ID;
                            findFlag = true;
                            break;
                        }
                    }
                    if (findFlag)
                    {
                        break;
                    }
                }
                //update the clone vals
                CloneSubject.BelongingGroup = ComboBelongingGroup;
                CloneSubject.SubName = TxbSubName;
                CloneSubject.ShortName = TxbShortName;

                bool hasUpdated = db.UpdateSub(CloneSubject);
                if (hasUpdated)
                {
                    // same grp or not
                    if (this.CmbSelectedSubGroup1 == this.ComboBelongingGroup)
                    {
                        var sb = from s in this.SubList
                                       where s.BelongingGroup == this.CmbSelectedSubGroup1
                                       where s.SubName == this.TxbSelectedSub1
                                       where s.ShortName == this.TxbShortName1
                                       select s;
                        foreach (Subject Sitem in sb)
                        {
                            Sitem.BelongingGroup = ComboBelongingGroup;
                            Sitem.SubName = TxbSubName;
                            Sitem.ShortName = TxbShortName;
                        }
                    }
                    else 
                    { 
                     // remove old one
                                                
                            foreach (SubjectGroup itemGr in SbGroups)
                            {
                                bool findFlag = false;
                                foreach (Subject itemSb in itemGr.SubsList)
                                {
                                    if (itemSb.ID == CloneSubject.ID )
                                    {
                                        itemGr.SubsList.Remove(itemSb);
                                        findFlag = true;
                                        break;
                                    }
                                }
                                if (findFlag)
                                {
                                    break;
                                }
                            }
                            
                        

                     // insert new one
                            foreach (SubjectGroup itemGr in SbGroups)
                            {
                                
                                if (itemGr.GroupTitle == CloneSubject.BelongingGroup)
                                {
                                    itemGr.SubsList.Add(CloneSubject);
                                    break;
                                }
                               
                            }

                    }
                    this.ResetNewSubVal();
                    this.ResetOldSubVal();
                    this.SubSindi = subSaveIndicator.None;
                }
            }
        }



        private bool CanDeleteSub()
        {
            if (string.IsNullOrWhiteSpace(this.CmbSelectedSubGroup1) || string.IsNullOrWhiteSpace(this.TxbSelectedSub1) || string.IsNullOrWhiteSpace(this.TxbShortName1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DeleteSub()
        {
            string sbjId = string.Empty;
            foreach (SubjectGroup itemGr in SbGroups)
            {
                bool findFlag = false;
                foreach (Subject itemSb in itemGr.SubsList)
                {
                    if (itemSb.SubName == this.TxbSelectedSub1)
                    {
                        sbjId = itemSb.ID;
                        findFlag = true;
                        break;
                    }
                }
                if (findFlag)
                {
                    break;
                }
            }
            if (!string.IsNullOrEmpty(sbjId))
            {
                if (db.DeleteSubject(sbjId))
                {
                    foreach (SubjectGroup itemGr in SbGroups)
                    {
                        bool removeFlag = false;
                        foreach (Subject itemSb in itemGr.SubsList)
                        {
                            if (itemSb.ID == sbjId)
                            {
                                itemGr.SubsList.Remove(itemSb);
                                removeFlag = true;
                                break;
                            }
                        }
                        if (removeFlag)
                        {
                            break;
                        }
                    }
                    this.ResetOldSubVal();
                }    
            }

           
        }
        private bool CanEnableSaveBtn()
        {
            bool rs = false;
            if (String.IsNullOrWhiteSpace(TxbSubName) || String.IsNullOrWhiteSpace(TxbShortName))
            {
                rs = false;
                return rs;
            }
            else if (this.isSubExist(TxbSubName) || this.isShortExist(TxbShortName))
            {
                rs = false;
                return rs;
            }
            else if (String.IsNullOrWhiteSpace(this.ComboBelongingGroup))
            {
                rs = false;
                return rs;
            }
            else
            {
                rs = true;
            }
            return rs;
        }
        private bool CanEnableEditSaveBtn()
        {
            bool rs = false;
            if (String.IsNullOrWhiteSpace(TxbSubName) || String.IsNullOrWhiteSpace(TxbShortName))
            {
                rs = false;
                return rs;
            }
            //else if (this.isSubExist(TxbSubName) || this.isShortExist(TxbShortName))
            //{
            //    rs = false;
            //    return rs;
            //}
            //else if (String.IsNullOrWhiteSpace(this.ComboBelongingGroup))
            //{
            //    rs = false;
            //    return rs;
            //}
            else
            {
                rs = true;
            }
            return rs;
        }
        private bool isSubExist(string newSb)
        {
            bool sbExist = false;
            foreach (SubjectGroup itemGr in SbGroups)
            {
                bool findFlag = false;
                foreach (Subject itemSb in itemGr.SubsList)
                {
                    if (itemSb.SubName == newSb)
                    {
                        sbExist = true;
                        findFlag = true;
                        break;
                    }
                }
                if (findFlag)
                {
                    break;
                }
            }
            return sbExist;
        }
        private bool isShortExist(string newShort)
        {
            bool shrtExist = false;
            foreach (SubjectGroup itemGr in SbGroups)
            {
                bool findFlag = false;
                foreach (Subject itemSb in itemGr.SubsList)
                {
                    if (itemSb.ShortName == newShort)
                    {
                        shrtExist = true;
                        findFlag = true;
                        break;
                    }
                }
                if (findFlag)
                {
                    break;
                }
            }
            return shrtExist;
        }

        private void ResetNewSubVal()
        {
            this.ComboBelongingGroupIndex = -1;
            this.TxbSubName = string.Empty;
            this.TxbShortName = string.Empty;
        }

        private void ResetOldSubVal()
        {
            this.SelectedGroupIndex2 = -1;
        }

        #endregion
    }
}
