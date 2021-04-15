using MVP_Tema2.Commands;
using MVP_Tema2.Models;
using MVP_Tema2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVP_Tema2.ViewModels
{
    class CellVM:BaseNotification
    {

        GameBusinessLogic bl;
        public CellVM(int x,int y,string color,Piece piece,GameBusinessLogic bl)
        {
            SimpleCell = new Cell(x, y,color,piece);
            this.bl = bl;
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



        private ICommand clickCommand;
        [JsonIgnore]
        public ICommand ClickCommand
        {
            get
            {
                if(clickCommand==null)
                {
                    clickCommand = new RelayCommand<Cell>(bl.ClickAction);
                }
                return clickCommand;
            }
        }

    }
}
