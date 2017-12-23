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
    }
}
