using MVP_Tema2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.ViewModels
{
    class CellVM:BaseNotification
    {
        public CellVM(int x,int y)
        {
            SimpleCell = new Cell(x, y);
        }


        private Cell simpleCell;
        public Cell SimpleCell 
        {
            get
            {
                return simpleCell;
            }
            set
            {
                simpleCell = value;
                NotifyPropertyChanged("SimpleCell");
            }
        }
    }
}
