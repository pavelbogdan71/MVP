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
            CuvantDictionar cuv = new CuvantDictionar
            {
                Cuvant = textBoxCuvant.Text,
                Descriere = textBoxExplcatie.Text,
                Categorie = comboBoxCategorie.Text
            };

            cuv.Categorie = textBoxNewCategory.Text;

            (DataContext as CuvantDictionarVM).CuvinteDictionar.Add(cuv);  
          
        }

      
    }
}
