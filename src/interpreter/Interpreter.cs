using Hell.Compilation;

namespace Hell.Interpretation
{
    /**
     * The interpreter prepares to run the program by importing the given file, going through the standard compiling process etc - the normal importing process.
     * 
     * The general loop for the interpreter is as follows:
     * Check if the interpreter can get the next line of the running file.
     * IF YES:
     *      Execute the next line
     * IF NO:
     *      Loop back to the entrypoint
     */
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

        internal Boolean PrepareToStart()
        {
            Boolean rootFileCompiles = Compiler.CompileFromFile(RunContext.ProgramPath);
            _programCounter = Compiler.EntryLine;

            if (rootFileCompiles)
                return true;
            else
                return false;
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
