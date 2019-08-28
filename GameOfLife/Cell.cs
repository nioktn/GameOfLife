namespace GameOfLife
{
    public struct Cell
    {
        public Cell(bool isAlive, (int, int) cellIndex, int matrixOrder)
        {
            IsAlive = isAlive;
            NeighboursIndexes = new (int, int)[8];
            NeighboursIndexes = GetNeighbours(cellIndex, matrixOrder);
        }

        public (int, int)[] NeighboursIndexes { get; private set; }

        public bool IsAlive { get; set; }

        private (int, int)[] GetNeighbours((int, int) cellIndexes, int matrixOrder)
        {
            var border = matrixOrder - 1;
            var neighboursIndexes = new (int, int)[8];
            neighboursIndexes[0] = (CalcLowerIndex(cellIndexes.Item1 - 1, border), CalcLowerIndex(cellIndexes.Item2 - 1, border));
            neighboursIndexes[1] = (cellIndexes.Item1, CalcLowerIndex(cellIndexes.Item2 - 1, border));
            neighboursIndexes[2] = (CalcTopIndex(cellIndexes.Item1 + 1, border), CalcLowerIndex(cellIndexes.Item2 - 1, border));
            neighboursIndexes[3] = (CalcLowerIndex(cellIndexes.Item1 - 1, border), cellIndexes.Item2);
            neighboursIndexes[4] = (CalcTopIndex(cellIndexes.Item1 + 1, border), cellIndexes.Item2);
            neighboursIndexes[5] = (CalcLowerIndex(cellIndexes.Item1 - 1, border), CalcTopIndex(cellIndexes.Item2 + 1, border));
            neighboursIndexes[6] = (cellIndexes.Item1, CalcTopIndex(cellIndexes.Item2 + 1, border));
            neighboursIndexes[7] = (CalcTopIndex(cellIndexes.Item1 + 1, border), CalcTopIndex(cellIndexes.Item2 + 1, border));
            return neighboursIndexes;
        }

        private int CalcLowerIndex(int index, int border) => index >= 0 ? index : border;
        private int CalcTopIndex(int index, int border) => index <= border ? index : 0;
    }
}
