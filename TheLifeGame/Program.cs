using System;
using System.Linq;
using System.Threading;

namespace TheLifeGame
{
    class Program
    {
        static Cell[,] previousGen, currentGen;
        const int matrixSize = 20;
        
        static void Main(string[] args)
        {
            currentGen = new Cell[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    currentGen[i, j] = new Cell(false, (i, j), matrixSize);
                }
            }

            currentGen[1, 1].IsAlive = true;
            currentGen[2, 2].IsAlive = true;
            currentGen[1, 3].IsAlive = true;
            currentGen[2, 3].IsAlive = true;
            currentGen[3, 2].IsAlive = true;
            currentGen[2, 10].IsAlive = true;
            currentGen[2, 8].IsAlive = true;
            currentGen[2, 9].IsAlive = true;
            //currentGen[12, 3].IsAlive = true;
            //currentGen[12, 4].IsAlive = true;
            //currentGen[12, 5].IsAlive = true;
            //currentGen[13, 4].IsAlive = true;
            //currentGen[13, 5].IsAlive = true;
            //currentGen[13, 6].IsAlive = true;
            currentGen[13, 7].IsAlive = true;
            currentGen[14, 8].IsAlive = true;
            currentGen[15, 9].IsAlive = true;
            currentGen[12, 8].IsAlive = true;
            currentGen[12, 9].IsAlive = true;
            currentGen[13, 10].IsAlive = true;
            currentGen[14, 10].IsAlive = true;

            PrintMatrix(currentGen);

            while (true)
            {
                Console.Clear();
                Evolve();
                PrintMatrix(currentGen);
                Thread.Sleep(100);
            }
        }

        public static void PrintMatrix(Cell[,] matrix)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j].IsAlive)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("@   ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else
                    {
                        Console.Write("    ");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        public static void Evolve()
        {
            previousGen = (Cell[,])currentGen.Clone();
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    var aliveNeighbours = previousGen[i, j].NeighboursIndexes.Count(indexTuple => previousGen[indexTuple.Item1, indexTuple.Item2].IsAlive == true);
                    if (aliveNeighbours == 3 && previousGen[i, j].IsAlive == false) currentGen[i, j].IsAlive = true;
                    else if (aliveNeighbours < 2 || aliveNeighbours > 3) currentGen[i, j].IsAlive = false;
                }
            }
        }


        public struct Cell
        {
            public Cell(bool isAlive, (int, int) cellIndex, int matrixSize)
            {
                IsAlive = isAlive;
                NeighboursIndexes = new (int, int)[8];
                NeighboursIndexes = GetNeighbours(cellIndex, matrixSize);
            }

            public (int, int)[] NeighboursIndexes { get; private set; }

            public bool IsAlive { get; set; }

            private (int, int)[] GetNeighbours((int, int) cellIndexes, int matrixSize)
            {
                var border = matrixSize - 1;
                var neighboursIndexes = new (int, int)[8];
                neighboursIndexes[0] = (CalcBelowIndex(cellIndexes.Item1 - 1, border), CalcBelowIndex(cellIndexes.Item2 - 1, border));
                neighboursIndexes[1] = (cellIndexes.Item1, CalcBelowIndex(cellIndexes.Item2 - 1, border));
                neighboursIndexes[2] = (CalcAboveIndex(cellIndexes.Item1 + 1, border), CalcBelowIndex(cellIndexes.Item2 - 1, border));
                neighboursIndexes[3] = (CalcBelowIndex(cellIndexes.Item1 - 1, border), cellIndexes.Item2);
                neighboursIndexes[4] = (CalcAboveIndex(cellIndexes.Item1 + 1, border), cellIndexes.Item2);
                neighboursIndexes[5] = (CalcBelowIndex(cellIndexes.Item1 - 1, border), CalcAboveIndex(cellIndexes.Item2 + 1, border));
                neighboursIndexes[6] = (cellIndexes.Item1, CalcAboveIndex(cellIndexes.Item2 + 1, border));
                neighboursIndexes[7] = (CalcAboveIndex(cellIndexes.Item1 + 1, border), CalcAboveIndex(cellIndexes.Item2 + 1, border));
                return neighboursIndexes;
            }

            private int CalcBelowIndex(int index, int border) => index >= 0 ? index : border;
            private int CalcAboveIndex(int index, int border) => index <= border ? index : 0;
        }
    }
}
