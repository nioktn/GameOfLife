using System;
using System.Threading;

namespace GameOfLife
{
    public class Game
    {
        public static Cell[,] CurrentGen { get; private set; }

        private bool _running;
        private GameField _gameField;
        private GameProcessor _gameProcessor;
        private GameRules _gameRules;
        private Func<Cell[,], Cell[,], (int, int), bool> _rulesDelegate;

        public Game(int fieldSize, IDisplay displayProvider, Cell[,] firstGen)
        {
            CurrentGen = firstGen;

            _gameField = new GameField(fieldSize, displayProvider);
            _gameProcessor = new GameProcessor();
            _gameRules = new GameRules();
            _running = true;
        }

        public void Run()
        {
            _rulesDelegate += _gameRules.BornOfCell;
            _rulesDelegate += _gameRules.DeathOfCell;
            _rulesDelegate += _gameRules.StaleStateOfCells;

            while (_running)
            {
                _gameField.DisplayGeneration(CurrentGen);
                //Thread.Sleep(100);
                _running = _gameProcessor.Evolve(CurrentGen, CurrentGen.GetLength(0), _rulesDelegate);
            }
        }
    }
}
