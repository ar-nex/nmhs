﻿using System.Windows;

namespace NaimouzaHighSchool.Views
{
    /// <summary>
    /// Interaction logic for RollUpdateView.xaml
    /// </summary>
    public partial class RollUpdateView : Window
    {
        public RollUpdateView()
        {
            InitializeComponent();
        }

        public static bool IsOpen;

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }
    }
}
