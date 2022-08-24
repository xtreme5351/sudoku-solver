using System;

namespace SudokuSolver
{
    public class Solver
    {
        private List<List<int>> board;
        private readonly int boardLength;

        public Solver(List<List<int>> inputBoard)
        {
            board = inputBoard;
            boardLength = board.Count;
        }

        /*
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
        */

        private bool IsNumInRow(int n, int row)
        {
            for (int col = 0; col < boardLength; col++)
            {
                if (board[row][col] == n)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumInCol(int n, int col)
        {
            for (int row = 0; row < boardLength; row++)
            {
                if (board[row][col] == n)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumInLocalBox(int n, int row, int col)
        {
            int localRow = row - row % 3;
            int localCol = col - col % 3;
            for (int y = localRow; y < localRow + 3; y++)
            {
                for (int x = localCol; x < localCol + 3; x++)
                {
                    if (board[y][x] == n)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsValid(int n, int row, int col)
        {
            return !IsNumInRow(n, row) && !IsNumInCol(n, col) && !IsNumInLocalBox(n, row, col);
        }

        public bool Solve()
        {
            for (int y = 0; y < boardLength; y++)
            {
                for (int x = 0; x < boardLength; x++)
                {
                    if (board[y][x] == 0)
                    {
                        for (int n = 1; n <= boardLength; n++)
                        {
                            if (IsValid(n, y, x))
                            {
                                board[y][x] = n;
                                if (Solve())
                                {
                                    return true;
                                } else
                                {
                                    board[y][x] = 0;
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        } 
    }
}