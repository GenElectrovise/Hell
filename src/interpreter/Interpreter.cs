using Hell.src.interpreter;
using Hell.src.interpreter.token;
using System.Text;
using System.Text.RegularExpressions;

namespace Hell.Interpretation
{
    /// <summary>
    /// The interpreter prepares to run the program by importing the given file, going through the standard compiling process etc - the normal importing process.
    ///
    /// The general loop for the interpreter is as follows:
    /// Check if the interpreter can get the next line of the running file.
    ///     IF YES:
    ///         Execute the next line
    ///     IF NO:
    ///         Loop back to the entrypoint
    ///
    /// </summary>
    internal class Interpreter
    {
        public RunContext RunContext { get; }
        private int _programCounter = 0;
        private string _runningFilePath = "";
        private int _runningFileLength = 0;

        public Interpreter(RunContext runContext)
        {
            this.RunContext = runContext;
        }

        /// <summary>
        /// Prepares the interpreter environment to start executing by, for example, finding the root file.
        /// </summary>
        /// <returns>Whether the preparation was successful, and the program can start to execute</returns>
        internal Boolean PrepareToStart()
        {
            if (!File.Exists(RunContext.S_ProgramPath))
            {
                Hell.Info("Ah darn it, that program's not where you said... Guess I'll just make one up!");
                Hell.Debug("File " + RunContext.S_ProgramPath + " does not exist. Creating...");
                return false;
            }

            // Create the runnningfile
            _runningFilePath = RunContext.S_ProgramPath + ".runningfile";
            File.Open(_runningFilePath, FileMode.OpenOrCreate);

            AddNewFile(RunContext.S_ProgramPath);

            return true;
        }

        int i = 0;

        internal bool GetNextLine()
        {
            //throw new NotImplementedException();

            i++;
            return i<20;
        }

        internal IToken[]? ParseLine(string line)
        {
            Hell.Trace("Parsing " + line);
            return null;
        }

        internal void ExecuteLine(IToken[] tokens)
        {
            Hell.Trace("Executing " + tokens);
        }

        internal void AddNewFile(string path)
        {
            CopyNewFileIntoRunningFile(path);
            IndexRunningFile();
        }

        internal void CopyNewFileIntoRunningFile(string path)
        {
            byte[] newLines = Encoding.UTF8.GetBytes("\n\n");
            byte[] contents = File.ReadAllBytes(path);
            byte[] combination = new byte[newLines.Length + contents.Length];
            Buffer.BlockCopy(newLines, 0, combination, 0, newLines.Length);
            Buffer.BlockCopy(contents, 0, combination, newLines.Length, contents.Length);

            FileStream stream = File.Open(_runningFilePath, FileMode.Append);
            stream.Write(combination, 0, combination.Length);
        }

        private void IndexRunningFile()
        {
            _runningFileLength = GetLineCount(_runningFilePath);

            // Find function declarations
            // i ranges 1 to rFL
            for (int i = 1; i <= _runningFileLength; i++)
            {
                // If the current line starts a paragraph
                string line = ReadLine(_runningFilePath, i);
                if (line.StartsWith(Tokens.PARAGRAPH_START))
                {
                    int lineNumber = i;
                    string pureLine = line.Replace(Tokens.ENTRY_PARAGRAPH_NAME, "");

                    foreach (char c in pureLine.ToCharArray())
                    {
                        // TODO Form the name of the method and store to running file index
                    }
                }
            }
        }

        internal int GetLineCount(string path)
        {
            return File.ReadLines(path).Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="lineNumber">Number greater than 0. The line numbering starts at 1.</param>
        /// <returns></returns>
        internal string ReadLine(string path, int lineNumber)
        {
            return File.ReadLines(path).Skip(lineNumber - 1).Take(1).First();
        }
    }
}