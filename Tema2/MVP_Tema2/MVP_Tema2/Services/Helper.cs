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
            string culoareDeschisa = "#E8C090";
            string culoareInchisa = "#BD6904";

            ObservableCollection<ObservableCollection<Cell>> result = new ObservableCollection<ObservableCollection<Cell>>();
            for(int i=0;i<8;i++)
            {
                ObservableCollection<Cell> line = new ObservableCollection<Cell>();

                for(int j=0;j<8;j++)
                {
                    if((i+j)%2==0)
                    {
                        line.Add(new Cell(i, j,culoareDeschisa,new Piece()));
                    }
                    else
                    {
                        if(i<3)
                        {
                            line.Add(new Cell(i, j, culoareInchisa, new Piece("#FFFFFF")));
                        }
                        else if(i>4)
                        {
                            line.Add(new Cell(i, j, culoareInchisa, new Piece("#B20505")));
                        }
                        else
                        {
                            line.Add(new Cell(i, j, culoareInchisa, new Piece()));
                        }
                        
                    }
                    
                }
                result.Add(line);
            }

            return result;
        }
    }
}
