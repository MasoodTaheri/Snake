using System.Collections.Generic;
using Assets.Scripts.Board;
using Assets.Scripts.InputController;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Snake
{
    class SnakeController : ISnakeController
    {
        private IInput _input;
        public Vector3 Direction;
        private LinkedList<Vector2Int> _snakeTail;
        private GridValue _headHit;
        private readonly int _freeCellsFrontOfSnake = 2;
        private List<Board.GridCell> _freeCellsForSnake;

        public int[,] Initialize(int[,] board, int initLength, Vector3 direction, IInput inputManager)
        {
            _input = inputManager;
            if (_freeCellsForSnake != null && _freeCellsForSnake.Count > 0)
            {
                var emptySpace = _freeCellsForSnake[Random.Range(0, _freeCellsForSnake.Count)];

                _snakeTail = new LinkedList<Vector2Int>();
                for (int i = 0; i < initLength; i++)
                {
                    _snakeTail.AddLast(new Vector2Int(emptySpace.X + i + _freeCellsFrontOfSnake, emptySpace.Y));
                    board[emptySpace.X + i + _freeCellsFrontOfSnake, emptySpace.Y] = (int)GridValue.Snake;
                }
                Direction = direction;
            }

            return board;
        }

        public bool CheckForSnakeSpace(int initLength, int[,] board)
        {
            int freeCellsNeeded = initLength + _freeCellsFrontOfSnake;
            _freeCellsForSnake = new List<Board.GridCell>(GetConnectedEmptyCell(freeCellsNeeded, board));
            return (_freeCellsForSnake.Count > 0);
        }

        IEnumerable<Board.GridCell> GetConnectedEmptyCell(int count, int[,] board)
        {
            bool allCellsAreEmpty = false;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    allCellsAreEmpty = true;
                    for (int k = 0; k < count; k++)
                    {
                        if (IsInBound(new Board.GridCell() { X = i + k, Y = j }, board))
                        {
                            if (board[i + k, j] != (int)GridValue.Empty)
                                allCellsAreEmpty = false;
                        }
                        else
                        {
                            allCellsAreEmpty = false;
                        }
                    }

                    if (allCellsAreEmpty)
                        yield return new Board.GridCell() { X = i, Y = j };


                }
            }
        }

        private Vector3 GetDirection()
        {
            if (Direction.x != 0f)
            {
                if (_input.GetKeyup())
                {
                    Direction = Vector3.forward;
                }
                else if (_input.GetKeyDown())
                {
                    Direction = Vector3.back;
                }
            }

            else if (Direction.z != 0f)
            {
                if (_input.GetKeyRight())
                {
                    Direction = Vector3.right;
                }
                else if (_input.GetKeyLeft())
                {
                    Direction = Vector3.left;
                }
            }

            return Direction;
        }

        public int[,] Move(int[,] board)
        {

            Direction = GetDirection();
            int headXPos = _snakeTail.First.Value.x + (int)Direction.x;
            int headYPos = _snakeTail.First.Value.y + (int)Direction.z;

            _headHit = (GridValue)board[headXPos, headYPos];

            if (IsInBound(new Board.GridCell() { X = headXPos, Y = headYPos }, board) &&
                _headHit != GridValue.Wall && _headHit != GridValue.Snake)
            {
                if (_headHit == GridValue.Empty)
                {
                    board[_snakeTail.Last.Value.x, _snakeTail.Last.Value.y] = (int)GridValue.Empty;
                    _snakeTail.RemoveLast();
                }

                //else it is food 
                _snakeTail.AddFirst(new Vector2Int(headXPos, headYPos));
                board[_snakeTail.First.Value.x, _snakeTail.First.Value.y] = (int)GridValue.Snake;
            }

            //if (Input.GetKeyDown(KeyCode.Q))
            //    Grow();
            return board;
        }

        private bool IsInBound(Board.GridCell cell, int[,] board)
        {
            return cell.X >= 0 && cell.X < board.GetLength(0) &&
                   cell.Y >= 0 && cell.Y < board.GetLength(1);
        }

        public GridValue GetHit()
        {
            return _headHit;
        }

        public int[,] RemoveSnake(int[,] board)
        {
            foreach (Vector2Int i in _snakeTail)
            {
                board[i.x, i.y] = (int)GridValue.Empty;
            }

            return board;
        }
    }


}
