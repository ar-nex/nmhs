using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class PromotionBasic : RollUpdater
    {
        public PromotionBasic()
            : base()
        {

        }


        private string _sex;
        public string Sex
        {
            get => _sex;
            set
            {
                _sex = value;
                OnPropertyChanged("Sex");
            }
        }

        private string _newClass;
        public string NewClass
        {
            get => _newClass;
            set
            {
                _newClass = value;
                OnPropertyChanged("NewClass");
            }
        }

        private string _newSection;
        public string NewSection
        {
            get => _newSection;
            set
            {
                if (value != null && (value.ToUpper() == "A" || value.ToUpper() == "B" || value.ToUpper() == "C" || value.ToUpper() == "D" || value.ToUpper() == "E") )
                {
                    _newSection = value.ToUpper();
                }
                else
                {
                    _newSection = string.Empty;
                }
                OnPropertyChanged("NewSection");
            }
        }

        private string _oldStat;
        public string OldStat
        {
            get => _oldStat;
            set
            {
                _oldStat = value;
                OnPropertyChanged("OldStat");
            }
        }

        private string _stream;
        public string Stream
        {
            get => _stream;
            set
            {
                _stream = value;
                OnPropertyChanged("Stream");
            }
        }

        private string _hsSub1;
        public string HsSub1
        {
            get => _hsSub1;
            set
            {
                _hsSub1 = value;
                OnPropertyChanged("HsSub1");
            }
        }

        private string _hsSub2;
        public string HsSub2
        {
            get => _hsSub2;
            set
            {
                _hsSub2 = value;
                OnPropertyChanged("HsSub2");
            }
        }

        private string _hsSub3;
        public string HsSub3        {
            get => _hsSub2;
            set
            {
                _hsSub3= value;
                OnPropertyChanged("HsSub3");
            }
        }

        private string _hsAdl;
        public string HsAdl
        {
            get => _hsAdl;
            set
            {
                _hsAdl = value;
                OnPropertyChanged("HsAdl");
            }
        }

    }
}
