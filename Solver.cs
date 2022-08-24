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

        // Function to check if number is in a row
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

        // Function to check if number is in a column
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

        // Function to check if number is in the same 3x3 box in a sudoku grid
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

        /* Is only valid is all are false, which makes sense.
         If any are true then that number cannot be placed in that location as it violates sudoku rules
        */

        private bool IsValid(int n, int row, int col)
        {
            return !IsNumInRow(n, row) && !IsNumInCol(n, col) && !IsNumInLocalBox(n, row, col);
        }

        /* Recursive method to solve the board
        Goes through each available (non-zero) square, checks if number n can be inserted into that location.
        If it is a valid insertion, the method calls itself to insert a number into the next available square and keeps happening until either the row is full or false is returned
        Returning false allows the program to backtrack to the last "good" location i.e., last location where the insertion of n was valid and the previous "bad" location is set to 0
        The program then tries other values of n and the process repeats until either the board is solved or there are no solutions.
        */
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