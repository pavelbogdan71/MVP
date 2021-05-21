using MVP_Tema3.Helpers;
using MVP_Tema3.Models.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVP_Tema3.ViewModels
{
    class AdministratorVM:BaseVM
    {
        AdministratorActions aAct;

        public AdministratorVM()
        {
            aAct = new AdministratorActions(this);
        }

        #region Data Members

        private int adminId;
        private string numeUtilizator;
        private string parola;

        private ObservableCollection<AdministratorVM> adminList;

        private ObservableCollection<ElevVM> elevList;
        private ObservableCollection<ProfesorVM> profList;
        private ObservableCollection<MaterieVM> materiiList;

        public int AdminId
        {
            get
            {
                return adminId;
            }
            set
            {
                adminId = value;
                NotifyPropertyChanged("AdminId");
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

        public ObservableCollection<AdministratorVM> AdminList
        {
            get
            {
                adminList = aAct.AllAdmins();
                return adminList;
            }

            set
            {
                adminList = value;
                NotifyPropertyChanged("AdminList");
            }
        }

        public ObservableCollection<ElevVM> ElevList
        {
            get
            {
                elevList = aAct.AllElevs();
                return elevList;
            }
            set
            {
                elevList = value;
                NotifyPropertyChanged("ElevList");
            }
        }

        public ObservableCollection<ProfesorVM> ProfList
        {
            get
            {
                profList = aAct.AllProf();
                return profList;
            }
            set
            {
                profList = value;
                NotifyPropertyChanged("ProfList");
            }
        }

        public ObservableCollection<MaterieVM> MateriiList
        {
            get
            {
                materiiList = aAct.AllMaterii();
                return materiiList;
            }
            set
            {
                materiiList = value;
                NotifyPropertyChanged("MateriiList");
            }
        }
        #endregion

        #region Commands

        private ICommand adaugareElev;
        public ICommand AdaugareElev
        {
            get
            {
                if(adaugareElev==null)
                {
                    adaugareElev = new RelayCommand(aAct.AdaugareElev);
                }
                return adaugareElev;
            }
        }

        private ICommand modificareElev;
        public ICommand ModificareElev
        {
            get
            {
                if(modificareElev==null)
                {
                    modificareElev = new RelayCommand(aAct.ModificareElev);
                }
                return modificareElev;
            }
        }

        private ICommand stergereElev;
        public ICommand StergereElev
        {
            get
            {
                if(stergereElev==null)
                {
                    stergereElev = new RelayCommand(aAct.StergereElev);
                }
                return stergereElev;
            }
        }


        private ICommand adaugareProfesor;
        public ICommand AdaugareProfesor
        {
            get
            {
                if(adaugareProfesor==null)
                {
                    adaugareProfesor = new RelayCommand(aAct.AdaugareProfesor);
                }
                return adaugareProfesor;
            }
        }

        private ICommand modificareProfesor;
        public ICommand ModificareProfesor
        {
            get
            {
                if(modificareProfesor==null)
                {
                    modificareProfesor = new RelayCommand(aAct.ModificareProfesor);
                }
                return modificareProfesor;
            }
        }

        private ICommand stergereProfesor;
        public ICommand StergereProfesor
        {
            get
            {
                if(stergereProfesor==null)
                {
                    stergereProfesor = new RelayCommand(aAct.StergereProfesor);
                }
                return stergereProfesor;
            }
        }

        private ICommand adaugareMaterie;
        public ICommand AdaugareMaterie
        {
            get
            {
                if(adaugareMaterie==null)
                {
                    adaugareMaterie = new RelayCommand(aAct.AdaugareMaterie);
                }
                return adaugareMaterie;
            }
        }

        private ICommand modificareMaterie;
        public ICommand ModificareMaterie
        {
            get
            {
                if(modificareMaterie==null)
                {
                    modificareMaterie = new RelayCommand(aAct.ModificareMaterie);
                }
                return modificareMaterie;
            }
        }

        private ICommand stergereMaterie;
        public ICommand StergereMaterie
        {
            get
            {
                if(stergereMaterie==null)
                {
                    stergereMaterie = new RelayCommand(aAct.StergereMaterie);
                }
                return stergereMaterie;
            }
        }
        #endregion
    }
}
