using System;

namespace NaimouzaHighSchool.Models.Utility
{
    public class RollUpdater : BaseModel
    {
        public RollUpdater()
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
            set { this._name = value; }
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
            set { this._section = value; }
        }

        private int _oldRoll;
        public int OldRoll
        {
            get { return this._oldRoll; }
            set { this._oldRoll = value; }
        }

        private int _newRoll;
        public int NewRoll
        {
            get { return this._newRoll; }
            set 
            {
                this._newRoll = value;
                this.OnPropertyChanged("NewRoll");
                this.OnNewRollSectionSetEvent();
            }
        }

        private string _newSection;

        public string NewSection
        {
            get { return _newSection; }
            set
            {
                if (value != null)
                {
                    if ("A" == value.ToUpper() || "B" == value.ToUpper() || "C" == value.ToUpper() || "D" == value.ToUpper())
                    {
                        _newSection = value.ToUpper();
                    }
                    else
                    {
                        _newSection = string.Empty;
                    }
                }
                OnPropertyChanged("NewSection");
                OnNewRollSectionSetEvent();
            }
        }


        public event EventHandler NewRollSectionSetEvent;

        public void OnNewRollSectionSetEvent()
        {
            NewRollSectionSetEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
