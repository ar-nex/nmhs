﻿using System;
using System.Windows;
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
        public RelayCommand ShowStudentDetailViewCommand { get; set; }
        public RelayCommand ShowLeavingCharacterCommand { get; set; }
        public RelayCommand ShowRollUpdateWindowCommand { get; set; }
        public RelayCommand ShowMarksEntryWindowCommand { get; set; }
        public RelayCommand ShowStaffExcelImportWindowCommand { get; set; }
        public RelayCommand ShowPromotionBasicViewCommand { get; set; }
        public RelayCommand ShowRegistrationUpdaterCommand { get; set; }
        public RelayCommand ShowTeacherEntryViewCommand { get; set; }
        public RelayCommand ShowStdAddrUpdateCommand { get; set; }
        public RelayCommand ShowDashGridCommand { get; set; }
        public RelayCommand ShowUDiseCommand { get; set; }
        public RelayCommand ShowPromotionWindowCommand { get; set; }
        public RelayCommand ShowSchoolProfileCommand { get; set; }
        public RelayCommand ShowStaffAddViewCommand { get; set; }


        private void StartUpInitializer()
        {
            this.ShowExcelExportCommand = new RelayCommand(this.ShowExcelExport, this.CanShowExcelExport);
            this.ShowSessionWindowCommand = new RelayCommand(this.ShowSessionWindow, this.CanShowSessoinWindow);
            this.ShowBoardExamViewCommand = new RelayCommand(this.ShowBoardExamView, this.CanShowBoardExamView);
            this.ShowDeleteViewCommand = new RelayCommand(this.ShowDeleteView, this.CanShowDeleteView);
            this.ShowStaffDetailViewCommand = new RelayCommand(this.ShowStaffDetailView, this.CanShowStaffDetailView);
            this.ShowStudentDetailViewCommand = new RelayCommand(this.ShowStudentDetailView, this.CanShowStudentDetailView);
            this.ShowLeavingCharacterCommand = new RelayCommand(this.ShowLvngCharcWindow, this.CanShowLvngCharcWindow);
            this.ShowRollUpdateWindowCommand = new RelayCommand(this.ShowRollUpdateWindow, this.CanShowRollUpdateWindow);
            ShowStaffExcelImportWindowCommand = new RelayCommand(ShowStaffExcelImportView, CanShowStaffExcelImportView);
            ShowMarksEntryWindowCommand = new RelayCommand(ShowMarkEntryWindow, CanShowMarkEntryWindow);
            ShowPromotionBasicViewCommand = new RelayCommand(ShowPromotionBasicView, CanShowPromotionBasicView);
            ShowRegistrationUpdaterCommand = new RelayCommand(ShowRegistrationUpdater, CanShowRegistrationUpdater);
            ShowTeacherEntryViewCommand = new RelayCommand(ShowTeacherEntry, CanShowTeacherEntry);
            ShowStdAddrUpdateCommand = new RelayCommand(ShowStdAddrUpdateWindow, CanShowStdAddrUpdateWindow);
            ShowDashGridCommand = new RelayCommand(ShowDashGrid, CanShowDashGrid);
            ShowUDiseCommand = new RelayCommand(ShowUDise, CanShowUDise);
            ShowPromotionWindowCommand = new RelayCommand(ShowPromotionWindow, CanShowPromotionWindow);
            ShowSchoolProfileCommand = new RelayCommand(ShowSchoolProfileWindow, CanShowSchoolProfileWindow);
            ShowStaffAddViewCommand = new RelayCommand(ShowStaffAddView, CanShowStaffAddView);

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

        private void ShowLvngCharcWindow()
        {
            if (NaimouzaHighSchool.Views.SchoolLeavingAndCharacterView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.SchoolLeavingAndCharacterView LvCh = new Views.SchoolLeavingAndCharacterView();
                NaimouzaHighSchool.Views.SchoolLeavingAndCharacterView.IsOpen = true;
                LvCh.Show();
            }
        }

        private bool CanShowLvngCharcWindow()
        {
            return !NaimouzaHighSchool.Views.SchoolLeavingAndCharacterView.IsOpen;
        }

        private void ShowRollUpdateWindow()
        {
            if (NaimouzaHighSchool.Views.RollUpdateView.IsOpen)
            {
                return;
            }
            else
            {
                NaimouzaHighSchool.Views.RollUpdateView rollUpdate = new Views.RollUpdateView();
                NaimouzaHighSchool.Views.RollUpdateView.IsOpen = true;
                rollUpdate.Show();
            }
        }

        private bool CanShowRollUpdateWindow()
        { 
            return !NaimouzaHighSchool.Views.RollUpdateView.IsOpen;
        }

        private void ShowMarkEntryWindow()
        {
            if (Views.MarkEntryView.IsOpen)
            {
                return;
            }
            else
            {
                Views.MarkEntryView markEntry = new Views.MarkEntryView();
                Views.MarkEntryView.IsOpen = true;
                markEntry.Show();
            }
        }

        private bool CanShowMarkEntryWindow()
        {
            return !Views.MarkEntryView.IsOpen;
        }

        private void ShowStaffExcelImportView()
        {
            if (Views.ExcelEntryStaffView.IsOpen)
            {
                return;
            }
            else
            {
                Views.ExcelEntryStaffView exlstaff = new Views.ExcelEntryStaffView();
                Views.ExcelEntryStaffView.IsOpen = true;
                exlstaff.Show();
            }
        }

        private bool CanShowStaffExcelImportView()
        {
            return !Views.ExcelEntryStaffView.IsOpen;
        }

        private void ShowPromotionBasicView()
        {
            if (Views.PromotionBasicView.IsOpen)
            {
                return;
            }
            else
            {
                Views.PromotionBasicView promView = new Views.PromotionBasicView();
                Views.PromotionBasicView.IsOpen = true;
                promView.Show();
            }
        }

        private bool CanShowPromotionBasicView()
        {
            return !Views.PromotionBasicView.IsOpen;
        }

        private void ShowRegistrationUpdater()
        {
            if (Views.RegistrationUpdaterView.IsOpen)
            {
                return;
            }
            else
            {
                Views.RegistrationUpdaterView regView = new Views.RegistrationUpdaterView();
                Views.RegistrationUpdaterView.IsOpen = true;
                regView.Owner = Application.Current.MainWindow;
                regView.Show();
            }
        }
        private bool CanShowRegistrationUpdater()
        {
            return !Views.RegistrationUpdaterView.IsOpen;
        }

        private void ShowTeacherEntry()
        {
            if (Views.TeacherEntryView.IsOpen)
            {
                return;
            }
            else
            {
                Views.TeacherEntryView te = new Views.TeacherEntryView();
                Views.TeacherEntryView.IsOpen = true;
                te.Owner = Application.Current.MainWindow;
                te.Show();
            }
        }

        private bool CanShowTeacherEntry()
        {
            return !Views.TeacherEntryView.IsOpen;
        }

        private void ShowStdAddrUpdateWindow()
        {
            if (Views.StdAddressUpdateView.IsOpen)
            {
                return;
            }
            else
            {
                Views.StdAddressUpdateView adrup = new Views.StdAddressUpdateView();
                Views.StdAddressUpdateView.IsOpen = true;
                adrup.Owner = Application.Current.MainWindow;
                adrup.Show();
            }
        }

        private bool CanShowStdAddrUpdateWindow()
        {
            return !Views.StdAddressUpdateView.IsOpen;
        }

        private void ShowDashGrid()
        {
            if (Views.DashGridView.IsOpen)
            {
                return;
            }
            else
            {
                Views.DashGridView dgrid = new Views.DashGridView();
                Views.DashGridView.IsOpen = true;
                dgrid.Owner = Application.Current.MainWindow;
                dgrid.Show();
            }
        }

        private bool CanShowDashGrid()
        {
            return !Views.DashGridView.IsOpen;
        }

        private void ShowUDise()
        {
            if (!Views.UdiseView.IsOpen)
            {
                Views.UdiseView udise = new Views.UdiseView();
                Views.UdiseView.IsOpen = true;
                udise.Owner = Application.Current.MainWindow;
                udise.Show();
            }
        }

        private bool CanShowUDise()
        {
            return !Views.UdiseView.IsOpen;
        }

        private void ShowPromotionWindow()
        {
            if (!Views.PromotionView.IsOpen)
            {
                Views.PromotionView pview = new Views.PromotionView();
                Views.PromotionView.IsOpen = true;
                pview.Owner = Application.Current.MainWindow;
                pview.Show();
            }
        }

        private bool CanShowPromotionWindow()
        {
            return !Views.PromotionView.IsOpen;
        }

        private void ShowSchoolProfileWindow()
        {
            if (!Views.SchoolProfileView.IsOpen)
            {
                Views.SchoolProfileView sview = new Views.SchoolProfileView();
                Views.SchoolProfileView.IsOpen = true;
                sview.Owner = Application.Current.MainWindow;
                sview.Show();
            }
        }

        private bool CanShowSchoolProfileWindow()
        {
            return !Views.SchoolProfileView.IsOpen;
        }

        private void ShowStaffAddView()
        {
            if (!Views.StaffAddView.IsOpen)
            {
                Views.StaffAddView stfView = new Views.StaffAddView();
                Views.StaffAddView.IsOpen = true;
                stfView.Show();
            }
        }

        private bool CanShowStaffAddView()
        {
            return !Views.StaffAddView.IsOpen;
        }
    }
}
