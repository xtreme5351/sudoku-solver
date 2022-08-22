using System;

namespace SudokuSolver
{
    public class Solver
    {
        private List<List<int>> board;
        private int boardLength;
        private Tuple<int, int>? rowColIndexes;

        public Solver(List<List<int>> inputBoard)
        {
            board = inputBoard;
            boardLength = board.Count;
            Solve();
        }
        private Tuple<int, int> FindFirstZero()
        {
            for (int row = 0; row < boardLength; row++)
            {
                for (int col = 0; col < boardLength; col++)
                {
                    List<int> temp = board.ElementAt(row);
                    if (temp.ElementAt(col) == 0)
                    {
                        return new Tuple<int, int>(row, col);
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }

        private void Solve()
        {
            rowColIndexes = FindFirstZero();
        } 
    }
}