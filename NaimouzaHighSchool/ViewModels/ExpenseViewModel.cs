using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lottery.Models;
using Lottery.Database;
using Lottery.Commands;


namespace Lottery.ViewModels
{
    public class ExpenseViewModel : BaseViewModel
    {
        public ExpenseViewModel()
        :base()
        {
            this.expModel = new ExpenseModel();
            this.expDb = new ExpenseDb();
            this.ComboType = expDb.getExpenseTypes();
            this.SaveCommand = new RelayCommand(SaveData, CanSave);
            this.ResetCommand = new RelayCommand(ResetData, CanReset);

        }

        private ExpenseModel expModel;
        private List<string> typeList;
        private ExpenseDb expDb;
      

        #region property
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public string TxbType
        {
            get { return expModel.Type; }
            set { expModel.Type = value; this.OnPropertyChanged("TxbType"); }
        }

        public string TxbDate
        {
            get { return expModel.ExpDate.ToString("dd-MM-yyyy"); }
            set { expModel.ExpDate = DateTime.Parse(value); }
        }
        public List<string> ComboType
        {
            get { return typeList; }
            set { typeList = value; }
        }
        public string TxbDetail
        {
            get { return expModel.Detail; }
            set { expModel.Detail = value; this.OnPropertyChanged("TxbDetail"); }
        }
        public string TxbAmount
        {
            get 
            {
                if (expModel.Amount == 0)
                {
                    return "";
                }
                else
                {
                    return expModel.Amount.ToString();
                }
            }
            set
            {
                try
                {
                    expModel.Amount = decimal.Parse(value);
                }
                catch (Exception)
                {

                    expModel.Amount = 0;
                }
            }
        }
        #endregion

        #region methods
        public bool CanSave(Object param)
        {
            if (expModel.Amount <= 0 || string.IsNullOrWhiteSpace(expModel.Type))
            {
                return false;
            }
            else
            {
                return true;
            }
        
        }

        public void SaveData(Object param)
        {
            bool hasInserted = expDb.insertExpense(expModel);
            if (hasInserted)
            {
                System.Windows.MessageBox.Show("Saved successfully");
                this.ResetData(this);
            }
            else
            {
                System.Windows.MessageBox.Show("failed.");
            }
        }

        public bool CanReset(Object param)
        {
            return true;
        }

        public void ResetData(Object param)
        {
            this.expModel.Type = "";
            this.expModel.Detail = "";
            this.expModel.Amount = 0;
            this.OnPropertyChanged(String.Empty);
        }
        #endregion

    }
}
