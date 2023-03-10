using System.Collections.Generic;
using Assets.Scripts.GridCell;
using UnityEngine;

namespace Assets.Scripts.Board
{
    public class BoardRenderer : MonoBehaviour, IBoardRenderer
    {
        private int[,] _board;
        private Cell[,] _boardCells;
        [SerializeField] private Cell _cellPrefab;


        private Dictionary<int, Sprite> _cellSprite;

        public void Initialize(int[,] board)
        {
            _board = board;
            _boardCells = new Cell[board.GetLength(0), board.GetLength(1)];
            for (int i = 0; i < _boardCells.GetLength(0); i++)
            {
                for (int j = 0; j < _boardCells.GetLength(1); j++)
                {
                    _boardCells[i, j] = Instantiate(_cellPrefab);
                    _boardCells[i, j].transform.position = new Vector3(i, 0, j);
                    _boardCells[i, j].transform.SetParent(transform);
                }
            }
            transform.position = new Vector3(-1 * board.GetLength(0) / 2.0f, 0, -1 * board.GetLength(1) / 2.0f);
        }

        public void Draw(int[,] board)
        {
            for (int i = 0; i < _boardCells.GetLength(0); i++)
            {
                for (int j = 0; j < _boardCells.GetLength(1); j++)
                {
                    if (_board[i, j] == (int)GridValue.Wall)
                        _boardCells[i, j].SetCell(GridValue.Wall);
                    if (_board[i, j] == (int)GridValue.Empty)
                        _boardCells[i, j].SetCell(GridValue.Empty);
                    if (_board[i, j] == (int)GridValue.Snake)
                        _boardCells[i, j].SetCell(GridValue.Snake);
                    if (_board[i, j] == (int)GridValue.Food)
                        _boardCells[i, j].SetCell(GridValue.Food);
                }
            }
        }
    }
}