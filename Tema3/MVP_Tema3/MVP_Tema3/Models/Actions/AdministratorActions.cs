using MVP_Tema3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.Actions
{
    class AdministratorActions
    {
        ScoalaDBEntities1 context = new ScoalaDBEntities1();

        private AdministratorVM adminContext;

        public AdministratorActions(AdministratorVM adminContext)
        {
            this.adminContext = adminContext;
        }

        public ObservableCollection<AdministratorVM> AllAdmins()
        {
            List<Administrator> admins = context.Administrators.ToList();
            ObservableCollection<AdministratorVM> result = new ObservableCollection<AdministratorVM>();

            foreach(Administrator admin in admins)
            {
                result.Add(new AdministratorVM()
                {
                    AdminId = admin.adminID,
                    NumeUtilizator = admin.nume_utilizator,
                    Parola = admin.parola
                });
            }

            return result;
        }
    }
}
