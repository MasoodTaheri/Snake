using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Board;
using Assets.Scripts.InputController;
using Assets.Scripts.Snake;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private BoardRenderer _renderer;
        private IBoardController _boardController;
        private List<ISnakeController> _snakeControllers;
        private int _snakeSize = 4;
        private int _boardWidth=20;
        private int _boardHeight=20;
        void Start()
        {
            _boardController = new BoardController();
            _boardController.Initialize(_boardWidth, _boardHeight);

            _renderer.Initialize(_boardController.Board);
            _renderer.Draw(_boardController.Board);

            _snakeControllers = new List<ISnakeController>();
            IInput input = new HumanInput();
            AddNewSnake(input);

            input = new HumanKeyBoardInput();
            AddNewSnake(input);

            _boardController.MakeNewFood();
            StartCoroutine(UpdateBoard());
        }

        private bool AddNewSnake(IInput input)
        {
            _snakeSize = Random.Range(2, 6);
            SnakeController snake = new SnakeController();
            if (snake.CheckForSnakeSpace(_snakeSize, _boardController.Board))
            {
                _snakeControllers.Add(snake);
                _boardController.Board = snake.Initialize(_boardController.Board, _snakeSize, Vector3.left, input);
                return true;
            }
            else
            {
                return false;
            }
        }

        IEnumerator UpdateBoard()
        {
            while (_snakeControllers.Count != 0 )
            {
                yield return new WaitForSeconds(0.25f);

                for (int i = 0; i < _snakeControllers.Count; i++)
                {
                    _boardController.Board = _snakeControllers[i].Move(_boardController.Board);
                    GridValue hit = _snakeControllers[i].GetHit();
                    if (hit == GridValue.Wall || hit == GridValue.Snake)
                    {
                        _boardController.Board = _snakeControllers[i].RemoveSnake(_boardController.Board);
                        _snakeControllers.RemoveAt(i);
                    }
                    if (hit == GridValue.Food)
                    {
                        _boardController.MakeNewFood();
                    }
                }
                _renderer.Draw(_boardController.Board);
            }

            Debug.Log("finish game");

        }

    }
}
