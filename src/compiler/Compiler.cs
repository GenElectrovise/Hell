namespace Hell.Compilation
{
    internal class Compiler
    {
        public RunContext RunContext { get; }
        public int EntryLine { get; set; }

        public Compiler(RunContext runContext)
        {
            RunContext = runContext;
        }

        internal Boolean CompileFromFile(string programPath)
        {
            Hell.Debug("Compiling " + programPath);
            return true;
        }
    }
}
