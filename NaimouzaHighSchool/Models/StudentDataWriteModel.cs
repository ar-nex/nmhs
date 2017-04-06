using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.Models
{
    public class StudentDataWriteModel : BaseModel
    {
        public StudentDataWriteModel()
        :base()
        {
            this._std = new Student();
        }

        Student _std;

        #region Name
        string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value.ToUpper();
                this.OnPropertyChanged(string.Empty);
                string FullName = FirstName + " " + MidName + " " + LastName;
                this._std.Name = FullName.Trim();

            }
        }
       
        string _midName;
        public string MidName
        {
            get { return _midName; }
            set
            {
                _midName = value.ToUpper();
                this.OnPropertyChanged(string.Empty);
                string FullName = FirstName + " " + MidName + " " + LastName;
                this._std.Name = FullName.Trim();
            }
        }
        
        string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value.ToUpper();
                this.OnPropertyChanged(string.Empty);
                string FullName = FirstName + " " + MidName + " " + LastName;
                this._std.Name = FullName.Trim();
            }
        }
        #endregion

        #region classInfo
        public string StdClass
        {
            get { return _std.StudyingClass; }
            set { _std.StudyingClass = value; this.OnPropertyChanged("StdClass"); }
        }
        public string StdSection
        {
            get { return _std.Section; }
            set { _std.Section = value; this.OnPropertyChanged("StdSection"); }
        }

        public string StdRoll
        {
            get
            {
                if (_std.Roll == 0)
                {
                    return "";
                }
                else
                {
                    return _std.Roll.ToString();
                }
            }
            set
            {
                int t;
                Int32.TryParse(value, out t);
                _std.Roll = t;
                this.OnPropertyChanged("Roll");
            }
        }

        public string SubCombId
        {
            get { return _std.SubjectComboId; }
            set { _std.SubjectComboId = value; this.OnPropertyChanged("SubCombId"); }
        }
        #endregion


       

       

      

       public string StdSex
       {
           get { return _std.Sex; }
           set { _std.Sex = value; this.OnPropertyChanged("StdSex"); }
       }

       public bool StdIsBpl
       {
           get { return _std.IsBpl; }
           set 
           { 
               _std.IsBpl = value;
               if (!_std.IsBpl)
               {
                   this.StdBplNo = "";
               }
               this.EnableBplTxb = _std.IsBpl;              
               this.OnPropertyChanged(string.Empty);
              
           }
       }
       public bool EnableBplTxb { get; set; }
       public string StdBplNo
       {
           get { return _std.BplNo; }
           set { _std.BplNo = value; this.OnPropertyChanged(string.Empty); }
       }

       public bool StdIsPh
       {
           get { return _std.IsPH; }
           set 
           { 
               _std.IsPH = value;
               this.EnablePhTypeTxb = _std.IsPH;
               this.OnPropertyChanged(String.Empty); 
           }
       }

       public string StdPhType
       {
           get { return _std.PhType; }
           set { _std.PhType = value; this.OnPropertyChanged("StdPhType"); }
       }
       public bool EnablePhTypeTxb { get; set; }
       public string StdDob
       {
           get 
           {
               DateTime dfDate = new DateTime();
               if (_std.Dob.Date == dfDate.Date)
               {
                   return "";
               }
               else
               {
                   return _std.Dob.ToString("dd-MM-yyyy");
               }
           }
           set 
           {
               try
               {
                   _std.Dob = DateTime.Parse(value);
               }
               catch (Exception)
               {
                   
                  
               }
               this.OnPropertyChanged("StdDob");
           }
       }

       public string StdBloodGroup
       {
           get { return _std.BloodGroup; }
           set { _std.BloodGroup = value; this.OnPropertyChanged("StdBloodGroup"); }
       }

       public string StdAadhar
       {
           get { return _std.Aadhar; }
           set
           {
               _std.Aadhar = value;
               this.OnPropertyChanged("StdAadhar");
            
           }
       }

       public string StdSocialCat
       {
           get { return _std.SocialCategory; }
           set { _std.SocialCategory = value; this.OnPropertyChanged("StdSocialCat"); }
       }

        public Student getStudentObj()
        {
            return this._std;
        }

    }
}
