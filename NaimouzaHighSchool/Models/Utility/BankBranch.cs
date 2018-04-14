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
                _ifsc = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("IFSC");
            }
        }

        private string _branchName;
        public string BranchName
        {
            get => _branchName;
            set
            {
                _branchName = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("BranchName");
            }
        }

        private string _bankName;
        public string BankName
        {
            get => _bankName;
            set
            {
                _bankName = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("BankName");
            }
        }

        private string _micr;
        public string Micr
        {
            get => _micr;
            set
            {
                _micr = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("Micr");
            }
        }

        private string[] _bankNameAlias;
        public string[] BankNameAlias
        {
            get { return _bankNameAlias; }
            set { _bankNameAlias = value; }
        }

    }
}
