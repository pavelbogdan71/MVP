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
            CuvantDictionar cuv = new CuvantDictionar
            {
                Cuvant = textBoxCuvant.Text,
                Descriere = textBoxExplcatie.Text,
                Categorie = comboBoxCategorie.Text,
                Imagine = System.IO.Path.GetFileName(imgPhoto.Source.ToString())
            };

            if(cuv.Categorie=="")
            {
                cuv.Categorie = textBoxNewCategory.Text;
            }
            

            (DataContext as CuvantDictionarVM).CuvinteDictionar.Add(cuv);

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All files (*.*)|*.*";


            if (op.ShowDialog() == true)
            {
                string source = op.FileName;
                string destination = @"C:\Users\pavel\Desktop\Fac Repo\MVP\Tema1\MVP_Tema1\MVP_Tema1\Images\" + op.SafeFileName;
                if(source!=destination)
                {
                    System.IO.File.Copy(source, destination, true);
                }
                
                imgPhoto.Source = new BitmapImage(new Uri(destination));
                
            }
        }
    }
}
