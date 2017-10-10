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

        #region properties
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

        private string _altMobile;
        public string AltMobile
        {
            get { return this._altMobile; }
            set
            {
                this._altMobile = value;
                OnPropertyChanged("AltMobile");
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
    
        #endregion
    }
}
