using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class Staff
    {
        public Staff()
        {

        }

        #region properties
        private string _id;
        public string Id
        {
            get { return this._id; }
            set { this._id = value.ToUpper(); }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value.ToUpper(); }
        }

        private string _designation;
        public string Designation
        {
            get { return this._designation; }
            set { this._designation = value.ToUpper(); }
        }

        private string _subject;
        public string Subject
        {
            get { return this._subject; }
            set { this._subject = value.ToUpper(); }
        }

        private string _qualification;
        public string Qualification
        {
            get { return this._qualification; }
            set { this._qualification = value.ToUpper(); }
        }

        private string _professionalQualification;
        public string ProfessionalQualification
        {
            get { return this._professionalQualification; }
            set { this._professionalQualification = value.ToUpper(); }
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

            }
        }

        private DateTime _dateOfJoining;
        public DateTime DateOfJoining
        {
            get { return this._dateOfJoining; }
            set { this._dateOfJoining = value; }
        }

        private string _mobile;
        public string Mobile
        {
            get { return this._mobile; }
            set { this._mobile = value; }
        }

        private string _altMobile;
        public string AltMobile
        {
            get { return this._altMobile; }
            set { this._altMobile = value; }
        }

        private string _email;
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }


        private string _bankAcc;
        public string BankAcc
        {
            get { return this._bankAcc; }
            set { this._bankAcc = value; }
        }

        private string _ifsc;
        public string Ifsc
        {
            get { return this._ifsc; }
            set { this._ifsc = value; }
        }

        private string _micr;
        public string Micr
        {
            get { return this._micr; }
            set { this._micr = value; }
        }

        private string _bankName;
        public string BankName
        {
            get { return this._bankName; }
            set { this._bankName = value; }
        }

        private string _bankBranch;
        public string BankBranch
        {
            get { return this._bankBranch; }
            set { this._bankBranch = value; }
        }

        private string _status;
        public string Status
        {
            get { return this._status; }
            set
            {
                if (value.ToUpper() == "ACTIVE" || value.ToUpper() == "RETIRED")
                {
                    this._status = value.ToUpper();
                }
                else
                {
                    this._status = "ACTIVE";
                }

            }
        }

        private DateTime _retiredDate;
        public DateTime RetireDate
        {
            get { return this._retiredDate; }
            set { this._retiredDate = value; }
        }
        #endregion
    }
}
