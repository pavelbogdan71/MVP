using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.Models
{
    class Player:INotifyPropertyChanged
    {
        public Player(string pieceColor,int piecesNumber)
        {
            this.pieceColor = pieceColor;
            this.piecesNumber = piecesNumber ;
        }

        private string pieceColor;
        public string PieceColor
        {
            get
            {
                return pieceColor;
            }
            set
            {
                pieceColor = value;

                NotifyPropertyChanged("PieceColor");
            }
        }

        private int piecesNumber;
        public int PiecesNumber
        {
            get
            {
                return piecesNumber;
            }

            set
            {
                piecesNumber = value;
                NotifyPropertyChanged("PiecesNumber");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
