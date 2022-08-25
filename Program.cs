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
            
            // Formatting console output to make it look nice
            FormatOutput("Input board", true);
            parser.PrintBoard(inputBoard);
            solver.Solve();
            FormatOutput("Solution");
            FormatOutput("Saved in output.txt", true);
            parser.PrintBoard(inputBoard);
            
            parser.OutputFileData(inputBoard);
        }

        // To avoid an adjacent ==== line from appearing in the console
        private static void FormatOutput(string output, bool endOutput = false)
        {
            Console.WriteLine("===================");
            Console.WriteLine(output);
            if (endOutput)
            {
                Console.WriteLine("===================");
            }
        }
    }
}