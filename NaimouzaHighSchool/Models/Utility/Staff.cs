using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Staff : BaseModel
    {
        public Staff()
            : base()
        {

        }


        private string _id;
        public string Id
        {
            get { return this._id; }
            set
            {
                this._id = value.ToUpper();
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value.ToUpper();
                OnPropertyChanged("Name");
            }
        }

        private DateTime _dob;
        public DateTime Dob
        {
            get => _dob;
            set
            {
                _dob = value;
                OnPropertyChanged("Dob");
            }
        }

        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set
            {
                string sx = value.ToUpper();
                if (sx == "M" || sx == "MALE" || sx == "BOY" || sx == "BOYS" || sx == "B" || sx == "BY")
                {
                    _sex = "M";
                }
                else if (sx == "F" || sx == "FEMALE" || sx == "GIRL" || sx == "GIRLS" || sx == "GRL" || sx == "G")
                {
                    _sex = "F";
                }
                else
                {
                    _sex = string.Empty;
                }
                OnPropertyChanged("Sex");
            }
        }

        private string _voterId;
        public string VoterId
        {
            get => _voterId;
            set
            {
                _voterId = value;
                OnPropertyChanged("VoterId");
            }
        }

        private string _designation;
        public string Designation
        {
            get { return this._designation; }
            set
            {
                this._designation = value.ToUpper();
                OnPropertyChanged("Name");
            }
        }

        private DateTime _dateOfJoining;
        public DateTime DateOfJoining
        {
            get { return this._dateOfJoining; }
            set
            {
                this._dateOfJoining = value;
                OnPropertyChanged("DateOfJoining");
            }
        }

        private DateTime _retiredDate;
        public DateTime RetireDate
        {
            get { return this._retiredDate; }
            set
            {
                this._retiredDate = value;
                OnPropertyChanged("RetireDate");
            }
        }


        private string _qualification;
        public string Qualification
        {
            get { return this._qualification; }
            set
            {
                this._qualification = value.ToUpper();
                OnPropertyChanged("Qualification");
            }
        }

        private string _professionalQualification;
        public string ProfessionalQualification
        {
            get { return this._professionalQualification; }
            set
            {
                this._professionalQualification = value.ToUpper();
                OnPropertyChanged("ProfessionalQualification");
            }
        }

        private string _subject;
        public string Subject
        {
            get { return this._subject; }
            set
            {
                this._subject = value.ToUpper();
                OnPropertyChanged("Subject");
            }
        }

        private string _academicGroup;
        public string AcademicGroup
        {
            get => _academicGroup;
            set
            {
                _academicGroup = value;
                OnPropertyChanged("AcademicGroup");
            }
        }

        private string _appntApprovalNo;
        public string AppntApprovalNo
        {
            get => _appntApprovalNo;
            set
            {
                _appntApprovalNo = value;
                OnPropertyChanged("AppntApprovalNo");
            }
        }

        private DateTime _appntApprovalDate;
        public DateTime AppntApprovalDate
        {
            get => _appntApprovalDate;
            set
            {
                _appntApprovalDate = value;
                OnPropertyChanged("AppntApprovalDate");
            }
        }

        private string _payband;
        public string PayBand
        {
            get => _payband;
            set
            {
                _payband = value;
                OnPropertyChanged("PayBand");
            }
        }

        private string _payScale;
        public string PayScale
        {
            get => _payScale;
            set
            {
                _payScale = value;
                OnPropertyChanged("PayScale");
            }
        }

        private string _basicPay;
        public string BasicPay
        {
            get => _basicPay;
            set
            {
                _basicPay = value;
                OnPropertyChanged("BasicPay");
            }
        }

        private string _gradePay;
        public string GradePay
        {
            get => _gradePay;
            set
            {
                _gradePay = value;
                OnPropertyChanged("GradePay");
            }
        }

        private DateTime _nextIncrementDate;
        public DateTime NextIncrementDate
        {
            get => _nextIncrementDate;
            set
            {
                _nextIncrementDate = value;
                OnPropertyChanged("NextIncrementDate");
            }
        }

        private int _incrementAmount;
        public int IncrementAmount
        {
            get => _incrementAmount;
            set
            {
                _incrementAmount = value;
                OnPropertyChanged("IncrementAmount");
            }
        }

        private string _bankAcc;
        public string BankAcc
        {
            get { return this._bankAcc; }
            set
            {
                this._bankAcc = value;
                OnPropertyChanged("BankAcc");
            }
        }

        private string _ifsc;
        public string Ifsc
        {
            get { return this._ifsc; }
            set
            {
                this._ifsc = value;
                OnPropertyChanged("Ifsc");
            }
        }

        private string _micr;
        public string Micr
        {
            get { return this._micr; }
            set
            {
                this._micr = value;
                OnPropertyChanged("Micr");
            }
        }

        private string _bankName;
        public string BankName
        {
            get { return this._bankName; }
            set
            {
                this._bankName = value;
                OnPropertyChanged("BankName");
            }
        }

        private string _bankBranch;
        public string BankBranch
        {
            get { return this._bankBranch; }
            set
            {
                this._bankBranch = value;
                OnPropertyChanged("BankBranch");
            }
        }

        private DateTime _dateOfRetirement;
        public DateTime DateOfRetirement
        {
            get => _dateOfRetirement;
            set
            {
                _dateOfRetirement = value;
                OnPropertyChanged("DateOfRetirement");
            }
        }

        private string _caste;
        public string Caste
        {
            get => _caste;
            set
            {
                _caste = value;
                OnPropertyChanged("Caste");
            }
        }

        private string _vacancyStatus;
        public string VacancyStatus
        {
            get => _vacancyStatus;
            set
            {
                _vacancyStatus = value;
                OnPropertyChanged("VacancyStatus");
            }
        }

        private string _billType_salarySource;
        public string BillType_salarySource
        {
            get => _billType_salarySource;
            set
            {
                _billType_salarySource = value;
                OnPropertyChanged("BillType_salarySource");
            }
        }

        private string _employeeGroup;
        public string EmployeeGroup
        {
            get => _employeeGroup;
            set
            {
                _employeeGroup = value;
                OnPropertyChanged("EmployeeGroup");
            }
        }

        private string _fatherName;
        public string FatherName
        {
            get => _fatherName;
            set
            {
                _fatherName = value;
                OnPropertyChanged("FatherName");
            }
        }

        private string _motherName;
        public string MotherName
        {
            get => _motherName;
            set
            {
                _motherName = value;
                OnPropertyChanged("MotherName");
            }
        }

        private string _religion;
        public string Religion
        {
            get => _religion;
            set
            {
                _religion = value;
                OnPropertyChanged("Religion");
            }
        }

        private string _motherTounge;
        public string MotherTounge
        {
            get => _motherTounge;
            set
            {
                _motherTounge = value;
                OnPropertyChanged("MotherTounge");
            }
        }

        private string _maritalStatus;
        public string MaritalStatus
        {
            get => _maritalStatus;
            set
            {
                string ms = value.ToUpper();
                if (ms == "YES" || ms=="Y" || ms=="MARRIED")
                {
                    _maritalStatus = "Y";
                }
                else
                {
                    _maritalStatus = "N";
                }
                _maritalStatus = value;
                OnPropertyChanged("MaritalStatus");
            }
        }

       

        private string _spouseName;
        public string SpouseName
        {
            get => _spouseName;
            set
            {
                _spouseName = value;
                OnPropertyChanged("SpouseName");
            }
        }

        private string _optedWBHealthScheme;
        public string OptedWBHealthScheme
        {
            get => _optedWBHealthScheme;
            set
            {
                string op = value.ToUpper();
                if (op == "YES" || op == "Y" || op == "1")
                {
                    _optedWBHealthScheme = "Y";
                }
                else
                {
                    _optedWBHealthScheme = "N";
                }
                OnPropertyChanged("OptedWBHealthScheme");
            }
        }

        private string _residentialStatus;
        public string ResidentialStatus
        {
            get => _residentialStatus;
            set
            {
                _residentialStatus = value;
                OnPropertyChanged("ResidentialStatus");
            }
        }

        private string _panNo;
        public string PanNo
        {
            get => _panNo;
            set
            {
                _panNo = value;
                OnPropertyChanged("PanNo");
            }
        }

        private string _aadhaar;
        public string Aadhaar
        {
            get => _aadhaar;
            set
            {
                _aadhaar = value;
                OnPropertyChanged("Aadhaar");
            }
        }

        private string _assemblyConstiNo;
        public string AssemblyConstiNo
        {
            get => _assemblyConstiNo;
            set
            {
                _assemblyConstiNo = value;
                OnPropertyChanged("AssemblyConstiNo");
            }
        }

        private string _assemblyPartNo;
        public string AssemblyPartNo
        {
            get => _assemblyPartNo;
            set
            {
                _assemblyPartNo = value;
                OnPropertyChanged("AssemblyPartNo");
            }
        }

        private string _voterSlNoInPart;
        public string VoterSlNoInPart
        {
            get => _voterSlNoInPart;
            set
            {
                _voterSlNoInPart = value;
                OnPropertyChanged("VoterSlNoInPart");
            }
        }

        private string _bloodGrp;
        public string BloodGrp
        {
            get => _bloodGrp;
            set
            {
                _bloodGrp = value;
                OnPropertyChanged("BloodGrp");
            }
        }

        private string _isPH;
        public string IsPH
        {
            get => _isPH;
            set
            {
                string ph = value.ToUpper();
                if (ph == "YES" || ph == "Y" || ph == "1")
                {
                    _isPH = "Y";
                }
                else
                {
                    _isPH = "N";
                }
                OnPropertyChanged("IsPH");
            }
        }

        private string _stateDetails;
        public string StateDetails
        {
            get => _stateDetails;
            set
            {
                _stateDetails = value;
                OnPropertyChanged("StateDetails");
            }
        }

        private float _heightInInch;
        public float HeightInInch
        {
            get => _heightInInch;
            set
            {
                _heightInInch = value;
                OnPropertyChanged("HeightInInch");
            }
        }

        private string _identificationMark;
        public string IdentificationMark
        {
            get => _identificationMark;
            set
            {
                _identificationMark = value;
                OnPropertyChanged("IdentificationMark");
            }
        }

        private string _houseNo;
        public string HouseNo
        {
            get => _houseNo;
            set
            {
                _houseNo = value;
                OnPropertyChanged("HouseNo");
            }
        }

        private string _street;
        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }

        private string _villageOrTown;
        public string VillageOrTown
        {
            get => _villageOrTown;
            set
            {
                _villageOrTown = value;
                OnPropertyChanged("VillageOrTown");
            }
        }

        private string _dist;
        public string Dist
        {
            get => _dist;
            set
            {
                _dist = value;
                OnPropertyChanged("Dist");
            }
        }

        private string _pin;
        public string Pin
        {
            get => _pin;
            set
            {
                _pin = value;
                OnPropertyChanged("Pin");
            }
        }

        private string _state;
        public string State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        private string _prmHouseNo;
        public string PrmHouseNo
        {
            get => _prmHouseNo;
            set
            {
                _prmHouseNo = value;
                OnPropertyChanged("PrmHouseNo");
            }
        }

        private string _PrmStreet;
        public string PrmStreet
        {
            get => _PrmStreet;
            set
            {
                _PrmStreet = value;
                OnPropertyChanged("PrmStreet");
            }
        }

        private string _prmVillageOrTown;
        public string PrmVillageOrTown
        {
            get => _prmVillageOrTown;
            set
            {
                _prmVillageOrTown = value;
                OnPropertyChanged("PrmVillageOrTown");
            }
        }

        private string _prmDist;
        public string PrmDist
        {
            get => _prmDist;
            set
            {
                _prmDist = value;
                OnPropertyChanged("PrmDist");
            }
        }

        private string _PrmPin;
        public string PrmPin
        {
            get => _PrmPin;
            set
            {
                _PrmPin = value;
                OnPropertyChanged("PrmPin");
            }
        }

        private string _prmState;
        public string PrmState
        {
            get => _prmState;
            set
            {
                _prmState = value;
                OnPropertyChanged("PrmState");
            }
        }

        private string _mobile;
        public string Mobile
        {
            get { return this._mobile; }
            set
            {
                this._mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        private string _landPhone;
        public string LandPhone
        {
            get { return this._landPhone; }
            set
            {
                this._landPhone = value;
                OnPropertyChanged("LandPhone");
            }
        }

        private string _email;
        public string Email
        {
            get { return this._email; }
            set
            {
                this._email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _serviceType;
        public string ServiceType
        {
            get => _serviceType;
            set
            {
                _serviceType = value;
                OnPropertyChanged("ServiceType");
            }
        }

        private string _otherProfQualification;
        public string OtherProfQualification
        {
            get => _otherProfQualification;
            set
            {
                _otherProfQualification = value;
                OnPropertyChanged("OtherProfQualification");
            }
        }

        private int _profQualificationYear;
        public int ProfQualificationYear
        {
            get => _profQualificationYear;
            set
            {
                _profQualificationYear = value;
                OnPropertyChanged("ProfQualificationYear");
            }
        }

        private string _postStatus;
        public string PostStatus
        {
            get => _postStatus;
            set
            {
                _postStatus = value;
                OnPropertyChanged("PostStatus");
            }
        }

        private string _appntLetterNo;
        public string AppntLetterNo
        {
            get => _appntLetterNo;
            set
            {
                _appntLetterNo = value;
                OnPropertyChanged("AppntLetterNo");
            }
        }

        private DateTime _appntLetterDate;
        public DateTime AppntLetterDate
        {
            get => _appntLetterDate;
            set
            {
                _appntLetterDate = value;
                OnPropertyChanged("AppntLetterDate");
            }
        }

        private string _mcResolutionNo;
        public string McResolutionNo
        {
            get => _mcResolutionNo;
            set
            {
                _mcResolutionNo = value;
                OnPropertyChanged("McResolutionNo");
            }
        }

        private DateTime _mcResolutionDate;
        public DateTime McResolutionDate
        {
            get => _mcResolutionDate;
            set
            {
                _mcResolutionDate = value;
                OnPropertyChanged("McResolutionDate");
            }
        }

        private string _memoNo;
        public string MemoNo
        {
            get => _memoNo;
            set
            {
                _memoNo = value;
                OnPropertyChanged("MemoNo");
            }
        }

        private DateTime _memoDate;
        public DateTime MemoDate
        {
            get => _memoDate;
            set
            {
                _memoDate = value;
                OnPropertyChanged("MemoDate");
            }
        }

        private string _postSanctionMemoNo;
        public string PostSanctionMemoNo
        {
            get => _postSanctionMemoNo;
            set
            {
                _postSanctionMemoNo = value;
                OnPropertyChanged("PostSanctionMemoNo");
            }
        }

        private DateTime _postSanctionMemoDate;
        public DateTime PostSanctionMemoDate
        {
            get => _postSanctionMemoDate;
            set
            {
                _postSanctionMemoDate = value;
                OnPropertyChanged("PostSanctionMemoDate");
            }
        }

        private string _optedDCRB;
        public string OptedDCRB
        {
            get => _optedDCRB;
            set
            {
                string op = value.ToUpper();
                if (op == "YES" || op == "Y" || op == "1")
                {
                    _optedDCRB = "Y";
                }
                else
                {
                    _optedDCRB = "N";
                }
                OnPropertyChanged("OptedDCRB");
            }
        }

        private string _optionExcerciseUnder;
        public string OptionExcerciseUnder
        {
            get => _optionExcerciseUnder;
            set
            {
                _optionExcerciseUnder = value;
                OnPropertyChanged("OptionExcerciseUnder");
            }
        }

        private string _optedPost1981Scheme;
        public string OptedPost1981Scheme
        {
            get => _optedPost1981Scheme;
            set
            {
                string op1981 = value.ToUpper();
                if (op1981 == "YES" || op1981 == "Y" || op1981 == "1")
                {
                    _optedPost1981Scheme = "Y";
                }
                else
                {
                    _optedPost1981Scheme = "N";
                }
                OnPropertyChanged("OptedPost1981Scheme");
            }
        }

        private DateTime _cPFShareRefundDate;
        public DateTime CPFShareRefundDate
        {
            get => _cPFShareRefundDate;
            set
            {
                _cPFShareRefundDate = value;
                OnPropertyChanged("CPFShareRefundDate");
            }
        }

        private DateTime _treasuryName;
        public DateTime TreasuryName
        {
            get => _treasuryName;
            set
            {
                _treasuryName = value;
                OnPropertyChanged("TreasuryName");
            }
        }

        private decimal _refundAmount;
        public decimal RefundAmount
        {
            get => _refundAmount;
            set
            {
                _refundAmount = value;
                OnPropertyChanged("RefundAmount");
            }
        }
    }
}
