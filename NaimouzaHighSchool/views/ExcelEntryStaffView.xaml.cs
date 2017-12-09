using System.Windows;

namespace NaimouzaHighSchool.Views
{
    /// <summary>
    /// Interaction logic for ExcelEntryStaffView.xaml
    /// </summary>
    public partial class ExcelEntryStaffView : Window
    {
        public ExcelEntryStaffView()
        {
            InitializeComponent();
        }

        public static bool IsOpen;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }
    }
}
