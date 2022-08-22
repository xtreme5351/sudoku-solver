using System;

namespace SudokuSolver
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parser parser = new(args);
            List<List<int>> inputBoard = parser.GetInputFileData();
            _ = new Solver(inputBoard);
            parser.PrintBoard(inputBoard);
        }
    }
}