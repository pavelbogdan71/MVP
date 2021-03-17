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
using System.IO;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for PaginaCautare.xaml
    /// </summary>
    public partial class PaginaCautare : Page
    {
        public PaginaCautare()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CuvantDictionarVM.CautareCuvant(searchTextBox, wordCategory, wordDescription, image, checkBox, categoryComboBox, searchListBox);
        }


        private void searchListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CuvantDictionarVM.SelectareCuvantListaCautari(searchListBox, searchTextBox, wordDescription, wordCategory, image);
            
        }

        
    }
}
