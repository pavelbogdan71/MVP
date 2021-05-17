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

        public ObservableCollection<GetStudentGrades_Result> Note(int elevId)
        {
            ObservableCollection<GetStudentGrades_Result> result = new ObservableCollection<GetStudentGrades_Result>();

            var note = context.GetStudentGrades(elevId);

            foreach(var nota in note)
            {
                result.Add(new GetStudentGrades_Result()
                {
                    nota = nota.nota,
                    denumire = nota.denumire
                });
                
            }

            return result;
        }

        public ObservableCollection<GetStudentAbsence_Result> Absente(int elevId)
        {
            ObservableCollection<GetStudentAbsence_Result> result = new ObservableCollection<GetStudentAbsence_Result>();

            var absente = context.GetStudentAbsence(elevId);

            foreach(var absenta in absente)
            {
                result.Add(new GetStudentAbsence_Result()
                {
                    data = absenta.data,
                    denumire = absenta.denumire
                    
                });
            }

            return result;
        }

        public ObservableCollection<GetStudentAverageGrades_Result> Medii(int elevId)
        {
            ObservableCollection<GetStudentAverageGrades_Result> result = new ObservableCollection<GetStudentAverageGrades_Result>();

            var medii = context.GetStudentAverageGrades(elevId);

            foreach(var medie in medii)
            {
                result.Add(new GetStudentAverageGrades_Result()
                {
                    denumire = medie.denumire,
                    Column1 = medie.Column1.Value
                });
            }

            return result;
        }
    }
}
