using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
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
    /// Interaction logic for DashGridView.xaml
    /// </summary>
    public partial class DashGridView : Window
    {
        public DashGridView()
        {
            InitializeComponent();
        }
        public static bool IsOpen;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }

        private void PrintDashGrid(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(GridForPrint, "A Simple Drawing");
            }
        }
    }
}
