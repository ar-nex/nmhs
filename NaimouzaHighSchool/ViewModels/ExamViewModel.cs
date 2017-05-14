using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;
namespace NaimouzaHighSchool.ViewModels
{
    public class ExamViewModel : BaseViewModel
    {
        public ExamViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        #region property
        private enum buttonClick {none, add, save};
        private buttonClick bclick;
        private ObservableCollection<Exam> _examList;
        public ObservableCollection<Exam> ExamList
        {
            get { return this._examList; }
            set { this._examList = value; this.OnPropertyChanged("ExamList"); }
        }

        private int _examListIndex;
        public int ExamListIndex
        {
            get { return this._examListIndex; }
            set
            {
                this.ExamListIndex = value;
                this.UpdateDetailPane();
                this.OnPropertyChanged("ExamListIndex");
            }
        }

        private string _txbName;
        public string TxbName
        {
            get { return this._txbName; }
            set { this._txbName = value.ToUpper(); this.OnPropertyChanged("TxbName"); }
        }

        private string _txbShortName;
        public string TxbShortName
        {
            get { return this._txbShortName; }
            set { this._txbShortName = value.ToUpper(); this.OnPropertyChanged("TxbShortName"); }
        }

        private int _txbSerialNo;
        public int TxbSerialNo
        {
            get { return this._txbSerialNo; }
            set { this._txbSerialNo = value; this.OnPropertyChanged("TxbSerialNo"); }
        }

        private ExamDb db { get; set; }
        #endregion

        #region Method
        private void StartUpInitializer()
        {
            this.ExamListIndex = -1;
            this.db = new ExamDb();
            this.ExamList = new ObservableCollection<Exam>(db.GetExamList());
        }

        private void UpdateDetailPane()
        {
            if (this.ExamListIndex < 0 || this.ExamListIndex >= this.ExamList.Count)
            {
                this.TxbName = string.Empty;
                this.TxbShortName = string.Empty;
                this.TxbSerialNo = 0;
            }
            else 
            {
                this.TxbName = this.ExamList[this.ExamListIndex].Name;
                this.TxbShortName = this.ExamList[this.ExamListIndex].ShortName;
                this.TxbSerialNo = this.ExamList[this.ExamListIndex].SerialNo;
            }
        }

        private void AddBtnClicked()
        {
            this.ExamListIndex = -1;
            this.bclick = buttonClick.add;
        }
        private bool CanAddBtnClicked()
        {
            return true;
        }

        private void SaveBtnClicked()
        {
            if (this.bclick == buttonClick.add)
            {
                Exam exm = new Exam();
                exm.Name = this.TxbName;
                exm.ShortName = this.TxbShortName;
                exm.SerialNo = this.TxbSerialNo;
                int insertedId = this.db.InsertExam(exm);
                if (insertedId > 0)
                {
                    exm.Id = insertedId.ToString();
                    this.ExamList.Add(exm);
                    System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("Data inserted successfully. Insert more?", "", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
                    if (result == System.Windows.MessageBoxResult.Yes)
                    {
                        this.ExamListIndex = -1;
                    }
                    else
                    {
                        this.ExamListIndex = this.ExamList.IndexOf(exm);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to insert.");
                }
            }
            else
            {
                Exam exm = new Exam();
                exm.Name = this.TxbName;
                exm.ShortName = this.TxbShortName;
                exm.SerialNo = this.TxbSerialNo;
                exm.Id = this.ExamList[this.ExamListIndex].Id;
                
                if (this.db.UpdateExam(exm))
                {
                    System.Windows.MessageBox.Show("Updated successfully.");
                    this.ExamList[this.ExamListIndex].Name = this.TxbName;
                    this.ExamList[this.ExamListIndex].ShortName = this.TxbShortName;
                    this.ExamList[this.ExamListIndex].SerialNo = this.TxbSerialNo;
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to update.");
                }
            }
        }
        private bool CanSaveBtnClicked()
        {
            if (this.bclick == buttonClick.add)
            {
                return (!(string.IsNullOrEmpty(TxbName)) && this.TxbSerialNo > 0);
            }
            else
            {
                return (this.ExamListIndex > -1) && (this.ExamListIndex < this.ExamList.Count);
            }
        }

        private void DeleteBtnClicked()
        {
            if (this.db.DeleteExam(this.ExamList[this.ExamListIndex].Id))
            {
                System.Windows.MessageBox.Show("Deleted successfully");
                int temp_index = this.ExamListIndex;
                this.ExamListIndex = -1;
                this.ExamList.RemoveAt(temp_index);
            }
            else
            {
                System.Windows.MessageBox.Show("Failed to delete.");
            }
        }

        private bool CanDeleteBtnClicked()
        {
            return (this.ExamListIndex > -1) && (this.ExamListIndex < this.ExamList.Count);
        }
        #endregion
    }
}
