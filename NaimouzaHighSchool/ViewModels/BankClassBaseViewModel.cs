using NaimouzaHighSchool.Models.Utility;
using System.Collections.ObjectModel;
using System.Linq;

namespace NaimouzaHighSchool.ViewModels
{
    public class BankClassBaseViewModel : StudentClassBaseViewModel
    {
        public BankClassBaseViewModel()
            : base()
        {
            this.StartUpInitializer();
        }

        private ObservableCollection<string> _banks;

        public ObservableCollection<string> Banks
        {
            get { return this._banks; }
            set { this._banks = value; this.OnPropertyChanged("Banks"); }
        }

        private string _bankName;

        public string BankName
        {
            get { return this._bankName; }
            set {
                this._bankName =(value != null) ? value.ToUpper() : value;
                this.OnPropertyChanged("BankName");
                if (value != null)
                {
                    SetUpdatedBranchNames(value.ToUpper());
                    SetIfscAndMicr();
                }
            }
        }

        private ObservableCollection<string> _branchs;

        public ObservableCollection<string> Branchs
        {
            get { return this._branchs; }
            set { this._branchs = value; this.OnPropertyChanged("Branchs"); }
        }

        private string _branchName;
        public string BranchName
        {
            get { return this._branchName; }
            set
            {
                this._branchName = (value != null) ? value.ToUpper() : value;
                this.OnPropertyChanged("BranchName");
                if (value != null)
                {
                    SetIfscAndMicr();
                }
            }
        }

        private string _accNo;

        public string AccNo
        {
            get { return this._accNo; }
            set { this._accNo = value; this.OnPropertyChanged("AccNo"); }
        }

        private ObservableCollection<string> _ifcrList;

        public ObservableCollection<string> IfcrList
        {
            get { return this._ifcrList; }
            set { this._ifcrList = value; this.OnPropertyChanged("IfcrList"); }
        }

        private string _ifsc;
        public string Ifsc
        {
            get { return this._ifsc; }
            set { this._ifsc = value.ToUpper(); this.OnPropertyChanged("Ifsc"); }
        }

        private string _micr;

        public string Micr
        {
            get { return this._micr; }
            set { this._micr = value; this.OnPropertyChanged("Micr"); }
        }

        private ObservableCollection<string> _micrList;

        public ObservableCollection<string> MICRList
        {
            get { return this._micrList; }
            set { this._micrList = value; this.OnPropertyChanged("MICRList"); }
        }

        protected BankBranch[] BankBranchArr { get; set; }

        private void StartUpInitializer()
        {
            BankBranchArr = StartUpInitializerBankBranch();

            this.Banks = new ObservableCollection<string>();
            this.Branchs = new ObservableCollection<string>();
            this.IfcrList = new ObservableCollection<string>();
            this.MICRList = new ObservableCollection<string>();

            var bNameGroup = from br in BankBranchArr
                               group br by br.BankName;
            foreach (var itemGrp in bNameGroup)
            {
                Banks.Add(itemGrp.Key);
            }

           
        }

        private static BankBranch[] StartUpInitializerBankBranch()
        {
            return new BankBranch[] { new BankBranch() {
                    BankName = "STATE BANK OF INDIA",
                    BranchName = "SUJAPUR",
                    IFSC = "SBIN0006810",
                    Micr = "732002506",
                    BankNameAlias = new string [] { "STATE BANK OF INDIA", "SBI", "S.B.I.", "S.B.I", "S B I", "SB I", "S BI", "SBIN", "STATE BANK"}
                }, new BankBranch(){
                    BankName = "CANARA BANK",
                    BranchName = "BAMONGRAM",
                    IFSC = "CNRB0005768",
                    Micr = "732015505",
                    BankNameAlias = new string [] { "CANARA BANK", "CANARA", "CB", "C.B", "C.B.", "C B" },
                }, new BankBranch(){
                    BankName = "CANARA BANK",
                    BranchName = "CHASPARA",
                    IFSC = "CNRB0005766",
                    Micr = "732015506",
                    BankNameAlias = new string [] { "CANARA BANK", "CANARA", "CB", "C.B", "C.B.", "C B" }
                }, new BankBranch(){
                    BankName = "UNITED BANK OF INDIA",
                    BranchName = "SUJAPUR",
                    IFSC = "UTBI0SUJY10",
                    Micr = string.Empty,
                    BankNameAlias = new string [] { "UNITED BANK OF INDIA", "UBI", "U.B.I", "U.B.I.", "U B I", "UB I", "U BI" }
                }, new BankBranch(){
                    BankName = "UNITED BANK OF INDIA",
                    BranchName = "BANGIYA GRAMIN VIKASH BANK",
                    IFSC = "UTBI0RRBBGB",
                    Micr = string.Empty,
                    BankNameAlias = new string [] { "UNITED BANK OF INDIA", "BANGIYA GRAMIN VIKASH BANK", "BGVB", "BANGIYA GRAMIN VIKAS BANK", "B.G.V.B.", "B.G.V.B", "B G V B", "UBI", "U.B.I", "U.B.I.", "U B I", "UB I", "U BI" }
                }
            };
        }

        private void SetUpdatedBranchNames(string bname)
        {
            var Bankbranches = from br in BankBranchArr
                           where br.BankName == bname
                           select br.BranchName;
            Branchs.Clear();
            foreach (var item in Bankbranches)
            {
                Branchs.Add(item);
            }
        }

        private void SetIfscAndMicr()
        {
            if (string.IsNullOrEmpty(BankName) || string.IsNullOrEmpty(BranchName))
            {
                return;
            }
            else
            {
                var bnk = from b in BankBranchArr
                          where b.BankName == BankName
                          where b.BranchName == BranchName
                          select b;
                foreach (var item in bnk)
                {
                    Ifsc = item.IFSC;
                    Micr = item.Micr;
                    break;
                }
            }
        }
    }
}