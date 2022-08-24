using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SudokuSolver
{
    // Derived from PCC :P
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

        public void CheckInputs()
        {
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
        }

        public List<List<int>> GetInputFileData()
        {
            string[] tempOutput = File.ReadAllLines(inputArgs[0]);
            List<List<int>> finalOutput = new();
            foreach (string line in tempOutput)
            {
                List<int> temp = new();
                Array.ForEach(line.ToCharArray(), x => temp.Add(Convert.ToInt16(char.GetNumericValue(x))));
                finalOutput.Add(temp);
            }
            return finalOutput;
        }

        public void PrintBoard(List<List<int>> input)
        {
            foreach (List<int> output in input)
            {
                Console.WriteLine(String.Join("|", output));
            }
        }

        public void OutputFileData(List<List<int>> input)
        {
            List<string> output = new();
            for (int i = 0; i < input.Count; i++)
            {
                output.Add(String.Join('|', input[i]));
            }
            File.WriteAllLines(inputArgs[1], output);
        }
    }
}
