using System.Windows;

namespace NaimouzaHighSchool.Views
{
    /// <summary>
    /// Interaction logic for PromotionBasicView.xaml
    /// </summary>
    public partial class PromotionBasicView : Window
    {
        public PromotionBasicView()
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
