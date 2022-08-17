using System;
namespace SudokuSolver
{
    public class Solver
    {
        private int[,] board;
        private int boardLength;
        private int rowIndex = 0;
        private int colIndex = 0;

        public Solver(int[,] inputBoard)
        {
            board = inputBoard;
            boardLength = board.Length;
            Solve();
        }

        private void Solve()
        {
            for (int row = 0; row < boardLength; row++)
            {
                for (int col = 0; col < boardLength; col++)
                {

                }
            }
        }
    }
}