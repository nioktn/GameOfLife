using System.Linq;
using static GameOfLife.Program;

namespace GameOfLife
{
    public class GameRules
    {
        private int AliveCellNeighbours(Cell[,] previousGen, (int, int) cellIndex)
        {
            var cell = previousGen[cellIndex.Item1, cellIndex.Item2];
            return cell.NeighboursIndexes.Count(indexTuple => previousGen[indexTuple.Item1, indexTuple.Item2].IsAlive == true);
        }

        public bool BornOfCell(Cell[,] previousGen, Cell[,] currentGen, (int, int) cellIndex)
        {
            var aliveNeighbours = AliveCellNeighbours(previousGen, cellIndex);

            if (aliveNeighbours == 3)
            {
                currentGen[cellIndex.Item1, cellIndex.Item2].IsAlive = true;
            }

            return true;
        }

        public bool DeathOfCell(Cell[,] previousGen, Cell[,] currentGen, (int, int) cellIndex)
        {
            var aliveNeighbours = AliveCellNeighbours(previousGen, cellIndex);

            if (aliveNeighbours < 2 || aliveNeighbours > 3)
            {
                currentGen[cellIndex.Item1, cellIndex.Item2].IsAlive = false;
            }

            return true;
        }

        public bool StaleStateOfCells(Cell[,] previousGen, Cell[,] currentGen, (int, int) cellIndex)
        {
            for (int i = 0; i < previousGen.GetLength(0); i++)
            {
                for (int j = 0; j < previousGen.GetLength(1); j++)
                {
                    if (previousGen[i, j].IsAlive != currentGen[i, j].IsAlive)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
