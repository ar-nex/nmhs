using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.ViewModels
{
    public class SessionViewModel : BaseViewModel
    {
        public SessionViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        private System.Windows.Visibility _msgVisibility;
        public System.Windows.Visibility MsgVisibility
        {
            get { return this._msgVisibility; }
            set { this._msgVisibility = value; this.OnPropertyChanged("MsgVisibility"); }
        }

        private void StartUpInitializer()
        {

          
        }
    }
}
