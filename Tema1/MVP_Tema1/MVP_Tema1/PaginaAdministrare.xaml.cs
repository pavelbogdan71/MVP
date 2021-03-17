using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PaginaAdministrare.xaml
    /// </summary>
    public partial class PaginaAdministrare : Page
    {
        public PaginaAdministrare()
        {
            InitializeComponent();
        }

        private void btnClickAdd(object sender, RoutedEventArgs e)
        {
            CuvantDictionarVM.AdaugareCuvant(textBoxCuvant, textBoxExplcatie, comboBoxCategorie, imgPhoto, textBoxNewCategory);

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            CuvantDictionarVM.IncarcareImagine(imgPhoto);
        }
    }
}
