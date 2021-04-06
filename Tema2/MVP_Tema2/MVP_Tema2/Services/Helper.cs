using MVP_Tema2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.Services
{
    class Helper
    {
        public static ObservableCollection<ObservableCollection<Cell>> InitBoard()
        {
            ObservableCollection<ObservableCollection<Cell>> result = new ObservableCollection<ObservableCollection<Cell>>();
            for(int i=0;i<8;i++)
            {
                ObservableCollection<Cell> line = new ObservableCollection<Cell>();

                for(int j=0;j<8;j++)
                {
                    line.Add(new Cell(i, j));
                }
                result.Add(line);
            }

            return result;
        }
    }
}
