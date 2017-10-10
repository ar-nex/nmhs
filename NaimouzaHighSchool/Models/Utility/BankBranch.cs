using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class BankBranch : BaseModel
    {
        public BankBranch()
            : base()
        {

        }

        private string _ifsc;
        public string IFSC
        {
            get => _ifsc;
            set
            {
                _ifsc = value.ToUpper();
                OnPropertyChanged("IFSC");
            }
        }

        private string _branchName;
        public string BranchName
        {
            get => _branchName;
            set
            {
                _branchName = value.ToUpper();
                OnPropertyChanged("BranchName");
            }
        }

        private string _bankName;
        public string BankName
        {
            get => _bankName;
            set
            {
                _bankName = value.ToUpper();
                OnPropertyChanged("BankName");
            }
        }

        private string _micr;
        public string Micr
        {
            get => _micr;
            set
            {
                _micr = value.ToUpper();
                OnPropertyChanged("Micr");
            }
        }
    }
}
