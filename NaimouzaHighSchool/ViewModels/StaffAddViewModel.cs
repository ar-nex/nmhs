using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Utility;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class StaffAddViewModel : StaffBaseViewModel
    {
        public StaffAddViewModel()
            : base()
        {
            StartUpinitializer();
        }


        public RelayCommand SaveCommand { get; set; }

        #region Method
        private void StartUpinitializer()
        {
            SaveCommand = new RelayCommand(Save, CanSave);
        }

        private void Save()
        {
            System.Windows.MessageBox.Show(VacancyStatus);
        }

        private bool CanSave()
        {
            return true;
        }
        #endregion
    }
}
