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
        public RelayCommand ShowSessionWindowCommand { get; set; }

        private void StartUpInitializer()
        {
            this.ShowExcelExportCommand = new RelayCommand(this.ShowExcelExport, this.CanShowExcelExport);
            this.ShowSessionWindowCommand = new RelayCommand(this.ShowSessionWindow, this.CanShowSessoinWindow);
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

        private void ShowSessionWindow()
        {
            if (NaimouzaHighSchool.Views.SessionView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.SessionView sessionWindow = new Views.SessionView();
                NaimouzaHighSchool.Views.SessionView.IsOpen = true;
                sessionWindow.Show();
            }
        }

        private bool CanShowSessoinWindow()
        {
            return !NaimouzaHighSchool.Views.SessionView.IsOpen;
        }
    }
}
