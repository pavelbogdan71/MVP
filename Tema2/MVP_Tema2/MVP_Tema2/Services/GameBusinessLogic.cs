using MVP_Tema2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.Services
{
    class GameBusinessLogic
    {
        private ObservableCollection<ObservableCollection<Cell>> board;

        public GameBusinessLogic(ObservableCollection<ObservableCollection<Cell>> board)
        {
            this.board = board;
        }


        private void HintWhiteSimpleMove(Cell cell)
        {
            if(cell.Y>0 && board[cell.X + 1][cell.Y - 1].Piece.Color!= "White" && board[cell.X + 1][cell.Y - 1].Piece.Color != "Red")
            {
                board[cell.X + 1][cell.Y - 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X + 1][cell.Y - 1]);
            }
            if(cell.Y<7 && board[cell.X + 1][cell.Y + 1].Piece.Color!= "White" && board[cell.X + 1][cell.Y + 1].Piece.Color != "Red")
            {
                board[cell.X + 1][cell.Y + 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X + 1][cell.Y + 1]);
            }
        }

        private void HintRedSimpleMove(Cell cell)
        {
            if(cell.Y>0 && board[cell.X - 1][cell.Y - 1].Piece.Color!="White" && board[cell.X - 1][cell.Y - 1].Piece.Color!="Red")
            {
                board[cell.X - 1][cell.Y - 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X - 1][cell.Y - 1]);
            }

            if(cell.Y<7 && board[cell.X - 1][cell.Y + 1].Piece.Color!="White" && board[cell.X - 1][cell.Y + 1].Piece.Color!="Red")
            {
                board[cell.X - 1][cell.Y + 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X - 1][cell.Y + 1]);
            }
        }

        private void SimpleMove(Cell cell)
        {

            if(Helper.PreviousCell.Piece.Color=="White")
            {
                cell.Piece.Color = "White";
            }
            if (Helper.PreviousCell.Piece.Color == "Red")
            {
                cell.Piece.Color = "Red";
            }


            if (Helper.PreviousCell!=null)
            {
                Helper.PreviousCell.Piece.Color = "Transparent";
            }


            Helper.HintCellsClear();
        }


        private void HintWhiteJump(Cell cell)
        {
            //verificare saritura la stanga
            if(cell.X<6 && cell.Y>1)
            {
               if(board[cell.X+1][cell.Y-1].Piece.Color == "Red" && board[cell.X+2][cell.Y-2].Piece.Color == "Transparent")
               {
                    board[cell.X + 2][cell.Y - 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X + 2][cell.Y - 2]);
               }
            }
            //verificare saritura la dreapta
            if(cell.X<6 && cell.Y<6)
            {
                if(board[cell.X+1][cell.Y+1].Piece.Color =="Red" && board[cell.X+2][cell.Y+2].Piece.Color == "Transparent")
                {
                    board[cell.X + 2][cell.Y + 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X + 2][cell.Y + 2]);
                }
            }

        }

        private void HintRedJump(Cell cell)
        {
            //verificare saritura la stanga
            if(cell.X>1 && cell.Y>1)
            {
                if(board[cell.X-1][cell.Y-1].Piece.Color == "White" && board[cell.X-2][cell.Y-2].Piece.Color == "Transparent")
                {
                    board[cell.X - 2][cell.Y - 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X - 2][cell.Y - 2]);
                }
            }
            //verificare saritura la dreapta
            if(cell.X>1 && cell.Y<6)
            {
                if(board[cell.X-1][cell.Y+1].Piece.Color=="White" && board[cell.X-2][cell.Y+2].Piece.Color == "Transparent")
                {
                    board[cell.X - 2][cell.Y + 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X - 2][cell.Y + 2]);
                }
            }
        }


        private void Jump(Cell cell)
        {
            if(Helper.PreviousCell.Piece.Color == "White")
            {
                cell.Piece.Color = "White";
            }
            if(Helper.PreviousCell.Piece.Color == "Red")
            {
                cell.Piece.Color = "Red";
            }

            Helper.PreviousCell.Piece.Color = "Transparent";

            board[(cell.X + Helper.PreviousCell.X) / 2][(cell.Y + Helper.PreviousCell.Y) / 2].Piece.Color = "Transparent";

            Helper.HintCellsClear();
        }

        private void Action(Cell cell)
        {

            Helper.CurrentCell = cell;
            
           
            if(cell.Piece.Color== "White")
            {
                Helper.HintCellsClear();

                HintWhiteSimpleMove(cell);
                HintWhiteJump(cell);
            }

            if(cell.Piece.Color== "Red")
            {
                Helper.HintCellsClear();

                HintRedSimpleMove(cell);
                HintRedJump(cell);
            }




            if (cell.Piece.Color == "Green")
            {
                if(Helper.PreviousCell.X == cell.X - 1 || Helper.PreviousCell.X == cell.X + 1)
                {
                    SimpleMove(cell);
                }
                if(Helper.PreviousCell.X == cell.X - 2 || Helper.PreviousCell.X == cell.X + 2)
                {
                    Jump(cell);
                }
            }

            Helper.PreviousCell = cell;
        }



        public void ClickAction(Cell obj)
        {
            Action(obj);
        }
    }
}
