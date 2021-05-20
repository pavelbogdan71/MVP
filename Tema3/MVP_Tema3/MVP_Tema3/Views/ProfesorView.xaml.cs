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
    /// Interaction logic for ProfesorView.xaml
    /// </summary>
    public partial class ProfesorView : Window
    {
        public static int ProfesorId;

        public ProfesorView()
        {
            InitializeComponent();
        }

        public ProfesorView(int profId)
        {
            ProfesorId = profId;
            InitializeComponent();
        }
    }
}
