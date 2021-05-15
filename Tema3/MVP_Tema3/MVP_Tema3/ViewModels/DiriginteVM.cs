using MVP_Tema3.Helpers;
using MVP_Tema3.Models.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.ViewModels
{
    class DiriginteVM:BaseVM
    {
        DiriginteActions dAct;

        public DiriginteVM()
        {
            dAct = new DiriginteActions(this);
        }

        #region Data Members
        private int diriginteId;
        private string nume;
        private string numeUtilizator;
        private string parola;
        private bool diriginte;

        private ObservableCollection<DiriginteVM> diriginteList;

        public int DiriginteId
        {
            get
            {
                return DiriginteId;
            }
            set
            {
                DiriginteId = value;
                NotifyPropertyChanged("DiriginteId");
            }
        }

        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }

        public string NumeUtilizator
        {
            get
            {
                return numeUtilizator;
            }
            set
            {
                numeUtilizator = value;
                NotifyPropertyChanged("NumeUtilizator");
            }
        }

        public string Parola
        {
            get
            {
                return parola;
            }
            set
            {
                parola = value;
                NotifyPropertyChanged("Parola");
            }
        }

        public bool Diriginte
        {
            get
            {
                return diriginte;
            }
            set
            {
                diriginte = value;
                NotifyPropertyChanged("Diriginte");
            }
        }

        public ObservableCollection<DiriginteVM> DiriginteList
        {
            get
            {
                diriginteList = dAct.AllDiriginti();
                return diriginteList;
            }
            set
            {
                diriginteList = value;
                NotifyPropertyChanged("DiriginteList");
            }
        }
        #endregion
    }
}
