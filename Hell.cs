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

        public static readonly string[] MANDATORY_ARGUMENTS = { "S_ProgramPath", "hell_test.hell" };
        public static readonly bool USE_MANDATORY_ARGUMENTS = true;

        public static readonly string[] ALLOWED_ARGUMENTS = { "S_ProgramPath", "DebugMode" };

        static void Main(String[] args)
        {
            Hell.Info("Starting to run the program...");

            string[] editedArguments = args;
            if (USE_MANDATORY_ARGUMENTS)
            {
                Debug("Applying mandatory arguments");

                editedArguments = new string[args.Length + MANDATORY_ARGUMENTS.Length];
                // Add mandatory arguments
                for (int i = 0; i < MANDATORY_ARGUMENTS.Length; i++)
                {
                    editedArguments[i] = MANDATORY_ARGUMENTS[i];
                    Debug("Applied " + editedArguments[i]);
                }
                // Append any other arguments inputted
                for (int i = 0; i < args.Length; i++)
                {
                    editedArguments[MANDATORY_ARGUMENTS.Length - 1 + i] = args[i];
                    Debug("Appended " + editedArguments[i]);
                }
            }

            RunContext = new RunContext(editedArguments);
            Interpreter = new Interpreter(RunContext);

            // Main execution loop
            // If prepared successfully, start to run
            if (Interpreter.PrepareToStart())
            {
                while (Interpreter.GetNextLine())
                {
                    Interpreter.ExecuteLine();
                }
            }
            else
            {
                Hell.Info("Oh no! Something went really wrong and I don't want to keep going!");
                Hell.Debug("Program failed to prepare correctly");
            }

            // Stop the console from immediately closing
            Hell.Info("All done! Click any button on your keyboard to make me go away!");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the message on the console if debugging is enabled in the RunContext. This should only be information which should NOT be shown to the average user, and is PURELY for development purposes.
        /// </summary>
        /// <param name="message">The message to potentially display</param>
        public static void Debug(string? message)
        {
            if (RunContext == null ? true : RunContext.B_UseDebug) 
                Console.WriteLine( " [ D E B U G ] : " + message);
        }

        /// <summary>
        /// Displays the message on the console. This should only be information which should be shown to the average user, and should NOT contain useful or technical information lol.
        /// </summary>
        /// <param name="message">The message to display</param>
        public static void Info(string? message)
        {
            Console.WriteLine(" [INFORMATION] : " + message);
        }
        
        /// <summary>
        /// Displays the message on the console. This should only be information which should be shown to the average user, and should NOT contain useful or technical information lol.
        /// </summary>
        /// <param name="message">The message to display</param>
        public static void Trace(string? message)
        {
            if (RunContext == null ? true : RunContext.B_UseTrace)
                Console.WriteLine(" [ T R A C E ] : " + message);
        }
    }
}
