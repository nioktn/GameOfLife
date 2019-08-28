using System;
using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        static Cell[,] currentGen;

        const int matrixOrder = 20;

        static void Main(string[] args)
        {
            var boolMatrix = new bool[matrixOrder, matrixOrder];
            currentGen = new Cell[matrixOrder, matrixOrder];

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

            var gameProcessor = new GameProcessor();
            var rules = new GameRules();

            var consoleDisplay = new ConsoleDisplay();
            var gameField = new GameField(matrixOrder, consoleDisplay);

            Action<Cell[,], Cell[,], (int, int)> rulesDelegate = rules.BornOfCell;
            rulesDelegate += rules.DeathOfCell;
                       
            while (true)
            {
                gameField.DisplayGeneration(currentGen);
                Thread.Sleep(100);
                gameProcessor.Evolve(currentGen, currentGen.GetLength(0), rulesDelegate);
            }


            //PrintMatrix(currentGen);

            //while (true)
            //{
            //    Console.Clear();
            //    Evolve();
            //    PrintMatrix(currentGen);
            //    Thread.Sleep(100);
            //}
        }


        //public static void Evolve()
        //{
        //    previousGen = (Cell[,])currentGen.Clone();
        //    for (int i = 0; i < matrixOrder; i++)
        //    {
        //        for (int j = 0; j < matrixOrder; j++)
        //        {
        //            else if 
        //        }
        //    }
        //}


    }
}
