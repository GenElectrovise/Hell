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

        /// <summary>
        /// Reads the bytes of a file, then passes them to CompileFromBytes to compile.
        /// </summary>
        /// <param name="programPath">A relative path to the file to compile</param>
        /// <returns>Whether the compilation was successful</returns>
        internal Boolean CompileFromFile(string programPath)
        {
            // Create buffer now so can reference outside of the try/catch
            byte[] buffer = new byte[0];

            // Using statement automatically closes and disposes of the resource when the statement ends
            using (FileStream stream = File.OpenRead(programPath)) {
                try
                {
                    // Read all bytes from stream into the buffer
                    buffer = new byte[stream.Length];
                    stream.ReadAsync(buffer, 0, (int)stream.Length, CancellationToken.None);
                } catch (Exception ex)
                {
                    Hell.Info("Oh deary me! I had a little difficulty reading that!");
                    Hell.Debug(ex.Source);
                    Hell.Debug(ex.Message);
                    Hell.Debug(ex.StackTrace);
                    return false;
                }
            }

            return CompileFromBytes(buffer);
        }

        /// <summary>
        /// Compiles an array of bytes into Compiled-Hell.
        /// </summary>
        /// <param name="buffer">The array of bytes to compile</param>
        /// <returns>Whether the compilation was successful</returns>
        private Boolean CompileFromBytes(byte[] buffer)
        {
            return true;
        }
    }
}
