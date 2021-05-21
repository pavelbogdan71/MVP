using MVP_Tema3.ViewModels;
using MVP_Tema3.Views;
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
            List<Profesor> profesors = context.Profesors.ToList();
            ObservableCollection<ProfesorVM> result = new ObservableCollection<ProfesorVM>();

            foreach(Profesor prof in profesors)
            {
                result.Add(new ProfesorVM()
                {
                    ProfesorId = prof.profesorID,
                    Nume = prof.nume,
                    NumeUtilizator = prof.nume_utilizator,
                    Parola = prof.parola,
                    Diriginte = prof.diriginte,
                    MaterieId = prof.materieID
                });
                
            }

            return result;
        }

        public ObservableCollection<GetTeacherClasses_Result> GetClaseProfesor(int profId)
        {
            List<GetTeacherClasses_Result> clase = context.GetTeacherClasses(profId).ToList();
            ObservableCollection<GetTeacherClasses_Result> result = new ObservableCollection<GetTeacherClasses_Result>();

            foreach(GetTeacherClasses_Result clasa in clase)
            {
                result.Add(new GetTeacherClasses_Result()
                {
                    clasaID = clasa.clasaID,
                    an = clasa.an,
                    specializare = clasa.specializare
                });
            }

            return result;
        }

        public void SetareClasa(object obj)
        {
            if(obj!=null)
            {
                GetTeacherClasses_Result clasa = obj as GetTeacherClasses_Result;

                List<GetClassStudents_Result> elevi = context.GetClassStudents(clasa.clasaID).ToList();


                ObservableCollection<GetClassStudents_Result> result = new ObservableCollection<GetClassStudents_Result>();

                foreach (GetClassStudents_Result elev in elevi)
                {
                    result.Add(new GetClassStudents_Result()
                    {
                        elevID = elev.elevID,
                        nume = elev.nume
                    });
                }


                profesorContext.EleviClasa = result;
            }
            
        }

        public void SetareNote(object obj)
        {
            if(obj!=null)
            {
                GetClassStudents_Result elev = obj as GetClassStudents_Result;

                List<GetStudentGrades_Result> note = context.GetStudentGrades(elev.elevID).ToList();

                ObservableCollection<GetStudentGrades_Result> result = new ObservableCollection<GetStudentGrades_Result>();

                foreach (GetStudentGrades_Result nota in note)
                {
                    result.Add(new GetStudentGrades_Result()
                    {
                        nota = nota.nota,
                        denumire = nota.denumire
                    });

                }

                profesorContext.NoteElev = result;
            }
            
        }

        public void SetareAbsente(object obj)
        {
            if(obj!=null)
            {
                GetClassStudents_Result elev = obj as GetClassStudents_Result;

                List<GetStudentAbsence_Result> absente = context.GetStudentAbsence(elev.elevID).ToList();

                ObservableCollection<GetStudentAbsence_Result> result = new ObservableCollection<GetStudentAbsence_Result>();

                foreach (GetStudentAbsence_Result absenta in absente)
                {
                    result.Add(new GetStudentAbsence_Result()
                    {
                        data = absenta.data,
                        denumire = absenta.denumire
                    });
                }

                profesorContext.AbsenteElev = result;
            }
            
        }


        public void AdaugareNota(object obj)
        {
            ElevVM elev = obj as ElevVM;

            context.AddGrade(context.Notas.Count() + 1,1, profesorContext.MaterieId,1);
        }



        public void ModificareNota(object obj)
        {
            Nota nota = obj as Nota;

            if(nota!=null)
            {
                context.ModifyGrade(nota.notaID, Convert.ToInt32(nota.nota1));
                context.SaveChanges();
            }
        }
    }
}
