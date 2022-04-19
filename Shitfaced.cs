using Shitfaced.Interpretation;

namespace Shitfaced
{
   public class Shitfaced {

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

        public static void Debug(string? message)
        {
            if (RunContext != null ? RunContext.DebugMode : true) 
                Console.WriteLine(message);
        }
        public static void Info(string? message)
        {
            Console.WriteLine(message);
        }
    }

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
