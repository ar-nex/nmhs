using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NaimouzaHighSchool.Views
{
    /// <summary>
    /// Interaction logic for UdiseView.xaml
    /// </summary>
    public partial class UdiseView : Window
    {
        public UdiseView()
        {
            InitializeComponent();
        }

        public static bool IsOpen;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => IsOpen = false;

        private void BrowseOutputStream(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefd = new SaveFileDialog();
            savefd.Filter = "Excel file|*.xlsx;*.xls";
            savefd.Title = "Save an Excel File";
            savefd.ShowDialog();
            if (savefd.FileName != "")
            {
                OutputFilePathName.Text = savefd.FileName;
            }
        }
    }
}
