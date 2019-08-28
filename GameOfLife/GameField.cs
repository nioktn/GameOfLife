namespace GameOfLife
{
    public class GameField
    {
        private IDisplay _display;

        public GameField(int matrixOrder, IDisplay display)
        {
            _display = display;
            MatrixOrder = matrixOrder;
        }

        public int MatrixOrder { get; private set; }

        public void DisplayGeneration(Cell[,] currentGeneration) => _display.Draw(currentGeneration);
    }
}
