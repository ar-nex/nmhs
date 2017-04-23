using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        : base()
        {
            this.StartUpInitializer();
        }

        public RelayCommand ShowExcelExportCommand { get; set; }

        private void StartUpInitializer()
        {
            this.ShowExcelExportCommand = new RelayCommand(this.ShowExcelExport, this.CanShowExcelExport);
        }

        private void ShowExcelExport()
        {
            if (NaimouzaHighSchool.Views.ExcelExportView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.ExcelExportView exExport = new Views.ExcelExportView();
                NaimouzaHighSchool.Views.ExcelExportView.IsOpen = true;
                exExport.Show();
            }
        }

        private bool CanShowExcelExport()
        {
            return !NaimouzaHighSchool.Views.ExcelExportView.IsOpen;
        }
    }
}
