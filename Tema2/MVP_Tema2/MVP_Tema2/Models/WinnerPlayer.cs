using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.Models
{
    class WinnerPlayer
    {

        public WinnerPlayer(string color,int wins)
        {
            this.color = color;
            this.wins = wins;
        }


        private string color;
        public String Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private int wins;
        public int Wins 
        {
            get
            {
                return wins;
            }
            set
            {
                wins = value;
            }
        }
    }
}
