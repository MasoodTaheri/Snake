using Assets.Scripts.Board;
using Assets.Scripts.InputController;
using UnityEngine;

namespace Assets.Scripts.Snake
{
    public interface ISnakeController
    {
        int[,] Initialize(int[,] board, int initLength, Vector3 direction, IInput inputManager);
        int[,] Move(int[,] board);
        //int[,] Grow();
        GridValue GetHit();

        int[,] RemoveSnake(int[,] board);
    }
}