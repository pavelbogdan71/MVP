﻿using MVP_Tema2.Models;
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


            if (Helper.HintCells.Count > 0)
            {
                foreach (Cell c in Helper.HintCells)
                {
                    if(c.Piece.Color == "Green")
                    {
                        c.Piece.Color = "Transparent";
                    }
                    
                }
            }
        }

        private void Hint(Cell cell)
        {

            Helper.CurrentCell = cell;
            
           
            if(cell.Piece.Color== "White")
            {
                HintWhiteSimpleMove(cell);
            }

            if(cell.Piece.Color== "Red")
            {
                HintRedSimpleMove(cell);
            }




            if (cell.Piece.Color == "Green")
            {
                SimpleMove(cell);
            }

            Helper.PreviousCell = cell;
        }





        private void Action(Cell cell)
        {
            Hint(cell);
        }

        public void ClickAction(Cell obj)
        {
            Action(obj);
        }
    }
}