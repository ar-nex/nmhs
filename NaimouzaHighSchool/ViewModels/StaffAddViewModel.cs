using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class StaffAddViewModel : StaffBaseViewModel
    {
        public StaffAddViewModel()
            : base()
        {
            StartUpinitializer();
        }


        public RelayCommand SaveCommand { get; set; }

        #region Method
        private void StartUpinitializer()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void Save()
        {
            Staff s = BuildNewStaff();
            int r = 5;
        }

        private bool CanSave()
        {
            return true;
        }

        private Staff BuildNewStaff()
        {
            Staff s = new Staff();
            s.Name = Name;
            s.Dob = Helpers.DateHelper.GetDate(yyyy: YYYY, dd: DD, yyIndex: DobYYIndex, mm: DobMMIndex+1, ddIndex: DobDDIndex);
            s.Sex = (SexIndex != -1) ? Sex[SexIndex] : string.Empty;
            s.Caste = (SocialCategoryIndex != -1) ? SocialCategory[SocialCategoryIndex] : string.Empty;
            s.VoterId = VoterId;
            s.VacancyStatus = VacancyStatus;
            s.Designation = Designation;
            s.Subject = Subject;
            s.RetireDate = Helpers.DateHelper.GetDate(yyyy: YYYY, dd: DDRt, yyIndex: DorYYIndex, mm: DorMMIndex +1, ddIndex: DorDDIndex);
            s.BillType_salarySource = SalarySource;
            s.DateOfJoining = Helpers.DateHelper.GetDate(yyyy: YYYY, dd:DDJn, yyIndex: DojYYIndex, mm: DojMMIndex+1, ddIndex: DojDDIndex);
            s.EmployeeGroup = EmpGroup;
            s.Qualification = ApprvQualification;
            s.GradePay = GradePay;
            s.AdditionalQualification = AdlQualification;
            s.BasicPay = BasicPay;
            s.AcademicSection = AcademicSection;
            s.PayScale = PayScale;
            s.AppntApprovalNo = ApprvApntNo;
            s.NextIncrementDate = Helpers.DateHelper.GetDate(yyyy: YYYY, dd: DDIncr, yyIndex: DoIncrYYIndex, mm: DoIncrMMIndex + 1, ddIndex: DoIncrDDIndex);
            s.AppntApprovalDate = Helpers.DateHelper.GetDate(yyyy: YYYY, dd: DDAad, yyIndex: DoAadYYIndex, mm: DoAadMMIndex + 1, ddIndex: DoAadDDIndex);
            s.IncrementAmount = IncrementAmount;
            s.PayInPayBand = PayInPayBand;
            s.PayBand = PayBand;

            return s;
        }

        
        #endregion
    }
}
