using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Board
{
    public enum GridValue
    {
        Empty, Snake, Food, Wall
    }

    public class BoardController : IBoardController
    {
        public int[,] Board { get; set; }
        //private readonly int _defaultCellValue = (int)GridValue.Empty;


        public void Initialize(int width, int height)
        {
            Board = new int[width, height];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    //Board[i, j] = _defaultCellValue;
                    if (i == 0 || j == 0 || i == Board.GetLength(0) - 1 || j == Board.GetLength(1) - 1)
                        Board[i, j] = (int)GridValue.Wall;
                    else
                        Board[i, j] = (int)GridValue.Empty;
                }
            }

  
        }




        public void MakeNewFood()
        {
            List<GridCell> emptyCells = new List<GridCell>(GetEmptyCell());
            GridCell randomEmptyCell = emptyCells[Random.Range(0, emptyCells.Count)];
            Board[randomEmptyCell.X, randomEmptyCell.Y] = (int)GridValue.Food;
        }

        public IEnumerable<GridCell> GetEmptyCell()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == (int)GridValue.Empty)
                        yield return new GridCell() { X = i, Y = j };
                }
            }
        }


    }
}
