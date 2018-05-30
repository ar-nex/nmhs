using System;
using System.Collections.Generic;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Staff : BaseModel
    {
        public Staff()
            : base()
        {

        }

        #region primary
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = (value > 0) ? value : 0;
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = (value != null) ?value.ToUpper() : value;
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
                string sx = (value != null) ? value.ToUpper() : value;
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

        private string _caste;
        public string Caste
        {
            get => _caste;
            set => _caste = (value != null) ? value.ToUpper() : value;
        }

        private string _voterId;
        public string VoterId
        {
            get => _voterId;
            set
            {
                _voterId = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("VoterId");
            }
        }

        private string _vacancyStatus;
        public string VacancyStatus
        {
            get => _vacancyStatus;
            set => _vacancyStatus = (value != null) ? value.ToUpper() : value;
        }

        private string _designation;
        public string Designation
        {
            get { return this._designation; }
            set
            {
                this._designation = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("Designation");
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

        private DateTime _retireDate;
        public DateTime RetireDate
        {
            get { return this._retireDate; }
            set
            {
                this._retireDate = value;
                OnPropertyChanged("RetireDate");
            }
        }

        private string _billType_salarySource;
        public string BillType_salarySource
        {
            get => _billType_salarySource;
            set => _billType_salarySource = value;
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

        private string _employeeGroup;
        public string EmployeeGroup
        {
            get => _employeeGroup;
            set => _employeeGroup = value;
        }

        private string _qualification;
        public string Qualification
        {
            get { return this._qualification; }
            set
            {
                this._qualification = (value != null) ? value.ToUpper() : value;
            }
        }

        private int _gradePay;
        public int GradePay
        {
            get => _gradePay;
            set => _gradePay = value;
        }

        private string _additionalQualification;
        public string AdditionalQualification
        {
            get { return this._additionalQualification; }
            set
            {
                this._additionalQualification = (value != null) ? value.ToUpper() : value;
            }
        }

        private int _basicPay;
        public int BasicPay
        {
            get => _basicPay;
            set => _basicPay = value;
        }

        private string _academicSection;
        public string AcademicSection
        {
            get => _academicSection;
            set
            {
                _academicSection = (value != null) ? value.ToUpper() : value;
                OnPropertyChanged("AcademicSection");
            }
        }

        private string _payScale;
        public string PayScale
        {
            get => _payScale;
            set => _payScale = value;
        }

        private string _appntApprovalNo;
        public string AppntApprovalNo
        {
            get => _appntApprovalNo;
            set => _appntApprovalNo = (value != null) ? value.ToUpper() : value;
        }

        private DateTime _nextIncrementDate;
        public DateTime NextIncrementDate
        {
            get => _nextIncrementDate;
            set => _nextIncrementDate = value;
        }

        private DateTime _appntApprovalDate;
        public DateTime AppntApprovalDate
        {
            get => _appntApprovalDate;
            set => _appntApprovalDate = value;
        }

        private int _incrementAmount;
        public int IncrementAmount
        {
            get => _incrementAmount;
            set => _incrementAmount = value;
        }

        public int PayInPayBand { get; set; }

        private string _payband;
        public string PayBand
        {
            get => _payband;
            set => _payband = value;
        }

        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string BankAcc { get; set; }
        public string Ifsc { get; set; }
        public string Micr { get; set; }
        public string BankBranch { get; set; }

        #endregion

        #region personal

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Religion { get; set; }
        public string MotherTongue { get; set; }
        public string MarritalStatus { get; set; }
        public string SpouseName { get; set; }
        public bool OptedWBHealthScheme { get; set; }
        public string ResidentialStatus { get; set; }
        public string PANNo { get; set; }
        public string Aadhaar { get; set; }
        public string AssemblyConstiNo { get; set; }
        public string AssemblyPartNo { get; set; }
        public int VoterSlNoInPart { get; set; }
        public string BloodGroup { get; set; }
        public bool IsPh { get; set; }
        public string StateDetails { get; set; }
        public float HeightInInch { get; set; }
        public string IdentificationMark { get; set; }

        #endregion

        #region contact
        public string State { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string Town_Village { get; set; }
        public string PO { get; set; }
        public string PS { get; set; }
        public string Dist { get; set; }
        public string PIN { get; set; }

        public string PrmState { get; set; }
        public string PrmHouseNo { get; set; }
        public string PrmStreet { get; set; }
        public string PrmTown_Village { get; set; }
        public string PrmPO { get; set; }
        public string PrmPS { get; set; }
        public string PrmDist { get; set; }
        public string PrmPIN { get; set; }

        public string TelNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        #endregion

        #region ProfessionalDetails
        public string ServiceType { get; set; }
        public string ProfQualification { get; set; }
        public int ProfQualificationYear { get; set; }
        public string OtherProfQualification { get; set; }
        #endregion

        #region AppointmentApproval
        public string PostStatus { get; set; }
        public string AppntLetterNo { get; set; }
        public DateTime AppntLetterDate { get; set; }
        public string MCResolutionNo { get; set; }
        public DateTime MCResolutionDate { get; set; }
        public string TempPostMemoNo { get; set; }
        public DateTime TempPostMemoDate { get; set; }
        public string PostSancMemoNo { get; set; }
        public DateTime PostSancMemoDate { get; set; }
        #endregion

        #region other
        public List<Empolyment> PreviousEmployment { get; set; }
        public bool OptedDCRB { get; set; }
        public string OptionExerciseUnder { get; set; }
        public bool OptedPost1981Pension { get; set; }
        public DateTime CPFShareRefundDate { get; set; }
        public string TreasuryName { get; set; }
        public decimal RefundAmount { get; set; }
        public bool AnyCourtCase { get; set; }
        public string CaseNo { get; set; }
        public int CaseYear { get; set; }
        public string CaseRelatedWith { get; set; }
        #endregion
    }
}
