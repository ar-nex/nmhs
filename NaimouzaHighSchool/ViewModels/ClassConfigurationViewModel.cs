using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NaimouzaHighSchool.Models.Utility;

namespace NaimouzaHighSchool.ViewModels
{
    public class ClassConfigurationViewModel: BaseViewModel
    {
        public ClassConfigurationViewModel()
        :base()
        {
            this.startUpInitialize();
        }

        #region fields
        private ObservableCollection<Subject> Subs_V;
        #endregion

        #region property
        public string[] CommonSubs_V { get; set; }
        #endregion

        #region method
        private void startUpInitialize()
        {
            this.CommonSubs_V = new string[] { "Mathematics", "Environment & Science", "History", "Geography" };
        }
        #endregion
    }
}
