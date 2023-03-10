using System.Collections.Generic;

namespace Assets.Scripts.Board
{
    public interface IBoardController
    {
        void Initialize(int width, int height);
        void MakeNewFood();
        IEnumerable<GridCell> GetEmptyCell();
        int[,] Board { get; set; }

    }
}