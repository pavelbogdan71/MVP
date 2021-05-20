using MVP_Tema3.Helpers;
using MVP_Tema3.Models;
using MVP_Tema3.Models.Actions;
using MVP_Tema3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVP_Tema3.ViewModels
{
    class ProfesorVM : BaseVM
    {
        ProfesorActions pAct;

        public ProfesorVM()
        {
            pAct = new ProfesorActions(this);
        }


        #region Data Members
        private int profesorId;
        private string nume;
        private string numeUtilizator;
        private string parola;
        private bool diriginte;

        private ObservableCollection<ProfesorVM> profesorList;

        private ObservableCollection<GetTeacherClasses_Result> claseProfesor;
        private ObservableCollection<GetClassStudents_Result> eleviClasa;

        private ObservableCollection<GetStudentGrades_Result> noteElev;
        private ObservableCollection<GetStudentAbsence_Result> absenteElev;

        public ObservableCollection<GetStudentAbsence_Result> AbsenteElev
        {
            get
            {
                return absenteElev;
            }
            set
            {
                absenteElev = value;
                NotifyPropertyChanged("AbsenteElev");
            }
        }

        public ObservableCollection<GetStudentGrades_Result> NoteElev
        {
            get
            {
                return noteElev;
            }
            set
            {
                noteElev = value;
                NotifyPropertyChanged("NoteElev");
            }
        }

        public ObservableCollection<GetClassStudents_Result> EleviClasa
        {
            get
            {
                return eleviClasa;
            }
            set
            {
                eleviClasa = value;
                NotifyPropertyChanged("EleviClasa");
            }
        }
        public ObservableCollection<GetTeacherClasses_Result> ClaseProfesor
        {
            get
            {
                claseProfesor = pAct.GetClaseProfesor(ProfesorView.ProfesorId);
                return claseProfesor;
            }
            set
            {
                claseProfesor = value;
                NotifyPropertyChanged("ClaseProfesor");
            }
        }

        public int ProfesorId
        {
            get
            {
                return profesorId;
            }
            set
            {
                profesorId = value;
                NotifyPropertyChanged("ProfesorId");
            }
        }

        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
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

        public bool Diriginte
        {
            get
            {
                return diriginte;
            }
            set
            {
                diriginte = value;
                NotifyPropertyChanged("Diriginte");
            }
        }

        public ObservableCollection<ProfesorVM> ProfesorList
        {
            get
            {
                profesorList = pAct.AllProfesors();
                return profesorList;
            }
            set
            {
                profesorList = value;
                NotifyPropertyChanged("ProfesorList");
            }
        }
        #endregion


        #region Commands


        private ICommand afisareClasa;
        public ICommand AfisareClasa
        {
            get
            {
                if(afisareClasa==null)
                {
                    afisareClasa = new RelayCommand(pAct.SetareClasa);
                }
                return afisareClasa;
            }
        }

        private ICommand afisareNote;
        public ICommand AfisareNote
        {
            get
            {
                if(afisareNote==null)
                {
                    afisareNote = new RelayCommand(pAct.SetareNote);
                }
                return afisareNote;
            }
        }

        private ICommand afisareAbsente;
        public ICommand AfisareAbsente
        {
            get
            {
                if(afisareAbsente==null)
                {
                    afisareAbsente = new RelayCommand(pAct.SetareAbsente);
                }
                return afisareAbsente;
            }
        }

        /*
        private ICommand adaugareNota;
        public ICommand AdaugareNota
        {
            get
            {
                if(adaugareNota==null)
                {
                    adaugareNota = new RelayCommand(pAct.AdaugareNota);
                }

                return adaugareNota;
            }
        }*/

        private ICommand modificareNota;
        public ICommand ModificareNota
        {
            get
            {
                if(modificareNota==null)
                {
                    modificareNota = new RelayCommand(pAct.ModificareNota);
                }
                return modificareNota;
            }
        }
        #endregion
    }
}
