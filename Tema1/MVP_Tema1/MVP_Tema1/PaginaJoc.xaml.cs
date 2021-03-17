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
    /// Interaction logic for PaginaJoc.xaml
    /// </summary>
    public partial class PaginaJoc : Page
    {
        public CuvantDictionar cuvAux;

        public PaginaJoc()
        {
            InitializeComponent();



            Random random = new Random();


            List<CuvantDictionar> listaCuvinte = (DataContext as CuvantDictionarVM).CuvinteDictionar.ToList();

            int elemRandom = random.Next(0, listaCuvinte.Count());

            cuvAux = listaCuvinte.ElementAt(elemRandom);


            
            int comp = random.Next(0, 2);

            image.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\",cuvAux.Imagine)));
            textBlock.Text = cuvAux.Descriere;

            if(comp==0 && cuvAux.Imagine!="no_image_available.jpg")
            {
                textBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                image.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(raspuns.Text==cuvAux.Cuvant)
            {
                MessageBox.Show("Corect");
                
            }
            else
            {
                MessageBox.Show("Gresit");

            }

        }
    }
}
