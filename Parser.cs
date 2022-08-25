using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuSolver
{
    // Derived from PCC :P
    // Just a class to manage IO, ik "Parser" is a slightly misleading name but oh well.
    public class Parser
    {
        private readonly string[] inputArgs;
        private Dictionary<string, string> argsDict;
        private static readonly MissingFieldException missingFileError = new("Input or output file paths missing");
        private static readonly ArgumentException invalidFileError = new("Incorrect input file type");
        private static readonly FormatException invalidBoardFormat = new("Incorrect board dimensions");

        public Parser(string[] args)
        {
            inputArgs = args;
            argsDict = new();
            CheckInputs();
        }
        /* Checking all inputs, including file paths and the input board itself
        For " sudokuSolver.exe input.txt output.txt " to work, the input and output files have to be in the same location as the program binary
         */
        public void CheckInputs()
        {
            // Check input file
            try
            {
                argsDict.Add("inputPath", inputArgs[0]);
            }
            catch (IndexOutOfRangeException)
            {
                throw missingFileError;
            }
            if (Path.GetExtension(Path.GetFullPath(inputArgs[0])) != ".txt")
            {
                throw invalidFileError;
            }
            string[] tempOutput = File.ReadAllLines(inputArgs[0]);
            if (tempOutput.Length != 9)
            {
                throw invalidBoardFormat;
            }
            foreach (string line in tempOutput)
            {
                if (line.Length != 9)
                {
                    throw invalidBoardFormat;
                }
            }
            // Check output file
            try
            {
                argsDict.Add("outputPath", inputArgs[1]);
            }
            catch (IndexOutOfRangeException)
            {
                throw missingFileError;
            }
            if (Path.GetExtension(Path.GetFullPath(inputArgs[1])) != ".txt")
            {
                throw invalidFileError;
            }

            try
            {
                argsDict.Add("charSep", inputArgs[2]);
            } 
            catch (IndexOutOfRangeException)
            {
                argsDict.Add("charSep", "");
            }
        }

        // Unpack input file data into correct data structure
        public List<List<int>> GetInputFileData()
        {
            string[] tempOutput = File.ReadAllLines(argsDict["inputPath"]);
            List<List<int>> finalOutput = new();
            foreach (string line in tempOutput)
            {
                List<int> temp = new();
                Array.ForEach(line.ToCharArray(), x => temp.Add(Convert.ToInt16(char.GetNumericValue(x))));
                finalOutput.Add(temp);
            }
            return finalOutput;
        }

        // Write to output file, | is used as the separator for the output which creates disconnect between input and output, will fix.
        public void OutputFileData(List<List<int>> input)
        {
            List<string> output = new();
            for (int i = 0; i < input.Count; i++)
            {
                output.Add(String.Join(argsDict["charSep"], input[i]));
            }
            File.WriteAllLines(argsDict["outputPath"], output);
        }

        // Print the board with custom separators that were specified
        public void PrintBoard(List<List<int>> input)
        {
            foreach (List<int> output in input)
            {
                Console.WriteLine(String.Join(argsDict["charSep"], output));
            }
        }
    }
}
