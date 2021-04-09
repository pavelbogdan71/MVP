﻿using MVP_Tema2.Models;
using MVP_Tema2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Tema2.ViewModels
{
    class GameVM
    {
        public ObservableCollection<ObservableCollection<CellVM>> GameBoard { get; set; }
        private GameBusinessLogic bl;

        public PlayerVM CurrentPlayer { get; set; }
        public PlayerVM PlayerWhite { get; set; }
        public PlayerVM PlayerRed { get; set; }

        public GameVM()
        {
            ObservableCollection<ObservableCollection<Cell>> board = Helper.InitBoard();
            bl = new GameBusinessLogic(board);
            GameBoard = CellBoardToCellVMBoard(board);



            Player player = Helper.InitPlayer();
            CurrentPlayer = new PlayerVM(player);


            PlayerWhite = new PlayerVM(Helper.PlayerWhite);
            PlayerRed = new PlayerVM(Helper.PlayerRed);
        }

        private ObservableCollection<ObservableCollection<CellVM>> CellBoardToCellVMBoard(ObservableCollection<ObservableCollection<Cell>> board)
        {
            ObservableCollection<ObservableCollection<CellVM>> result = new ObservableCollection<ObservableCollection<CellVM>>();

            for(int i=0;i<board.Count;i++)
            {
                ObservableCollection<CellVM> line = new ObservableCollection<CellVM>();
                for(int j=0;j<board[i].Count;j++)
                {
                    Cell cell = board[i][j];
                    CellVM cellVM = new CellVM(cell.X, cell.Y,cell.Color,cell.Piece,bl);
                    line.Add(cellVM);
                }

                result.Add(line);
            }

            return result;
        }
    }
}
