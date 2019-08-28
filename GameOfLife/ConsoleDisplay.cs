using System;

namespace GameOfLife
{
    public class ConsoleDisplay : IDisplay
    {
        public void Draw(Cell[,] matrix)
        {
            Console.Clear();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
    }
}
