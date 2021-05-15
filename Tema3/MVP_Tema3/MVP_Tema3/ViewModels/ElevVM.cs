using MVP_Tema3.Helpers;
using MVP_Tema3.Models.Actions;
using MVP_Tema3.Models.ResultEntities;
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
        private ObservableCollection<NotaElev> noteList;
        private ObservableCollection<AbsentaElev> absenteList;
        private ObservableCollection<MedieMaterie> mediiList;

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

        public ObservableCollection<NotaElev> NoteList
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

        public ObservableCollection<AbsentaElev> AbsenteList
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

        public ObservableCollection<MedieMaterie> MediiList
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
