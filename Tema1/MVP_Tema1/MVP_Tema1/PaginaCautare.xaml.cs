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
            if (searchTextBox.Text == string.Empty)
            {
                wordCategory.Text = string.Empty;
                wordDescription.Text = string.Empty;
                image.Visibility = Visibility.Hidden;
            }
            else
            {
                List<CuvantDictionar> lista = new List<CuvantDictionar>();

                string cuvantCautat = searchTextBox.Text;

                foreach (CuvantDictionar cuv in (DataContext as CuvantDictionarVM).CuvinteDictionar) 
                {
                    if (cuv.Cuvant.StartsWith(cuvantCautat))
                    {
                        if(checkBox.IsChecked.GetValueOrDefault())
                        {
                            if(cuv.Categorie==categoryComboBox.Text.ToString())
                            {
                                lista.Add(cuv);
                            }
                        }
                        else
                        {
                            lista.Add(cuv);
                        }
                        
                    }
                }

                searchListBox.ItemsSource = lista;
                searchListBox.Visibility = Visibility.Visible;
            }
        }


        private void searchListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (searchListBox.SelectedItem != null)
            {

                searchTextBox.Text = (searchListBox.SelectedItem as CuvantDictionar).Cuvant.ToString();
                searchListBox.Visibility = Visibility.Collapsed;

                wordDescription.Text = "Descriere: " + (searchListBox.SelectedItem as CuvantDictionar).Descriere.ToString();
                wordCategory.Text = "Categorie: " + (searchListBox.SelectedItem as CuvantDictionar).Categorie.ToString();


                
                image.Source =new BitmapImage(new Uri (System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\Images\", (searchListBox.SelectedItem as CuvantDictionar).Imagine)));

                image.Visibility = Visibility.Visible;
            }
            
        }
    }
}
