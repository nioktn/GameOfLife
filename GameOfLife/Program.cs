using System;
using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        const int matrixOrder = 20;

        static void Main(string[] args)
        {
            var consoleDisplay = new ConsoleDisplay();
            var fistGen = FirstGenInitialize();

            new Game(matrixOrder, consoleDisplay, fistGen).Run();
        }

        public static Cell[,] FirstGenInitialize()
        {
            var currentGen = new Cell[matrixOrder, matrixOrder];

            for (int i = 0; i < matrixOrder; i++)
            {
                for (int j = 0; j < matrixOrder; j++)
                {
                    currentGen[i, j] = new Cell(false, (i, j), matrixOrder);
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

            return currentGen;
        }
    }
}