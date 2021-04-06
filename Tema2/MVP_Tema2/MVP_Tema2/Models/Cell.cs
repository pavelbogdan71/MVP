using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.Models
{
    class Cell : INotifyPropertyChanged
    {

        public Cell(int x,int y)
        {
            
        }


        private int x;
        public int X
        {
            get
            { 
                return x; 
            }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                x = value;
                NotifyPropertyChanged("Y");
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
