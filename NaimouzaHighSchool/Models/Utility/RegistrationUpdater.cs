using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaimouzaHighSchool.Models.Utility
{
    public class RegistrationUpdater : ViewModels.BaseViewModel
    {
        public RegistrationUpdater()
            : base()
        {

        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Cls { get; set; }
        public string Section { get; set; }
        public int Roll { get; set; }
        private string _registrationNo;
        public string RegistrationNo
        {
            get => _registrationNo;
            set
            {
                _registrationNo = value;
                OnPropertyChanged("RegistrationNo");
            }
        }
    }
}
