using MVP_Tema3.Models.ResultEntities;
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

        public ObservableCollection<NotaElev> Note(int elevId)
        {
            ObservableCollection<NotaElev> result = new ObservableCollection<NotaElev>();

            var note = context.GetStudentGrades(elevId);

            foreach(var nota in note)
            {
                result.Add(new NotaElev()
                {
                    Nota = nota.nota,
                    DenumireMaterie = nota.denumire
                });
                
            }

            return result;
        }

        public ObservableCollection<AbsentaElev> Absente(int elevId)
        {
            ObservableCollection<AbsentaElev> result = new ObservableCollection<AbsentaElev>();

            var absente = context.GetStudentAbsence(elevId);

            foreach(var absenta in absente)
            {
                result.Add(new AbsentaElev()
                {
                    Data = absenta.data,
                    DenumireMaterie = absenta.denumire
                });
            }

            return result;
        }

        public ObservableCollection<MedieMaterie> Medii(int elevId)
        {
            ObservableCollection<MedieMaterie> result = new ObservableCollection<MedieMaterie>();

            var medii = context.GetStudentAverageGrades(elevId);

            foreach(var medie in medii)
            {
                result.Add(new MedieMaterie()
                {
                    DenumireMaterie = medie.denumire,
                    Medie = medie.Column1
                });
            }

            return result;
        }
    }
}
