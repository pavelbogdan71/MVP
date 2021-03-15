using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVP_Tema1
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

        private void BtnClickAdministrare(object sender, RoutedEventArgs e)
        {
            dex.Visibility = Visibility.Hidden;
            MainFrame.Content = new PaginaAdministrare();
        }

        private void BtnClickCautare(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PaginaCautare();
        }

        private void BtnClickJoc(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PaginaJoc();
        }

        

    }
}
