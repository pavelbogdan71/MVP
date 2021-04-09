using MVP_Tema2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.ViewModels
{
    class PlayerVM:BaseNotification
    {
        public PlayerVM(Player player)
        {
            SimplePlayer = player;
        }


        private Player simplePlayer;
        public Player SimplePlayer 
        {
            get
            {
                return simplePlayer;
            }
            set
            {
                simplePlayer = value;
                NotifyPropertyChanged("SimplePlayer");
            }
        }
    }
}
