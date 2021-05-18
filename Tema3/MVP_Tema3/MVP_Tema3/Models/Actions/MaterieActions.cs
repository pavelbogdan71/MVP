using MVP_Tema3.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema3.Models.Actions
{
    class MaterieActions
    {
        ScoalaDBEntities1 context = new ScoalaDBEntities1();

        private MaterieVM materieContext;

        public MaterieActions(MaterieVM materieContext)
        {
            this.materieContext = materieContext;
        }

        public ObservableCollection<MaterieVM> AllMaterii()
        {
            List<Materie> materii = context.Materie.ToList();
            ObservableCollection<MaterieVM> result = new ObservableCollection<MaterieVM>();

            foreach(Materie materie in materii)
            {
                result.Add(new MaterieVM()
                {
                    MaterieId = materie.materieID,
                    DenumireMaterie = materie.denumire
                });
            }

            return result;
        }
    }
}
