using Hell.Interpretation;

namespace Hell
{
   /// <summary>
   /// Root class for the Hell Compiler and Interpreter ecosystem.
   /// </summary>
   public class Hell {

        // https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
        internal static RunContext? RunContext { get; set; }
        internal static Interpreter? Interpreter { get; set; }
    
        static void Main(String[] args)
        {
            Console.WriteLine("Starting to run the program...");

            RunContext = new RunContext(args);
            Interpreter = new Interpreter(RunContext);

            // Main execution loop
            Interpreter.PrepareToStart();
            while (Interpreter.HasNextLine()) {
                Interpreter.ExecuteNextLine();
            }

            // Stop the console from immediately closing
            Console.WriteLine("The program has finished running! Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the message on the console if debugging is enabled in the RunContext. This should only be information which should NOT be shown to the average user, and is PURELY for development purposes.
        /// </summary>
        /// <param name="message">The message to potentially display</param>
        public static void Debug(string? message)
        {
            if (RunContext != null ? RunContext.DebugMode : true) 
                Console.WriteLine(message);
        }

        /// <summary>
        /// Displays the message on the console. This should only be information which should be shown to the average user, and should NOT contain useful or technical information lol.
        /// </summary>
        /// <param name="message">The message to display</param>
        public static void Info(string? message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Global configuration for the running Hell Compiler and Interpreter.
    /// </summary>
    public class RunContext
    {
        public string[] Args { get; } = new string[0];
        public string ProgramPath { get; set; } = "no_path";
        public bool DebugMode { get; set; } = true;

        public RunContext(string[] args)
        {
            this.Args = args;
            SetFromArgs();
        }

        private void SetFromArgs()
        {
            //TODO SetFromArgs
            ProgramPath = "this/is/a/path.lang";
            DebugMode = true;
        }
    }
}
