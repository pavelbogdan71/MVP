using MVP_Tema3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.Actions
{
    class DiriginteActions
    {
        ScoalaDBEntities1 context = new ScoalaDBEntities1();

        private DiriginteVM diriginteContext;

        public DiriginteActions(DiriginteVM diriginteContext)
        {
            this.diriginteContext = diriginteContext;
        }

        public ObservableCollection<DiriginteVM> AllDiriginti()
        {
            List<Profesor> diriginti = context.Profesors.ToList();
            ObservableCollection<DiriginteVM> result = new ObservableCollection<DiriginteVM>();

            foreach(Profesor prof in diriginti)
            {
                result.Add(new DiriginteVM() 
                { DiriginteId = prof.profesorID,
                  Nume = prof.nume,
                  NumeUtilizator = prof.nume_utilizator,
                  Parola = prof.parola
                });

            }


            return result;
        }
    }
}
