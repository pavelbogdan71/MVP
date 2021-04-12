using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.Models
{
    class Piece:INotifyPropertyChanged
    {

        public Piece(string color)
        {
            this.Color = color;
        }

        public Piece()
        {
            
        }

        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                NotifyPropertyChanged("Color");
            }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
                NotifyPropertyChanged("IsVisible");
            }
        }

        private string kingText;
        public string KingText 
        {
            get
            {
                return kingText;
            }
            set
            {
                kingText = value;
                NotifyPropertyChanged("KingText");
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
