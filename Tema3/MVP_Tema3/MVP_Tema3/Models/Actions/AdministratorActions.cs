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

        public ObservableCollection<ElevVM> AllElevs()
        {
            return new ElevVM().ElevList;
        }

        public ObservableCollection<ProfesorVM> AllProf()
        {
            return new ProfesorVM().ProfesorList;
        }

        public ObservableCollection<MaterieVM> AllMaterii()
        {
            return new MaterieVM().MateriiList;
        }


        public void AdaugareElev(object obj)
        {
            string nume = obj as string;

            if(nume!=null)
            {
                context.AddStudent(adminContext.ElevList.Count()+1, nume, adminContext.ElevList.First().ClasaId);
                context.SaveChanges();

                adminContext.ElevList = AllElevs();
            }
        }

        public void ModificareElev(object obj)
        {
            ElevVM elev = obj as ElevVM;

            if(elev!=null)
            {
                context.ModifyStudent(elev.ElevId, elev.Nume);
                context.SaveChanges();
            }
        }

        public void StergereElev(object obj)
        {
            ElevVM elev = obj as ElevVM;

            if(elev!=null)
            {
                context.DeleteStudent(elev.ElevId);
                context.SaveChanges();

                adminContext.ElevList = AllElevs();
            }
        }

        public void AdaugareProfesor(object obj)
        {
            string nume = obj as string;

            if(nume!=null)
            {
                context.AddTeacher(adminContext.ProfList.Count() + 1, nume, false, adminContext.ProfList.First().MaterieId);
                context.SaveChanges();

                adminContext.ProfList = AllProf();
            }
        }

        public void ModificareProfesor(object obj)
        {
            ProfesorVM profesor = obj as ProfesorVM;

            if(profesor!=null)
            {
                context.ModifyTeacher(profesor.ProfesorId, profesor.Nume, false);
                context.SaveChanges();
            }
        }

        public void StergereProfesor(object obj)
        {
            ProfesorVM profesor = obj as ProfesorVM;

            if(profesor!=null)
            {
                context.DeleteTeacher(profesor.ProfesorId);
                context.SaveChanges();

                adminContext.ProfList = AllProf();
            }
        }

        public void AdaugareMaterie(object obj)
        {
            string nume = obj as string;

            if(nume!=null)
            {
                context.AddSubject(adminContext.MateriiList.Count() + 1, nume);
                context.SaveChanges();

                adminContext.MateriiList = AllMaterii();
            }
        }

        public void ModificareMaterie(object obj)
        {
            MaterieVM materie = obj as MaterieVM;

            if(materie!=null)
            {
                context.ModifySubject(materie.MaterieId, materie.DenumireMaterie);
                context.SaveChanges();
            }
        }

        public void StergereMaterie(object obj)
        {
            MaterieVM materie = obj as MaterieVM;

            if(materie!=null)
            {
                context.DeleteSubject(materie.MaterieId);
                context.SaveChanges();

                adminContext.MateriiList = AllMaterii();
            }
        }
    }
}
