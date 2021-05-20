using MVP_Tema3.Helpers;
using MVP_Tema3.Models;
using MVP_Tema3.Models.Actions;
using MVP_Tema3.Views;
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

        private ObservableCollection<GetTeacherClasses_Result> claseProfesor;



        public ObservableCollection<GetTeacherClasses_Result> ClaseProfesor
        {
            get
            {
                claseProfesor = pAct.GetClaseProfesor(ProfesorView.ProfesorId);
                return claseProfesor;
            }
            set
            {
                claseProfesor = value;
                NotifyPropertyChanged("ClaseProfesor");
            }
        }

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
