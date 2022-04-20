using Hell.Compilation;

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
        public Compiler Compiler { get; set; }
        private int _programCounter = 0;

        public Interpreter(RunContext runContext)
        {
            this.RunContext = runContext;
            Compiler = new Compiler(this.RunContext);
        }

        /// <summary>
        /// Prepares the interpreter environment to start executing by, for example, compiling the root file.
        /// </summary>
        /// <returns>Whether the preparation was successful, and the program can start to execute</returns>
        internal Boolean PrepareToStart()
        {
            Boolean rootFileCompiles = Compiler.CompileFromFile(RunContext.ProgramPath);
            _programCounter = Compiler.EntryLine;

            if (!rootFileCompiles)
                return false;
            return true;
        }

        int i = 0;

        internal bool HasNextLine()
        {
            //throw new NotImplementedException();
            i++;
            return i<20;
        }

        internal void ExecuteNextLine()
        {
            //throw new NotImplementedException();
            Console.WriteLine(i);
        }
    }
}
