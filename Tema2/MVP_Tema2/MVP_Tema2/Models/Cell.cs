﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVP_Tema2.Models
{
    class Cell : INotifyPropertyChanged
    {

        public Cell(int x,int y,string color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
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
                y = value;
                NotifyPropertyChanged("Y");
            }
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


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
