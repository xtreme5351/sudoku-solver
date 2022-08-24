using System;

namespace SudokuSolver
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parser parser = new(args);
            List<List<int>> inputBoard = parser.GetInputFileData();
            Solver solver = new(inputBoard);
            solver.Solve();
            Console.WriteLine("Solved!");
            parser.PrintBoard(inputBoard);
            parser.OutputFileData(inputBoard);
        }
    }
}