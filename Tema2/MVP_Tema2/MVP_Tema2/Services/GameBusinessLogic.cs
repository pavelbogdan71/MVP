using MVP_Tema2.Models;
using MVP_Tema2.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVP_Tema2.Services
{
    class GameBusinessLogic
    {
        private ObservableCollection<ObservableCollection<Cell>> board;
        private bool isJumping;

        public GameBusinessLogic(ObservableCollection<ObservableCollection<Cell>> board)
        {
            this.board = board;
        }

        
        private void HintWhiteSimpleMove(Cell cell)
        {
            if(cell.Y>0 && cell.X >= 0 && cell.X < 7 && board[cell.X + 1][cell.Y - 1].Piece.Color!= "White" && board[cell.X + 1][cell.Y - 1].Piece.Color != "Red")
            {
                  board[cell.X + 1][cell.Y - 1].Piece.Color = "Green";

                 Helper.HintCells.Add(board[cell.X + 1][cell.Y - 1]);
              
                
            }
            if(cell.Y<7 && cell.X >= 0 && cell.X < 7 && board[cell.X + 1][cell.Y + 1].Piece.Color!= "White" && board[cell.X + 1][cell.Y + 1].Piece.Color != "Red")
            {
                board[cell.X + 1][cell.Y + 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X + 1][cell.Y + 1]);
            }
        }

        private void HintRedSimpleMove(Cell cell)
        {
            if(cell.Y>0 && cell.X>0 && cell.X<8 && board[cell.X - 1][cell.Y - 1].Piece.Color!="White" && board[cell.X - 1][cell.Y - 1].Piece.Color!="Red")
            {
                board[cell.X - 1][cell.Y - 1].Piece.Color = "Green";

                Helper.HintCells.Add(board[cell.X - 1][cell.Y - 1]);
            }

            if(cell.Y<7 && cell.X > 0 && cell.X < 8 && board[cell.X - 1][cell.Y + 1].Piece.Color!="White" && board[cell.X - 1][cell.Y + 1].Piece.Color!="Red")
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



            if (Helper.PrevPlayer.PieceColor == "Red")
            {
                Helper.PrevPlayer.PieceColor = "White";
            }
            else if (Helper.PrevPlayer.PieceColor == "White")
            {
                Helper.PrevPlayer.PieceColor = "Red";
            }
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

            isJumping = true;

            if (!CanJump(cell))
            {
                if (Helper.PrevPlayer.PieceColor == "Red")
                {
                    Helper.PrevPlayer.PieceColor = "White";
                }
                else if (Helper.PrevPlayer.PieceColor == "White")
                {
                    Helper.PrevPlayer.PieceColor = "Red";
                }

                isJumping = false;
            }



            if(Helper.PlayerRed.PiecesNumber == 0)
            {
                Helper.Winner.PieceColor = "Winner: White";
                AddWinnerToStatistics(1); 
            }

            if (Helper.PlayerWhite.PiecesNumber == 0)
            {
                Helper.Winner.PieceColor = "Winner: Red";
                AddWinnerToStatistics(0);
            }

        }

        private void AddWinnerToStatistics(int index)
        {
            StreamReader reader = new StreamReader(@"..\..\Resources\Statistics.json");
            string json = reader.ReadToEnd();

            List<WinnerPlayer> winners = JsonConvert.DeserializeObject<List<WinnerPlayer>>(json);
            winners[index].Wins++;

            reader.Close();

            json = JsonConvert.SerializeObject(winners.ToArray(), Formatting.Indented);
            File.WriteAllText(@"..\..\Resources\Statistics.json", json);
        }


        private void Hint(Cell cell)
        {
            if (cell.Piece.Color == "White" && Helper.PrevPlayer.PieceColor == "White")
            {
                Helper.HintCellsClear();

                if(cell.X<7)
                {
                    if (!isJumping)
                    {
                        HintWhiteSimpleMove(cell);
                    }
                    HintWhiteJump(cell);
                }
                

                if(cell.Piece.KingText=="K")
                {
                    if (!isJumping)
                    {
                        HintRedSimpleMove(cell);
                    }
                    HintRedJump(cell);
                }

            }

            if (cell.Piece.Color == "Red" && Helper.PrevPlayer.PieceColor == "Red")
            {
                Helper.HintCellsClear();

                if(cell.X>0)
                {
                    if(!isJumping)
                    {
                        HintRedSimpleMove(cell);
                    }
                    
                    HintRedJump(cell);
                }
                

                if(cell.Piece.KingText=="K")
                {
                    if (!isJumping)
                    {
                        HintWhiteSimpleMove(cell);
                    }
                    HintWhiteJump(cell);
                }
            }
        }


        private bool CanJump(Cell cell)
        {
            bool ok = false;
            //verificare saritura la stanga
            if (cell.X < 6 && cell.Y > 1)
            {
                if (cell.Piece.Color == "White" && board[cell.X + 1][cell.Y - 1].Piece.Color == "Red" && board[cell.X + 2][cell.Y - 2].Piece.Color == "Transparent")
                {
                    ok = true;
                }

                if (cell.Piece.Color == "Red" && board[cell.X + 1][cell.Y - 1].Piece.Color == "White" && board[cell.X + 2][cell.Y - 2].Piece.Color == "Transparent" && cell.Piece.KingText=="K")
                {
                    ok = true;
                }
            }
            //verificare saritura la dreapta
            if (cell.X < 6 && cell.Y < 6)
            {
                if (cell.Piece.Color == "White" && board[cell.X + 1][cell.Y + 1].Piece.Color == "Red" && board[cell.X + 2][cell.Y + 2].Piece.Color == "Transparent")
                {
                    ok = true;
                }

                if (cell.Piece.Color == "Red" && board[cell.X + 1][cell.Y + 1].Piece.Color == "White" && board[cell.X + 2][cell.Y + 2].Piece.Color == "Transparent" && cell.Piece.KingText == "K")
                {
                    ok = true;
                }
            }

            //verificare saritura la stanga
            if (cell.X > 1 && cell.Y > 1)
            {
                if (cell.Piece.Color == "Red" && board[cell.X - 1][cell.Y - 1].Piece.Color == "White" && board[cell.X - 2][cell.Y - 2].Piece.Color == "Transparent")
                {
                    ok = true;
                }

                if (cell.Piece.Color == "White" && board[cell.X - 1][cell.Y - 1].Piece.Color == "Red" && board[cell.X - 2][cell.Y - 2].Piece.Color == "Transparent" && cell.Piece.KingText == "K")
                {
                    ok = true;
                }
            }
            //verificare saritura la dreapta
            if (cell.X > 1 && cell.Y < 6)
            {
                if (cell.Piece.Color == "Red" && board[cell.X - 1][cell.Y + 1].Piece.Color == "White" && board[cell.X - 2][cell.Y + 2].Piece.Color == "Transparent")
                {
                    ok = true;
                }

                if (cell.Piece.Color == "White" && board[cell.X - 1][cell.Y + 1].Piece.Color == "Red" && board[cell.X - 2][cell.Y + 2].Piece.Color == "Transparent" && cell.Piece.KingText == "K")
                {
                    ok = true;
                }
            }

            return ok;
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
