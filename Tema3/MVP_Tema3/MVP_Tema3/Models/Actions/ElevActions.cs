using MVP_Tema3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.Actions
{
    class ElevActions
    {
        ScoalaDBEntities1 context = new ScoalaDBEntities1();

        private ElevVM elevContext;

        public ElevActions(ElevVM elevContext)
        {
            this.elevContext = elevContext;
        }


        public ObservableCollection<ElevVM> AllElevs()
        {
            List<Elev> elevs = context.Elevs.ToList();
            ObservableCollection<ElevVM> result = new ObservableCollection<ElevVM>();

            foreach(Elev elev in elevs)
            {
                result.Add(new ElevVM()
                {
                    ElevId = elev.elevID,
                    Nume = elev.nume,
                    NumeUtilizator = elev.nume_utilizator,
                    Parola = elev.parola

                });
            }

            return result;
        }
    }
}
