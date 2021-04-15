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
        public static Cell CurrentCell { get; set; }
        public static Cell PreviousCell { get; set; }
        public static ObservableCollection<Cell> HintCells { get; set; }

        public static Player PlayerRed = new Player("Red");
        public static Player PlayerWhite = new Player("White");

        public static Player PrevPlayer = PlayerWhite;

        public static Player Winner = new Player("");

        public static void HintCellsClear()
        {
            if (HintCells.Count > 0)
            {
                foreach (Cell c in HintCells)
                {
                    if (c.Piece.Color == "Green")
                    {
                        c.Piece.Color = "Transparent";
                    }

                }
            }
        }


        public static Player InitPlayer()
        {
            if(PrevPlayer==PlayerWhite)
            {
                PrevPlayer = PlayerRed;
                return PlayerRed;
            }
            PrevPlayer = PlayerWhite;
            return PlayerWhite;
        }

        public static Player GetWinner()
        {
            return Winner;
        }

        public static ObservableCollection<ObservableCollection<Cell>> InitBoard()
        {
            HintCells = new ObservableCollection<Cell>();

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
                        line.Add(new Cell(i, j,culoareDeschisa,new Piece("Transparent")));
                    }
                    else
                    {
                        if(i<3)
                        {
                            line.Add(new Cell(i, j, culoareInchisa, new Piece("White")));
                        }
                        else if(i>4)
                        {
                            line.Add(new Cell(i, j, culoareInchisa, new Piece("Red")));
                        }
                        else
                        {
                            line.Add(new Cell(i, j, culoareInchisa, new Piece("Transparent")));
                        }
                        
                    }
                    
                }
                result.Add(line);
            }

            return result;
        }
    }
}
