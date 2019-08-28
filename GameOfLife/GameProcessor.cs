using System;

namespace GameOfLife
{
    public class GameProcessor
    {
        public void Evolve(Cell[,] currentGen, int matrixSize, Action<Cell[,], Cell[,], (int, int)> evolveCondition)
        {
            var previousGen = (Cell[,])currentGen.Clone();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    evolveCondition(previousGen, currentGen, (i, j));
                }
            }
        }
    }
}