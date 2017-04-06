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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NaimouzaHighSchool.Views;

namespace NaimouzaHighSchool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            GroupSubjectPaperView sb = new GroupSubjectPaperView();
            sb.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ExcelEntry exl = new ExcelEntry();
            exl.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            StudentDataWriteView stdWr = new StudentDataWriteView();
            stdWr.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            CharacterCertificateView chr = new CharacterCertificateView();
            chr.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            SubjectComboView scom = new SubjectComboView();
            scom.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            StudentDataReadView stdR = new StudentDataReadView();
            stdR.Show();
        }
    }
}
