using MVP_Tema3.Helpers;
using MVP_Tema3.Models.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.ViewModels
{
    class MaterieVM:BaseVM
    {
        MaterieActions mAct;

        public MaterieVM()
        {
            mAct = new MaterieActions(this);
        }

        #region Data Members

        private int materieId;
        private string denumireMaterie;

        private ObservableCollection<MaterieVM> materiiList;

        public int MaterieId
        {
            get
            {
                return materieId;
            }
            set
            {
                materieId = value;
                NotifyPropertyChanged("MaterieId");
            }
        }

        public string DenumireMaterie
        {
            get
            {
                return denumireMaterie;
            }
            set
            {
                denumireMaterie = value;
                NotifyPropertyChanged("DenumireMaterie");
            }
        }

        public ObservableCollection<MaterieVM> MateriiList
        {
            get
            {
                materiiList = mAct.AllMaterii();
                return materiiList;
            }
            set
            {
                materiiList = value;
                NotifyPropertyChanged("MateriiList");
            }
        }
        #endregion
    }
}
