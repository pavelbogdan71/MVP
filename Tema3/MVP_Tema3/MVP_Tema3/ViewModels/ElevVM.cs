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

namespace MVP_Tema3.ViewModels
{
    class ElevVM:BaseVM
    {
        ElevActions eAct;

        public ElevVM()
        {
            eAct = new ElevActions(this);
        }

        #region Data Members

        private int elevId;
        private string nume;
        private string numeUtilizator;
        private string parola;

        private ObservableCollection<ElevVM> elevList;

        private ObservableCollection<GetStudentGrades_Result> noteList;
        private ObservableCollection<GetStudentAbsence_Result> absenteList;
        private ObservableCollection<GetStudentAverageGrades_Result> mediiList;

        public int ElevId
        {
            get
            {
                return elevId;
            }
            set
            {
                elevId = value;
                NotifyPropertyChanged("ElevId");
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

        public ObservableCollection<ElevVM> ElevList
        {
            get
            {
                elevList = eAct.AllElevs();
                return elevList;
            }
            set
            {
                elevList = value;
                NotifyPropertyChanged("ElevList");
            }
        }

        public ObservableCollection<GetStudentGrades_Result> NoteList
        {
            get
            {
                noteList = eAct.Note(ElevView.ElevId);
                return noteList;
            }
            set
            {
                noteList = value;
                NotifyPropertyChanged("NoteList");
            }
        }

        public ObservableCollection<GetStudentAbsence_Result> AbsenteList
        {
            get
            {
                absenteList = eAct.Absente(ElevView.ElevId);
                return absenteList;
            }
            set
            {
                absenteList = value;
                NotifyPropertyChanged("AbsenteList");
            }
        }

        public ObservableCollection<GetStudentAverageGrades_Result> MediiList
        {
            get
            {
                mediiList = eAct.Medii(ElevView.ElevId);
                return mediiList;
            }
            set
            {
                mediiList = value;
                NotifyPropertyChanged("MediiList");
            }
        }
        #endregion

    }
}
