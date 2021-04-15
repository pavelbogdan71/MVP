using MVP_Tema2.Models;
using MVP_Tema2.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace MVP_Tema2.Services
{
    class MenuServices
    {

        public void AboutInfo(object obj)
        {
            string message = "Pavel Bogdan-Vasile\nbogdan.pavel@student.unitbv.ro\nGrupa 10LF293\nJOC DE DAME";
            MessageBox.Show(message);
        }


        public void Save(ObservableCollection<ObservableCollection<CellVM>> boardVM)
        {
            string json = JsonConvert.SerializeObject(boardVM.ToArray(),Formatting.Indented);


            File.WriteAllText(@"..\..\Resources\SavedGame.json", json);


            MessageBox.Show("Game saved succesfully");
        }


        public void Open(ObservableCollection<ObservableCollection<CellVM>> boardVM)
        {
            StreamReader reader = new StreamReader(@"..\..\Resources\SavedGame.json");
            string json = reader.ReadToEnd();

            ObservableCollection<ObservableCollection<CellVM>> boardCopy = JsonConvert.DeserializeObject < ObservableCollection<ObservableCollection<CellVM>>> (json);

            boardVM = boardCopy;
        }

        public void NewGame(ObservableCollection<ObservableCollection<CellVM>> boardVM)
        {
            ObservableCollection<ObservableCollection<Cell>> board;
            board = Helper.InitBoard();

            ObservableCollection<ObservableCollection<CellVM>> result = new ObservableCollection<ObservableCollection<CellVM>>();

            for (int i = 0; i < board.Count; i++)
            {
                ObservableCollection<CellVM> line = new ObservableCollection<CellVM>();
                for (int j = 0; j < board[i].Count; j++)
                {
                    Cell cell = board[i][j];
                    CellVM cellVM = new CellVM(cell.X, cell.Y, cell.Color, cell.Piece,new GameBusinessLogic(board));
                    line.Add(cellVM);
                }

                result.Add(line);
            }
            boardVM = result;
        }


        public void Statistics(object obj)
        {
            StreamReader reader = new StreamReader(@"..\..\Resources\Statistics.json");
            string json = reader.ReadToEnd();

            List<WinnerPlayer> winners = JsonConvert.DeserializeObject<List<WinnerPlayer>>(json);

            string message = winners[0].Color + " wins: " + winners[0].Wins + "\n" + winners[1].Color + " wins: " + winners[1].Wins;
            MessageBox.Show(message);

        }
    }
}
