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
    }
}
