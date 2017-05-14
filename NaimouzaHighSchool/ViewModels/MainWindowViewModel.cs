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
        public RelayCommand ShowExamViewCommand { get; set; }
        public RelayCommand ShowStudentDetailViewCommand { get; set; }

        private void StartUpInitializer()
        {
            this.ShowExcelExportCommand = new RelayCommand(this.ShowExcelExport, this.CanShowExcelExport);
            this.ShowSessionWindowCommand = new RelayCommand(this.ShowSessionWindow, this.CanShowSessoinWindow);
            this.ShowBoardExamViewCommand = new RelayCommand(this.ShowBoardExamView, this.CanShowBoardExamView);
            this.ShowDeleteViewCommand = new RelayCommand(this.ShowDeleteView, this.CanShowDeleteView);
            this.ShowStaffDetailViewCommand = new RelayCommand(this.ShowStaffDetailView, this.CanShowStaffDetailView);
            this.ShowExamViewCommand = new RelayCommand(this.ShowExamView, this.CanShowExamView);
            this.ShowStudentDetailViewCommand = new RelayCommand(this.ShowStudentDetailView, this.CanShowStudentDetailView);
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

        private void ShowExamView()
        {
            if (NaimouzaHighSchool.Views.ExamView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.ExamView examView = new Views.ExamView();
                examView.Show();
                NaimouzaHighSchool.Views.ExamView.IsOpen = true;
            }
        }

        private bool CanShowExamView()
        {
            return !NaimouzaHighSchool.Views.ExamView.IsOpen;
        }

        private void ShowStudentDetailView()
        {
            if (NaimouzaHighSchool.Views.StudentDataReadView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.StudentDataReadView stdView;
                try
                {
                    stdView = new Views.StudentDataReadView();
                    stdView.Show();
                    NaimouzaHighSchool.Views.StudentDataReadView.IsOpen = true;
                }
                catch (Exception sview)
                {
                    System.Windows.MessageBox.Show("sview : "+sview.Message);
                }
                
            }
        }

        private bool CanShowStudentDetailView()
        {
            return !NaimouzaHighSchool.Views.StudentDataReadView.IsOpen;
        }
    }
}
