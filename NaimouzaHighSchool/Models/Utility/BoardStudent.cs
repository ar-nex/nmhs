using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models;

namespace NaimouzaHighSchool.Models.Utility
{
    public class BoardStudent : NaimouzaHighSchool.Models.BaseModel
    {
        public BoardStudent()
        : base()
        {

        }

        private string _id;
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value.ToUpper(); }
        }

        private string _cls;
        public string Cls
        {
            get { return this._cls; }
            set { this._cls = value; }
        }

        private string _section;
        public string Section
        {
            get { return this._section; }
            set { this._section = value.ToUpper(); }
        }

        private int _roll;
        public int Roll
        {
            get { return this._roll; }
            set { this._roll = value; }
        }

        private int _year;
        public int Year
        {
            get { return this._year; }
            set { this._year = value; }
        }

        private int _boardRoll;
        public int BoardRoll
        {
            get { return this._boardRoll; }
            set { this._boardRoll = value; }
        }

        private int _boardNo;
        public int BoardNo
        {
            get { return this._boardNo; }
            set { this._boardNo = value; }
        }

        private int _obtainedMarks;
        public int ObtainedMarks
        {
            get { return this._obtainedMarks; }
            set 
            {
                if (this.TotalMarks <= 300)
                {
                    System.Windows.MessageBox.Show("Please enter valid Full marks");
                    this._obtainedMarks = 0;
                }
                else if (value > this.TotalMarks)
                {
                    System.Windows.MessageBox.Show("Marks obtained should be less than full marks");
                    this._obtainedMarks = 0;
                }
                else
                {
                    this._obtainedMarks = value;
                    this.OnPropertyChanged("ObtainedMarks");
                    this.UpdateMarksStatus();
                }
                
            }
        }

        private int _totalMarks;
        public int TotalMarks
        {
            get { return this._totalMarks; }
            set 
            { 
                this._totalMarks = value;
                this.OnPropertyChanged("TotalMarks");
                this.UpdateMarksStatus();
            }
        }

        private float _percentage;
        public float Percentage
        {
            get { return this._percentage; }
            set { this._percentage = value; this.OnPropertyChanged("Percentage"); }
        }

        private string _grade;
        public string Grade
        {
            get { return this._grade; }
            set { this._grade = value; this.OnPropertyChanged("Grade"); }
        }

        private string _status;
        public string Status
        {
            get { return this._status; }
            set { this._status = value.ToUpper(); this.OnPropertyChanged("Status"); }
        }


        private void UpdateMarksStatus()
        {
            if (this.TotalMarks > 0)
            {
                this.Percentage = (this.ObtainedMarks  * 100 ) / this.TotalMarks;
                if (this.Percentage >= 90 && this.Percentage <= 100)
                {
                    this.Grade = "AA";
                    this.Status = "Pass";
                }
                else if (this.Percentage >= 80 && this.Percentage < 90)
                {
                    this.Grade = "A+";
                    this.Status = "Pass";
                }
                else if (this.Percentage >= 60 && this.Percentage < 80)
                {
                    this.Grade = "A";
                    this.Status = "Pass";
                }
                else if (this.Percentage >= 45 && this.Percentage < 60)
                {
                    this.Grade = "B+";
                    this.Status = "Pass";
                }
                else if (this.Percentage >= 35 && this.Percentage < 45)
                {
                    this.Grade = "B";
                    this.Status = "Pass";
                }
                else if (this.Percentage >= 25 && this.Percentage < 35)
                {
                    this.Grade = "C";
                    this.Status = "Pass";
                }
                else if (this.Percentage < 25)
                {
                    this.Grade = "D";
                    this.Status = "Fail";
                }
            }
        }
    }
}
