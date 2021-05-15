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
    class ProfesorVM:BaseVM
    {
        ProfesorActions pAct;

        public ProfesorVM()
        {
            pAct = new ProfesorActions(this);
        }


        #region Data Members
        private int profesorId;
        private string nume;
        private string numeUtilizator;
        private string parola;
        private bool diriginte;

        private ObservableCollection<ProfesorVM> profesorList;

        public int ProfesorId 
        {
            get
            {
                return profesorId;
            }
            set
            {
                profesorId = value;
                NotifyPropertyChanged("ProfesorId");
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

        public ObservableCollection<ProfesorVM> ProfesorList
        {
            get
            {
                profesorList = pAct.AllProfesors();
                return profesorList;
            }
            set
            {
                profesorList = value;
                NotifyPropertyChanged("ProfesorList");
            }
        }
        #endregion
    }
}
