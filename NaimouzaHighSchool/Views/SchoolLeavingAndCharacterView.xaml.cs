﻿using System;
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
    /// Interaction logic for SchoolLeavingAndCharacterView.xaml
    /// </summary>
    public partial class SchoolLeavingAndCharacterView : Window
    {
        public SchoolLeavingAndCharacterView()
        {
            InitializeComponent();
        }

        static public bool IsOpen;

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }
    }
}
