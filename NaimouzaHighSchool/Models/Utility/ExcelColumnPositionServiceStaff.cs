using System.Collections.Generic;

namespace NaimouzaHighSchool.Models.Utility
{
    public class ExcelColumnPositionServiceStaff
    {
        public ExcelColumnPositionServiceStaff()
        {
            ListCol = new List<ExcelColumnPositionStaff>();
            // primary details
            ListCol.Add(new ExcelColumnPositionStaff("Staff Name"));
            ListCol.Add(new ExcelColumnPositionStaff("Date of Birth"));
            ListCol.Add(new ExcelColumnPositionStaff("Sex"));
            ListCol.Add(new ExcelColumnPositionStaff("Voter ID No."));
            ListCol.Add(new ExcelColumnPositionStaff("Designation"));
            ListCol.Add(new ExcelColumnPositionStaff("Date of Retirement"));
            ListCol.Add(new ExcelColumnPositionStaff("Date of Joining"));
            ListCol.Add(new ExcelColumnPositionStaff("Date of Retirement"));
            ListCol.Add(new ExcelColumnPositionStaff("Educational Qualification"));
            ListCol.Add(new ExcelColumnPositionStaff("Subject Name"));
            ListCol.Add(new ExcelColumnPositionStaff("Academic Group"));
            ListCol.Add(new ExcelColumnPositionStaff("Appointment Approval No."));
            ListCol.Add(new ExcelColumnPositionStaff("Appointment Approval Date"));
            ListCol.Add(new ExcelColumnPositionStaff("Pay Band"));
            ListCol.Add(new ExcelColumnPositionStaff("Pay Scale"));
            ListCol.Add(new ExcelColumnPositionStaff("Basic Pay"));
            ListCol.Add(new ExcelColumnPositionStaff("Grade Pay"));
            ListCol.Add(new ExcelColumnPositionStaff("Next Increment Date"));
            ListCol.Add(new ExcelColumnPositionStaff("Increment Amount"));
            ListCol.Add(new ExcelColumnPositionStaff("Bank Name"));
            ListCol.Add(new ExcelColumnPositionStaff("Bank Branch"));
            ListCol.Add(new ExcelColumnPositionStaff("Bank Branch Code"));
            ListCol.Add(new ExcelColumnPositionStaff("Bank IFSC Code"));
            ListCol.Add(new ExcelColumnPositionStaff("Bank MICR"));
            ListCol.Add(new ExcelColumnPositionStaff("Date of Retirement"));
            ListCol.Add(new ExcelColumnPositionStaff("Caste"));
            ListCol.Add(new ExcelColumnPositionStaff("Vacancy Status"));
            ListCol.Add(new ExcelColumnPositionStaff("Bill Type/Salary Source"));
            ListCol.Add(new ExcelColumnPositionStaff("Employee Group"));

            // personal details
            ListCol.Add(new ExcelColumnPositionStaff("Father"));
            ListCol.Add(new ExcelColumnPositionStaff("Mother"));
            ListCol.Add(new ExcelColumnPositionStaff("Religion"));
            ListCol.Add(new ExcelColumnPositionStaff("Mother tongue"));
            ListCol.Add(new ExcelColumnPositionStaff("Marital Status"));
            ListCol.Add(new ExcelColumnPositionStaff("Spouse Name"));
            ListCol.Add(new ExcelColumnPositionStaff("Opted WB Health Scheme"));
            ListCol.Add(new ExcelColumnPositionStaff("Residential Status"));
            ListCol.Add(new ExcelColumnPositionStaff("PAN"));
            ListCol.Add(new ExcelColumnPositionStaff("Aadhar ID No."));
            ListCol.Add(new ExcelColumnPositionStaff("Assembly Const. No."));
            ListCol.Add(new ExcelColumnPositionStaff("Assembly Part No."));
            ListCol.Add(new ExcelColumnPositionStaff("Voter SL no. in Part"));
            ListCol.Add(new ExcelColumnPositionStaff("Blood Group"));
            ListCol.Add(new ExcelColumnPositionStaff("Is Differently Able"));
            ListCol.Add(new ExcelColumnPositionStaff("State details"));
            ListCol.Add(new ExcelColumnPositionStaff("Height (In Inch)"));
            ListCol.Add(new ExcelColumnPositionStaff("Identification Mark"));

            // Contact details
            ListCol.Add(new ExcelColumnPositionStaff("House No."));
            ListCol.Add(new ExcelColumnPositionStaff("Street"));
            ListCol.Add(new ExcelColumnPositionStaff("Town/Village"));
            ListCol.Add(new ExcelColumnPositionStaff("District"));
            ListCol.Add(new ExcelColumnPositionStaff("State"));
            ListCol.Add(new ExcelColumnPositionStaff("PIN"));

            ListCol.Add(new ExcelColumnPositionStaff("Prm House No."));
            ListCol.Add(new ExcelColumnPositionStaff("Prm Street"));
            ListCol.Add(new ExcelColumnPositionStaff("Prm Town/Village"));
            ListCol.Add(new ExcelColumnPositionStaff("Prm District"));
            ListCol.Add(new ExcelColumnPositionStaff("Prm State"));
            ListCol.Add(new ExcelColumnPositionStaff("Prm PIN"));

            ListCol.Add(new ExcelColumnPositionStaff("Land Phone"));
            ListCol.Add(new ExcelColumnPositionStaff("Mobile"));
            ListCol.Add(new ExcelColumnPositionStaff("Email Id"));

            // professional details
            ListCol.Add(new ExcelColumnPositionStaff("Service Type"));
            ListCol.Add(new ExcelColumnPositionStaff("Professional Qualification"));
            ListCol.Add(new ExcelColumnPositionStaff("Prof. Qualification Year"));
            ListCol.Add(new ExcelColumnPositionStaff("Other Prof. Qualification"));

            // Approval of Appointment
            ListCol.Add(new ExcelColumnPositionStaff("Post Status"));
            ListCol.Add(new ExcelColumnPositionStaff("Appointment Letter No."));
            ListCol.Add(new ExcelColumnPositionStaff("Appointment Letter Date"));
            ListCol.Add(new ExcelColumnPositionStaff("MC Resolution No."));
            ListCol.Add(new ExcelColumnPositionStaff("MC Resolution Date"));
            ListCol.Add(new ExcelColumnPositionStaff("Memo No/DI'S PP Memo No."));
            ListCol.Add(new ExcelColumnPositionStaff("Memo No/DI'S PP Memo Date"));
            ListCol.Add(new ExcelColumnPositionStaff("Post Sanctioning Memo No."));
            ListCol.Add(new ExcelColumnPositionStaff("Post Sanctioning Memo Date"));

            // Details of previous Employment

            // Other
            ListCol.Add(new ExcelColumnPositionStaff("Opted Under DCRB Scheme"));
            ListCol.Add(new ExcelColumnPositionStaff("Option Excercise Under"));
            ListCol.Add(new ExcelColumnPositionStaff("Opted Under post 1981 pension"));
            ListCol.Add(new ExcelColumnPositionStaff("Date of refund of employer's share of CPF"));
            ListCol.Add(new ExcelColumnPositionStaff("Name of treasury"));
            ListCol.Add(new ExcelColumnPositionStaff("Amount refunded"));


        }

        public List<ExcelColumnPositionStaff> ListCol { get; set; }
        public List<ExcelColumnPositionStaff> GetListCol()
        {
            return ListCol;
        }
    }
}
