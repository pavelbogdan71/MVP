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
            if(cell.Y>0 && cell.X >= 0 && cell.X < 8 && board[cell.X + 1][cell.Y - 1].Piece.Color!= "White" && board[cell.X + 1][cell.Y - 1].Piece.Color != "Red")
            {
                board[cell.X + 1][cell.Y - 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X + 1][cell.Y - 1]);
            }
            if(cell.Y<7 && cell.X >= 0 && cell.X < 8 && board[cell.X + 1][cell.Y + 1].Piece.Color!= "White" && board[cell.X + 1][cell.Y + 1].Piece.Color != "Red")
            {
                board[cell.X + 1][cell.Y + 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X + 1][cell.Y + 1]);
            }
        }

        private void HintRedSimpleMove(Cell cell)
        {
            if(cell.Y>0 && cell.X>=0 && cell.X<8 && board[cell.X - 1][cell.Y - 1].Piece.Color!="White" && board[cell.X - 1][cell.Y - 1].Piece.Color!="Red")
            {
                board[cell.X - 1][cell.Y - 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X - 1][cell.Y - 1]);
            }

            if(cell.Y<7 && cell.X >= 0 && cell.X < 8 && board[cell.X - 1][cell.Y + 1].Piece.Color!="White" && board[cell.X - 1][cell.Y + 1].Piece.Color!="Red")
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

                if(cell.X==7)
                {
                    cell.Piece.KingText = "K";
                }

            }
            if (Helper.PreviousCell.Piece.Color == "Red")
            {
                cell.Piece.Color = "Red";

                if(cell.X==0)
                {
                    cell.Piece.KingText = "K";
                }

            }


            if (Helper.PreviousCell!=null)
            {
                Helper.PreviousCell.Piece.Color = "Transparent";

                if(Helper.PreviousCell.Piece.KingText == "K")
                {
                    cell.Piece.KingText = "K";
                    Helper.PreviousCell.Piece.KingText = "";
                }
               
            }

            Helper.HintCellsClear();
        }





        private void HintWhiteJump(Cell cell)
        {
            //verificare saritura la stanga
            if(cell.X<6 && cell.Y>1)
            {
               if(cell.Piece.Color=="White" && board[cell.X+1][cell.Y-1].Piece.Color == "Red" && board[cell.X+2][cell.Y-2].Piece.Color == "Transparent")
               {
                    board[cell.X + 2][cell.Y - 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X + 2][cell.Y - 2]);
               }

                if (cell.Piece.Color == "Red" && board[cell.X + 1][cell.Y - 1].Piece.Color == "White" && board[cell.X + 2][cell.Y - 2].Piece.Color == "Transparent")
                {
                    board[cell.X + 2][cell.Y - 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X + 2][cell.Y - 2]);
                }
            }
            //verificare saritura la dreapta
            if(cell.X<6 && cell.Y<6)
            {
                if(cell.Piece.Color=="White" && board[cell.X+1][cell.Y+1].Piece.Color =="Red" && board[cell.X+2][cell.Y+2].Piece.Color == "Transparent")
                {
                    board[cell.X + 2][cell.Y + 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X + 2][cell.Y + 2]);
                }

                if (cell.Piece.Color == "Red" && board[cell.X + 1][cell.Y + 1].Piece.Color == "White" && board[cell.X + 2][cell.Y + 2].Piece.Color == "Transparent")
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
                if(cell.Piece.Color=="Red" && board[cell.X-1][cell.Y-1].Piece.Color == "White" && board[cell.X-2][cell.Y-2].Piece.Color == "Transparent")
                {
                    board[cell.X - 2][cell.Y - 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X - 2][cell.Y - 2]);
                }

                if (cell.Piece.Color == "White" && board[cell.X - 1][cell.Y - 1].Piece.Color == "Red" && board[cell.X - 2][cell.Y - 2].Piece.Color == "Transparent")
                {
                    board[cell.X - 2][cell.Y - 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X - 2][cell.Y - 2]);
                }
            }
            //verificare saritura la dreapta
            if(cell.X>1 && cell.Y<6)
            {
                if(cell.Piece.Color=="Red" && board[cell.X-1][cell.Y+1].Piece.Color=="White" && board[cell.X-2][cell.Y+2].Piece.Color == "Transparent")
                {
                    board[cell.X - 2][cell.Y + 2].Piece.Color = "Green";

                    Helper.HintCells.Add(board[cell.X - 2][cell.Y + 2]);
                }

                if (cell.Piece.Color == "White" && board[cell.X - 1][cell.Y + 1].Piece.Color == "Red" && board[cell.X - 2][cell.Y + 2].Piece.Color == "Transparent")
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
                Helper.PlayerRed.PiecesNumber -= 1;

                if(cell.X==7)
                {
                    cell.Piece.KingText = "K";
                }
            }
            if(Helper.PreviousCell.Piece.Color == "Red")
            {
                cell.Piece.Color = "Red";
                Helper.PlayerWhite.PiecesNumber -= 1;

                if(cell.X==0)
                {
                    cell.Piece.KingText = "K";
                }
            }


            if(Helper.PreviousCell.Piece.KingText=="K")
            {
                cell.Piece.KingText = "K";
            }

            Helper.PreviousCell.Piece.Color = "Transparent";
            Helper.PreviousCell.Piece.KingText = "";

            board[(cell.X + Helper.PreviousCell.X) / 2][(cell.Y + Helper.PreviousCell.Y) / 2].Piece.Color = "Transparent";
            board[(cell.X + Helper.PreviousCell.X) / 2][(cell.Y + Helper.PreviousCell.Y) / 2].Piece.KingText = "";


            Helper.HintCellsClear();
        }



        private void Hint(Cell cell)
        {
            if (cell.Piece.Color == "White" && Helper.PrevPlayer.PieceColor == "White")
            {
                Helper.HintCellsClear();

                if(cell.X<7)
                {
                    HintWhiteSimpleMove(cell);
                    HintWhiteJump(cell);
                }
                

                if(cell.Piece.KingText=="K")
                {
                    HintRedSimpleMove(cell);
                    HintRedJump(cell);
                }

            }

            if (cell.Piece.Color == "Red" && Helper.PrevPlayer.PieceColor == "Red")
            {
                Helper.HintCellsClear();

                if(cell.X>0)
                {
                    HintRedSimpleMove(cell);
                    HintRedJump(cell);
                }
                

                if(cell.Piece.KingText=="K")
                {
                    HintWhiteSimpleMove(cell);
                    HintWhiteJump(cell);
                }
            }
        }

        private void Move(Cell cell)
        {
            if (cell.Piece.Color == "Green")
            {
                if (Helper.PreviousCell.X == cell.X - 1 || Helper.PreviousCell.X == cell.X + 1)
                {
                    SimpleMove(cell);
                }

                if (Helper.PreviousCell.X == cell.X - 2 || Helper.PreviousCell.X == cell.X + 2)
                {
                    Jump(cell);
                }


                if (Helper.PrevPlayer.PieceColor == "Red")
                {
                    Helper.PrevPlayer.PieceColor = "White";
                }
                else if (Helper.PrevPlayer.PieceColor == "White")
                {
                    Helper.PrevPlayer.PieceColor = "Red";
                }
            }
        }







        private void Action(Cell cell)
        {
            Helper.CurrentCell = cell;


            Hint(cell);

            Move(cell);


            Helper.PreviousCell = cell;
        }



        public void ClickAction(Cell obj)
        {
            Action(obj);
        }
    }
}
