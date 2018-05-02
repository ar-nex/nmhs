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
    /// Interaction logic for SchoolProfileView.xaml
    /// </summary>
    public partial class SchoolProfileView : Window
    {
        public SchoolProfileView()
        {
            InitializeComponent();
        }

        public static bool IsOpen;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }

        private void PrintSchoolCanvas(object sender, RoutedEventArgs e)
        {
            PrintDialog pdc = new PrintDialog();
            if (pdc.ShowDialog() == true)
            {
                pdc.PrintVisual(GridSchool, "School Profile");
            }
        }

        private void PrintCanvasClass(object sender, RoutedEventArgs e)
        {
            PrintDialog pdc = new PrintDialog();
            if (pdc.ShowDialog() == true)
            {
                pdc.PrintVisual(GridClass, "Class Profile");
            }
        }

        private void PrintStreamProfile(object sender, RoutedEventArgs e)
        {
            PrintDialog pdc = new PrintDialog();
            if (pdc.ShowDialog() == true)
            {
                pdc.PrintVisual(GridStream, "Stream Profile");
            }
        }
    }
}
