using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class UdiseViewModel : StudentClassBaseViewModel
    {
        public UdiseViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private string _outputFile;
        public string OutputFile
        {
            get { return _outputFile; }
            set { _outputFile = value; OnPropertyChanged("OutputFile"); }
        }

        public RelayCommand SaveGeneratedExcelFileCommand { get; set; }

        private void StartUpInitializer()
        {
            SaveGeneratedExcelFileCommand = new RelayCommand(SaveGeneratedExcelFile, CanSaveGeneratedExcelFile);
        }


        private void SaveGeneratedExcelFile()
        {
            System.Windows.MessageBox.Show(OutputFile);
        }

        private bool CanSaveGeneratedExcelFile()
        {
            return !string.IsNullOrEmpty(OutputFile) && SchoolClassIndex != -1 && SchoolSectionIndex != -1;
        }


    }
}
