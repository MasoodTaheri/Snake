namespace Assets.Scripts.Board
{
    public interface IBoardRenderer
    {
        void Initialize(int[,] board);
        void Draw(int[,] board);
    }
}