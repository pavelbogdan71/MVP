using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace MVP_Tema1
{
    class CuvantDictionarVM
    {
        public ObservableCollection<CuvantDictionar> CuvinteDictionar { get; set; }
        public ObservableCollection<string> Categorii { get; set; }

        public CuvantDictionarVM()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<CuvantDictionar>));
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\Data\cuvinte.xml");
            CuvinteDictionar = (ObservableCollection<CuvantDictionar>)reader.Deserialize(file);

            Categorii = new ObservableCollection<string>();
            foreach(CuvantDictionar cuvant in CuvinteDictionar)
            {
                bool ok = true;
                if(Categorii!=null)
                {
                    foreach (string categorie in Categorii)
                    {
                        if (cuvant.Categorie == categorie)
                        {
                            ok = false;
                        }
                    }
                }
                
                if(ok)
                {
                    Categorii.Add(cuvant.Categorie);
                }
            }

            file.Close();
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
