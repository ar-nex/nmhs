using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class PromotionMapping : BaseModel
    {
        public PromotionMapping(string map)
        {
            Map = map;
        }
        private string _map;
        public string Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged("Map"); }
        }

    }
}
