﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVP_Tema3.Views
{
    /// <summary>
    /// Interaction logic for ElevView.xaml
    /// </summary>
    public partial class ElevView : Window
    {
        public static int ElevId;

        public ElevView()
        {
            InitializeComponent();
        }

        public ElevView(int elevId)
        {
            ElevId = elevId;
            InitializeComponent();
            
        }
    }
}
