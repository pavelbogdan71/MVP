using MVP_Tema3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.Actions
{
    class ProfesorActions
    {
        ScoalaDBEntities1 context = new ScoalaDBEntities1();

        private ProfesorVM profesorContext;

        public ProfesorActions(ProfesorVM profesorContext)
        {
            this.profesorContext = profesorContext;
        }

        public ObservableCollection<ProfesorVM> AllProfesors()
        {
            List<Profesor> profesors = context.Profesor.ToList();
            ObservableCollection<ProfesorVM> result = new ObservableCollection<ProfesorVM>();

            foreach(Profesor prof in profesors)
            {
                result.Add(new ProfesorVM()
                {
                    ProfesorId = prof.profesorID,
                    Nume = prof.nume,
                    NumeUtilizator = prof.nume_utilizator,
                    Parola = prof.parola,
                    Diriginte = prof.diriginte
                });
                
            }

            return result;
        }
    }
}
