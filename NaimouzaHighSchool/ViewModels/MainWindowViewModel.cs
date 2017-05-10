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
        public RelayCommand ShowBoardExamViewCommand { get; set; }
        public RelayCommand ShowDeleteViewCommand { get; set; }
        public RelayCommand ShowStaffDetailViewCommand { get; set; }

        private void StartUpInitializer()
        {
            this.ShowExcelExportCommand = new RelayCommand(this.ShowExcelExport, this.CanShowExcelExport);
            this.ShowSessionWindowCommand = new RelayCommand(this.ShowSessionWindow, this.CanShowSessoinWindow);
            this.ShowBoardExamViewCommand = new RelayCommand(this.ShowBoardExamView, this.CanShowBoardExamView);
            this.ShowDeleteViewCommand = new RelayCommand(this.ShowDeleteView, this.CanShowDeleteView);
            this.ShowStaffDetailViewCommand = new RelayCommand(this.ShowStaffDetailView, this.CanShowStaffDetailView);
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

        private void ShowBoardExamView()
        {
            if (NaimouzaHighSchool.Views.BoardExamView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.BoardExamView bexam = new Views.BoardExamView();
                NaimouzaHighSchool.Views.BoardExamView.IsOpen = true;
                bexam.Show();
            }
        }

        private bool CanShowBoardExamView()
        {
            return !NaimouzaHighSchool.Views.BoardExamView.IsOpen;
        }

        private void ShowDeleteView()
        {
            if (NaimouzaHighSchool.Views.DeleteView.IsOpen)
            {
                return;
            }
            else 
            {
                NaimouzaHighSchool.Views.DeleteView delWindow = new Views.DeleteView();
                NaimouzaHighSchool.Views.DeleteView.IsOpen = true;
                delWindow.Show();
            }
        }

        private bool CanShowDeleteView()
        {
            return !NaimouzaHighSchool.Views.DeleteView.IsOpen;
        }

        private void ShowStaffDetailView()
        {
            if (NaimouzaHighSchool.Views.StaffDetailView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.StaffDetailView Staff = new Views.StaffDetailView();
                NaimouzaHighSchool.Views.StaffDetailView.IsOpen = true;
                Staff.Show();
            }
        }

        private bool CanShowStaffDetailView()
        {
            return !NaimouzaHighSchool.Views.StaffDetailView.IsOpen;
        }
    }
}
