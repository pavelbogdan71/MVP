using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace MVP_Tema1
{
    class CuvantDictionarVM
    {
        public static ObservableCollection<CuvantDictionar> CuvinteDictionar { get; set; }
        public ObservableCollection<string> Categorii { get; set; }


        public static List<CuvantDictionar> listaCuvinte;
        public static int index;
        public static int points;


        public CuvantDictionarVM()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<CuvantDictionar>));
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\Data\cuvinte.xml");
            CuvinteDictionar = (ObservableCollection<CuvantDictionar>)reader.Deserialize(file);

            Categorii = new ObservableCollection<string>();
            foreach (CuvantDictionar cuvant in CuvinteDictionar)
            {
                bool ok = true;
                if (Categorii != null)
                {
                    foreach (string categorie in Categorii)
                    {
                        if (cuvant.Categorie == categorie)
                        {
                            ok = false;
                        }
                    }
                }

                if (ok)
                {
                    Categorii.Add(cuvant.Categorie);
                }
            }

            file.Close();
        }




        public static void AdaugareCuvant(TextBox textBoxCuvant, TextBox textBoxExplcatie, ComboBox comboBoxCategorie, Image imgPhoto, TextBox textBoxNewCategory)
        {
            CuvantDictionar cuv = new CuvantDictionar
            {
                Cuvant = textBoxCuvant.Text,
                Descriere = textBoxExplcatie.Text,
                Categorie = comboBoxCategorie.Text,
                Imagine = System.IO.Path.GetFileName(imgPhoto.Source.ToString())
            };

            if (cuv.Categorie == "")
            {
                cuv.Categorie = textBoxNewCategory.Text;
            }


            if(cuv.Cuvant=="" || cuv.Descriere=="" || cuv.Categorie=="")
            {
                MessageBox.Show("Cuvantul nu a fost adaugat\nInput invalid");
            }
            else
            {
                CuvinteDictionar.Add(cuv);
            }
            
        }

        public static void IncarcareImagine(Image imgPhoto)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All files (*.*)|*.*";


            if (op.ShowDialog() == true)
            {
                string source = op.FileName;
                string destination = @"C:\Users\pavel\Desktop\Fac Repo\MVP\Tema1\MVP_Tema1\MVP_Tema1\Images\" + op.SafeFileName;
                if (source != destination)
                {
                    System.IO.File.Copy(source, destination, true);
                }

                imgPhoto.Source = new BitmapImage(new Uri(destination));

            }
        }

        public static void CautareCuvant(TextBox searchTextBox, TextBlock wordCategory, TextBlock wordDescription, Image image, CheckBox checkBox, ComboBox categoryComboBox, ListBox searchListBox)
        {
            if(checkBox.IsChecked.GetValueOrDefault())
            {
                searchListBox.Visibility = Visibility.Collapsed;
            }
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

                foreach (CuvantDictionar cuv in CuvantDictionarVM.CuvinteDictionar)
                {
                    if (cuv.Cuvant.StartsWith(cuvantCautat))
                    {
                        if (checkBox.IsChecked.GetValueOrDefault())
                        {
                            if (cuv.Categorie == categoryComboBox.Text.ToString())
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

        public static void SelectareCuvantListaCautari(ListBox searchListBox,TextBox searchTextBox,TextBlock wordDescription,TextBlock wordCategory,Image image)
        {

            if (searchListBox.SelectedItem != null)
            {

                searchTextBox.Text = (searchListBox.SelectedItem as CuvantDictionar).Cuvant.ToString();
                searchListBox.Visibility = Visibility.Collapsed;

                wordDescription.Text = "Descriere: " + (searchListBox.SelectedItem as CuvantDictionar).Descriere.ToString();
                wordCategory.Text = "Categorie: " + (searchListBox.SelectedItem as CuvantDictionar).Categorie.ToString();



                image.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\", (searchListBox.SelectedItem as CuvantDictionar).Imagine)));

                image.Visibility = Visibility.Visible;
            }
        }



        public static List<CuvantDictionar> ListaCuvinteRandom()
        {

            List<CuvantDictionar> cuvinteRandom = new List<CuvantDictionar>();
            List<CuvantDictionar> copie=new List<CuvantDictionar>(CuvinteDictionar);

            Random random = new Random();

            for(int i=0;i<5;i++)
            {
                int nrRandom = random.Next(copie.Count());
                cuvinteRandom.Add(copie.ElementAt(nrRandom));
                copie.RemoveAt(nrRandom);
            }

            return cuvinteRandom;
        }

        public static void InitiareJoc(Image image,TextBlock textBlock,Button button)
        {
            Random random = new Random();

            listaCuvinte = ListaCuvinteRandom();


            int elemRandom = random.Next(0, listaCuvinte.Count());

            points = 0;
            index = 0;

            CuvantDictionar cuvAux = listaCuvinte.ElementAt(index);


            int comp = random.Next(0, 2);

            image.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\", cuvAux.Imagine)));
            textBlock.Text = cuvAux.Descriere;

            if (comp == 0 && cuvAux.Imagine != "no_image_available.jpg")
            {
                textBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                image.Visibility = Visibility.Hidden;
            }


        }


        public static void UrmatorulCuvant(Image image,TextBox raspuns,TextBlock textBlock,Button button)
        {

            if (listaCuvinte.ElementAt(index).Cuvant.Equals(raspuns.Text))
            {
                points++;
                MessageBox.Show("Corect");
            }
            else
            {
                MessageBox.Show("Incorect\nRaspuns corect:"+ listaCuvinte.ElementAt(index).Cuvant);
            }
            index++;

            raspuns.Text = "";

            if (index<5)
            {
              
                CuvantDictionar cuvAux = listaCuvinte.ElementAt(index);

                Random random = new Random();
                int comp = random.Next(0, 2);

                image.Source = new BitmapImage(new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images\", cuvAux.Imagine)));
                textBlock.Text = cuvAux.Descriere;

                if (comp == 0 && cuvAux.Imagine != "no_image_available.jpg")
                {
                    textBlock.Visibility = Visibility.Hidden;
                    image.Visibility = Visibility.Visible;
                }
                else
                {
                    textBlock.Visibility = Visibility.Visible;
                    image.Visibility = Visibility.Hidden;
                }
            }

            if(index==4)
            {
                button.Content = "Finish";
            }

            if(index==5)
            {
                MessageBox.Show("Raspunsuri corecte:" + points+"/5");
                InitiareJoc(image, textBlock, button);
            }
            
        }
        ~CuvantDictionarVM()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<CuvantDictionar>));

            TextWriter writer = new StreamWriter(@"..\..\Data\cuvinte.xml");

            ser.Serialize(writer, CuvinteDictionar);

            writer.Close();
        }
    }
}
