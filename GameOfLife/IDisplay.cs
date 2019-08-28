namespace GameOfLife
{
    public interface IDisplay
    {
        void Draw(Cell[,] currentGeneration);
    }
}