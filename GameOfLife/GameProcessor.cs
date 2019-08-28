using System;

namespace GameOfLife
{
    public class GameProcessor
    {
        private bool _gameRunning;
        public GameProcessor()
        {
            _gameRunning = true;
        }

        public bool Evolve(Cell[,] currentGen, int matrixSize, Func<Cell[,], Cell[,], (int, int), bool> evolveCondition)
        {
            var previousGen = (Cell[,])currentGen.Clone();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    _gameRunning = evolveCondition(previousGen, currentGen, (i, j));
                }
            }

            return _gameRunning;
        }
    }
}