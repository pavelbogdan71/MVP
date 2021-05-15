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
        #endregion
    }
}
